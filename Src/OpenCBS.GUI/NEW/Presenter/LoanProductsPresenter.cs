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

using OpenCBS.GUI.NEW.AppController;
using OpenCBS.GUI.NEW.CommandData;
using OpenCBS.GUI.NEW.Repository;
using OpenCBS.GUI.NEW.View;

namespace OpenCBS.GUI.NEW.Presenter
{
    public class LoanProductsPresenter : ILoanProductsPresenter, ILoanProductsPresenterCallbacks
    {
        private readonly ILoanProductsView _view;
        private readonly IApplicationController _appController;
        private readonly ILoanProductRepository _loanProductRepository;

        public LoanProductsPresenter(ILoanProductsView view, IApplicationController appController, ILoanProductRepository loanProductRepository)
        {
            _view = view;
            _appController = appController;
            _loanProductRepository = loanProductRepository;
        }

        public void OnAdd()
        {
            _appController.Execute(new AddLoanProductData());
        }

        public void OnEdit()
        {
            var loanProduct = _view.SelectedLoanProduct;
            if (loanProduct == null) return;
            _appController.Execute(new EditLoanProductData { LoanProduct = loanProduct });
        }

        public void OnDelete()
        {
        }

        public void OnSelectionChanged()
        {
            var loanProduct = _view.SelectedLoanProduct;
            _view.EditEnabled = _view.DeleteEnabled = loanProduct != null;
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
            var loanProducts = _loanProductRepository.FindAll();
            _view.ShowLoanProducts(loanProducts);
        }
    }
}
