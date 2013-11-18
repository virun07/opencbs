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
using System.Threading;
using NSubstitute;
using NUnit.Framework;
using OpenCBS.DataContract;
using OpenCBS.Interface;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;
using OpenCBS.Presenter;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Presenter
{
    [TestFixture]
    public class RolePresenterTest
    {
        private IRoleView _roleView;
        private IRoleService _roleService;
        private IAuthService _authService;
        private IApplicationController _appController;
        private RolePresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _roleView = Substitute.For<IRoleView>();
            _roleService = Substitute.For<IRoleService>();

            var permissions = new List<string>();
            _authService = Substitute.For<IAuthService>();
            _authService.GetAllPermissions().Returns(permissions);

            _appController = Substitute.For<IApplicationController>();
            _presenter = new RolePresenter(_roleView, _roleService, _authService, _appController);
        }

        [Test]
        public void Get_RunsAttachAndShowPermissionsAndRunOnView()
        {
            _presenter.Get(null);
            _roleView.Received().Attach(_presenter);
            _roleView.Received().ShowPermissions(Arg.Any<IList<string>>());
            _roleView.Received().Run();
        }

        [Test]
        public void Get_RoleIsNull_InjectsEmptyValues()
        {
            _presenter.Get(null);
            Assert.AreEqual(0, _roleView.Id);
            Assert.IsNullOrEmpty(_roleView.RoleName);
            Assert.IsTrue(_roleView.Permissions == null || _roleView.Permissions.Count == 0);
        }

        [Test]
        public void Get_RoleIsNotNull_InjectsActualValues()
        {
            var role = new RoleDto
            {
                Id = 1,
                Name = "Test role",
                Permissions = new List<string> { "User.View" }
            };
            _presenter.Get(role);
            Assert.AreEqual(1, _roleView.Id);
            Assert.AreEqual("Test role", _roleView.RoleName);
            Assert.That(_roleView.Permissions, Is.EquivalentTo(new List<string> { "User.View" }));
        }

        [Test]
        public void Ok_RoleIsInvalid_CallsShowNotificationsOnView()
        {
            _roleService
                .When(x => x.Validate(Arg.Any<RoleDto>()))
                .Do(x =>
                {
                    var notification = new Notification();
                    notification.AddError(new Error());
                    x.Arg<RoleDto>().Notification = notification;
                });
            _presenter.Ok();
            _roleView.Received().ShowNotification(Arg.Any<Notification>());
            _roleView.DidNotReceive().Stop();
        }

        [Test]
        public void Ok_RoleIsValid_CallsStopOnView()
        {
            _roleService
                .When(x => x.Validate(Arg.Any<RoleDto>()))
                .Do(x =>
                {
                    x.Arg<RoleDto>().Notification = new Notification();
                });
            _presenter.Ok();
            _roleView.DidNotReceive().ShowNotification(Arg.Any<Notification>());
            _roleView.Received().Stop();
        }

        [Test]
        public void Cancel_CallsStopOnView()
        {
            _presenter.Cancel();
            _roleView.Received().Stop();
        }
    }
}
// ReSharper restore InconsistentNaming
