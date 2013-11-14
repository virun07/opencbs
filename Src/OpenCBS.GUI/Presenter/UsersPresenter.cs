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
    public class UsersPresenter : IUsersPresenter, IUsersPresenterCallbacks,
        IEventHandler<UserSavedEvent>
    {
        private readonly IUsersView _view;
        private readonly IApplicationController _appController;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UsersPresenter(IUsersView view, IApplicationController appController, IUserService userService, IRoleService roleService)
        {
            _view = view;
            _appController = appController;
            _userService = userService;
            _roleService = roleService;
        }

        public void Run()
        {
            _view.Attach(this);
            _view.Roles = _roleService.FindAll();
            ShowUsers();
            _view.Run();
        }

        public object View
        {
            get { return _view; }
        }

        public void Add()
        {
            _appController.Execute(new AddUserData());
        }

        public void Edit()
        {
            var id = _view.SelectedUserId;
            if (id == null) return;
            _appController.Execute(new EditUserData { Id = id.Value });
        }

        public void Delete()
        {
            var id = _view.SelectedUserId;
            if (id == null) return;
            _appController.Execute(new DeleteUserData { Id = id.Value });
        }

        public void Refresh()
        {
            ShowUsers();
        }

        public void ChangeSelection()
        {
            var id = _view.SelectedUserId;
            _view.CanEdit = _view.CanDelete = id != null;
        }

        public void Close()
        {
            _appController.Unsubscribe(this);
        }

        private void ShowUsers()
        {
            var users = _userService.FindAll();
            _view.ShowUsers(_view.ShowDeleted ? users : users.Where(u => !u.Deleted).ToList().AsReadOnly());
        }

        public void Handle(UserSavedEvent eventData)
        {
            ShowUsers();
        }
    }
}
