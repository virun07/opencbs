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
using OpenCBS.Common;
using OpenCBS.DataContract;
using OpenCBS.Interface.Presenter;

namespace OpenCBS.Interface.View
{
    public interface ILoanProductView : IView<ILoanProductPresenterCallbacks>
    {
        void Run();
        void Stop();
        void ShowPaymentFrequencyPolicies(IList<string> paymentFrequencyPolicies);
        void ShowSchedulePolicies(IList<string> schedulePolicies);
        void ShowYearPolicies(IList<string> yearPolicies);
        void ShowDateShiftPolicies(IList<string> dateShiftPolicies);
        void ShowRoundingPolicies(IList<string> roundingPolicies);
        void ShowCurrencies(Dictionary<int, string> currencies);
        void ShowNotification(Notification notification);

        string LoanProductName { get; set; }
        string Code { get; set; }
        AvailableFor AvailableFor { get; set; }
        string PaymentFrequencyPolicy { get; set; }
        string SchedulePolicy { get; set; }
        string YearPolicy { get; set; }
        string DateShiftPolicy { get; set; }
        string RoundingPolicy { get; set; }

        decimal? AmountMin { get; set; }
        decimal? AmountMax { get; set; }
        decimal? InterestRateMin { get; set; }
        decimal? InterestRateMax { get; set; }
        int? MaturityMin { get; set; }
        int? MaturityMax { get; set; }
        int? GracePeriodMin { get; set; }
        int? GracePeriodMax { get; set; }
        bool ChargeInterestDuringGracePeriod { get; set; }

        IList<EntryFeeDto> EntryFees { get; set; }
    }
}
