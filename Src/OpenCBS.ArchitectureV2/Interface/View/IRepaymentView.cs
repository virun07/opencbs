using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.CoreDomain.Contracts.Loans.Installments;

namespace OpenCBS.ArchitectureV2.Interface.View
{
    public interface IRepaymentView : IView<IRepaymentPresenterCallbacks>
    {
        void Run();
        void Stop();

        List<Installment> Installments { get; set; }
        List<string> RepaymentScripts { get; set; }
        decimal Amount { get; set; }
        decimal Principal { get; set; }
        decimal Interest { get; set; }
        decimal Penalty { get; set; }
        decimal Commission { get; set; }
        DateTime Date { get; set; }
        bool OkButtonEnabled { get; set; }
        string Comment { get; set; }
        string Title { get; set; }
        string SelectedScript { get; set; }
    }
}
