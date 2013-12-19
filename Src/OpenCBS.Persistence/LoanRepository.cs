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
using OpenCBS.Model.Loan;

namespace OpenCBS.Persistence
{
    public class LoanRepository : Repository, ILoanRepository
    {
        private class LoanEventRow
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public decimal Amount { get; set; }
            public int TransactionId { get; set; }
            public string Extra { get; set; }
        }

        public LoanRepository(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        { }

        public IList<Loan> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Loan FindById(int id)
        {
            const string sql = @"select * from Loan where Id = @LoanId
                select * from [Transaction] where LoanId = @LoanId
                select * from LoanEvent where TransactionId in (select Id from [Transaction] where LoanId = @LoanId)";
            using (var connection = GetConnection())
            {
                using (var multi = connection.QueryMultiple(sql, new { LoanId = id }))
                {
                    var result = multi.Read<Loan>().FirstOrDefault();
                    if (result == null) return null;
                    result.Transactions = multi.Read<Transaction>().ToList();
                    var loanEventRows = multi.Read<LoanEventRow>().ToList();
                    foreach (var loanEvent in loanEventRows)
                    {
                        result.Transactions[loanEvent.TransactionId].LoanEvents.Add(new LoanDisbursementEvent
                        {
                            Code = loanEvent.Code,
                            Amount = loanEvent.Amount,
                            Id = loanEvent.Id
                        });
                    }
                    return result;
                }
            }
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
                var loanId = connection.Query<int>(sql, new { entity.Code }).Single();

                foreach (var transaction in entity.Transactions)
                {
                    sql = @"
                        insert [Transaction] (Code, Date, UserId, LoanId, Comment) 
                        values (@Code, @Date, @UserId, @LoanId, @Comment) select cast(scope_identity() as int)
                    ";
                    transaction.Id = connection.Query<int>(sql, new
                    {
                        transaction.Code,
                        transaction.Date,
                        UserId = User.Current.Id,
                        LoanId = loanId,
                        transaction.Comment
                    }).Single();

                    foreach (var loanEvent in transaction.LoanEvents)
                    {
                        sql = @"
                            insert LoanEvent (Code, Amount, TransactionId, Extra)
                            values (@Code, @Amount, @TransactionId, @Extra) select cast(scope_identity() as int)
                        ";
                        loanEvent.Id = connection.Query<int>(sql, new
                        {
                            loanEvent.Code,
                            loanEvent.Amount,
                            TransactionId = transaction.Id,
                            Extra = loanEvent.Serialize()
                        }).Single();
                    }
                }

                return loanId;
            }
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
