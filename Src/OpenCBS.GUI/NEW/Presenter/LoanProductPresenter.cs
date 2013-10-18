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

using OpenCBS.GUI.NEW.Model;
using OpenCBS.GUI.NEW.Repository;
using OpenCBS.GUI.NEW.View;

namespace OpenCBS.GUI.NEW.Presenter
{
    public class LoanProductPresenter : ILoanProductPresenter, ILoanProductPresenterCallbacks
    {
        private readonly ILoanProductView _view;
        private readonly IPaymentFrequencyRepository _paymentFrequencyRepository;
        private CommandResult _commandResult = CommandResult.Cancel;

        public LoanProductPresenter(ILoanProductView view, IPaymentFrequencyRepository paymentFrequencyRepository)
        {
            _view = view;
            _paymentFrequencyRepository = paymentFrequencyRepository;
        }

        public Result<LoanProduct> Get(LoanProduct loanProduct)
        {
            _view.Attach(this);
            _view.ShowPaymentFrequencies(_paymentFrequencyRepository.FindAll());
            ShowLoanProduct(loanProduct);
            _view.Run();
            var newLoanProduct = (LoanProduct) null;
            if (_commandResult == CommandResult.Ok)
            {
                newLoanProduct = GetLoanProduct();
                if (loanProduct != null)
                {
                    newLoanProduct.Id = loanProduct.Id;
                }
            }
            return new Result<LoanProduct>(_commandResult, newLoanProduct);
        }

        public object View
        {
            get { return _view; }
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

        private void ShowLoanProduct(LoanProduct loanProduct)
        {
            if (loanProduct == null)
            {
                _view.AvailableFor = AvailableFor.Individual | AvailableFor.SolidarityGroup |
                                     AvailableFor.NonSolidarityGroup | AvailableFor.Company;
                return;
            }
            _view.LoanProductName = loanProduct.Name;
            _view.Code = loanProduct.Code;
            _view.PaymentFrequency = loanProduct.PaymentFrequency;
            _view.AvailableFor = loanProduct.AvailableFor;
        }

        private LoanProduct GetLoanProduct()
        {
            return new LoanProduct
            {
                Name = _view.LoanProductName,
                Code = _view.Code,
                PaymentFrequency = _view.PaymentFrequency,
                AvailableFor = _view.AvailableFor
            };
        }
    }
}
