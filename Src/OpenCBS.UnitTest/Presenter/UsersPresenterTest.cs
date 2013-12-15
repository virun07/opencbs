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
using OpenCBS.DataContract.CommandData;
using OpenCBS.Interface;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;
using OpenCBS.Presenter;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Presenter
{
    [TestFixture]
    public class UsersPresenterTest
    {
        private IUsersView _usersView;
        private IUserService _userService;
        private IRoleService _roleService;
        private IAuthService _authService;
        private IApplicationController _appController;
        private UsersPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _usersView = Substitute.For<IUsersView>();
            _userService = Substitute.For<IUserService>();
            _roleService = Substitute.For<IRoleService>();
            _authService = Substitute.For<IAuthService>();
            _appController = Substitute.For<IApplicationController>();
            _presenter = new UsersPresenter(_usersView, _appController, _userService, _roleService, _authService);
        }

        [Test]
        public void Run_CallsAttachAndRunOnView()
        {
            _presenter.Run();
            _usersView.Received().Attach(_presenter);
            _usersView.Received().Run();
        }

        [Test]
        public void Run_ChecksPermissions()
        {
            _presenter.Run();
            _authService.Received().Can("Security.AddUser");
            _authService.Received().Can("Security.EditUser");
            _authService.Received().Can("Security.DeleteUser");
        }

        [Test]
        public void Run_HasAddPermission_CanAdd()
        {
            _authService.Can("Security.AddUser").Returns(true);
            _presenter.Run();
            Assert.IsTrue(_usersView.AllowAdding);
        }

        [Test]
        public void Run_HasEditPermission_CanEdit()
        {
            _authService.Can("Security.EditUser").Returns(true);
            _presenter.Run();
            Assert.IsTrue(_usersView.AllowEditing);
        }

        [Test]
        public void Run_HasDeletePermission_CanDelete()
        {
            _authService.Can("Security.DeleteUser").Returns(true);
            _presenter.Run();
            Assert.IsTrue(_usersView.AllowDeleting);
        }

        [Test]
        public void Run_ShowsUsers()
        {
            _userService.FindAll().Returns(new List<UserDto>());
            _presenter.Run();
            _usersView.Received().ShowUsers(Arg.Any<IList<UserDto>>());
        }

        [Test]
        public void Run_LoadsRoles()
        {
            var roles = new List<RoleDto>
            {
                new RoleDto { Id = 1, Name = "Test role"}
            };
            _roleService.FindAll().Returns(roles);
            _presenter.Run();
            Assert.That(_usersView.Roles, Is.EquivalentTo(roles));
        }

        [Test]
        public void Refresh_ShowsUsers()
        {
            _userService.FindAll().Returns(new List<UserDto>());
            _presenter.Refresh();
            _usersView.Received().ShowUsers(Arg.Any<IList<UserDto>>());
        }

        [Test]
        public void Refresh_ShowDeletedIsFalse_ShowsOnlyNonDeleted()
        {
            var users = new List<UserDto>
            {
                new UserDto { Id = 1, Deleted = false},
                new UserDto { Id = 2, Deleted = true }
            };
            _usersView.ShowDeleted.Returns(false);
            _userService.FindAll().Returns(users);
            _presenter.Refresh();
            _usersView.Received().ShowUsers(Arg.Is<IList<UserDto>>(x => x.Count == 1));
        }

        [Test]
        public void Refresh_ShowDeletedIsTrue_ShowsAll()
        {
            var users = new List<UserDto>
            {
                new UserDto { Id = 1, Deleted = false },
                new UserDto { Id = 2, Deleted = true }
            };
            _usersView.ShowDeleted.Returns(true);
            _userService.FindAll().Returns(users);
            _presenter.Refresh();
            _usersView.Received().ShowUsers(Arg.Is<IList<UserDto>>(x => x.Count == 2));
        }

        [Test]
        public void Add_ExecutesCommand()
        {
            _presenter.Add();
            _appController.Received().Execute(Arg.Any<AddUserData>());
        }

        [Test]
        public void Edit_IdIsNull_DoesNotExecuteCommand()
        {
            _usersView.SelectedUserId.Returns(x => null);
            _presenter.Edit();
            _appController.DidNotReceive().Execute(Arg.Any<EditUserData>());
        }

        [Test]
        public void Edit_IdIsNotNull_ExecutesCommand()
        {
            _usersView.SelectedUserId.Returns(1);
            _presenter.Edit();
            _appController.Received().Execute(Arg.Is<EditUserData>(x => x.Id == 1));
        }

        [Test]
        public void Delete_IdIsNull_DoesNotExecuteCommand()
        {
            _usersView.SelectedUserId.Returns(x => null);
            _presenter.Delete();
            _appController.DidNotReceive().Execute(Arg.Any<DeleteUserData>());
        }

        [Test]
        public void Delete_IdIsNotNull_ExecutesCommand()
        {
            _usersView.SelectedUserId.Returns(1);
            _presenter.Delete();
            _appController.Received().Execute(Arg.Is<DeleteUserData>(x => x.Id == 1));
        }

        [Test]
        public void ChangeSelection_IdIsNull_EditingAndDeletingDisabled()
        {
            _usersView.SelectedUserId.Returns(x => null);
            _presenter.ChangeSelection();
            Assert.IsFalse(_usersView.CanEdit);
            Assert.IsFalse(_usersView.CanDelete);
        }

        [Test]
        public void ChangeSelection_IdIsNotNull_EditingAndDeletingEnabled()
        {
            _usersView.SelectedUserId.Returns(1);
            _presenter.ChangeSelection();
            Assert.IsTrue(_usersView.CanEdit);
            Assert.IsTrue(_usersView.CanDelete);
        }
    }
}
// ReSharper restore InconsistentNaming
