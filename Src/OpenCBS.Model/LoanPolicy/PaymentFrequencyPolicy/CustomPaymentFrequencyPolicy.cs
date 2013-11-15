using System;
using OpenCBS.Model.Interface;

namespace OpenCBS.Model.LoanPolicy.PaymentFrequencyPolicy
{
    public class CustomPaymentFrequencyPolicy : IPaymentFrequencyPolicy
    {
        private readonly int _numberOfDays;

        public CustomPaymentFrequencyPolicy(int numberOfDays)
        {
            _numberOfDays = numberOfDays;
        }

        public DateTime GetNextDate(DateTime date)
        {
            return date.AddDays(_numberOfDays);
        }

        public DateTime GetPreviousDate(DateTime date)
        {
            return date.AddDays(-_numberOfDays);
        }

        public int GetNumberOfDays(DateTime date)
        {
            return _numberOfDays;
        }
    }
}
