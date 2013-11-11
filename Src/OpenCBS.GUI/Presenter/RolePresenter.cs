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

namespace OpenCBS.GUI.Presenter
{
    public class RolePresenter : IRolePresenter, IRolePresenterCallbacks
    {
        private readonly IRoleView _view;
        private readonly IRoleService _roleService;
        private readonly IApplicationController _appContoller;
        private CommandResult _commandResult = CommandResult.Cancel;

        public RolePresenter(IRoleView view, IRoleService roleService, IApplicationController appController)
        {
            _view = view;
            _roleService = roleService;
            _appContoller = appController;
        }

        public Result<RoleDto> Get(RoleDto roleDto)
        {
            _view.Attach(this);

            _view.InjectFrom(roleDto ?? new RoleDto());
            _view.RoleName = roleDto != null ? roleDto.Name : string.Empty;
            var permissions = new[]
            {
                "IEntryFeeService.Add",
                "IEntryFeeService.Update",
                "IEntryFeeService.Remove",
                "ILoanProductService.Add",
                "ILoanProductService.Update",
                "ILoanProductService.Remove"
            };
            _view.ShowPermissions(permissions);
            _view.Run();

            if (_commandResult != CommandResult.Ok)
                return new Result<RoleDto>(_commandResult, null);

            var newRoleDto = GetRoleDto();
            newRoleDto.Id = roleDto != null ? roleDto.Id : 0;
            return new Result<RoleDto>(_commandResult, newRoleDto);
        }

        public object View
        {
            get { return _view; }
        }

        public void Ok()
        {
            var roleDto = GetRoleDto();
            _roleService.Validate(roleDto);
            if (roleDto.Notification.HasErrors)
            {
                _view.ShowNotification(roleDto.Notification);
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
            _appContoller.Unsubscribe(this);
        }

        private RoleDto GetRoleDto()
        {
            var result = new RoleDto();
            result.InjectFrom(_view);
            result.Name = _view.RoleName;
            return result;
        }
    }
}
