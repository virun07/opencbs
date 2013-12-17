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

using Omu.ValueInjecter;
using OpenCBS.DataContract;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;

namespace OpenCBS.Presenter
{
    public class ChangePasswordPresenter : IChangePasswordPresenterCallbacks, IChangePasswordPresenter
    {
        private readonly IChangePasswordView _view;
        private readonly IApplicationController _appController;
        private readonly IUserService _service;

        private CommandResult _commandResult = CommandResult.Cancel;

        public ChangePasswordPresenter(IChangePasswordView view, IApplicationController appController, IUserService service)
        {
            _view = view;
            _appController = appController;
            _service = service;
        }

        public Result<PasswordDto> Get(int id)
        {
            _view.Attach(this);
            _view.Id = id;
            _view.RequireCurrentPassword = id == UserDto.Current.Id;
            _view.Run();
            return new Result<PasswordDto>(_commandResult, _commandResult == CommandResult.Ok ? GetDto() : null);
        }

        public object View
        {
            get { return _view; }
        }

        public void Ok()
        {
            var dto = GetDto();
            _service.ValidateChangePassword(dto);
            if (dto.Notification.HasErrors)
            {
                _view.ShowNotification(dto.Notification);
            }
            else
            {
                _commandResult = CommandResult.Ok;
                _view.Stop();
            }
        }

        public void Cancel()
        {
            _commandResult = CommandResult.Cancel;
            _view.Stop();
        }

        public void Close()
        {
            _appController.Unsubscribe(this);
        }

        private PasswordDto GetDto()
        {
            var result = new PasswordDto();
            result.InjectFrom(_view);
            return result;
        }
    }
}
