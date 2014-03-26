using System;
using OpenCBS.CoreDomain.Accounting;
using OpenCBS.CoreDomain.Contracts.Loans;

namespace OpenCBS.ArchitectureV2.Service
{
    public class RepaymentSettings
    {
        public Loan Loan { get; set; }
        public decimal Amount { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal Penalty { get; set; }
        public decimal Commission { get; set; }
        public DateTime Date { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Comment { get; set; }
        public string ScriptName { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
