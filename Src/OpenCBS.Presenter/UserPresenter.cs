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
using Omu.ValueInjecter;
using OpenCBS.DataContract;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;

namespace OpenCBS.Presenter
{
    public class UserPresenter : IUserPresenter, IUserPresenterCallbacks
    {
        private readonly IUserView _view;
        private readonly IApplicationController _appController;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private CommandResult _commandResult = CommandResult.Cancel;

        public UserPresenter(IUserView view, IUserService userService, IRoleService roleService, IApplicationController appController)
        {
            _view = view;
            _userService = userService;
            _roleService = roleService;
            _appController = appController;
        }

        public Result<UserDto> Get(UserDto userDto)
        {
            _view.Attach(this);
            userDto = userDto ?? new UserDto();
            if (!userDto.IsSuperuser)
                _view.ShowRoles(_roleService.FindAll().ToDictionary(r => r.Id, r => r.Name));
            _view.InjectFrom(userDto);
            if (!userDto.IsNew)
                _view.DisablePassword();
            _view.Run();

            if (_commandResult != CommandResult.Ok)
                return new Result<UserDto>(_commandResult, null);

            return new Result<UserDto>(_commandResult, GetUserDto());
        }

        public object View
        {
            get { return _view; }
        }

        public void Ok()
        {
            var userDto = GetUserDto();
            _userService.Validate(userDto);
            if (userDto.Notification.HasErrors)
            {
                _view.ShowNotification(userDto.Notification);
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

        private UserDto GetUserDto()
        {
            var result = new UserDto();
            result.InjectFrom(_view);
            return result;
        }
    }
}
