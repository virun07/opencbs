// Copyright © 2013 Open Octopus Ltd.
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful
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
    public class RolesPresenterTest
    {
        private IRolesView _rolesView;
        private IApplicationController _appController;
        private IRoleService _roleService;
        private IAuthService _authService;
        private RolesPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _rolesView = Substitute.For<IRolesView>();
            _appController = Substitute.For<IApplicationController>();
            _roleService = Substitute.For<IRoleService>();
            _authService = Substitute.For<IAuthService>();
            _presenter = new RolesPresenter(_rolesView, _appController, _roleService, _authService);
        }

        [Test]
        public void Run_CallsAttachAndRunOnView()
        {
            _presenter.Run();
            _rolesView.Received().Attach(_presenter);
            _rolesView.Received().Run();
        }

        [Test]
        public void Run_ChecksPermissions()
        {
            _presenter.Run();
            _authService.Received().Can("Role.Add");
            _authService.Received().Can("Role.Edit");
            _authService.Received().Can("Role.Delete");
        }

        [Test]
        public void Run_HasAddPermission_CanAdd()
        {
            _authService.Can("Role.Add").Returns(true);
            _presenter.Run();
            Assert.IsTrue(_rolesView.AllowAdding);
        }

        [Test]
        public void Run_HasEditPermission_CanEdit()
        {
            _authService.Can("Role.Edit").Returns(true);
            _presenter.Run();
            Assert.IsTrue(_rolesView.AllowEditing);
        }

        [Test]
        public void Run_HasDeletePermission_CanDelete()
        {
            _authService.Can("Role.Delete").Returns(true);
            _presenter.Run();
            Assert.IsTrue(_rolesView.AllowDeleting);
        }

        [Test]
        public void Run_ShowsRoles()
        {
            _roleService.FindAll().Returns(new List<RoleDto>());
            _presenter.Run();
            _rolesView.Received().ShowRoles(Arg.Any<IList<RoleDto>>());
            _roleService.Received().FindAll();
        }

        [Test]
        public void Refresh_ShowsRoles()
        {
            _roleService.FindAll().Returns(new List<RoleDto>());
            _presenter.Refresh();
            _rolesView.Received().ShowRoles(Arg.Any<IList<RoleDto>>());
            _roleService.Received().FindAll();
        }
        
        [Test]
        public void Refresh_ShowDeletedIsFalse_ShowsOnlyNonDeleted()
        {
            var roles = new List<RoleDto>
            {
                new RoleDto { Id = 1, Deleted = false }, 
                new RoleDto { Id = 2, Deleted = true }
            };
            _rolesView.ShowDeleted.Returns(false);
            _roleService.FindAll().Returns(roles);
            _presenter.Refresh();
            _rolesView.Received().ShowRoles(Arg.Is<IList<RoleDto>>(x => x.Count == 1));
        }

        [Test]
        public void Refresh_ShowDeletedIsTrue_ShowsAll()
        {
            var roles = new List<RoleDto>
            {
                new RoleDto { Id = 1, Deleted = false }, 
                new RoleDto { Id = 2, Deleted = true }
            };
            _rolesView.ShowDeleted.Returns(true);
            _roleService.FindAll().Returns(roles);
            _presenter.Refresh();
            _rolesView.Received().ShowRoles(Arg.Is<IList<RoleDto>>(x => x.Count == 2));
        }

        [Test]
        public void Add_ExecutesCommand()
        {
            _presenter.Add();
            _appController.Received().Execute(Arg.Any<AddRoleData>());
        }

        [Test]
        public void Edit_IdIsNull_DoesNotExecuteCommand()
        {
            _rolesView.SelectedRoleId.Returns(x => null);
            _presenter.Edit();
            _appController.DidNotReceive().Execute(Arg.Any<EditRoleData>());
        }

        [Test]
        public void Edit_IdIsNotNull_ExecutesCommand()
        {
            _rolesView.SelectedRoleId.Returns(1);
            _presenter.Edit();
            _appController.Received().Execute(Arg.Is<EditRoleData>(x => x.Id == 1));
        }

        [Test]
        public void Delete_IdIsNull_DoesNotExecuteCommand()
        {
            _rolesView.SelectedRoleId.Returns(x => null);
            _presenter.Delete();
            _appController.DidNotReceive().Execute(Arg.Any<DeleteRoleData>());
        }

        [Test]
        public void Delete_IdIsNotNull_ExecutesCommand()
        {
            _rolesView.SelectedRoleId.Returns(1);
            _presenter.Delete();
            _appController.Received().Execute(Arg.Is<DeleteRoleData>(x => x.Id == 1));
        }

        [Test]
        public void ChangeSelection_IdIsNull_EditingAndDeletingDisabled()
        {
            _rolesView.SelectedRoleId.Returns(x => null);
            _presenter.ChangeSelection();
            Assert.IsFalse(_rolesView.CanEdit);
            Assert.IsFalse(_rolesView.CanDelete);
        }

        [Test]
        public void ChangeSelection_IdIsNotNull_EditingAndDeletingEnabled()
        {
            _rolesView.SelectedRoleId.Returns(1);
            _presenter.ChangeSelection();
            Assert.IsTrue(_rolesView.CanEdit);
            Assert.IsTrue(_rolesView.CanDelete);
        }
    }
}
// ReSharper restore InconsistentNaming
