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
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.View;

namespace OpenCBS.Presenter
{
    public class ExoticSchedulePresenter : IExoticSchedulePresenter, IExoticSchedulePresenterCallbacks
    {
        private readonly IExoticScheduleView _view;
        private readonly IApplicationController _appController;

        private CommandResult _commandResult = CommandResult.Cancel;

        public ExoticSchedulePresenter(IExoticScheduleView view, IApplicationController appController)
        {
            _view = view;
            _appController = appController;
        }

        public Result<ExoticScheduleDto> Get(ExoticScheduleDto dto)
        {
            _view.Attach(this);
            _view.Run();
            return new Result<ExoticScheduleDto>(CommandResult.Cancel, null);
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
            _appController.Unsubscribe(this);
        }

        public object View
        {
            get { return _view; }
        }
    }
}
