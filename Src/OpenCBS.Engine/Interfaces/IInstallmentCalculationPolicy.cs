
namespace OpenCBS.Engine.Interfaces
{
    public interface IInstallmentCalculationPolicy : IPolicy
    {
        string Name { get; }
        void Calculate(IInstallment installment, IScheduleConfiguration configuration);
    }
}
