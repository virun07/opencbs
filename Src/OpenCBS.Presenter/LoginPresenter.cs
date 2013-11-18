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
using System.ComponentModel;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;

namespace OpenCBS.Presenter
{
    public class LoginPresenter : ILoginPresenter, ILoginPresenterCallbacks
    {
        private readonly ILoginView _view;
        private readonly IDatabaseService _databaseService;
        private readonly IAuthService _authService;

        public LoginPresenter(ILoginView view, IDatabaseService databaseService, IAuthService authService)
        {
            _view = view;
            _databaseService = databaseService;
            _authService = authService;
        }

        public void Ok()
        {
            var userDto = _authService.Login(_view.Username, _view.Password);
            if (userDto == null)
                _view.ShowError("User not found.");
            else
            {
                _view.Stop();
            }
        }

        public void Run()
        {
            _view.Attach(this);

            var worker = new BackgroundWorker();
            worker.DoWork += (sender, e) =>
            {
                e.Result = _databaseService.FindAll();
            };
            worker.RunWorkerCompleted += (sender, e) =>
            {
                _view.StopDatabaseListRefresh();
                if (e.Error != null)
                {
                    _view.ShowError(e.Error.Message);
                    return;
                }
                _view.ShowDatabases((IList<string>) e.Result);
            };
            _view.StartDatabaseListRefresh();
            worker.RunWorkerAsync();
        }

        public object View
        {
            get { return _view; }
        }
    }
}
