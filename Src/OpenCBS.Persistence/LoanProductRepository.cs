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
using Omu.ValueInjecter;
using OpenCBS.Common.Injection;
using OpenCBS.Interface.Repository;
using OpenCBS.Model;

namespace OpenCBS.Persistence
{
    public class LoanProductRepository : ILoanProductRepository
    {
        private readonly IConnectionProvider _connectionProvider;

        // ReSharper disable UnusedMember.Local
        // ReSharper disable ClassNeverInstantiated.Local
        // ReSharper disable UnusedAutoPropertyAccessor.Local
        private class LoanProductEntryFee
        {
            public int LoanProductId { get; set; }
            public int EntryFeeId { get; set; }
        }

        private class LoanProductRow
        {
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
            public bool ChargeInterestDuringGracePeriod { get; set; }
            public decimal LateFeeAmountRateMin { get; set; }
            public decimal LateFeeAmountRateMax { get; set; }
            public decimal LateFeeOlbRateMin { get; set; }
            public decimal LateFeeOlbRateMax { get; set; }
            public decimal LateFeeLatePrincipalRateMin { get; set; }
            public decimal LateFeeLatePrincipalRateMax { get; set; }
            public decimal LateFeeLateInterestRateMin { get; set; }
            public decimal LateFeeLateInterestRateMax { get; set; }
            public int LateFeeGracePeriod { get; set; }
        }
        // ReSharper restore UnusedAutoPropertyAccessor.Local
        // ReSharper restore ClassNeverInstantiated.Local
        // ReSharper restore UnusedMember.Local

        public LoanProductRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public IList<LoanProduct> FindAll()
        {
            const string sql = @"
                select * from LoanProduct p left join Currency c on c.id = p.CurrencyId
                select * from EntryFee
                select * from LoanProductEntryFee
            ";
            using (var connection = _connectionProvider.GetConnection())
            using (var multi = connection.QueryMultiple(sql))
            {
                var loanProducts = multi.Read<LoanProduct, Currency, LoanProduct>((loanProduct, currency) =>
                {
                    loanProduct.Currency = currency;
                    return loanProduct;
                }).ToList();
                var entryFees = multi.Read<EntryFee>().ToList();
                var map = multi.Read<LoanProductEntryFee>().ToList();
                foreach (var lp in loanProducts)
                {
                    lp.EntryFees = new List<EntryFee>();
                    foreach (var ef in entryFees)
                    {
                        if (map.Count(e => e.LoanProductId == lp.Id && e.EntryFeeId == ef.Id) <= 0) continue;

                        var entryFee = new EntryFee();
                        entryFee.InjectFrom(ef);
                        lp.EntryFees.Add(entryFee);
                    }
                }
                return loanProducts.AsReadOnly();
            }
        }

        public LoanProduct FindById(int id)
        {
            const string sql = @"
                select * from LoanProduct p left join Currency c on c.id = p.CurrencyId where p.id = @Id
                select * from EntryFee where id in (select EntryFeeId from LoanProductEntryFee where LoanProductId = @Id)
            ";
            using (var connection = _connectionProvider.GetConnection())
            using (var multi = connection.QueryMultiple(sql, new { Id = id }))
            {
                var result = multi.Read<LoanProduct, Currency, LoanProduct>((loanProduct, currency) =>
                {
                    loanProduct.Currency = currency;
                    return loanProduct;
                }).FirstOrDefault();
                if (result == null) return null;
                result.EntryFees = multi.Read<EntryFee>().ToList();
                return result;
            }
        }

        public void Update(LoanProduct entity)
        {
            var row = new LoanProductRow();
            row.InjectFrom<FlatLoopValueInjection>(entity).InjectFrom<EnumToIntInjection>(entity);
            using (var connection = _connectionProvider.GetConnection())
            {
                connection.Execute("delete from LoanProductEntryFee where LoanProductId = @Id", new { entity.Id });
                var map = entity.EntryFees
                                .Select(ef => new LoanProductEntryFee { LoanProductId = entity.Id, EntryFeeId = ef.Id })
                                .ToList();
                connection.Execute("insert LoanProductEntryFee values (@LoanProductId, @EntryFeeId)", map);
                connection.Update(row);
            }
        }

        public int Add(LoanProduct entity)
        {
            var row = new LoanProductRow();
            row.InjectFrom<FlatLoopValueInjection>(entity).InjectFrom<EnumToIntInjection>(entity);
            using (var connection = _connectionProvider.GetConnection())
            {
                var id = connection.Insert(row);
                var map = entity.EntryFees
                                .Select(ef => new LoanProductEntryFee { LoanProductId = id, EntryFeeId = ef.Id })
                                .ToList();
                connection.Execute("insert LoanProductEntryFee values (@LoanProductId, @EntryFeeId)", map);
                return id;
            }
        }

        public void Remove(int id)
        {
            using (var connection = _connectionProvider.GetConnection())
            {
                connection.Delete<LoanProduct>(id);
            }
        }
    }
}
