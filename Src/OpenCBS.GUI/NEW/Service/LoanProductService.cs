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
using OpenCBS.GUI.NEW.Dto;
using OpenCBS.GUI.NEW.Model;
using OpenCBS.GUI.NEW.Repository;
using OpenCBS.GUI.NEW.Validator;

namespace OpenCBS.GUI.NEW.Service
{
    public class LoanProductService : ILoanProductService
    {
        private readonly ILoanProductRepository _repository;
        private readonly IPolicyRepository _policyRepository;
        private readonly ILoanProductValidator _validator;

        public LoanProductService(ILoanProductRepository repository, 
            IPolicyRepository policyRepository,
            ILoanProductValidator validator)
        {
            _repository = repository;
            _policyRepository = policyRepository;
            _validator = validator;
        }

        public IList<LoanProductDto> FindAll()
        {
            return _repository.FindAll().Select(loanProduct =>
            {
                var loanProductDto = new LoanProductDto();
                loanProductDto.InjectFrom(loanProduct);
                return loanProductDto;
            }).ToList();
        }

        public IList<LoanProductDto> FindNonDeleted()
        {
            return _repository.FindNonDeleted().Select(loanProduct =>
            {
                var loanProductDto = new LoanProductDto();
                loanProductDto.InjectFrom(loanProduct);
                return loanProductDto;
            }).ToList();
        }

        public void Add(LoanProductDto loanProductDto)
        {
            var loanProduct = new LoanProduct();
            loanProduct.InjectFrom(loanProductDto);
            _repository.Add(loanProduct);
        }

        public void Update(LoanProductDto loanProductDto)
        {
            var loanProduct = _repository.FindById(loanProductDto.Id);
            loanProduct.InjectFrom(loanProductDto);
            _repository.Update(loanProduct);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
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
                Currencies = new Dictionary<int, string>
                {
                    {1, "USD"}
                }
            };
            return result;
        }
    }
}
