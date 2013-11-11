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
using System.Collections.Generic;
using System.Linq;
using Omu.ValueInjecter;
using OpenCBS.DataContract;
using OpenCBS.Interface.Repository;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.Validator;
using OpenCBS.Model;

namespace OpenCBS.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleValidator _validator;

        public RoleService(IRoleRepository roleRepository, IRoleValidator validator)
        {
            _roleRepository = roleRepository;
            _validator = validator;
        }

        public IList<RoleDto> FindAll()
        {
            return _roleRepository.FindAll().Select(Map).ToList().AsReadOnly();
        }

        public RoleDto FindById(int id)
        {
            var role = _roleRepository.FindById(id);
            return role == null ? null : Map(role);
        }

        public void Validate(RoleDto dto)
        {
            _validator.Validate(dto);
        }

        public int Add(RoleDto dto)
        {
            _validator.Validate(dto);
            if (dto.Notification.HasErrors)
                throw new ArgumentException("Validation failed.", "dto");

            var role = new Role();
            role.InjectFrom(dto);
            return _roleRepository.Add(role);
        }

        public void Update(RoleDto dto)
        {
            _validator.Validate(dto);
            if (dto.Notification.HasErrors)
                throw new ArgumentException("Validation failed.", "dto");

            var role = _roleRepository.FindById(dto.Id);
            if (role == null)
                throw new ArgumentException("Object not found in repository.", "dto");

            role.InjectFrom(dto);
            _roleRepository.Update(role);
        }

        public void Remove(int id)
        {
            _roleRepository.Remove(id);
        }

        private static RoleDto Map(Role role)
        {
            var roleDto = new RoleDto();
            roleDto.InjectFrom(role);
            return roleDto;
        }
    }
}
