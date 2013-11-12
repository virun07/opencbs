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
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.Presenter
{
    public class UserPresenter : IUserPresenter, IUserPresenterCallbacks
    {
        private readonly IUserView _view;
        private readonly IApplicationController _appController;
        private CommandResult _commandResult = CommandResult.Cancel;

        public UserPresenter(IUserView view, IApplicationController appController)
        {
            _view = view;
            _appController = appController;
        }

        public Result<UserDto> Get(UserDto userDto)
        {
            _view.Attach(this);
            _view.InjectFrom(userDto);
            _view.CanEditPassword = userDto == null;
            _view.Run();

            if (_commandResult != CommandResult.Ok)
                return new Result<UserDto>(_commandResult, null);

            var newUserDto = GetUserDto();
            newUserDto.Id = userDto != null ? userDto.Id : 0;
            return new Result<UserDto>(_commandResult, newUserDto);
        }

        public object View
        {
            get { return _view; }
        }

        public void Ok()
        {
        }

        public void Cancel()
        {
            _commandResult = CommandResult.Cancel;
            _view.Stop();
        }

        public void Close()
        {
        }

        private UserDto GetUserDto()
        {
            return null;
        }
    }
}
