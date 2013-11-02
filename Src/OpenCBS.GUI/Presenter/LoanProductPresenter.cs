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

using System.Collections.Generic;
using Omu.ValueInjecter;
using OpenCBS.DataContract;
using OpenCBS.GUI.CommandData;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;
using OpenCBS.Interfaces;

namespace OpenCBS.GUI.Presenter
{
    public class LoanProductPresenter : ILoanProductPresenter, ILoanProductPresenterCallbacks
    {
        private readonly ILoanProductView _view;
        private readonly ILoanProductService _loanProductService;
        private readonly IApplicationController _appController;
        private CommandResult _commandResult = CommandResult.Cancel;

        public LoanProductPresenter(ILoanProductView view, ILoanProductService loanProductService, IApplicationController appController)
        {
            _view = view;
            _loanProductService = loanProductService;
            _appController = appController;
        }

        public Result<LoanProductDto> Get(LoanProductDto loanProduct)
        {
            _view.Attach(this);
            var data = _loanProductService.GetReferenceData();
            _view.ShowSchedulePolicies(data.SchedulePolicies);
            _view.ShowPaymentFrequencyPolicies(data.PaymentFrequencyPolicies);
            _view.ShowYearPolicies(data.YearPolicies);
            _view.ShowDateShiftPolicies(data.DateShiftPolicies);
            _view.ShowRoundingPolicies(data.RoundingPolicies);
            _view.ShowCurrencies(data.Currencies);
            
            _view.InjectFrom(loanProduct ?? new LoanProductDto());
            _view.LoanProductName = loanProduct != null ? loanProduct.Name : string.Empty;
            _view.EntryFees = loanProduct != null ? loanProduct.EntryFees : new List<EntryFeeDto>();
            
            _view.Run();

            if (_commandResult != CommandResult.Ok)
                return new Result<LoanProductDto>(_commandResult, null);

            var newLoanProduct = GetLoanProduct();
            newLoanProduct.Id = loanProduct != null ? loanProduct.Id : 0;
            return new Result<LoanProductDto>(_commandResult, newLoanProduct);
        }

        public object View
        {
            get { return _view; }
        }

        public void Ok()
        {
            var loanProduct = GetLoanProduct();
            _loanProductService.Validate(loanProduct);
            if (loanProduct.Notification.HasErrors)
            {
                _view.ShowNotification(loanProduct.Notification);
            }
            else
            {
                _commandResult = CommandResult.Ok;
                _view.Stop();
            }
        }

        public void Cancel()
        {
            _commandResult = CommandResult.Cancel;
            _view.Stop();
        }

        public void AddEntryFee()
        {
            _appController.Execute(new SelectEntryFeeData());
        }

        public void RemoveEntryFee()
        {}

        private LoanProductDto GetLoanProduct()
        {
            var result = new LoanProductDto();
            result.InjectFrom(_view);
            result.Name = _view.LoanProductName;
            return result;
        }
    }
}
