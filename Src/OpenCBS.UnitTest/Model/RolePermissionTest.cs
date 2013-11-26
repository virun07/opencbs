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
using NUnit.Framework;
using OpenCBS.Model;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Model
{
    [TestFixture]
    public class RolePermissionTest
    {
        private static Role GetRoleWithPermission(string permission)
        {
            return new Role { Permissions = new List<string> { permission } };
        }

        private static void AssertMapsTo(Role role, IEnumerable<string> servicePermissions)
        {
            foreach (var servicePermission in servicePermissions)
            {
                Assert.IsTrue(role.HasServicePermission(servicePermission));
            }
        }

        [Test]
        public void Role_View()
        {
            var role = GetRoleWithPermission("Role.View");
            AssertMapsTo(role, new[] { "IRoleService.FindAll" });
        }

        [Test]
        public void Role_Add()
        {
            var role = GetRoleWithPermission("Role.Add");
            AssertMapsTo(role, new[] { "IRoleService.FindAll", "IRoleService.Validate", "IRoleService.Add" });
        }

        [Test]
        public void Role_Edit()
        {
            var role = GetRoleWithPermission("Role.Edit");
            AssertMapsTo(role, new[] { "IRoleService.FindById", "IRoleService.FindAll", "IRoleService.Validate", "IRoleService.Update" });
        }

        [Test]
        public void Role_Delete()
        {
            var role = GetRoleWithPermission("Role.Delete");
            AssertMapsTo(role, new[] { "IRoleService.FindAll", "IRoleService.Delete" });
        }

        [Test]
        public void User_View()
        {
            var role = GetRoleWithPermission("User.View");
            AssertMapsTo(role, new[] { "IUserService.FindAll" });
        }

        [Test]
        public void User_Add()
        {
            var role = GetRoleWithPermission("User.Add");
            AssertMapsTo(role, new[] { "IRoleService.FindAll", "IUserService.FindAll", "IUserService.Validate", "IUserService.Add" });
        }

        [Test]
        public void User_Edit()
        {
            var role = GetRoleWithPermission("User.Edit");
            AssertMapsTo(role, new[] { "IRoleService.FindAll", "IUserService.FindAll", "IUserService.FindById", "IUserService.Validate", "IUserService.Update" });
        }

        [Test]
        public void User_Delete()
        {
            var role = GetRoleWithPermission("User.Delete");
            AssertMapsTo(role, new[] { "IUserService.FindAll", "IUserService.Delete" });
        }

        [Test]
        public void EntryFee_View()
        {
            var role = GetRoleWithPermission("EntryFee.View");
            AssertMapsTo(role, new[] { "IEntryFeeService.FindAll" });
        }

        [Test]
        public void EntryFee_Add()
        {
            var role = GetRoleWithPermission("EntryFee.Add");
            AssertMapsTo(role, new[] { "IEntryFeeService.FindAll", "IEntryFeeService.Validate", "IEntryFeeService.Add" });
        }

        [Test]
        public void EntryFee_Edit()
        {
            var role = GetRoleWithPermission("EntryFee.Edit");
            AssertMapsTo(role, new[] { "IEntryFeeService.FindAll", "IEntryFeeService.FindById", "IEntryFeeService.Validate", "IEntryFeeService.Update" });
        }
    }
}
// ReSharper restore InconsistentNaming
