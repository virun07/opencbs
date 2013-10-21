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
using OpenCBS.GUI.NEW.Repository;

namespace OpenCBS.GUI.NEW.Mapper
{
    public class LoanProductMapper : ILoanProductMapper
    {
        private readonly IPaymentFrequencyRepository _paymentFrequencyRepository;
        private readonly ISchedulePolicyRepository _schedulePolicyRepository;
        private readonly IYearPolicyRepository _yearPolicyRepository;
        private readonly IDateShiftPolicyRepository _dateShiftPolicyRepository;
        private readonly IRoundingPolicyRepository _roundingPolicyRepository;

        public LoanProductMapper(IPaymentFrequencyRepository paymentFrequencyRepository, 
            ISchedulePolicyRepository schedulePolicyRepository,
            IYearPolicyRepository yearPolicyRepository,
            IDateShiftPolicyRepository dateShiftPolicyRepository,
            IRoundingPolicyRepository roundingPolicyRepository)
        {
            _paymentFrequencyRepository = paymentFrequencyRepository;
            _schedulePolicyRepository = schedulePolicyRepository;
            _yearPolicyRepository = yearPolicyRepository;
            _dateShiftPolicyRepository = dateShiftPolicyRepository;
            _roundingPolicyRepository = roundingPolicyRepository;
        }

        public LoanProduct Map(LoanProductDto dto)
        {
            return new LoanProduct
            {
                Id = dto.Id,
                Name = dto.Name,
                Code = dto.Code,
                PaymentFrequency = _paymentFrequencyRepository.FindById(dto.PaymentFrequencyId),
                AvailableFor = (AvailableFor)dto.AvailableFor,
                SchedulePolicy = _schedulePolicyRepository.FindByName(dto.SchedulePolicy),
                YearPolicy = _yearPolicyRepository.FindByName(dto.YearPolicy),
                DateShiftPolicy = _dateShiftPolicyRepository.FindByName(dto.DateShiftPolicy),
                RoundingPolicy = _roundingPolicyRepository.FindByName(dto.RoundingPolicy),
                Deleted = dto.Deleted
            };
        }

        public LoanProductDto Map(LoanProduct loanProduct)
        {
            if (loanProduct == null)
                throw new ArgumentNullException("loanProduct");
            if (loanProduct.PaymentFrequency == null)
                throw new NullReferenceException("loanProduct.PaymentFrequency");
            if (loanProduct.SchedulePolicy == null)
                throw new NullReferenceException("loanProduct.SchedulePolicy");
            if (loanProduct.YearPolicy == null)
                throw new NullReferenceException("loanProduct.YearPolicy");
            if (loanProduct.DateShiftPolicy == null)
                throw new NullReferenceException("loanProduct.DateShiftPolicy");
            if (loanProduct.RoundingPolicy == null)
                throw new NullReferenceException("loanProduct.RoundingPolicy");

            return new LoanProductDto
            {
                Id = loanProduct.Id,
                Name = loanProduct.Name,
                Code = loanProduct.Code,
                PaymentFrequencyId = loanProduct.PaymentFrequency.Id,
                AvailableFor = (int)loanProduct.AvailableFor,
                SchedulePolicy = loanProduct.SchedulePolicy.Name,
                YearPolicy = loanProduct.YearPolicy.Name,
                DateShiftPolicy = loanProduct.DateShiftPolicy.Name,
                RoundingPolicy = loanProduct.RoundingPolicy.Name,
                Deleted = loanProduct.Deleted
            };
        }
    }
}
