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
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;
using OpenCBS.Interfaces;

namespace OpenCBS.GUI.Presenter
{
    public class EntryFeesPresenter : IEntryFeesPresenter, IEntryFeesPresenterCallbacks
    {
        private readonly IEntryFeeService _entryFeeService;
        private readonly IApplicationController _appController;
        private readonly IEntryFeesView _view;

        public EntryFeesPresenter(IEntryFeesView view, IApplicationController appController, IEntryFeeService entryFeeService)
        {
            _view = view;
            _appController = appController;
            _entryFeeService = entryFeeService;
        }

        public void Run()
        {
            _view.Attach(this);
            _view.Run();
            ShowEntryFees();
        }

        public void Add()
        {
        }

        public void Edit()
        {
        }

        public void Delete()
        {
        }

        public void Refresh()
        {
            ShowEntryFees();
        }

        public void ChangeSelection()
        {
            var entryFee = _view.SelectedEntryFee;
            _view.EditEnabled = _view.DeleteEnabled = entryFee != null;
        }

        public void Close()
        {
            _appController.Unsubscribe(this);
        }

        private void ShowEntryFees()
        {
            var entryFees = _view.ShowDeleted
                                ? _entryFeeService.FindAll()
                                : _entryFeeService.FindAll().Where(ef => !ef.Deleted).ToList();
            _view.ShowEntryFees(entryFees);
        }
    }
}
