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
using OpenCBS.Interface.Validator;
using OpenCBS.Service.Shell;
using OpenCBS.Service.Validator;
using StructureMap;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.IoCContainer
{
    [TestFixture]
    public class ValidatorResolutionTest
    {
        private IContainer _container;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _container = new Container(new DefaultRegistry());
        }

        [Test]
        public void GetInstance_EntryFeeValidator_Resolves()
        {
            var validator = _container.GetInstance<IEntryFeeValidator>();
            Assert.IsInstanceOf<EntryFeeValidator>(validator);
        }

        [Test]
        public void GetInstance_LoanProductValidator_Resolves()
        {
            var validator = _container.GetInstance<ILoanProductValidator>();
            Assert.IsInstanceOf<LoanProductValidator>(validator);
        }

        [Test]
        public void GetInstance_RoleValidator_Resolves()
        {
            var validator = _container.GetInstance<IRoleValidator>();
            Assert.IsInstanceOf<RoleValidator>(validator);
        }

        [Test]
        public void GetInstance_UserValidator_Resolves()
        {
            var validator = _container.GetInstance<IUserValidator>();
            Assert.IsInstanceOf<UserValidator>(validator);
        }

        [Test]
        public void GetInstance_ChangePasswordValidator_Resolves()
        {
            var validator = _container.GetInstance<IPasswordValidator>();
            Assert.IsInstanceOf<PasswordValidator>(validator);
        }
    }
}
// ReSharper restore InconsistentNaming
