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

using System.Collections.ObjectModel;
using System.Linq;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;
using OpenCBS.Model;
using OpenCBS.Persistence;
using Dapper;

// ReSharper disable InconsistentNaming
namespace OpenCBS.Test.IntegrationTest.Persistence
{
    [TestFixture]
    public class RoleRepositoryTest : BaseTest
    {
        private RoleRepository _repository;

        [TestFixtureSetUp]
        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();
            _repository = new RoleRepository(ConnectionStringProvider);
            CleanUp();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            CleanUp();
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }

        [Test]
        public void Add_AddsRoleToDatabase()
        {
            var role = new Role
            {
                Name = "Role Administrator",
                Permissions = new ReadOnlyCollection<string>(new[] { "Security.ViewRole", "Security.AddRole", "Security.EditRole" })
            };
            role.Id = _repository.Add(role);

            using (var connection = GetConnection())
            {
                var sql = @"select count(*) from Roles where id = @Id";
                var count = connection.Query<int>(sql, new { role.Id }).Single();
                Assert.AreEqual(1, count);

                sql = @"select count(*) from RolePermission where RoleId = @Id";
                count = connection.Query<int>(sql, new { role.Id }).Single();
                Assert.AreEqual(3, count);
            }
        }

        [Test]
        public void FindById_FindsRoleInDatabase()
        {
            var role = new Role
            {
                Name = "User Administrator",
                Permissions = new ReadOnlyCollection<string>(new[] { "Security.ViewUser", "Security.AddUser", "Security.EditUser", "Security.DeleteUser" })
            };
            role.Id = _repository.Add(role);
            var roleCopy = _repository.FindById(role.Id);

            var comparison = new CompareObjects();
            Assert.IsTrue(comparison.Compare(role, roleCopy));
        }

        [Test]
        public void FindAll_FindsRolesInDatabase()
        {
            var role1 = new Role
            {
                Name = "Visitor 1",
                Permissions = new ReadOnlyCollection<string>(new[] { "Security.ViewRole", "Security.ViewUser" })
            };
            var role2 = new Role
            {
                Name = "Visitor 2",
                Permissions = new ReadOnlyCollection<string>(new[] { "Security.ViewRole" })
            };
            role1.Id = _repository.Add(role1);
            role2.Id = _repository.Add(role2);

            var list1 = new ReadOnlyCollection<Role>(new[] { role1, role2 });
            var list2 = _repository.FindAll();
            var comparison = new CompareObjects();
            Assert.IsTrue(comparison.Compare(list1, list2));
        }

        [Test]
        public void FindByIds_FindsRolesInDatabase()
        {
            var role1 = new Role
            {
                Name = "Visitor 1",
                Permissions = new ReadOnlyCollection<string>(new[] { "Security.ViewRole", "Security.ViewUser" })
            };
            var role2 = new Role
            {
                Name = "Visitor 2",
                Permissions = new ReadOnlyCollection<string>(new[] { "Security.ViewRole" })
            };
            var role3 = new Role
            {
                Name = "Visitor 3",
                Permissions = new ReadOnlyCollection<string>(new[] { "Security.ViewUser" })
            };
            role1.Id = _repository.Add(role1);
            role2.Id = _repository.Add(role2);
            role3.Id = _repository.Add(role3);

            var list1 = new ReadOnlyCollection<Role>(new[] { role1, role2 });
            var list2 = _repository.FindByIds(new[] { role1.Id, role2.Id });
            var comparison = new CompareObjects();
            Assert.IsTrue(comparison.Compare(list1, list2));
        }

        [Test]
        public void Update_UpdatesRoleInDatabase()
        {
            var role = new Role
            {
                Name = "Role Administrator",
                Permissions = new ReadOnlyCollection<string>(new[] { "Security.ViewRole", "Security.AddRole", "Security.EditRole" })
            };
            role.Id = _repository.Add(role);

            role.Name = "Test Role Name";
            role.Permissions = new ReadOnlyCollection<string>(new[] { "Security.ViewRole" });
            _repository.Update(role);

            var roleCopy = _repository.FindById(role.Id);

            var comparison = new CompareObjects();
            Assert.IsTrue(comparison.Compare(role, roleCopy));
        }

        [Test]
        public void Remove_MarksRoleAsDeleted()
        {
            var role = new Role
            {
                Name = "Visitor",
                Permissions = new ReadOnlyCollection<string>(new[] { "Security.ViewRole" })
            };
            role.Id = _repository.Add(role);

            _repository.Remove(role.Id);
            var roleCopy = _repository.FindById(role.Id);
            role.Deleted = true;
            var comparison = new CompareObjects();
            Assert.IsTrue(comparison.Compare(role, roleCopy));
        }

        private void CleanUp()
        {
            using (var connection = GetConnection())
            {
                connection.Execute(@"delete UserRole");
                connection.Execute(@"delete RolePermission");
                connection.Execute(@"delete Roles");
            }
        }
    }
}
// ReSharper restore InconsistentNaming
