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
    public class EntryFeeService : Service, IEntryFeeService
    {
        private readonly IEntryFeeRepository _repository;
        private readonly IEntryFeeValidator _validator;

        public EntryFeeService(IEntryFeeRepository repository, IEntryFeeValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public IList<EntryFeeDto> FindAll()
        {
            return _repository.FindAll().Select(entryFee =>
            {
                var entryFeeDto = new EntryFeeDto();
                entryFeeDto.InjectFrom(entryFee).InjectFrom<NormalToNullableInjection>(entryFee);
                return entryFeeDto;
            }).ToList();
        }

        public EntryFeeDto FindById(int id)
        {
            var entryFee = _repository.FindById(id);
            if (entryFee == null) return null;
            var entryFeeDto = new EntryFeeDto();
            entryFeeDto.InjectFrom(entryFee).InjectFrom<NormalToNullableInjection>(entryFee);
            return entryFeeDto;
        }

        public int Add(EntryFeeDto dto)
        {
            _validator.Validate(dto);
            ThrowIfInvalid(dto);

            var entryFee = new EntryFee();
            entryFee.InjectFrom(dto).InjectFrom<NullableToNormalInjection>(dto);
            return _repository.Add(entryFee);
        }

        public void Update(EntryFeeDto dto)
        {
            _validator.Validate(dto);
            ThrowIfInvalid(dto);

            var entryFee = _repository.FindById(dto.Id);
            ThrowIfNotFound(entryFee);
            entryFee.InjectFrom(dto).InjectFrom<NullableToNormalInjection>(dto);
            _repository.Update(entryFee);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void Validate(EntryFeeDto entryFeeDto)
        {
            _validator.Validate(entryFeeDto);
        }
    }
}
