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

using System;
using OpenCBS.GUI.NEW.Dto;
using OpenCBS.GUI.NEW.Model;
using OpenCBS.GUI.NEW.Service;
using OpenCBS.GUI.NEW.View.LoanProduct;

namespace OpenCBS.GUI.NEW.Presenter
{
    public class LoanProductPresenter : ILoanProductPresenter, ILoanProductPresenterCallbacks
    {
        private readonly ILoanProductView _view;
        private readonly ILoanProductService _loanProductService;
        private CommandResult _commandResult = CommandResult.Cancel;

        public LoanProductPresenter(ILoanProductView view, ILoanProductService loanProductService)
        {
            _view = view;
            _loanProductService = loanProductService;
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
            ShowLoanProduct(loanProduct);
            _view.Run();
            var newLoanProduct = (LoanProductDto) null;
            if (_commandResult == CommandResult.Ok)
            {
                newLoanProduct = GetLoanProduct();
                if (loanProduct != null)
                {
                    newLoanProduct.Id = loanProduct.Id;
                }
            }
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

        private void ShowLoanProduct(LoanProductDto loanProduct)
        {
            if (loanProduct == null)
            {
                _view.AvailableFor = AvailableFor.Individual | AvailableFor.SolidarityGroup |
                                     AvailableFor.NonSolidarityGroup | AvailableFor.Company;
                return;
            }
            _view.LoanProductName = loanProduct.Name;
            _view.Code = loanProduct.Code;
            _view.PaymentFrequencyPolicy = loanProduct.PaymentFrequencyPolicy;
            _view.AvailableFor = loanProduct.AvailableFor;
            _view.SchedulePolicy = loanProduct.SchedulePolicy;
            _view.YearPolicy = loanProduct.YearPolicy;
            _view.DateShiftPolicy = loanProduct.DateShiftPolicy;
            _view.RoundingPolicy = loanProduct.RoundingPolicy;
            _view.AmountMin = loanProduct.Amount.Item1;
            _view.AmountMax = loanProduct.Amount.Item2;
            _view.InterestRateMin = loanProduct.InterestRate.Item1;
            _view.InterestRateMax = loanProduct.InterestRate.Item2;
            _view.MaturityMin = loanProduct.Maturity.Item1;
            _view.MaturityMax = loanProduct.Maturity.Item2;
            _view.GracePeriodMin = loanProduct.GracePeriod.Item1;
            _view.GracePeriodMax = loanProduct.GracePeriod.Item2;
        }

        private LoanProductDto GetLoanProduct()
        {
            return new LoanProductDto
            {
                Name = _view.LoanProductName,
                Code = _view.Code,
                PaymentFrequencyPolicy = _view.PaymentFrequencyPolicy,
                AvailableFor = _view.AvailableFor,
                SchedulePolicy = _view.SchedulePolicy,
                YearPolicy = _view.YearPolicy,
                DateShiftPolicy = _view.DateShiftPolicy,
                RoundingPolicy = _view.RoundingPolicy,
                Amount = new Tuple<decimal?, decimal?>(_view.AmountMin, _view.AmountMax),
                InterestRate = new Tuple<decimal?, decimal?>(_view.InterestRateMin, _view.InterestRateMax),
                Maturity = new Tuple<int?, int?>(_view.MaturityMin, _view.MaturityMax),
                GracePeriod = new Tuple<int?, int?>(_view.GracePeriodMin, _view.GracePeriodMax)
            };
        }
    }
}
