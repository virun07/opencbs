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
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;

namespace OpenCBS.Presenter
{
    public class LoginPresenter : ILoginPresenter, ILoginPresenterCallbacks
    {
        private readonly ILoginView _view;
        private readonly IErrorView _errorView;
        private readonly IDatabaseService _databaseService;
        private readonly IAuthService _authService;
        private readonly IBackgroundTaskFactory _backgroundTaskFactory;

        public LoginPresenter(ILoginView view, IErrorView errorView, IDatabaseService databaseService, IAuthService authService, IBackgroundTaskFactory backgroundTaskFactory)
        {
            _view = view;
            _errorView = errorView;
            _databaseService = databaseService;
            _authService = authService;
            _backgroundTaskFactory = backgroundTaskFactory;
        }

        public void Ok()
        {
            var userDto = _authService.Login(_view.Username, _view.Password);
            if (userDto == null)
                _errorView.Run("User not found.");
            else
            {
                _view.Stop();
            }
        }

        public void Run()
        {
            _view.Attach(this);

            var task = _backgroundTaskFactory.GetTask();
            IList<string> databases = new List<string>();
            task.Action = () =>
            {
                databases = _databaseService.FindAll();
            };
            task.OnSuccess = () =>
            {
                _view.StopDatabaseListRefresh();
                _view.ShowDatabases(databases);
            };
            task.OnError = error =>
            {
                _view.StopDatabaseListRefresh();
                _errorView.Run(error.Message);
            };
            _view.StartDatabaseListRefresh();
            task.Run();
        }

        public object View
        {
            get { return _view; }
        }
    }
}
