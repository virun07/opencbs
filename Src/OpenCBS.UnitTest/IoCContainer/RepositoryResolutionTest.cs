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

// ReSharper disable InconsistentNaming
using NUnit.Framework;
using OpenCBS.Interface.Repository;
using OpenCBS.Persistence;
using OpenCBS.Service.Shell;
using StructureMap;

namespace OpenCBS.UnitTest.IoCContainer
{
    [TestFixture]
    public class RepositoryResolutionTest
    {
        private IContainer _container;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _container = new Container(new DefaultRegistry());
        }

        [Test]
        public void GetInstance_ConnectionStringProvider_Resolves()
        {
            var provider = _container.GetInstance<IConnectionStringProvider>();
            Assert.IsInstanceOf<ConnectionStringProvider>(provider);
        }

        [Test]
        public void GetInstance_CurrencyRepository_Resolves()
        {
            var repository = _container.GetInstance<ICurrencyRepository>();
            Assert.IsInstanceOf<CurrencyRepository>(repository);
        }

        [Test]
        public void GetInstance_DatabaseRepository_Resolves()
        {
            var repository = _container.GetInstance<IDatabaseRepository>();
            Assert.IsInstanceOf<DatabaseRepository>(repository);
        }

        [Test]
        public void GetInstance_EntryFeeRepository_Resolves()
        {
            var repository = _container.GetInstance<IEntryFeeRepository>();
            Assert.IsInstanceOf<EntryFeeRepository>(repository);
        }

        [Test]
        public void GetInstance_LoanProductRepository_Resolves()
        {
            var repository = _container.GetInstance<ILoanProductRepository>();
            Assert.IsInstanceOf<LoanProductRepository>(repository);
        }

        [Test]
        public void GetInstance_RoleRepository_Resolves()
        {
            var repository = _container.GetInstance<IRoleRepository>();
            Assert.IsInstanceOf<RoleRepository>(repository);
        }

        [Test]
        public void GetInstance_UserRepository_Resolves()
        {
            var repository = _container.GetInstance<IUserRepository>();
            Assert.IsInstanceOf<UserRepository>(repository);
        }

        [Test]
        public void GetInstance_ExoticScheduleRepository_Resolves()
        {
            var repository = _container.GetInstance<IExoticScheduleRepository>();
            Assert.IsInstanceOf<ExoticScheduleRepository>(repository);
        }
    }
}
// ReSharper restore InconsistentNaming
