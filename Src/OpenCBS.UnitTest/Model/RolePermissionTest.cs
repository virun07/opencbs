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
            var role = GetRoleWithPermission("Security.ViewRole");
            AssertMapsTo(role, new[] { "IRoleService.FindAll" });
        }

        [Test]
        public void Role_Add()
        {
            var role = GetRoleWithPermission("Security.AddRole");
            AssertMapsTo(role, new[] { "IRoleService.FindAll", "IRoleService.Validate", "IRoleService.Add" });
        }

        [Test]
        public void Role_Edit()
        {
            var role = GetRoleWithPermission("Security.EditRole");
            AssertMapsTo(role, new[] { "IRoleService.FindById", "IRoleService.FindAll", "IRoleService.Validate", "IRoleService.Update" });
        }

        [Test]
        public void Role_Delete()
        {
            var role = GetRoleWithPermission("Security.DeleteRole");
            AssertMapsTo(role, new[] { "IRoleService.FindAll", "IRoleService.Delete" });
        }

        [Test]
        public void User_View()
        {
            var role = GetRoleWithPermission("Security.ViewUser");
            AssertMapsTo(role, new[] { "IUserService.FindAll" });
        }

        [Test]
        public void User_Add()
        {
            var role = GetRoleWithPermission("Security.AddUser");
            AssertMapsTo(role, new[] { "IRoleService.FindAll", "IUserService.FindAll", "IUserService.Validate", "IUserService.Add" });
        }

        [Test]
        public void User_Edit()
        {
            var role = GetRoleWithPermission("Security.EditUser");
            AssertMapsTo(role, new[] { "IRoleService.FindAll", "IUserService.FindAll", "IUserService.FindById", "IUserService.Validate", "IUserService.Update" });
        }

        [Test]
        public void User_Delete()
        {
            var role = GetRoleWithPermission("Security.DeleteUser");
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

        [Test]
        public void EntryFee_Delete()
        {
            var role = GetRoleWithPermission("EntryFee.Delete");
            AssertMapsTo(role, new[] { "IEntryFeeService.FindAll", "IEntryFeeService.Delete" });
        }

        [Test]
        public void LoanProduct_View()
        {
            var role = GetRoleWithPermission("LoanProduct.View");
            AssertMapsTo(role, new[] { "ILoanProductService.FindAll" });
        }

        [Test]
        public void LoanProduct_Add()
        {
            var role = GetRoleWithPermission("LoanProduct.Add");
            AssertMapsTo(role, new[]
            {
                "IEntryFeeService.FindAll",
                "IEntryFeeService.FindById",
                "ILoanProductService.GetReferenceData",
                "ILoanProductService.FindAll",
                "ILoanProductService.Validate",
                "ILoanProductService.Add"
            });
        }

        [Test]
        public void LoanProduct_Edit()
        {
            var role = GetRoleWithPermission("LoanProduct.Edit");
            AssertMapsTo(role, new[]
            {
                "IEntryFeeService.FindAll",
                "IEntryFeeService.FindById",
                "ILoanProductService.GetReferenceData",
                "ILoanProductService.FindAll",
                "ILoanProductService.Validate",
                "ILoanProductService.Update"
            });
        }

        [Test]
        public void LoanProduct_Delete()
        {
            var role = GetRoleWithPermission("LoanProduct.Delete");
            AssertMapsTo(role, new[] { "ILoanProductService.FindAll", "ILoanProductService.Delete" });
        }
    }
}
// ReSharper restore InconsistentNaming
