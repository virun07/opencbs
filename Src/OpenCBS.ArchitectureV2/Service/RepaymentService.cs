using System;
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
        public RepaymentConfiguration Repay(RepaymentConfiguration configuration)
        {
            var script = RunScript(configuration);
            return (RepaymentConfiguration) script.GetVariable("configuration");
        }

        public Loan RepayAndSave(RepaymentConfiguration config)
        {
            var script = RunScript(config);
            var newConfig = ((RepaymentConfiguration) script.GetVariable("configuration"));
            var events = GenerateRepaymentEvents(config, newConfig);
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
                                    .ArchiveInstallments(config.Loan, repayEvent, sqlTransaction);
                    foreach (var installment in newConfig.Loan.InstallmentList)
                    {
                        var instalmentManager = new InstallmentManager(User.CurrentUser);
                        instalmentManager.UpdateInstallment(installment, newConfig.Loan.Id, repayEvent.Id,
                                                            sqlTransaction);
                    }
                    if (newConfig.Loan.AllInstallmentsRepaid)
                        ServicesProvider.GetInstance()
                                        .GetEventProcessorServices()
                                        .FireEvent(newConfig.Loan.GetCloseEvent(config.Date), newConfig.Loan, sqlTransaction);
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

        private static ScriptScope RunScript(RepaymentConfiguration configuration)
        {
            var engine = Python.CreateEngine();
            var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts\\" + configuration.ScriptName);
            var scope = engine.CreateScope();
            scope.SetVariable("configuration", configuration);
            return engine.ExecuteFile(file, scope);
        }

        private static EventStock GenerateRepaymentEvents(RepaymentConfiguration oldConfig, RepaymentConfiguration newConfig)
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
