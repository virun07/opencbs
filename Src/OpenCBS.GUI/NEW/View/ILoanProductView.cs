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
using OpenCBS.GUI.NEW.Dto;
using OpenCBS.GUI.NEW.Model;
using OpenCBS.GUI.NEW.Presenter;

namespace OpenCBS.GUI.NEW.View
{
    public interface ILoanProductView : IView<ILoanProductPresenterCallbacks>
    {
        void Run();
        void Stop();
        void ShowPaymentFrequencyPolicies(IEnumerable<string> paymentFrequencyPolicies);
        void ShowSchedulePolicies(IEnumerable<string> schedulePolicies);
        void ShowYearPolicies(IEnumerable<string> yearPolicies);
        void ShowDateShiftPolicies(IEnumerable<string> dateShiftPolicies);
        void ShowRoundingPolicies(IEnumerable<string> roundingPolicies);
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
    }
}
