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
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.Presenter
{
    public class EntryFeePresenter : IEntryFeePresenter, IEntryFeePresenterCallbacks
    {
        private readonly IEntryFeeView _view;
        private readonly IEntryFeeService _entryFeeService;

        private CommandResult _commandResult = CommandResult.Cancel;

        public EntryFeePresenter(IEntryFeeView view, IEntryFeeService entryFeeService)
        {
            _view = view;
            _entryFeeService = entryFeeService;
        }

        public void Ok()
        {
            var entryFee = GetEntryFee();
            _entryFeeService.Validate(entryFee);
            if (entryFee.Notification.HasErrors)
            {
                _view.ShowNotification(entryFee.Notification);
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

        public Result<EntryFeeDto> Get(EntryFeeDto entryFee)
        {
            _view.Attach(this);

            _view.InjectFrom(entryFee ?? new EntryFeeDto());
            _view.EntryFeeName = entryFee != null ? entryFee.Name : string.Empty;

            _view.Run();

            if (_commandResult != CommandResult.Ok)
                return new Result<EntryFeeDto>(_commandResult, null);

            var newEntryFee = GetEntryFee();
            newEntryFee.Id = entryFee != null ? entryFee.Id : 0;
            return new Result<EntryFeeDto>(_commandResult, newEntryFee);
        }

        private EntryFeeDto GetEntryFee()
        {
            var result = new EntryFeeDto();
            result.InjectFrom(_view);
            result.Name = _view.EntryFeeName;
            return result;
        }
    }
}
