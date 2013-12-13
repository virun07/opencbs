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

using NUnit.Framework;
using OpenCBS.Interface.Service;
using OpenCBS.Service;
using OpenCBS.Service.Shell;
using StructureMap;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.IoCContainer
{
    [TestFixture]
    public class ServiceResolutionTest
    {
        private IContainer _container;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _container = new Container(new DefaultRegistry());
        }

        [Test]
        public void GetInstance_AuthService_Resolves()
        {
            var service = _container.GetInstance<IAuthService>();
            Assert.IsInstanceOf<AuthService>(service);
        }

        [Test]
        public void GetInstance_CurrencyService_Resolves()
        {
            var service = _container.GetInstance<ICurrencyService>();
            Assert.IsInstanceOf<CurrencyService>(service);
        }

        [Test]
        public void GetInstance_DatabaseService_Resolves()
        {
            var service = _container.GetInstance<IDatabaseService>();
            Assert.IsInstanceOf<DatabaseService>(service);
        }

        [Test]
        public void GetInstance_EntryFeeService_Resolves()
        {
            var service = _container.GetInstance<IEntryFeeService>();
            Assert.IsNotNull(service);
            Assert.AreEqual("IEntryFeeServiceProxy", service.GetType().Name);
        }

        [Test]
        public void GetInstance_LoanProductService_Resolves()
        {
            var service = _container.GetInstance<ILoanProductService>();
            Assert.IsNotNull(service);
            Assert.AreEqual("ILoanProductServiceProxy", service.GetType().Name);
        }

        [Test]
        public void GetInstance_RoleService_Resolves()
        {
            var service = _container.GetInstance<IRoleService>();
            Assert.IsNotNull(service);
            Assert.AreEqual("IRoleServiceProxy", service.GetType().Name);
        }

        [Test]
        public void GetInstance_UserService_Resolves()
        {
            var service = _container.GetInstance<IUserService>();
            Assert.IsNotNull(service);
            Assert.AreEqual("IUserServiceProxy", service.GetType().Name);
        }
    }
}
// ReSharper restore InconsistentNaming
