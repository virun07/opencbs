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
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;
using OpenCBS.Interfaces;

namespace OpenCBS.GUI.Presenter
{
    public class LoanProductsPresenter : ILoanProductsPresenter, ILoanProductsPresenterCallbacks,
        IEventHandler<LoanProductUpdatedEvent>,
        IEventHandler<LoanProductAddedEvent>,
        IEventHandler<LoanProductDeletedEvent>
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
            var loanProduct = _view.SelectedLoanProduct;
            if (loanProduct == null) return;
            _appController.Execute(new EditLoanProductData { LoanProductDto = loanProduct });
        }

        public void Delete()
        {
            var loanProduct = _view.SelectedLoanProduct;
            if (loanProduct == null) return;
            _appController.Execute(new DeleteLoanProductData { Id = loanProduct.Id });
        }

        public void Refresh()
        {
            ShowLoanProducts();
        }

        public void ChangeSelection()
        {
            var loanProduct = _view.SelectedLoanProduct;
            _view.EditEnabled = _view.DeleteEnabled = loanProduct != null;
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

        public void Handle(LoanProductUpdatedEvent eventData)
        {
            ShowLoanProducts();
        }

        public void Handle(LoanProductAddedEvent eventData)
        {
            ShowLoanProducts();
        }

        public void Handle(LoanProductDeletedEvent eventData)
        {
            ShowLoanProducts();
        }
    }
}
