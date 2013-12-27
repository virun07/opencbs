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
using Dapper;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;
using OpenCBS.Model;
using OpenCBS.Persistence;

// ReSharper disable InconsistentNaming
namespace OpenCBS.Test.IntegrationTest.Persistence
{
    public class UserRepositoryTest : BaseTest
    {
        private Role _role;
        private UserRepository _repository;

        [TestFixtureSetUp]
        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();
            _repository = new UserRepository(ConnectionStringProvider);
            CleanUp();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            CleanUp();
        }

        [SetUp]
        public void SetUp()
        {
            CleanUp();
            _role = new Role
            {
                Name = "Visitor",
                Permissions = new ReadOnlyCollection<string>(new[] { "Security.ViewUser" })
            };
            var repository = new RoleRepository(ConnectionStringProvider);
            _role.Id = repository.Add(_role);
        }

        [Test]
        public void Add_AddsUserToDatabase()
        {
            var user = AddUser();

            using (var connection = GetConnection())
            {
                var sql = @"select count(*) from UserRole where user_id = @Id";
                var count = connection.Query<int>(sql, new { user.Id }).Single();
                Assert.AreEqual(1, count);

                sql = @"select count(*) from Users where id = @Id";
                count = connection.Query<int>(sql, new { user.Id }).Single();
                Assert.AreEqual(1, count);
            }
        }

        [Test]
        public void FindById_FindsUserInDatabase()
        {
            var user = AddUser();

            user.Password = null;
            var userCopy = _repository.FindById(user.Id);
            var comparison = new CompareObjects();
            Assert.IsTrue(comparison.Compare(user, userCopy));
        }

        [Test]
        public void UserExists_ExistsInDatabase_ReturnsTrue()
        {
            var user = AddUser();
            Assert.IsTrue(_repository.UserExists(user.Id, user.Password));
        }

        [Test]
        public void UserExists_DoesNotExistInDatabase_ReturnsFalse()
        {
            var user = AddUser();
            Assert.IsFalse(_repository.UserExists(user.Id, "blah"));
        }

        [Test]
        public void ChangePassword_ChangesPasswordInDatabase()
        {
            var user = AddUser();
            _repository.ChangePassword(user.Id, "newpass");
            Assert.IsTrue(_repository.UserExists(user.Id, "newpass"));
        }

        [Test]
        public void FindByUsernameAndPassword_FindsUserInDatabase()
        {
            var user = AddUser();
            var userCopy = _repository.FindByUsernameAndPassword(user.Username, user.Password);
            user.Password = null;
            var comparison = new CompareObjects();
            Assert.IsTrue(comparison.Compare(user, userCopy));
        }

        [Test]
        public void FindAll_FindsAllUsersInDatabase()
        {
            var user1 = AddUser();
            var user2 = new User
            {
                FirstName = "Bill",
                LastName = "Hicks",
                Username = "bill",
                Password = "billyboy",
                Email = "bill@hicks.com",
                Roles = new ReadOnlyCollection<Role>(new[] { _role })
            };
            user2.Id = _repository.Add(user2);
            user1.Password = null;
            user2.Password = null;
            var list1 = new ReadOnlyCollection<User>(new[] { user1, user2 });

            var list2 = _repository.FindAll();
            var comparison = new CompareObjects();
            Assert.IsTrue(comparison.Compare(list1, list2));
        }

        [Test]
        public void Update_UpdatesUserInDatabase()
        {
            var repository = new RoleRepository(ConnectionStringProvider);
            var newRole = new Role
            {
                Name = "Administrator",
                Permissions = new ReadOnlyCollection<string>(new[] { "Security.ViewUser", "Security.AddUser" })
            };
            newRole.Id = repository.Add(newRole);

            var user = AddUser();
            user.FirstName = "Bill";
            user.LastName = "Hicks";
            user.Username = "bill";
            user.Password = "billyboy";
            user.Email = "bill@hicks.com";
            user.Roles = new ReadOnlyCollection<Role>(new[] { _role, newRole });
            _repository.Update(user);

            var userCopy = _repository.FindById(user.Id);
            user.Password = null;
            var comparison = new CompareObjects();
            Assert.IsTrue(comparison.Compare(user, userCopy));
        }

        [Test]
        public void Remove_MarksUserAsDeletedInDatabase()
        {
            var user = AddUser();
            _repository.Remove(user.Id);

            var userCopy = _repository.FindById(user.Id);
            user.Password = null;
            user.Deleted = true;
            var comparison = new CompareObjects();
            Assert.IsTrue(comparison.Compare(user, userCopy));
        }

        private User AddUser()
        {
            var user = new User
            {
                FirstName = "George",
                LastName = "Carlin",
                Username = "george",
                Password = "gorgeousgeorge",
                Email = "george@carlin.com",
                IsSuperuser = false,
                Roles = new ReadOnlyCollection<Role>(new[] { _role })
            };
            user.Id = _repository.Add(user);
            return user;
        }

        private void CleanUp()
        {
            using (var connection = GetConnection())
            {
                connection.Execute(@"delete UserRole");
                connection.Execute(@"delete Users");
                connection.Execute(@"delete RolePermission");
                connection.Execute(@"delete Roles");
            }
        }
    }
}
// ReSharper restore InconsistentNaming
