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
using OpenCBS.GUI.NEW.Injection;
using OpenCBS.GUI.NEW.Model;

namespace OpenCBS.GUI.NEW.Repository
{
    public class LoanProductRepository : Repository, ILoanProductRepository
    {
        private readonly IConnectionProvider _connectionProvider;

        private class LoanProductRow
        {
            // ReSharper disable UnusedMember.Local
            // Filled in dynamically by ValueInjecter
            public int Id { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public int AvailableFor { get; set; }
            public string PaymentFrequencyPolicy { get; set; }
            public string SchedulePolicy { get; set; }
            public string YearPolicy { get; set; }
            public string DateShiftPolicy { get; set; }
            public string RoundingPolicy { get; set; }
            public decimal AmountMin { get; set; }
            public decimal AmountMax { get; set; }
            public decimal InterestRateMin { get; set; }
            public decimal InterestRateMax { get; set; }
            public int MaturityMin { get; set; }
            public int MaturityMax { get; set; }
            public int GracePeriodMin { get; set; }
            public int GracePeriodMax { get; set; }
            public int CurrencyId { get; set; }
            // ReSharper restore UnusedMember.Local
        }

        public LoanProductRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public IList<LoanProduct> FindAll()
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                const string sql = @"select *
                from LoanProduct p
                left join Currency c on c.id = p.CurrencyId";
                return connection.Query<LoanProduct, Currency, LoanProduct>(sql, (loanProduct, currency) =>
                {
                    loanProduct.Currency = currency;
                    return loanProduct;
                }).ToList();
            }
        }

        public LoanProduct FindById(int id)
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                const string sql = @"select *
                from LoanProduct p
                left join Currency c on c.id = p.CurrencyId
                where p.id = @Id";
                return connection.Query<LoanProduct, Currency, LoanProduct>(sql, (loanProduct, currency) =>
                {
                    loanProduct.Currency = currency;
                    return loanProduct;
                }, new { Id = id }).FirstOrDefault();
            }
        }

        public void Update(LoanProduct entity)
        {
            var row = new LoanProductRow();
            row.InjectFrom<FlatLoopValueInjection>(entity).InjectFrom<EnumToIntInjection>(entity);
            using (var connection = _connectionProvider.GetConnection())
            {
                Update(connection, "LoanProduct", row);
            }
        }

        public void Add(LoanProduct entity)
        {
            var row = new LoanProductRow();
            row.InjectFrom<FlatLoopValueInjection>(entity).InjectFrom<EnumToIntInjection>(entity);
            using (var connection = _connectionProvider.GetConnection())
            {
                entity.Id = Insert(connection, "LoanProduct", row);
            }
        }

        public void Remove(int id)
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                Delete(connection, "LoanProduct", id);
            }
        }

    }
}
