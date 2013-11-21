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
using OpenCBS.DataContract.AppEvent;
using OpenCBS.DataContract.CommandData;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;

namespace OpenCBS.Presenter
{
    public class EntryFeesPresenter : IEntryFeesPresenter, IEntryFeesPresenterCallbacks,
        IEventHandler<EntryFeeSavedEvent>,
        IEventHandler<EntryFeeDeletedEvent>,
        IEventHandler<LanguageChangedEvent>
    {
        private readonly IEntryFeeService _entryFeeService;
        private readonly IApplicationController _appController;
        private readonly IEntryFeesView _view;
        private readonly IAuthService _authService;

        public EntryFeesPresenter(IEntryFeesView view, IApplicationController appController, IEntryFeeService entryFeeService, IAuthService authService)
        {
            _view = view;
            _appController = appController;
            _entryFeeService = entryFeeService;
            _authService = authService;
        }

        public void Run()
        {
            _view.Attach(this);
            _view.AllowAdding = _authService.Can("EntryFee.Add");
            _view.AllowEditing = _authService.Can("EntryFee.Edit");
            _view.AllowDeleting = _authService.Can("EntryFee.Delete");
            ShowEntryFees();
            _view.Run();
        }

        public void Add()
        {
            _appController.Execute(new AddEntryFeeData());
        }

        public void Edit()
        {
            var id = _view.SelectedEntryFeeId;
            if (id == null) return;
            _appController.Execute(new EditEntryFeeData { Id = id.Value });
        }

        public void Delete()
        {
            var id = _view.SelectedEntryFeeId;
            if (id == null) return;
            _appController.Execute(new DeleteEntryFeeData { Id = id.Value });
        }

        public void Refresh()
        {
            ShowEntryFees();
        }

        public void ChangeSelection()
        {
            var id = _view.SelectedEntryFeeId;
            _view.EditEnabled = _view.DeleteEnabled = id.HasValue;
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

        public void Handle(EntryFeeSavedEvent eventData)
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
