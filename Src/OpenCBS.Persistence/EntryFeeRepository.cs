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
    public class EntryFeeRepository : Repository, IEntryFeeRepository
    {
        public EntryFeeRepository(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        {
        }

        public IList<EntryFee> FindAll()
        {
            using (var connection = GetConnection())
            {
                const string sql = "select * from EntryFee";
                return connection.Query<EntryFee>(sql).ToList().AsReadOnly();
            }
        }

        public EntryFee FindById(int id)
        {
            using (var connection = GetConnection())
            {
                const string sql = "select * from EntryFee where Id = @Id";
                return connection.Query<EntryFee>(sql, new { Id = id }).FirstOrDefault();
            }
        }

        public IList<EntryFee> FindByIds(int[] ids)
        {
            using (var connection = GetConnection())
            {
                const string sql = "select * from EntryFee where Id in @Ids";
                return connection.Query<EntryFee>(sql, new { Ids = ids }).ToList();
            }
        }

        public void Update(EntryFee entity)
        {
            using (var connection = GetConnection())
            {
                connection.Update(entity);
            }
        }

        public int Add(EntryFee entity)
        {
            using (var connection = GetConnection())
            {
                return connection.Insert(entity);
            }
        }

        public void Remove(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Delete<EntryFee>(id);
            }
        }
    }
}
