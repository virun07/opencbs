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
using OpenCBS.DataContract;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.Presenter
{
    public class SelectEntryFeePresenter : ISelectEntryFeePresenter, ISelectEntryFeePresenterCallbacks
    {
        private readonly ISelectEntryFeeView _view;
        private readonly IEntryFeeService _entryFeeService;

        private CommandResult _commandResult = CommandResult.Cancel;

        public SelectEntryFeePresenter(ISelectEntryFeeView view, IEntryFeeService entryFeeService)
        {
            _view = view;
            _entryFeeService = entryFeeService;
        }

        public Result<int> Get()
        {
            _view.Attach(this);
            ShowEntryFees();
            _view.Run();
            return new Result<int>(_commandResult, _view.SelectedEntryFeeId ?? 0);
        }
        
        public void Ok()
        {
            _commandResult = CommandResult.Ok;
            _view.Stop();
        }

        public void Cancel()
        {
            _commandResult = CommandResult.Cancel;
            _view.Stop();
        }

        public void ChangeSelection()
        {
            _view.CanSelectEntryFee = _view.SelectedEntryFeeId.HasValue;
        }

        private void ShowEntryFees()
        {
            var entryFees = _entryFeeService.FindAll();
            _view.ShowEntryFees(entryFees.Where(ef => !ef.Deleted).ToDictionary(ef => ef.Id, ef => ef.Name));
        }
    }
}
