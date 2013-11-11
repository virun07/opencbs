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
            using (var connection = _connectionProvider.GetConnection())
            {
                const string sql = "select * from [User] where Username = @Username and Password = @password";
                return connection.Query<User>(sql, new { Username = username, Password = password }).FirstOrDefault();
            }
        }

        public IList<User> FindAll()
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                const string sql = "select * from [User]";
                return connection.Query<User>(sql).ToList().AsReadOnly();
            }
        }

        public User FindById(int id)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}
