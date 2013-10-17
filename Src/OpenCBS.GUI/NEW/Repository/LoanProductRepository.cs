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
using OpenCBS.GUI.NEW.Dto;
using OpenCBS.GUI.NEW.Mapper;
using OpenCBS.GUI.NEW.Model;

namespace OpenCBS.GUI.NEW.Repository
{
    public class LoanProductRepository : Repository<LoanProduct>, ILoanProductRepository
    {
        private readonly ILoanProductMapper _mapper;

        public LoanProductRepository(IConnectionProvider connectionProvider, ILoanProductMapper mapper)
            : base(connectionProvider)
        {
            _mapper = mapper;
        }

        public override IEnumerable<LoanProduct> FindAll()
        {
            using (var connection = GetConnection())
            {
                var items = connection.GetList<LoanProductDto>();
                return items.Select(dto => _mapper.Map(dto));
            }
        }

        public override void Update(LoanProduct entity)
        {
            using (var connection = GetConnection())
            {
                var dto = _mapper.Map(entity);
                connection.Update(dto);
            }
        }
    }
}
