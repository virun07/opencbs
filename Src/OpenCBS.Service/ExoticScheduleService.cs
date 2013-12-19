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
using OpenCBS.DataContract;
using OpenCBS.Interface.Repository;
using OpenCBS.Interface.Service;
using OpenCBS.Model.Schedule;

namespace OpenCBS.Service
{
    public class ExoticScheduleService : Service, IExoticScheduleService
    {
        private readonly IExoticScheduleRepository _repository;

        public ExoticScheduleService(IExoticScheduleRepository repository)
        {
            _repository = repository;
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
            throw new System.NotImplementedException();
        }

        public int Add(ExoticScheduleDto dto)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ExoticScheduleDto dto)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
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
