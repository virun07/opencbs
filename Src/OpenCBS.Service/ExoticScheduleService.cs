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
using OpenCBS.DataContract;
using OpenCBS.Interface.Repository;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.Validator;
using OpenCBS.Model.Schedule;

namespace OpenCBS.Service
{
    public class ExoticScheduleService : Service, IExoticScheduleService
    {
        private readonly IExoticScheduleRepository _repository;
        private readonly IExoticScheduleValidator _validator;

        public ExoticScheduleService(IExoticScheduleRepository repository, IExoticScheduleValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public IList<ExoticScheduleDto> FindAll()
        {
            return _repository.FindAll().Select(Map).ToList().AsReadOnly();
        }

        public ExoticScheduleDto FindById(int id)
        {
            var result = _repository.FindById(id);
            return result == null ? null : Map(result);
        }

        public void Validate(ExoticScheduleDto dto)
        {
            _validator.Validate(dto);
        }

        public int Add(ExoticScheduleDto dto)
        {
            _validator.Validate(dto);
            ThrowIfInvalid(dto);

            var exoticSchedule = new ExoticSchedule();
            exoticSchedule.InjectFrom(dto);
            exoticSchedule.Items = dto.Items.Select(x => new ExoticScheduleItem().InjectFrom(x)).Cast<ExoticScheduleItem>().ToList().AsReadOnly();

            using (var scope = new TransactionScope())
            {
                var id = _repository.Add(exoticSchedule);
                scope.Complete();
                return id;
            }
        }

        public void Update(ExoticScheduleDto dto)
        {
            _validator.Validate(dto);
            ThrowIfInvalid(dto);

            var exoticSchedule = _repository.FindById(dto.Id);
            ThrowIfNotFound(exoticSchedule);

            exoticSchedule.InjectFrom(dto);
            exoticSchedule.Items = dto.Items.Select(x => new ExoticScheduleItem().InjectFrom(x)).Cast<ExoticScheduleItem>().ToList().AsReadOnly();

            using (var scope = new TransactionScope())
            {
                _repository.Update(exoticSchedule);
                scope.Complete();
            }
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
        }

        private static ExoticScheduleDto Map(ExoticSchedule schedule)
        {
            var result = new ExoticScheduleDto();
            result.InjectFrom(schedule);
            result.Items = schedule.Items
                .Select(x => new ExoticScheduleItemDto().InjectFrom(x))
                .Cast<ExoticScheduleItemDto>().ToList().AsReadOnly();
            return result;
        }
    }
}
