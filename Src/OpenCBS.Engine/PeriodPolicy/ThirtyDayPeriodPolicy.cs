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
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.PeriodPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "30 days")]
    public class ThirtyDayPeriodPolicy : IPeriodPolicy
    {
        public DateTime GetNextDate(DateTime date)
        {
            return date.AddDays(30);
        }

        public DateTime GetPreviousDate(DateTime date)
        {
            return date.AddDays(-30);
        }

        public int GetNumberOfDays(DateTime date)
        {
            return 30;
        }

        public double GetNumberOfPeriodsInYear(DateTime date, IYearPolicy yearPolicy)
        {
            return (double)yearPolicy.GetNumberOfDays(date) / 30;
        }
    }
}
