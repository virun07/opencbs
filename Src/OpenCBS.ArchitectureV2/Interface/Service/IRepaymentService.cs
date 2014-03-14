using OpenCBS.ArchitectureV2.Service;
using OpenCBS.CoreDomain.Contracts.Loans;

namespace OpenCBS.ArchitectureV2.Interface.Service
{
    public interface IRepaymentService
    {
        RepaymentConfiguration Repay(RepaymentConfiguration configuration);

        Loan RepayAndSave(RepaymentConfiguration configuration);
    }
}
