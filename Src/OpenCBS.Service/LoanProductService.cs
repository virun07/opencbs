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

using System.Collections.Generic;
using System.Linq;
using Omu.ValueInjecter;
using OpenCBS.Common.Injection;
using OpenCBS.DataContract;
using OpenCBS.Interface.Repository;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.Validator;
using OpenCBS.Model;

namespace OpenCBS.Service
{
    public class LoanProductService : ILoanProductService
    {
        private readonly ILoanProductRepository _loanProductRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IPolicyRepository _policyRepository;
        private readonly ILoanProductValidator _validator;

        public LoanProductService(ILoanProductRepository loanProductRepository,
            ICurrencyRepository currencyRepository,
            IPolicyRepository policyRepository,
            ILoanProductValidator validator)
        {
            _loanProductRepository = loanProductRepository;
            _currencyRepository = currencyRepository;
            _policyRepository = policyRepository;
            _validator = validator;
        }

        public IList<LoanProductDto> FindAll()
        {
            return _loanProductRepository.FindAll().Select(loanProduct =>
            {
                var loanProductDto = new LoanProductDto();
                loanProductDto
                    .InjectFrom(loanProduct)
                    .InjectFrom<NormalToNullableInjection>(loanProduct)
                    .InjectFrom<FlatNormalToNullableInjection>(loanProduct);
                loanProductDto.EntryFees = loanProduct.EntryFees
                    .Select(ef => new EntryFeeDto().InjectFrom(ef).InjectFrom<NormalToNullableInjection>(ef))
                    .Cast<EntryFeeDto>().ToList();
                return loanProductDto;
            }).ToList();
        }

        public void Add(LoanProductDto loanProductDto)
        {
            _validator.Validate(loanProductDto);
            if (loanProductDto.Notification.HasErrors) return;

            var loanProduct = new LoanProduct();
            loanProduct.InjectFrom(loanProductDto).InjectFrom<NullableToNormalInjection>(loanProductDto);
            loanProduct.Currency = _currencyRepository.FindById(loanProductDto.CurrencyId ?? 1);
            _loanProductRepository.Add(loanProduct);
        }

        public void Update(LoanProductDto loanProductDto)
        {
            _validator.Validate(loanProductDto);
            if (loanProductDto.Notification.HasErrors) return;

            var loanProduct = _loanProductRepository.FindById(loanProductDto.Id);
            loanProduct.InjectFrom(loanProductDto).InjectFrom<NullableToNormalInjection>(loanProductDto);
            loanProduct.Currency = _currencyRepository.FindById(loanProductDto.CurrencyId ?? 1);
            _loanProductRepository.Update(loanProduct);
        }

        public void Remove(int id)
        {
            _loanProductRepository.Remove(id);
        }

        public void Validate(LoanProductDto loanProductDto)
        {
            _validator.Validate(loanProductDto);
        }

        public LoanProductReferenceDataDto GetReferenceData()
        {
            var result = new LoanProductReferenceDataDto
            {
                SchedulePolicies = _policyRepository.FindSchedulePolicyNames(),
                PaymentFrequencyPolicies = _policyRepository.FindPaymentFrequencyPolicyNames(),
                YearPolicies = _policyRepository.FindYearPolicyNames(),
                DateShiftPolicies = _policyRepository.FindDateShiftPolicyNames(),
                RoundingPolicies = _policyRepository.FindRoundingPolicyNames(),
                Currencies = _currencyRepository
                    .FindAll()
                    .Where(c => !c.Deleted)
                    .ToDictionary(c => c.Id, c => c.Name)
            };
            return result;
        }
    }
}
