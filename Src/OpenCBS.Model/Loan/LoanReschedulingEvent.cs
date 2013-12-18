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
using Newtonsoft.Json;

namespace OpenCBS.Model.Loan
{
    public class LoanReschedulingEvent : LoanEvent
    {
        public decimal InterestRate { get; set; }
        public int Maturity { get; set; }
        public int GracePeriod { get; set; }
        public bool ChargeInterestDuringGracePeriod { get; set; }
        public DateTime FirstRepaymentDate { get; set; }

        private class Data
        {
            public decimal InterestRate { get; set; }
            public int Maturity { get; set; }
            public int GracePeriod { get; set; }
            public bool ChargeInterestDuringGracePeriod { get; set; }
            public DateTime FirstRepaymentDate { get; set; }
        }

        public override string Serialize()
        {
            var data = new Data
            {
                InterestRate = InterestRate,
                Maturity = Maturity,
                GracePeriod = GracePeriod,
                ChargeInterestDuringGracePeriod = ChargeInterestDuringGracePeriod,
                FirstRepaymentDate = FirstRepaymentDate
            };
            return JsonConvert.SerializeObject(data);
        }

        public override void Deserialize(string text)
        {
            var data = JsonConvert.DeserializeObject<Data>(text);
            InterestRate = data.InterestRate;
            Maturity = data.Maturity;
            GracePeriod = data.GracePeriod;
            ChargeInterestDuringGracePeriod = data.ChargeInterestDuringGracePeriod;
            FirstRepaymentDate = data.FirstRepaymentDate;
        }
    }
}
