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
using System.Transactions;
using Omu.ValueInjecter;
using OpenCBS.Common.Injection;
using OpenCBS.DataContract;
using OpenCBS.Interface.Repository;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.Validator;
using OpenCBS.Model;
using OpenCBS.Model.Interface;

namespace OpenCBS.Service
{
    public class LoanProductService : Service, ILoanProductService
    {
        private readonly ILoanProductRepository _loanProductRepository;
        private readonly IEntryFeeRepository _entryFeeRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IPolicyRepository _policyRepository;
        private readonly IPolicyFactory _policyFactory;
        private readonly ILoanProductValidator _validator;

        public LoanProductService(ILoanProductRepository loanProductRepository,
            IEntryFeeRepository entryFeeRepository,
            ICurrencyRepository currencyRepository,
            IPolicyRepository policyRepository,
            IPolicyFactory policyFactory,
            ILoanProductValidator validator)
        {
            _loanProductRepository = loanProductRepository;
            _entryFeeRepository = entryFeeRepository;
            _currencyRepository = currencyRepository;
            _policyRepository = policyRepository;
            _policyFactory = policyFactory;
            _validator = validator;
        }

        public IList<LoanProductDto> FindAll()
        {
            return _loanProductRepository.FindAll().Select(Map).ToList();
        }

        public LoanProductDto FindById(int id)
        {
            var loanProduct = _loanProductRepository.FindById(id);
            return loanProduct == null ? null : Map(loanProduct);
        }

        public int Add(LoanProductDto dto)
        {
            _validator.Validate(dto);
            ThrowIfInvalid(dto);

            var loanProduct = new LoanProduct();
            loanProduct.InjectFrom(dto).InjectFrom<NullableToNormalInjection>(dto);
            loanProduct.Currency = _currencyRepository.FindById(dto.CurrencyId ?? 1);
            var entryFeeIds = dto.EntryFees.Select(ef => ef.Id).ToArray();
            loanProduct.EntryFees = _entryFeeRepository.FindByIds(entryFeeIds);
            
            using (var scope = new TransactionScope())
            {
                var id = _loanProductRepository.Add(loanProduct);
                scope.Complete();
                return id;
            }
        }

        public void Update(LoanProductDto dto)
        {
            _validator.Validate(dto);
            ThrowIfInvalid(dto);

            var loanProduct = _loanProductRepository.FindById(dto.Id);
            ThrowIfNotFound(loanProduct);

            loanProduct.InjectFrom(dto).InjectFrom<NullableToNormalInjection>(dto);
            loanProduct.Currency = _currencyRepository.FindById(dto.CurrencyId ?? 1);
            var entryFeeIds = dto.EntryFees.Select(ef => ef.Id).ToArray();
            loanProduct.EntryFees = _entryFeeRepository.FindByIds(entryFeeIds);

            using (var scope = new TransactionScope())
            {
                _loanProductRepository.Update(loanProduct);
                scope.Complete();
            }
        }

        public void Delete(int id)
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
                PaymentFrequencyPolicies = _policyFactory.GetPaymentFrequencyPolicyNames(),
                YearPolicies = _policyFactory.GetYearPolicyNames(),
                DateShiftPolicies = _policyRepository.FindDateShiftPolicyNames(),
                RoundingPolicies = _policyFactory.GetRoundingPolicyNames(),
                LateFeePolicies = _policyFactory.GetLateFeePolicyNames(),
                Currencies = _currencyRepository.FindAll().Where(c => !c.Deleted).ToDictionary(c => c.Id, c => c.Name)
            };
            return result;
        }

        private static LoanProductDto Map(LoanProduct loanProduct)
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
        }
    }
}
