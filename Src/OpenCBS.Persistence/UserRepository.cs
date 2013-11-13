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
using Dapper;
using Omu.ValueInjecter;
using OpenCBS.Interface.Repository;
using OpenCBS.Model;

namespace OpenCBS.Persistence
{
    public class UserRepository : IUserRepository
    {
        // ReSharper disable UnusedMember.Local
        // ReSharper disable UnusedAutoPropertyAccessor.Local
        private class UserRow
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private class UserRole
        {
            public int UserId { get; set; }
            public int RoleId { get; set; }
        }
        // ReSharper restore UnusedAutoPropertyAccessor.Local
        // ReSharper restore UnusedMember.Local

        private readonly IConnectionProvider _connectionProvider;

        public UserRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public User FindByUsernameAndPassword(string username, string password)
        {
            const string sql = @"
                    select * from [User] where Username = @Username and Password = @Password

                    select r.* from Role r
                    inner join UserRole ur on ur.role_id = r.id
                    inner join [User] u on u.id = ur.user_id
                    where u.Username = @Username and u.Password = @Password

                    select rp.RoleId, rp.Permission from RolePermission rp
                    inner join UserRole ur on ur.role_id = rp.RoleId
                    inner join [User] u on u.id = ur.user_id
                    where u.Username = @Username and u.Password = @Password
                ";
            using (var connection = _connectionProvider.GetConnection())
            using (var multi = connection.QueryMultiple(sql, new { Username = username, Password = password }))
            {
                var user = multi.Read<User>().SingleOrDefault();
                if (user == null) return null;
                user.Roles = multi.Read<Role>().ToList();
                var permissions = multi.Read<int, string, Tuple<int, string>>(Tuple.Create, "*").ToList();
                foreach (var role in user.Roles)
                {
                    role.Permissions = permissions.Where(p => p.Item1 == role.Id).Select(p => p.Item2).ToList().AsReadOnly();
                }
                return user;
            }
        }

        public IList<User> FindAll()
        {
            const string sql = @"
                select * from [User]
                select user_id, role_id from UserRole
                select * from Role
            ";
            using (var connection = _connectionProvider.GetConnection())
            using (var multi = connection.QueryMultiple(sql))
            {
                var users = multi.Read<User>().ToList().AsReadOnly();
                var map = multi.Read<int, int, Tuple<int, int>>(Tuple.Create, "*").ToList();
                var roles = multi.Read<Role>().ToList().AsReadOnly();
                foreach (var user in users)
                {
                    var ids = map.Where(m => m.Item1 == user.Id).Select(m => m.Item2).ToList();
                    user.Roles = roles.Where(r => ids.Contains(r.Id)).ToList().AsReadOnly();
                }
                return users;
            }
        }

        public User FindById(int id)
        {
            const string sql = @"
                    select * from [User] where Id = @Id

                    select r.* from Role r
                    inner join UserRole ur on ur.role_id = r.id
                    inner join [User] u on u.id = ur.user_id
                    where u.Id = @Id

                    select rp.RoleId, rp.Permission from RolePermission rp
                    inner join UserRole ur on ur.role_id = rp.RoleId
                    inner join [User] u on u.id = ur.user_id
                    where u.Id = @Id
                ";
            using (var connection = _connectionProvider.GetConnection())
            using (var multi = connection.QueryMultiple(sql, new { Id = id }))
            {
                var user = multi.Read<User>().SingleOrDefault();
                if (user == null) return null;
                user.Roles = multi.Read<Role>().ToList();
                var permissions = multi.Read<int, string, Tuple<int, string>>(Tuple.Create, "*").ToList();
                foreach (var role in user.Roles)
                {
                    role.Permissions = permissions.Where(p => p.Item1 == role.Id).Select(p => p.Item2).ToList().AsReadOnly();
                }
                return user;
            }
        }

        public void Update(User entity)
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                var row = new UserRow();
                row.InjectFrom(entity);
                var exclude = new[] { "Password" };
                connection.Update(row, exclude);

                var sql = @"delete UserRole where user_id = @Id";
                connection.Execute(sql, new { entity.Id });
                var map = entity.Roles.Select(r => new UserRole { UserId = entity.Id, RoleId = r.Id });
                sql = @"insert UserRole (user_id, role_id) values (@UserId, @RoleId)";
                connection.Execute(sql, map);
            }
        }

        public int Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                connection.Delete<User>(id);
            }
        }
    }
}
