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
using System.Linq;
using Omu.ValueInjecter;
using OpenCBS.DataContract;
using OpenCBS.DataContract.AppEvent;
using OpenCBS.DataContract.CommandData;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;

namespace OpenCBS.GUI.Presenter
{
    public class LoanProductPresenter : ILoanProductPresenter, ILoanProductPresenterCallbacks,
        IEventHandler<EntryFeeSelectedEvent>
    {
        private readonly ILoanProductView _view;
        private readonly ILoanProductService _loanProductService;
        private readonly IEntryFeeService _entryFeeService;
        private readonly IApplicationController _appController;
        private CommandResult _commandResult = CommandResult.Cancel;

        public LoanProductPresenter(ILoanProductView view, 
            ILoanProductService loanProductService, 
            IEntryFeeService entryFeeService,
            IApplicationController appController)
        {
            _view = view;
            _loanProductService = loanProductService;
            _entryFeeService = entryFeeService;
            _appController = appController;
        }

        public Result<LoanProductDto> Get(LoanProductDto loanProductDto)
        {
            _view.Attach(this);
            var data = _loanProductService.GetReferenceData();
            _view.ShowCurrencies(data.Currencies);
            _view.ShowSchedulePolicies(data.SchedulePolicies);
            _view.ShowPaymentFrequencyPolicies(data.PaymentFrequencyPolicies);
            _view.ShowYearPolicies(data.YearPolicies);
            _view.ShowDateShiftPolicies(data.DateShiftPolicies);
            _view.ShowRoundingPolicies(data.RoundingPolicies);
            _view.ShowLateFeePolicies(data.LateFeePolicies);

            loanProductDto = loanProductDto ?? new LoanProductDto();
            _view.InjectFrom(loanProductDto);
            _view.LoanProductName = loanProductDto.Name;
            _view.EntryFees = loanProductDto.EntryFees ?? new List<EntryFeeDto>();
            
            _view.Run();

            if (_commandResult != CommandResult.Ok)
                return new Result<LoanProductDto>(_commandResult, null);

            return new Result<LoanProductDto>(_commandResult, GetLoanProductDto());
        }

        public object View
        {
            get { return _view; }
        }

        public void Ok()
        {
            var loanProduct = GetLoanProductDto();
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
        {
            var id = _view.SelectedEntryFeeId;
            if (id == null) return;
            var entryFees = _view.EntryFees;
            var entryFee = entryFees.FirstOrDefault(ef => ef.Id == id.Value);
            entryFees.Remove(entryFee);
            _view.EntryFees = entryFees;
        }

        public void Close()
        {
            _appController.Unsubscribe(this);
        }

        public void ChangeSelectedEntryFee()
        {
            _view.CanRemoveEntryFee = _view.SelectedEntryFeeId.HasValue;
        }

        private LoanProductDto GetLoanProductDto()
        {
            var result = new LoanProductDto();
            result.InjectFrom(_view);
            result.Name = _view.LoanProductName;
            result.EntryFees = _view.EntryFees;
            return result;
        }

        public void Handle(EntryFeeSelectedEvent eventData)
        {
            var entryFees = _view.EntryFees;
            if (entryFees.Count(ef => ef.Id == eventData.Id) > 0) return;
            entryFees.Add(_entryFeeService.FindById(eventData.Id));
            _view.EntryFees = entryFees;
        }
    }
}
