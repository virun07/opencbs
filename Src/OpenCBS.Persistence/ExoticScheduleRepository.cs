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
            throw new NotImplementedException();
        }

        public void Update(ExoticSchedule entity)
        {
            throw new NotImplementedException();
        }

        public int Add(ExoticSchedule entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
