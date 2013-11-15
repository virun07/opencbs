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
using OpenCBS.GUI.CommandData;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.Presenter
{
    public class MainPresenter : IMainPresenter, IMainPresenterCallbacks
    {
        private readonly IMainView _view;
        private readonly IApplicationController _appController;
        private readonly IAuthService _authService;

        public MainPresenter(IMainView view, IApplicationController appController, IAuthService authService)
        {
            _view = view;
            _appController = appController;
            _authService = authService;
        }

        public void ShowRoles()
        {
            _appController.Execute(new ShowRolesData());
        }

        public void ShowUsers()
        {
            _appController.Execute(new ShowUsersData());
        }

        public void ShowLoanProducts()
        {
            _appController.Execute(new ShowLoanProductsData());
        }

        public void ShowEntryFees()
        {
            _appController.Execute(new ShowEntryFeesData());
        }

        public void ChangeLanguage(string name)
        {
            _appController.Execute(new ChangeLanguageData { Name = name });
        }

        public void Run()
        {
            _view.Attach(this);
            Authorize();
            _view.Run();
        }

        public object View
        {
            get { return _view; }
        }

        private bool CanAny(string entity, string ops)
        {
            var permissions = ops.Split(',').Select(op => entity + "." + op.Trim()).ToList().AsReadOnly();
            return _authService.CanAny(permissions);
        }

        private void Authorize()
        {
            _view.AllowEntryFeeManagement = CanAny("EntryFee", "View, Add, Edit, Delete");
            _view.AllowLoanProductManagement = CanAny("LoanProduct", "View, Add, Edit, Delete");
            _view.AllowRoleManagement = CanAny("Role", "View, Add, Edit, Delete");
            _view.AllowUserManagement = CanAny("User", "View, Add, Edit, Delete");
        }
    }
}
