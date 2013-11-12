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
using Dapper;
using OpenCBS.Interface.Repository;
using OpenCBS.Model;

namespace OpenCBS.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionProvider _connectionProvider;

        public UserRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public User FindByUsernameAndPassword(string username, string password)
        {
            const string sql = @"
                    select * from [User] u left join Role r on r.Id = u.RoleId 
                    where u.Username = @Username and u.Password = @password

                    select Permission from RolePermission rp right join [User] u on rp.RoleId = u.RoleId
                    where u.Username = @Username and u.Password = @password                    
                ";
            using (var connection = _connectionProvider.GetConnection())
            using (var multi = connection.QueryMultiple(sql, new { Username = username, Password = password }))
            {
                var result = multi.Read<User, Role, User>((user, role) =>
                {
                    user.Role = role;
                    return user;
                }).SingleOrDefault();
                if (result == null) return null;
                result.Role.Permissions = multi.Read<string>().ToList().AsReadOnly();
                return result;
            }
        }

        public IList<User> FindAll()
        {
            const string sql = @"select * from [User] u left join Role r on r.id = u.RoleId";
            using (var connection = _connectionProvider.GetConnection())
            {
                return connection.Query<User, Role, User>(sql, (user, role) =>
                {
                    user.Role = role;
                    return user;
                }).ToList().AsReadOnly();
            }
        }

        public User FindById(int id)
        {
            const string sql = @"
                select * from [User] u left join Role r on r.id = u.RoleId where u.Id = @Id
                select Permission from RolePermission rp right join [User] u on rp.RoleId = u.RoleId where u.Id = @Id
            ";
            using (var connection = _connectionProvider.GetConnection())
            using (var multi = connection.QueryMultiple(sql, new { Id = id }))
            {
                var result = multi.Read<User, Role, User>((user, role) =>
                {
                    user.Role = role;
                    return user;
                }).SingleOrDefault();
                if (result == null) return null;
                result.Role.Permissions = multi.Read<string>().ToList().AsReadOnly();
                return result;
            }
        }

        public void Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public int Add(User entity)
        {
            throw new System.NotImplementedException();
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
