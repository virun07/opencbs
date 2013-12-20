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

using OpenCBS.DataContract;
using OpenCBS.DataContract.AppEvent;
using OpenCBS.DataContract.CommandData;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;

namespace OpenCBS.Service.Command
{
    public class EditExoticScheduleCommand : ICommand<EditExoticScheduleData>
    {
        private readonly IExoticSchedulePresenter _presenter;
        private readonly IExoticScheduleService _service;
        private readonly IApplicationController _appController;

        public EditExoticScheduleCommand(IExoticSchedulePresenter presenter, IExoticScheduleService service,
                                         IApplicationController appController)
        {
            _presenter = presenter;
            _service = service;
            _appController = appController;
        }

        public void Execute(EditExoticScheduleData commandData)
        {
            var dto = _service.FindById(commandData.Id);
            var result = _presenter.Get(dto);
            if (result.CommandResult == CommandResult.Ok)
            {
                _service.Update(result.Data);
                _appController.Raise(new ExoticScheduleSavedEvent { Id = result.Data.Id });
            }
        }
    }
}
