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
using OpenCBS.GUI.NEW.Model;
using OpenCBS.GUI.NEW.Dto;

namespace OpenCBS.GUI.NEW.Mapper
{
    public class LoanProductMapper : ILoanProductMapper
    {
        public LoanProduct Map(LoanProductDto dto)
        {
            return new LoanProduct
            {
                Id = dto.Id,
                Name = dto.Name,
                Code = dto.Code,
                AvailableFor = dto.AvailableFor,
                PaymentFrequencyPolicy = dto.PaymentFrequencyPolicy,
                SchedulePolicy = dto.SchedulePolicy,
                YearPolicy = dto.YearPolicy,
                DateShiftPolicy = dto.DateShiftPolicy,
                RoundingPolicy = dto.RoundingPolicy,
                AmountMin = dto.Amount.Item1 ?? 0,
                AmountMax = dto.Amount.Item2 ?? 0,
                InterestRateMin = dto.InterestRate.Item1 ?? 0,
                InterestRateMax = dto.InterestRate.Item2 ?? 0,
                MaturityMin = dto.Maturity.Item1 ?? 0,
                MaturityMax = dto.Maturity.Item2 ?? 0,
                GracePeriodMin = dto.GracePeriod.Item1 ?? 0,
                GracePeriodMax = dto.GracePeriod.Item2 ?? 0,
                Deleted = dto.Deleted
            };
        }

        public LoanProductDto Map(LoanProduct loanProduct)
        {
            if (loanProduct == null)
                throw new ArgumentNullException("loanProduct");

            return new LoanProductDto
            {
                Id = loanProduct.Id,
                Name = loanProduct.Name,
                Code = loanProduct.Code,
                AvailableFor = loanProduct.AvailableFor,
                PaymentFrequencyPolicy = loanProduct.PaymentFrequencyPolicy,
                SchedulePolicy = loanProduct.SchedulePolicy,
                YearPolicy = loanProduct.YearPolicy,
                DateShiftPolicy = loanProduct.DateShiftPolicy,
                RoundingPolicy = loanProduct.RoundingPolicy,
                Amount = new Tuple<decimal?, decimal?>(loanProduct.AmountMin, loanProduct.AmountMax),
                InterestRate = new Tuple<decimal?, decimal?>(loanProduct.InterestRateMin, loanProduct.InterestRateMax),
                Maturity = new Tuple<int?, int?>(loanProduct.MaturityMin, loanProduct.MaturityMax),
                GracePeriod = new Tuple<int?, int?>(loanProduct.GracePeriodMin, loanProduct.GracePeriodMax),
                Deleted = loanProduct.Deleted
            };
        }
    }
}
