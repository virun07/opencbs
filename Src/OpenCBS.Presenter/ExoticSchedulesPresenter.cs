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
    public class ExoticSchedulesPresenter : IExoticSchedulesPresenter, IExoticSchedulesPresenterCallbacks,
        IEventHandler<ExoticScheduleSavedEvent>
    {
        private readonly IExoticSchedulesView _view;
        private readonly IExoticScheduleService _service;
        private readonly IAuthService _authService;
        private readonly IApplicationController _appController;

        public ExoticSchedulesPresenter(IExoticSchedulesView view, IExoticScheduleService service, IAuthService authService, IApplicationController appController)
        {
            _view = view;
            _service = service;
            _authService = authService;
            _appController = appController;
        }

        public void Run()
        {
            _view.Attach(this);
            ShowExoticSchedules();
            _view.AllowAdding = _authService.Can("Configuration.AddExoticSchedule");
            _view.AllowEditing = _authService.Can("Configuration.EditExoticSchedule");
            _view.AllowDeleting = _authService.Can("Configuration.DeleteExoticSchedule");
            _view.Run();
        }

        public void Add()
        {
            _appController.Execute(new AddExoticScheduleData());
        }

        public void Edit()
        {
            var id = _view.SelectedScheduleId;
            if (id == null) return;
            _appController.Execute(new EditExoticScheduleData { Id = id.Value });
        }

        public void Delete()
        {
            var id = _view.SelectedScheduleId;
            if (id == null) return;
            _appController.Execute(new DeleteExoticScheduleData { Id = id.Value });
        }

        public void Refresh()
        {
            ShowExoticSchedules();
        }

        public void ChangeSelection()
        {
            var id = _view.SelectedScheduleId;
            _view.CanEdit = _view.CanDelete = id != null;
        }

        public void Close()
        {
            _appController.Unsubscribe(this);
        }

        public object View
        {
            get { return _view; }
        }

        private void ShowExoticSchedules()
        {
            var schedules = _view.ShowDeleted
                                ? _service.FindAll()
                                : _service.FindAll().Where(x => !x.Deleted).ToList().AsReadOnly();
            _view.ShowExoticSchedules(schedules);
        }

        public void Handle(ExoticScheduleSavedEvent eventData)
        {
            ShowExoticSchedules();
        }
    }
}
