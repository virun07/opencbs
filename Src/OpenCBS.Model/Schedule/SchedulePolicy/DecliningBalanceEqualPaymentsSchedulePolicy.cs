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
using OpenCBS.Model.Interface;

namespace OpenCBS.Model.Schedule.SchedulePolicy
{
    public class DecliningBalanceEqualPaymentsSchedulePolicy : BaseSchedulePolicy, ISchedulePolicy
    {
        public void Calculate(IInstallment installment, IScheduleConfiguration configuration)
        {
            var number = configuration.Maturity - configuration.GracePeriod;
            var numberOfPeriods = configuration.PaymentFrequencyPolicy.GetNumberOfPeriodsInYear(installment.EndDate, configuration.YearPolicy);
            var interestRate = (double) configuration.InterestRate / 100 / numberOfPeriods;

            var numerator = interestRate * (double) configuration.Amount;
            var denominator = 1 - 1 / Math.Pow(1 + interestRate, number);
            var total = configuration.RoundingPolicy.Round((decimal) (numerator / denominator));

            installment.Interest = CalculateInterest(installment, configuration, installment.Olb);
            installment.Principal = total - installment.Interest;
        }
    }
}
