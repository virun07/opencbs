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

using OpenCBS.GUI.NEW.Model;

namespace OpenCBS.GUI.NEW.Repository.Mapper
{
    public class LoanProductMapper
    {
        public LoanProduct Map(LoanProductRow row)
        {
            return new LoanProduct
            {
                Id = row.Id,
                Name = row.Name,
                Code = row.Code,
                AvailableFor = row.AvailableFor,
                PaymentFrequencyPolicy = row.PaymentFrequencyPolicy,
                SchedulePolicy = row.SchedulePolicy,
                YearPolicy = row.YearPolicy,
                DateShiftPolicy = row.DateShiftPolicy,
                RoundingPolicy = row.RoundingPolicy,
                Amount = new DecimalPair(row.AmountMin, row.AmountMax),
                InterestRateMin = row.InterestRateMin,
                InterestRateMax = row.InterestRateMax,
                MaturityMin = row.MaturityMin,
                MaturityMax = row.MaturityMax,
                GracePeriodMin = row.GracePeriodMin,
                GracePeriodMax = row.GracePeriodMax,
                Deleted = row.Deleted
            };
        }
    }
}
