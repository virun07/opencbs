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
    public class RoleRepository : Repository, IRoleRepository
    {
        // ReSharper disable ClassNeverInstantiated.Local
        // ReSharper disable UnusedAutoPropertyAccessor.Local
        private class RolePermission
        {
            public int RoleId { get; set; }
            public string Permission { get; set; }
        }
        // ReSharper restore UnusedAutoPropertyAccessor.Local
        // ReSharper restore ClassNeverInstantiated.Local

        public RoleRepository(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        {
        }

        public IList<Role> FindAll()
        {
            const string sql = @"
                select id Id, code Name, deleted Deleted from Roles
                select RoleId, Permission from RolePermission
            ";
            using (var connection = GetConnection())
            using (var multi = connection.QueryMultiple(sql))
            {
                var roles = multi.Read<Role>().ToList();
                var map = multi.Read<RolePermission>().ToList();
                foreach (var role in roles)
                {
                    role.Permissions = map.Where(x => x.RoleId == role.Id).Select(x => x.Permission).ToList().AsReadOnly();
                }
                return roles.AsReadOnly();
            }
        }

        public IList<Role> FindByIds(IList<int> ids)
        {
            const string sql = @"
                select id Id, code Name, deleted Deleted from Roles where id in @Ids
                select RoleId, Permission from RolePermission where RoleId in @Ids
            ";
            using (var connection = GetConnection())
            using (var multi = connection.QueryMultiple(sql, new { Ids = ids }))
            {
                var roles = multi.Read<Role>().ToList();
                var map = multi.Read<RolePermission>().ToList();
                foreach (var role in roles)
                {
                    role.Permissions = map.Where(x => x.RoleId == role.Id).Select(x => x.Permission).ToList().AsReadOnly();
                }
                return roles.AsReadOnly();
            }
        }

        public Role FindById(int id)
        {
            using (var connection = GetConnection())
            {
                var sql = @"select id Id, code Name, deleted Deleted from Roles where id = @Id";
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
            using (var connection = GetConnection())
            {
                var sql = @"update Roles set code = @Name where id = @Id";
                connection.Execute(sql, entity);

                sql = @"delete from RolePermission where RoleId = @Id";
                connection.Execute(sql, new { entity.Id });
                var map = entity
                    .Permissions
                    .Select(p => new { RoleId = entity.Id, Permission = p })
                    .ToList();
                sql = @"insert RolePermission values (@RoleId, @Permission)";
                connection.Execute(sql, map);
            }
        }

        public int Add(Role entity)
        {
            using (var connection = GetConnection())
            {
                var sql = @"insert Roles (code) values (@Name) select cast(scope_identity() as int)";
                var id = connection.Query<int>(sql, entity).Single();

                sql = @"insert RolePermission values (@RoleId, @Permission)";
                var map = entity.Permissions.Select(p => new { RoleId = id, Permission = p });
                connection.Execute(sql, map);
                return id;
            }
        }

        public void Remove(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Execute(@"update Roles set deleted = 1 where id = @id", new { Id = id });
            }
        }
    }
}
