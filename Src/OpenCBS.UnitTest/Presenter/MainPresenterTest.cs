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

using NSubstitute;
using NUnit.Framework;
using OpenCBS.DataContract.CommandData;
using OpenCBS.Interface;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;
using OpenCBS.Presenter;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Presenter
{
    [TestFixture]
    public class MainPresenterTest
    {
        private IMainView _mainView;
        private IApplicationController _appController;
        private IAuthService _authService;
        private MainPresenter _presenter;

        [SetUp]
        public void Setup()
        {
            _mainView = Substitute.For<IMainView>();
            _appController = Substitute.For<IApplicationController>();
            _authService = Substitute.For<IAuthService>();
            _presenter = new MainPresenter(_mainView, _appController, _authService);
        }

        [Test]
        public void Run_CallsAttachAndRunOnView()
        {
            _presenter.Run();
            _mainView.Received().Attach(_presenter);
            _mainView.Received().Run();
        }

        [Test]
        public void Run_ChecksRolePermissions()
        {
            _presenter.Run();
            _authService.Received().Can("Role.View");
            _authService.Received().Can("Role.Add");
            _authService.Received().Can("Role.Edit");
            _authService.Received().Can("Role.Delete");
        }

        [Test]
        public void Run_ChecksUserPermissions()
        {
            _presenter.Run();
            _authService.Received().Can("User.View");
            _authService.Received().Can("User.Add");
            _authService.Received().Can("User.Edit");
            _authService.Received().Can("User.Delete");
        }

        [Test]
        public void Run_ChecksEntryFeePermissions()
        {
            _presenter.Run();
            _authService.Received().Can("EntryFee.View");
            _authService.Received().Can("EntryFee.Add");
            _authService.Received().Can("EntryFee.Edit");
            _authService.Received().Can("EntryFee.Delete");
        }

        [Test]
        public void Run_ChecksLoanProductPermissions()
        {
            _presenter.Run();
            _authService.Received().Can("LoanProduct.View");
            _authService.Received().Can("LoanProduct.Add");
            _authService.Received().Can("LoanProduct.Edit");
            _authService.Received().Can("LoanProduct.Delete");
        }

        [Test]
        public void ShowRoles_ExecutesProperCommand()
        {
            _presenter.ShowRoles();
            _appController.Received().Execute(Arg.Any<ShowRolesData>());
        }

        [Test]
        public void ShowUsers_ExecutesProperCommand()
        {
            _presenter.ShowUsers();
            _appController.Received().Execute(Arg.Any<ShowUsersData>());
        }

        [Test]
        public void ShowLoanProducts_ExecutesProperCommand()
        {
            _presenter.ShowLoanProducts();
            _appController.Received().Execute(Arg.Any<ShowLoanProductsData>());
        }

        [Test]
        public void ShowEntryFees_ExecutesProperCommand()
        {
            _presenter.ShowEntryFees();
            _appController.Received().Execute(Arg.Any<ShowEntryFeesData>());
        }

        [Test]
        public void ChangeLanguage_ExecutesProperCommand()
        {
            _presenter.ChangeLanguage("en-US");
            _appController.Received().Execute(Arg.Is<ChangeLanguageData>(data => data.Name == "en-US"));
        }

        [Test]
        public void Run_NoPermission_CannotManageStuff()
        {
            _authService.Can(Arg.Any<string>()).Returns(false);
            _presenter.Run();
            Assert.IsFalse(_mainView.AllowRoleManagement);
            Assert.IsFalse(_mainView.AllowUserManagement);
            Assert.IsFalse(_mainView.AllowEntryFeeManagement);
            Assert.IsFalse(_mainView.AllowLoanProductManagement);
        }
    }
}
// ReSharper restore InconsistentNaming
