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
using OpenCBS.Interface.Repository;
using OpenCBS.Model.Schedule;

namespace OpenCBS.Persistence
{
    public class ExoticScheduleRepository : Repository, IExoticScheduleRepository
    {
        public ExoticScheduleRepository(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        {
        }
        public IList<ExoticSchedule> FindAll()
        {
            using (var connection = GetConnection())
            {
                const string sql = @"select id Id, name Name, Deleted from Exotics";
                return connection.Query<ExoticSchedule>(sql).ToList().AsReadOnly();
            }
        }

        public ExoticSchedule FindById(int id)
        {
            const string sql = @"
                    select id Id, name Name, Deleted from Exotics where id = @Id
                    select number Id, number Number, principal_coeff PrincipalPercentage, interest_coeff InterestPercentage
                    from ExoticInstallments
                    where exotic_id = @Id
                ";
            using (var connection = GetConnection())
            using (var multi = connection.QueryMultiple(sql, new { Id = id }))
            {
                var result = multi.Read<ExoticSchedule>().Single();
                result.Items = multi.Read<ExoticScheduleItem>().ToList().AsReadOnly();
                result.Items = result.Items.Select(x => new ExoticScheduleItem
                {
                    Id = x.Id,
                    Number = x.Number,
                    PrincipalPercentage = x.PrincipalPercentage * 100,
                    InterestPercentage = x.InterestPercentage * 100
                }).ToList().AsReadOnly();
                return result;
            }
        }

        public void Update(ExoticSchedule entity)
        {
            using (var connection = GetConnection())
            {
                var sql = @"update Exotics set name = @Name where id = @Id";
                connection.Execute(sql, new { entity.Name, entity.Id });
                sql = @"delete from ExoticInstallments where exotic_id = @Id";
                connection.Execute(sql, new { entity.Id });
                var items = entity.Items.Select(x => new
                {
                    x.Number,
                    PrincipalPercentage = x.PrincipalPercentage / 100,
                    InterestPercentage = x.InterestPercentage / 100,
                    ExoticScheduleId = entity.Id
                }).ToList().AsReadOnly();
                sql = @"
                    insert ExoticInstallments (number, principal_coeff, interest_coeff, exotic_id)
                    values (@Number, @PrincipalPercentage, @InterestPercentage, @ExoticScheduleId)
                ";
                connection.Execute(sql, items);
            }
        }

        public int Add(ExoticSchedule entity)
        {
            using (var connection = GetConnection())
            {
                var sql = @"insert Exotics (name) values (@Name) select cast(scope_identity() as int)";
                var id = connection.Query<int>(sql, new { entity.Name }).Single();
                var items = entity.Items.Select(x => new
                {
                    x.Number,
                    PrincipalPercentage = x.PrincipalPercentage / 100,
                    InterestPercentage = x.InterestPercentage / 100,
                    ExoticScheduleId = id
                }).ToList().AsReadOnly();
                sql = @"
                    insert ExoticInstallments (number, principal_coeff, interest_coeff, exotic_id)
                    values (@Number, @PrincipalPercentage, @InterestPercentage, @ExoticScheduleId)
                ";
                connection.Execute(sql, items);
                return id;
            }
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
