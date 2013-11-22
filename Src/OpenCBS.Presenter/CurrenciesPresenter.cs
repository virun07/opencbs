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

using OpenCBS.DataContract.CommandData;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;

namespace OpenCBS.Presenter
{
    public class CurrenciesPresenter : ICurrenciesPresenter, ICurrenciesPresenterCallbacks
    {
        private readonly ICurrenciesView _view;
        private readonly ICurrencyService _currencyService;
        private readonly IApplicationController _appController;
        private readonly IAuthService _authService;

        public CurrenciesPresenter(ICurrenciesView view, ICurrencyService currencyService, IApplicationController appController, IAuthService authService)
        {
            _view = view;
            _currencyService = currencyService;
            _appController = appController;
            _authService = authService;
        }

        public void Run()
        {
            _view.Attach(this);
            Authorize();
            ShowCurrencies();
            _view.Run();
        }

        public object View
        {
            get { return _view; }
        }

        public void Add()
        {
            _appController.Execute(new AddCurrencyData());
        }

        public void Edit()
        {
        }

        public void Delete()
        {
        }

        private void ShowCurrencies()
        {
            var currencies = _currencyService.FindAll();
            _view.ShowCurrencies(currencies);
        }

        private void Authorize()
        {
            _view.AllowAdding = _authService.Can("Currency.Add");
            _view.AllowEditing = _authService.Can("Currency.Edit");
            _view.AllowDeleting = _authService.Can("Currency.Delete");
        }
    }
}
