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

using OpenCBS.Model.Interface;
using OpenCBS.Model.Schedule.DateShiftPolicy;
using OpenCBS.Model.Schedule.LateFeePolicy;
using OpenCBS.Model.Schedule.PaymentFrequencyPolicy;
using OpenCBS.Model.Schedule.RoundingPolicy;
using OpenCBS.Model.Schedule.SchedulePolicy;
using OpenCBS.Model.Schedule.YearPolicy;
using StructureMap.Configuration.DSL;

namespace OpenCBS.Service
{
    public class PolicyRegistry : Registry
    {
        public PolicyRegistry()
        {
            For<ILateFeePolicy>().Use<DefaultLateFeePolicy>().Named("Always accrue");

            For<IPaymentFrequencyPolicy>().Add<DailyPaymentFrequencyPolicy>().Named("Daily");
            For<IPaymentFrequencyPolicy>().Add<WeeklyPaymentFrequencyPolicy>().Named("Weekly");
            For<IPaymentFrequencyPolicy>().Add<BiweeklyPaymentFrequencyPolicy>().Named("Biweekly");
            For<IPaymentFrequencyPolicy>().Add<ThirtyDaysPaymentFrequencyPolicy>().Named("30 days");
            For<IPaymentFrequencyPolicy>().Add<MonthlyPaymentFrequencyPolicy>().Named("Monthly");
            For<IPaymentFrequencyPolicy>().Add<Monthly30DayPaymentFrequencyPolicy>().Named("Monthly (30 day)");
            
            For<IYearPolicy>().Add<ActualYearPolicy>().Named("Actual");
            For<IYearPolicy>().Add<ThreeSixtyYearPolicy>().Named("360 days");
            For<IYearPolicy>().Add<ThreeSixtyFiveYearPolicy>().Named("365 days");

            For<IRoundingPolicy>().Add<WholeRoundingPolicy>().Named("Whole");
            For<IRoundingPolicy>().Add<TwoDecimalsRoundingPolicy>().Named("Two decimals");

            For<IDateShiftPolicy>().Add<NoDateShiftPolicy>().Named("No shift");
            For<IDateShiftPolicy>().Add<ForwardDateShiftPolicy>().Named("Forward");
            For<IDateShiftPolicy>().Add<BackwardDateShiftPolicy>().Named("Backward");

            For<ISchedulePolicy>().Add<FlatSchedulePolicy>().Named("Flat");
            For<ISchedulePolicy>().Add<DecliningBalanceSchedulePolicy>().Named("Declining balance");
            For<ISchedulePolicy>().Add<DecliningBalanceEqualPaymentsSchedulePolicy>().Named("Declining balance (equal payments)");
        }
    }
}
