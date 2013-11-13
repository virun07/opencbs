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
using Omu.ValueInjecter;
using OpenCBS.Interface.Repository;
using OpenCBS.Model;

namespace OpenCBS.Persistence
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IConnectionProvider _connectionProvider;

        // ReSharper disable UnusedMember.Local
        // ReSharper disable UnusedAutoPropertyAccessor.Local
        private class RolePermission
        {
            public int RoleId { get; set; }
            public string Permission { get; set; }
        }

        private class RoleRow
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        // ReSharper restore UnusedAutoPropertyAccessor.Local
        // ReSharper restore UnusedMember.Local

        public RoleRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public IList<Role> FindAll()
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                const string sql = @"select * from Role";
                return connection.Query<Role>(sql).ToList().AsReadOnly();
            }
        }

        public IList<Role> FindByIds(IList<int> ids)
        {
            const string sql = @"select * from Role where Id in @Ids";
            using (var connection = _connectionProvider.GetConnection())
            {
                return connection.Query<Role>(sql, new { Ids = ids }).ToList().AsReadOnly();
            }
        }

        public Role FindById(int id)
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                var sql = @"select * from Role where Id = @Id";
                var result = connection.Query<Role>(sql, new { Id = id }).FirstOrDefault();
                if (result != null)
                {
                    sql = @"select Permission from RolePermission where RoleId = @Id";
                    result.Permissions = connection.Query<string>(sql, new { Id = id }).ToList().AsReadOnly();
                }
                return result;
            }
        }

        public void Update(Role entity)
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                var row = new RoleRow();
                row.InjectFrom(entity);
                connection.Update(row);

                var sql = @"delete from RolePermission where RoleId = @Id";
                connection.Execute(sql, new { entity.Id });
                var map = entity
                    .Permissions
                    .Select(p => new RolePermission { RoleId = entity.Id, Permission = p })
                    .ToList();
                sql = @"insert RolePermission values (@RoleId, @Permission)";
                connection.Execute(sql, map);
            }
        }

        public int Add(Role entity)
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                var row = new RoleRow();
                row.InjectFrom(entity);
                var id = connection.Insert(row);

                const string sql = @"insert RolePermission values (@RoleId, @Permission)";
                var map = entity
                    .Permissions
                    .Select(p => new RolePermission { RoleId = id, Permission = p });
                connection.Execute(sql, map);
                return id;
            }
        }

        public void Remove(int id)
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                connection.Delete<Role>(id);
            }
        }
    }
}
