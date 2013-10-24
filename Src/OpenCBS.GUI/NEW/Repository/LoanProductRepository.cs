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
using DapperExtensions;
using OpenCBS.GUI.NEW.Model;
using OpenCBS.GUI.NEW.Repository.Mapper;

namespace OpenCBS.GUI.NEW.Repository
{
    public class LoanProductRepository : Repository<LoanProduct>, ILoanProductRepository
    {
        public LoanProductRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
        {
        }

        public override IEnumerable<LoanProduct> FindAll()
        {
            using (var connection = GetConnection())
            {
                var rows = connection.GetList<LoanProductRow>();
                var mapper = new LoanProductMapper();
                return rows.Select(mapper.Map);
            }
        }

        public override IEnumerable<LoanProduct> FindNonDeleted()
        {
            using (var connection = GetConnection())
            {
                var predicate = Predicates.Field<LoanProductRow>(t => t.Deleted, Operator.Eq, false);
                var rows = connection.GetList<LoanProductRow>(predicate);
                var mapper = new LoanProductMapper();
                return rows.Select(mapper.Map);
            }
        }
    }
}
