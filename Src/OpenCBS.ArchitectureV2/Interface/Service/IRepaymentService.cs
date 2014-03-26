using OpenCBS.ArchitectureV2.Service;
using OpenCBS.CoreDomain.Contracts.Loans;

namespace OpenCBS.ArchitectureV2.Interface.Service
{
    public interface IRepaymentService
    {
        RepaymentSettings Settings { get; set; }
        Loan Repay();
        Loan RepayAndSave();
    }
}
