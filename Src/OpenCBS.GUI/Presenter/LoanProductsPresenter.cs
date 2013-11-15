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

namespace OpenCBS.GUI.Presenter
{
    public class LoanProductsPresenter : ILoanProductsPresenter, ILoanProductsPresenterCallbacks,
        IEventHandler<LoanProductSavedEvent>,
        IEventHandler<LoanProductDeletedEvent>,
        IEventHandler<LanguageChangedEvent>
    {
        private readonly ILoanProductsView _view;
        private readonly IApplicationController _appController;
        private readonly ILoanProductService _loanProductService;

        public LoanProductsPresenter(ILoanProductsView view, IApplicationController appController, ILoanProductService loanProductService)
        {
            _view = view;
            _appController = appController;
            _loanProductService = loanProductService;
        }

        public void Add()
        {
            _appController.Execute(new AddLoanProductData());
        }

        public void Edit()
        {
            var id = _view.SelectedLoanProductId;
            if (id == null) return;
            _appController.Execute(new EditLoanProductData { Id = id.Value });
        }

        public void Delete()
        {
            var id = _view.SelectedLoanProductId;
            if (id == null) return;
            _appController.Execute(new DeleteLoanProductData { Id = id.Value });
        }

        public void Refresh()
        {
            ShowLoanProducts();
        }

        public void ChangeSelection()
        {
            var id = _view.SelectedLoanProductId;
            _view.CanEdit = _view.CanDelete = id != null;
        }

        public void Close()
        {
            _appController.Unsubscribe(this);
        }

        public void Run()
        {
            _view.Attach(this);
            _view.Run();
            ShowLoanProducts();
        }

        public object View
        {
            get { return _view; }
        }

        private void ShowLoanProducts()
        {
            var loanProducts = _view.ShowDeleted
                                   ? _loanProductService.FindAll()
                                   : _loanProductService.FindAll().Where(lp => !lp.Deleted).ToList();
            _view.ShowLoanProducts(loanProducts);
        }

        public void Handle(LoanProductSavedEvent eventData)
        {
            ShowLoanProducts();
        }

        public void Handle(LoanProductDeletedEvent eventData)
        {
            ShowLoanProducts();
        }

        public void Handle(LanguageChangedEvent eventData)
        {
            _view.Translate();
            ShowLoanProducts();
        }
    }
}
