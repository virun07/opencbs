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

using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.Presenter
{
    public class UsersPresenter : IUsersPresenter, IUsersPresenterCallbacks
    {
        private readonly IUsersView _view;
        private readonly IApplicationController _appController;
        private readonly IUserService _userService;

        public UsersPresenter(IUsersView view, IApplicationController appController, IUserService userService)
        {
            _view = view;
            _appController = appController;
            _userService = userService;
        }

        public void Run()
        {
            _view.Attach(this);
            _view.Run();
            ShowUsers();
        }

        public object View
        {
            get { return _view; }
        }

        public void Add()
        {
        }

        public void Edit()
        {
        }

        public void Delete()
        {
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
            _view.ShowUsers(users);
        }
    }
}
