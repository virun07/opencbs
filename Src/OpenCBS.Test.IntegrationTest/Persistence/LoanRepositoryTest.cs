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

using System.Linq;
using Dapper;
using NUnit.Framework;
using OpenCBS.Model.Loan;
using OpenCBS.Persistence;

// ReSharper disable InconsistentNaming
namespace OpenCBS.Test.IntegrationTest.Persistence
{
    [TestFixture]
    public class LoanRepositoryTest : BaseTest
    {
        private LoanRepository _repository;

        [TestFixtureSetUp]
        public override void TestFixtureSetUp()
        {
            base.TestFixtureSetUp();
            _repository = new LoanRepository(ConnectionStringProvider);
            CleanUp();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            CleanUp();
        }

        [Test]
        public void Add_AddsLoan()
        {
            var loan = new Loan { Code = "Test" };
            loan.Id = _repository.Add(loan);

            using (var connection = GetConnection())
            {
                const string sql = @"select count(*) from Loan where id = @Id";
                var count = connection.Query<int>(sql, new { loan.Id }).Single();
                Assert.AreEqual(1, count);
            }
        }

        private void CleanUp()
        {
            using (var connection = GetConnection())
            {
                connection.Execute(@"delete Loan");
            }
        }
    }
}
// ReSharper restore InconsistentNaming
