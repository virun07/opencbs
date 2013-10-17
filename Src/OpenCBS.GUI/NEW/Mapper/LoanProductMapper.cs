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

        public LoanProductMapper(IPaymentFrequencyRepository paymentFrequencyRepository)
        {
            _paymentFrequencyRepository = paymentFrequencyRepository;
        }

        public LoanProduct Map(LoanProductDto dto)
        {
            return new LoanProduct
            {
                Id = dto.Id,
                Name = dto.Name,
                Code = dto.Code,
                PaymentFrequency = _paymentFrequencyRepository.FindById(dto.PaymentFrequencyId)
            };
        }

        public LoanProductDto Map(LoanProduct loanProduct)
        {
            if (loanProduct == null)
                throw new ArgumentNullException("loanProduct");
            if (loanProduct.PaymentFrequency == null)
                throw new NullReferenceException("loanProduct.PaymentFrequency");

            return new LoanProductDto
            {
                Id = loanProduct.Id,
                Name = loanProduct.Name,
                Code = loanProduct.Code,
                PaymentFrequencyId = loanProduct.PaymentFrequency.Id
            };
        }
    }
}
