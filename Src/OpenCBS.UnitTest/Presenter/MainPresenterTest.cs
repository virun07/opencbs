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
using System.Collections.ObjectModel;
using System.Linq;
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
            var permissions = new List<string> { "Role.View", "Role.Add", "Role.Edit", "Role.Delete" }.AsReadOnly();
            _authService.Received().CanAny(Arg.Is<ReadOnlyCollection<string>>(actualPermissions => permissions.SequenceEqual(actualPermissions)));
        }

        [Test]
        public void Run_ChecksUserPermissions()
        {
            _presenter.Run();
            var permissions = new List<string> { "User.View", "User.Add", "User.Edit", "User.Delete" }.AsReadOnly();
            _authService.Received().CanAny(Arg.Is<ReadOnlyCollection<string>>(actualPermissions => permissions.SequenceEqual(actualPermissions)));
        }

        [Test]
        public void Run_ChecksEntryFeePermissions()
        {
            _presenter.Run();
            var permissions = new List<string> { "EntryFee.View", "EntryFee.Add", "EntryFee.Edit", "EntryFee.Delete" }.AsReadOnly();
            _authService.Received().CanAny(Arg.Is<ReadOnlyCollection<string>>(actualPermissions => permissions.SequenceEqual(actualPermissions)));
        }

        [Test]
        public void Run_ChecksLoanProductPermissions()
        {
            _presenter.Run();
            var permissions = new List<string> { "LoanProduct.View", "LoanProduct.Add", "LoanProduct.Edit", "LoanProduct.Delete" }.AsReadOnly();
            _authService.Received().CanAny(Arg.Is<ReadOnlyCollection<string>>(actualPermissions => permissions.SequenceEqual(actualPermissions)));
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
    }
}
// ReSharper restore InconsistentNaming
