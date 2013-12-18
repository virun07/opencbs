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
using OpenCBS.Model.Loan;

namespace OpenCBS.Persistence
{
    public class LoanRepository : Repository, ILoanRepository
    {
        public LoanRepository(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        { }

        public IList<Loan> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Loan FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Loan entity)
        {
            throw new System.NotImplementedException();
        }

        public int Add(Loan entity)
        {
            using (var connection = GetConnection())
            {
                var sql = @"insert Loan (Code) values (@Code) select cast(scope_identity() as int)";
                var id = connection.Query<int>(sql, new { Code = entity.Code }).Single();
                return id;
            }
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
