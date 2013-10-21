using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.InstallmentCalculationPolicy
{
    public abstract class BaseInstallmentCalculationPolicy
    {
        protected decimal CalculateInterest(IInstallment installment, IScheduleConfiguration configuration, decimal amount)
        {
            var daysInPeriod = configuration.PeriodPolicy.GetNumberOfDays(installment.EndDate);
            var daysInYear = configuration.YearPolicy.GetNumberOfDays(installment.EndDate);
            var interest = amount * configuration.InterestRate / 100 * daysInPeriod / daysInYear;
            return configuration.RoundingPolicy.Round(interest);
        }

        public abstract string Name { get; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return Name == ((IInstallmentCalculationPolicy) obj).Name;
        }
    }
}
