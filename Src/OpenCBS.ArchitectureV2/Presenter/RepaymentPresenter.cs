using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.ArchitectureV2.Service;
using OpenCBS.CoreDomain.Contracts.Loans;

namespace OpenCBS.ArchitectureV2.Presenter
{
    public class RepaymentPresenter : IRepaymentPresenter, IRepaymentPresenterCallbacks
    {
        private readonly IRepaymentView _view;
        private readonly IErrorView _errorView;
        private readonly IRepaymentService _repaymentService;
        private readonly IBackgroundTaskFactory _backgroundTaskFactory;

        public RepaymentPresenter(
            IRepaymentView view,
            IErrorView errorView,
            IRepaymentService repaymentService,
            IBackgroundTaskFactory backgroundTaskFactory)
        {
            _view = view;
            _errorView = errorView;
            _repaymentService = repaymentService;
            _backgroundTaskFactory = backgroundTaskFactory;
        }

        public object View { get { return _view; } }

        public void Run()
        {
            _view.Attach(this);
        }

        public void OnRepay()
        {
            SetSettings();
            _repaymentService.RepayAndSave();
            _view.Stop();
        }

        public void OnRefresh()
        {
            SetSettings();
            _repaymentService.Repay();
            _view.Installments = _repaymentService.Settings.Loan.InstallmentList;
            _view.Amount = _repaymentService.Settings.Amount;
            _view.Commission = _repaymentService.Settings.Commission;
            _view.Interest = _repaymentService.Settings.Interest;
            _view.Penalty = _repaymentService.Settings.Penalty;
            _view.Principal = _repaymentService.Settings.Principal;
        }

        private void SetSettings()
        {
            _repaymentService.Settings.Comment = _view.Comment;
            _repaymentService.Settings.Amount = _view.Amount;
            _repaymentService.Settings.Commission = _view.Commission;
            _repaymentService.Settings.Date = _view.Date;
            _repaymentService.Settings.Interest = _view.Interest;
            _repaymentService.Settings.Penalty = _view.Penalty;
            _repaymentService.Settings.Principal = _view.Principal;
            _repaymentService.Settings.ScriptName = _view.SelectedScript;
        }
    }
}
