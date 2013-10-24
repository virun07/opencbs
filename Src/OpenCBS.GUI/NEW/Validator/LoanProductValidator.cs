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

using OpenCBS.GUI.NEW.Dto;

namespace OpenCBS.GUI.NEW.Validator
{
    public class LoanProductValidator : Validator<LoanProductDto>, ILoanProductValidator
    {
        public override void Validate(LoanProductDto entity)
        {
            base.Validate(entity);

            FailIfNullOrEmpty("Name", "Cannot be empty.");
            FailIfNullOrEmpty("Code", "Cannot be empty.");
            FailIfNullOrEmpty("SchedulePolicy", "Cannot be empty.");
            FailIfNullOrEmpty("PaymentFrequencyPolicy", "Cannot be empty.");
            FailIfNullOrEmpty("YearPolicy", "Cannot be empty.");
            FailIfNullOrEmpty("DateShiftPolicy", "Cannot be empty.");
            FailIfNullOrEmpty("RoundingPolicy", "Cannot be empty.");
            FailIfNullOrEmpty(entity.Amount.Item2, "Amount", "Max value cannot be empty.");
            FailIfNullOrEmpty(entity.Amount.Item1, "Amount", "Min value cannot be empty.");
            FailIfNullOrEmpty(entity.InterestRate.Item2, "InterestRate", "Max value cannot be empty.");
            FailIfNullOrEmpty(entity.InterestRate.Item1, "InterestRate", "Min value cannot be empty.");
            FailIfNullOrEmpty(entity.Maturity.Item1, "Maturity", "Max value cannot be empty.");
            FailIfNullOrEmpty(entity.Maturity.Item2, "Maturity", "Min value cannot be empty.");
            FailIfNullOrEmpty(entity.GracePeriod.Item1, "GracePeriod", "Max value cannot be empty.");
            FailIfNullOrEmpty(entity.GracePeriod.Item2, "GracePeriod", "Min value cannot be empty.");
        }
    }
}
