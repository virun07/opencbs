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
using Omu.ValueInjecter;
using OpenCBS.DataContract;
using OpenCBS.Interface.Repository;
using OpenCBS.Interface.Service;
using OpenCBS.Model;
using OpenCBS.Services;

namespace OpenCBS.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto Login(string username, string password)
        {
            var user = _userRepository.FindByUsernameAndPassword(username, password);
            if (user == null) return null;

            var userDto = new UserDto();
            userDto.InjectFrom(user);

            User.Current = user;
            UserDto.Current = userDto;

            // TODO: Remove this when the new architecture is put in place
            CoreDomain.User.CurrentUser = ServicesProvider.GetInstance().GetUserServices().Find(username, password);

            return userDto;
        }

        public bool IsLoggedIn()
        {
            return User.Current != null;
        }

        public IList<string> GetAllPermissions()
        {
            var result = new List<string>
            {
                "Role.View",
                "Role.Add",
                "Role.Edit",
                "Role.Delete",

                "User.View",
                "User.Add",
                "User.Edit",
                "User.Delete",

                "EntryFee.View",
                "EntryFee.Add",
                "EntryFee.Edit",
                "EntryFee.Delete",

                "LoanProduct.View",
                "LoanProduct.Add",
                "LoanProduct.Edit",
                "LoanProduct.Delete",

                "Currency.View",
                "Currency.Add",
                "Currency.Edit",
                "Currency.Delete"
            };
            return result.AsReadOnly();
        }

        public bool Can(string permission)
        {
            return User.Current != null && User.Current.Can(permission);
        }
    }
}
