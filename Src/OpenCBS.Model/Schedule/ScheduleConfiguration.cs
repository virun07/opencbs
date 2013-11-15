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

namespace OpenCBS.Model.Schedule
{
    public class ScheduleConfiguration : IScheduleConfiguration
    {
        public decimal Amount { get; set; }
        public bool ChargeInterestDuringGracePeriod { get; set; }
        public DateTime FirstRepaymentDate { get; set; }
        public int GracePeriod { get; set; }
        public decimal InterestRate { get; set; }
        public int Maturity { get; set; }

        public IPaymentFrequencyPolicy PaymentFrequencyPolicy { get; set; }
        public IRoundingPolicy RoundingPolicy { get; set; }
        public DateTime StartDate { get; set; }
        public IYearPolicy YearPolicy { get; set; }
        public IDateShiftPolicy DateShiftPolicy { get; set; }
        public ISchedulePolicy SchedulePolicy { get; set; }
        public IAdjustmentPolicy AdjustmentPolicy { get; set; }
    }
}
