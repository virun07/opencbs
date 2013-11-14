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

namespace OpenCBS.Model
{
    public class User : EntityBase
    {
        public static User Current { get; set; }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<Role> Roles { get; set; }
        public bool IsSuperuser { get; set; }

        public bool Can(string permission)
        {
            if (IsSuperuser) return true;
            return Roles.Select(r => r.Can(permission)).Aggregate((x, y) => x || y);
        }

        public bool HasServicePermission(string servicePermission)
        {
            if (IsSuperuser) return true;
            return Roles.Select(r => r.HasServicePermission(servicePermission)).Aggregate((x, y) => x || y);
        }
    }
}
