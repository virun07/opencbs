// Copyright © 2013 Open Octopus Ltd.
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
// 
// Website: http://www.opencbs.com
// Contact: contact@opencbs.com

using System;
using System.Collections.Generic;
using OpenCBS.Model.Interface;

namespace OpenCBS.Model.Schedule
{
    public class ScheduleBuilder : IScheduleBuilder
    {
        public IList<IInstallment> BuildSchedule(IScheduleConfiguration configuration)
        {
            if (configuration.PaymentFrequencyPolicy == null) throw new ArgumentException("Payment frequency policy cannot be null.");
            if (configuration.YearPolicy == null) throw new ArgumentException("Year policy cannot be null.");
            if (configuration.RoundingPolicy == null) throw new ArgumentException("Rounding policy cannot be null.");
            if (configuration.SchedulePolicy == null) throw new ArgumentException("Schedule policy cannot be null.");
            if (configuration.DateShiftPolicy == null) throw new ArgumentException("Date shift policy cannot be null.");
            if (configuration.AdjustmentPolicy == null) throw new ArgumentException("Adjustment policy cannot be null.");
            if (configuration.GracePeriod >= configuration.Maturity) throw new ArgumentException("Grace period cannot be less than the number of installments.");

            var installment = BuildFirst(configuration);
            IList<IInstallment> result = new List<IInstallment> { installment };

            while ((installment = BuildNext(installment, configuration)) != null)
            {
                result.Add(installment);
            }

            result = configuration.AdjustmentPolicy.Adjust(result, configuration.Amount);

            // CalculationPolicy interest during grace period
            if (configuration.ChargeInterestDuringGracePeriod)
            {
                for (var i = 0; i < configuration.GracePeriod; i++)
                {
                    result[i].Interest = CalculateInterest(result[i], configuration);
                }
            }
            // Caluclate interest of the first installment if the maturity
            // is less than or greater than a period (week, month, etc.)
            var firstInstallment = result[0];
            var periodEndDate = configuration.PaymentFrequencyPolicy.GetNextDate(firstInstallment.StartDate);
            var actualEndDate = firstInstallment.EndDate;
            if (periodEndDate != actualEndDate)
            {
                var numerator = (decimal) (firstInstallment.EndDate.Date - firstInstallment.StartDate.Date).Days;
                var denominator = configuration.PaymentFrequencyPolicy.GetNumberOfDays(firstInstallment.EndDate);
                firstInstallment.Interest = configuration.RoundingPolicy.Round(firstInstallment.Interest * numerator / denominator);
            }

            // Initialize RepaymentDate's
            foreach (var i in result)
            {
                i.RepaymentDate = configuration.DateShiftPolicy.ShiftDate(i.EndDate);
            }

            return result;
        }

        private static IInstallment BuildFirst(IScheduleConfiguration configuration)
        {
            var installment = new Installment
            {
                Number = 1,
                StartDate = configuration.StartDate,
                EndDate = configuration.FirstRepaymentDate,
                Olb = configuration.Amount,
            };
            if (configuration.GracePeriod == 0)
            {
                configuration.SchedulePolicy.Calculate(installment, configuration);
            }

            return installment;
        }

        private static IInstallment BuildNext(IInstallment previous, IScheduleConfiguration configuration)
        {
            if (previous == null) throw new ArgumentException("Previous installment cannot be null.");

            if (previous.Number == configuration.Maturity) return null;
            var installment = new Installment
            {
                Number = previous.Number + 1,
                StartDate = previous.EndDate,
                EndDate = configuration.PaymentFrequencyPolicy.GetNextDate(previous.EndDate),
                Olb = previous.Olb - previous.Principal,
            };
            if (configuration.GracePeriod < installment.Number)
            {
                configuration.SchedulePolicy.Calculate(installment, configuration);
            }
            return installment;
        }

        private static decimal CalculateInterest(IInstallment installment, IScheduleConfiguration configuration)
        {
            var daysInPeriod = configuration.PaymentFrequencyPolicy.GetNumberOfDays(installment.EndDate);
            var daysInYear = configuration.YearPolicy.GetNumberOfDays(installment.EndDate);
            var interest = installment.Olb * configuration.InterestRate / 100 * daysInPeriod / daysInYear;
            return configuration.RoundingPolicy.Round(interest);
        }
    }
}
