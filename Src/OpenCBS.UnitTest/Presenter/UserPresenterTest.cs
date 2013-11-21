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
    public class UserPresenterTest
    {
        private IUserView _userView;
        private IUserService _userService;
        private IRoleService _roleService;
        private IApplicationController _appController;
        private UserPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _userView = Substitute.For<IUserView>();
            _userService = Substitute.For<IUserService>();
            _roleService = Substitute.For<IRoleService>();
            _roleService.FindAll().Returns(new List<RoleDto>());
            _appController = Substitute.For<IApplicationController>();
            _presenter = new UserPresenter(_userView, _userService, _roleService, _appController);
        }

        [Test]
        public void Get_RunsAttachAndRunOnView()
        {
            _presenter.Get(null);
            _userView.Received().Attach(_presenter);
            _userView.Received().Run();
        }

        [Test]
        public void Get_UserIsNull_InjectsEmptyValues()
        {
            _presenter.Get(null);
            Assert.AreEqual(0, _userView.Id);
            Assert.IsNullOrEmpty(_userView.FirstName);
            Assert.IsNullOrEmpty(_userView.LastName);
            Assert.IsNull(_userView.Email);
            Assert.IsNullOrEmpty(_userView.Username);
            Assert.IsNullOrEmpty(_userView.Password);
            Assert.IsNullOrEmpty(_userView.PasswordConfirmation);
        }

        [Test]
        public void Get_UserIsNotNull_InjectsActualValues()
        {
            var user = new UserDto
            {
                Id = 1,
                FirstName = "Homer",
                LastName = "Simpson",
                Email = "homer@simpson.com",
                Username = "homer",
                RoleIds = new[] { 1, 2, 3 }
            };
            _presenter.Get(user);
            Assert.AreEqual(1, _userView.Id);
            Assert.AreEqual("Homer", _userView.FirstName);
            Assert.AreEqual("Simpson", _userView.LastName);
            Assert.AreEqual("homer@simpson.com", _userView.Email);
            Assert.AreEqual("homer", _userView.Username);
            Assert.That(_userView.RoleIds, Is.EquivalentTo(new[] { 1, 2, 3 }));
        }
    }
}
// ReSharper restore InconsistentNaming
