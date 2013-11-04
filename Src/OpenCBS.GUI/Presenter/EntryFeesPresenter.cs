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
using OpenCBS.GUI.AppEvent;
using OpenCBS.GUI.CommandData;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.Presenter
{
    public class EntryFeesPresenter : IEntryFeesPresenter, IEntryFeesPresenterCallbacks,
        IEventHandler<EntryFeeAddedEvent>,
        IEventHandler<EntryFeeUpdatedEvent>,
        IEventHandler<EntryFeeDeletedEvent>,
        IEventHandler<LanguageChangedEvent>
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
            _appController.Execute(new AddEntryFeeData());
        }

        public void Edit()
        {
            var entryFee = _view.SelectedEntryFee;
            if (entryFee == null) return;
            _appController.Execute(new EditEntryFeeData { EntryFeeDto = entryFee });
        }

        public void Delete()
        {
            var entryFee = _view.SelectedEntryFee;
            if (entryFee == null) return;
            _appController.Execute(new DeleteEntryFeeData { Id = entryFee.Id });
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

        public void Handle(EntryFeeAddedEvent eventData)
        {
            ShowEntryFees();
        }

        public void Handle(EntryFeeUpdatedEvent eventData)
        {
            ShowEntryFees();
        }

        public void Handle(EntryFeeDeletedEvent eventData)
        {
            ShowEntryFees();
        }

        public void Handle(LanguageChangedEvent eventData)
        {
            _view.Translate();
            ShowEntryFees();
        }
    }
}
