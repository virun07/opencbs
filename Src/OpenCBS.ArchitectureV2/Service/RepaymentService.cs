using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.CoreDomain;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.CoreDomain.Events;
using OpenCBS.Enums;
using OpenCBS.Manager;
using OpenCBS.Services;

namespace OpenCBS.ArchitectureV2.Service
{
    public class RepaymentService : IRepaymentService
    {
        public RepaymentSettings Settings { get; set; }

        public Loan Repay()
        {
            var script = RunScript(Settings.ScriptName);
            script.Repay(Settings);
            return Settings.Loan;
        }

        public Loan RepayAndSave()
        {
            var script = RunScript(Settings.ScriptName);
            var newConfig = (RepaymentSettings)Settings.Clone();
            script.Repay(newConfig);
            var events = GenerateRepaymentEvents(Settings, newConfig);
            newConfig.Loan.Events.Add(events);
            using (var sqlTransaction = DatabaseConnection.GetConnection().BeginTransaction())
            {
                try
                {
                    var repayEvent = events.GetRepaymentEvents().First();
                    ServicesProvider.GetInstance()
                                    .GetEventProcessorServices()
                                    .FireEvent(repayEvent, newConfig.Loan, sqlTransaction);
                    ServicesProvider.GetInstance()
                                    .GetContractServices()
                                    .ArchiveInstallments(Settings.Loan, repayEvent, sqlTransaction);
                    foreach (var installment in newConfig.Loan.InstallmentList)
                    {
                        var instalmentManager = new InstallmentManager(User.CurrentUser);
                        instalmentManager.UpdateInstallment(installment, newConfig.Loan.Id, repayEvent.Id,
                                                            sqlTransaction);
                    }
                    if (newConfig.Loan.AllInstallmentsRepaid)
                        ServicesProvider.GetInstance()
                                        .GetEventProcessorServices()
                                        .FireEvent(newConfig.Loan.GetCloseEvent(Settings.Date), newConfig.Loan, sqlTransaction);
                    //_loanManager.UpdateLoan(savedContract, sqlTransaction);
                    sqlTransaction.Commit();
                }
                catch (Exception)
                {
                    sqlTransaction.Rollback();
                    throw;
                }
            }
            return newConfig.Loan;
        }

        private static dynamic RunScript(string scriptName)
        {
            var options = new Dictionary<string, object>();
#if DEBUG
            options["Debug"] = true;
#endif
            ScriptEngine engine = Python.CreateEngine(options);
            var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts\\" + scriptName);
            return engine.ExecuteFile(file);
        }

        private static EventStock GenerateRepaymentEvents(RepaymentSettings oldConfig, RepaymentSettings newConfig)
        {
            var events = new EventStock();
            foreach (var installment in oldConfig.Loan.InstallmentList)
            {
                if (installment.IsRepaid) continue;
                var newInstallment = newConfig.Loan.GetInstallment(installment.Number);
                if (newInstallment.CapitalRepayment != installment.CapitalRepayment)
                {
                    events.Add(new RepaymentEvent
                    {
                        Principal = newInstallment.PaidCapital - installment.PaidCapital,
                        Interests = newInstallment.PaidInterests - installment.PaidInterests,
                        Penalties = newInstallment.PaidFees - installment.PaidFees,
                        Commissions = newInstallment.PaidCommissions - installment.PaidCommissions,
                        InstallmentNumber = installment.Number,
                        PastDueDays =
                            newInstallment.ExpectedDate > oldConfig.Date
                                ? 0
                                : (oldConfig.Date - newInstallment.ExpectedDate).Days,
                        PaymentMethod = oldConfig.PaymentMethod,
                        Comment = oldConfig.Comment,
                        RepaymentType = OPaymentType.PartialPayment,
                        User = User.CurrentUser
                    });
                    break;
                }
                if (newInstallment.PaidCapital <= installment.PaidCapital &&
                    newInstallment.PaidInterests <= installment.PaidInterests &&
                    newInstallment.PaidFees <= installment.PaidFees &&
                    newInstallment.PaidCommissions <= installment.PaidCommissions) continue;
                if (newInstallment.ExpectedDate > oldConfig.Date)
                    events.Add(new RepaymentEvent
                    {
                        Principal = newInstallment.PaidCapital - installment.PaidCapital,
                        Interests = newInstallment.PaidInterests - installment.PaidInterests,
                        Penalties = newInstallment.PaidFees - installment.PaidFees,
                        Commissions = newInstallment.PaidCommissions - installment.PaidCommissions,
                        InstallmentNumber = installment.Number,
                        PastDueDays = 0,
                        PaymentMethod = oldConfig.PaymentMethod,
                        Comment = oldConfig.Comment,
                        RepaymentType = OPaymentType.StandardPayment,
                        User = User.CurrentUser
                    });
                else
                    events.Add(new BadLoanRepaymentEvent
                    {
                        Principal = newInstallment.PaidCapital - installment.PaidCapital,
                        Interests = newInstallment.PaidInterests - installment.PaidInterests,
                        Penalties = newInstallment.PaidFees - installment.PaidFees,
                        Commissions = newInstallment.PaidCommissions - installment.PaidCommissions,
                        InstallmentNumber = installment.Number,
                        PastDueDays = (oldConfig.Date - newInstallment.ExpectedDate).Days,
                        PaymentMethod = oldConfig.PaymentMethod,
                        Comment = oldConfig.Comment,
                        RepaymentType = OPaymentType.StandardPayment,
                        User = User.CurrentUser
                    });
            }
            return events;
        }
    }
}
