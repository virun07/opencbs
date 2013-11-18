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
using OpenCBS.DataContract;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;
using OpenCBS.Presenter;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Presenter
{
    [TestFixture]
    public class LoginPresenterTest
    {
        private ILoginView _loginView;
        private IAuthService _authService;
        private IDatabaseService _databaseService;
        private LoginPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _loginView = Substitute.For<ILoginView>();
            _authService = Substitute.For<IAuthService>();
            _databaseService = Substitute.For<IDatabaseService>();
            _presenter = new LoginPresenter(_loginView, _databaseService, _authService);
        }

        [Test]
        public void Run_CallsAttachOnView()
        {
            _presenter.Run();
            
            _loginView.Received().Attach(_presenter);
        }

        [Test]
        public void Run_LoadsListOfDatabasesIntoView()
        {
            _databaseService.FindAll().Returns(new[] { "db1" });
            
            _presenter.Run();
            
            _loginView.Received().StartDatabaseListRefresh();
            _databaseService.Received().FindAll();
            System.Threading.Thread.Sleep(100);
            _loginView.Received().StopDatabaseListRefresh();
        }

        [Test]
        public void Ok_RunsLoginOnAuthService()
        {
            _loginView.Username.Returns("user");
            _loginView.Password.Returns("password");

            _presenter.Ok();

            _authService.Received().Login("user", "password");
        }
        
        [Test]
        public void Ok_ValidUser_Stops()
        {
            _loginView.Username.Returns("user");
            _loginView.Password.Returns("password");
            _authService.Login("user", "password").Returns(new UserDto());

            _presenter.Ok();
            
            _loginView.Received().Stop();
        }

        [Test]
        public void Ok_InvalidUser_ShowsError()
        {
            _authService.Login(Arg.Any<string>(), Arg.Any<string>()).Returns(x => null);

            _presenter.Ok();

            _loginView.Received().ShowError("User not found.");
        }
    }
}
// ReSharper restore InconsistentNaming
