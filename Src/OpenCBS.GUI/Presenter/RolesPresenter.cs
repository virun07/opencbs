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

using System.Linq;
using OpenCBS.GUI.AppEvent;
using OpenCBS.GUI.CommandData;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.Presenter
{
    public class RolesPresenter : IRolesPresenter, IRolesPresenterCallbacks,
        IEventHandler<RoleSavedEvent>,
        IEventHandler<RoleDeletedEvent>,
        IEventHandler<LanguageChangedEvent>
    {
        private readonly IRolesView _view;
        private readonly IApplicationController _appController;
        private readonly IRoleService _roleService;
        private readonly IAuthService _authService;

        public RolesPresenter(IRolesView view, IApplicationController appController, IRoleService roleService, IAuthService authService)
        {
            _view = view;
            _appController = appController;
            _roleService = roleService;
            _authService = authService;
        }

        public void Run()
        {
            _view.Attach(this);
            _view.Run();
            if (!_authService.Can("Role.Add")) _view.ProhibitAdding();
            if (!_authService.Can("Role.Edit")) _view.ProhibitEditing();
            if (!_authService.Can("Role.Delete")) _view.ProhibitDeleting();
            ShowRoles();
        }

        public object View
        {
            get { return _view; }
        }

        public void Add()
        {
            _appController.Execute(new AddRoleData());
        }

        public void Edit()
        {
            var id = _view.SelectedRoleId;
            if (id == null) return;
            _appController.Execute(new EditRoleData { Id = id.Value });
        }

        public void Delete()
        {
            var id = _view.SelectedRoleId;
            if (id == null) return;
            _appController.Execute(new DeleteRoleData { Id = id.Value });
        }

        public void Refresh()
        {
            ShowRoles();
        }

        public void ChangeSelection()
        {
            var id = _view.SelectedRoleId;
            _view.CanEdit = _view.CanDelete = id != null;
        }

        public void Close()
        {
            _appController.Unsubscribe(this);
        }

        private void ShowRoles()
        {
            var roles = _view.ShowDeleted
                            ? _roleService.FindAll()
                            : _roleService.FindAll().Where(r => !r.Deleted).ToList().AsReadOnly();
            _view.ShowRoles(roles);
        }

        public void Handle(RoleSavedEvent eventData)
        {
            ShowRoles();
        }

        public void Handle(RoleDeletedEvent eventData)
        {
            ShowRoles();
        }

        public void Handle(LanguageChangedEvent eventData)
        {
            _view.Translate();
        }
    }
}
