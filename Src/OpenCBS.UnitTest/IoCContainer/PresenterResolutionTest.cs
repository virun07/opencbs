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
using NSubstitute;
using NUnit.Framework;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.View;
using OpenCBS.Presenter;
using OpenCBS.Service.Shell;
using StructureMap;

namespace OpenCBS.UnitTest.IoCContainer
{
    [TestFixture]
    public class PresenterResolutionTest
    {
        private IContainer _container;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _container = new Container(new DefaultRegistry());
            _container.Inject(Substitute.For<IEntryFeeView>());
            _container.Inject(Substitute.For<IEntryFeesView>());
            _container.Inject(Substitute.For<ILoanProductView>());
            _container.Inject(Substitute.For<ILoanProductsView>());
            _container.Inject(Substitute.For<ILoginView>());
            _container.Inject(Substitute.For<IMainView>());
            _container.Inject(Substitute.For<IRoleView>());
            _container.Inject(Substitute.For<IRolesView>());
            _container.Inject(Substitute.For<ISelectEntryFeeView>());
            _container.Inject(Substitute.For<IUserView>());
            _container.Inject(Substitute.For<IUsersView>());
        }
        
        [Test]
        public void GetInstance_ErrorPresenter_Resolves()
        {
            var presenter = _container.GetInstance<IErrorPresenter>();
            Assert.IsInstanceOf<ErrorPresenter>(presenter);
        }

        [Test]
        public void GetInstance_ConfirmationPresenter_Resolves()
        {
            var presenter = _container.GetInstance<IConfirmationPresenter>();
            Assert.IsInstanceOf<ConfirmationPresenter>(presenter);
        }

        [Test]
        public void GetInstance_EntryFeePresenter_Resolves()
        {
            var presenter = _container.GetInstance<IEntryFeePresenter>();
            Assert.IsInstanceOf<EntryFeePresenter>(presenter);
        }

        [Test]
        public void GetInstance_EntryFeesPresenter_Resolves()
        {
            var presenter = _container.GetInstance<IEntryFeesPresenter>();
            Assert.IsInstanceOf<EntryFeesPresenter>(presenter);
        }

        [Test]
        public void GetInstance_LoanProductPresenter_Resolves()
        {
            var presenter = _container.GetInstance<ILoanProductPresenter>();
            Assert.IsInstanceOf<LoanProductPresenter>(presenter);
        }

        [Test]
        public void GetInstance_LoanProductsPresenter_Resolves()
        {
            var presenter = _container.GetInstance<ILoanProductsPresenter>();
            Assert.IsInstanceOf<LoanProductsPresenter>(presenter);
        }

        [Test]
        public void GetInstance_LoginPresenter_Resolves()
        {
            var presenter = _container.GetInstance<ILoginPresenter>();
            Assert.IsInstanceOf<LoginPresenter>(presenter);
        }

        [Test]
        public void GetInstance_MainPresenter_Resolves()
        {
            var presenter = _container.GetInstance<IMainPresenter>();
            Assert.IsInstanceOf<MainPresenter>(presenter);
        }

        [Test]
        public void GetInstance_RolePresenter_Resolves()
        {
            var presenter = _container.GetInstance<IRolePresenter>();
            Assert.IsInstanceOf<RolePresenter>(presenter);
        }

        [Test]
        public void GetInstance_RolesPresenter_Resolves()
        {
            var presenter = _container.GetInstance<IRolesPresenter>();
            Assert.IsInstanceOf<RolesPresenter>(presenter);
        }

        [Test]
        public void GetInstance_SelectEntryFeePresenter_Resolves()
        {
            var presenter = _container.GetInstance<ISelectEntryFeePresenter>();
            Assert.IsInstanceOf<SelectEntryFeePresenter>(presenter);
        }

        [Test]
        public void GetInstance_UserPresenter_Resolves()
        {
            var presenter = _container.GetInstance<IUserPresenter>();
            Assert.IsInstanceOf<UserPresenter>(presenter);
        }

        [Test]
        public void GetInstance_UsersPresenter_Resolves()
        {
            var presenter = _container.GetInstance<IUsersPresenter>();
            Assert.IsInstanceOf<UsersPresenter>(presenter);
        }

        [Test]
        public void GetInstance_ChangePasswordPresenter_Resolves()
        {
            var presenter = _container.GetInstance<IChangePasswordPresenter>();
            Assert.IsInstanceOf<ChangePasswordPresenter>(presenter);
        }
    }
}
// ReSharper restore InconsistentNaming
