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
using NSubstitute;
using NUnit.Framework;
using OpenCBS.Model.Interface;
using OpenCBS.Model.Schedule.DateShiftPolicy;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Model.Schedule.DateShiftPolicy
{
    [TestFixture]
    public class ForwardDateShiftPolicyTest
    {
        [Test]
        [ExpectedException(typeof(NullReferenceException), ExpectedMessage = "Non-working day policy is null.")]
        public void ShiftDate_NonWorkingDayPolicyIsNull_ThrowsException()
        {
            var dateShiftPolicy = new ForwardDateShiftPolicy(null);
            dateShiftPolicy.ShiftDate(DateTime.Today);
        }

        [Test]
        public void ShiftDate_FirstOfJanuaryIsHoliday_ReturnsSecondOfJanuary()
        {
            var holidayPolicy = Substitute.For<INonWorkingDayPolicy>();
            var firstOfJanuary = new DateTime(2013, 1, 1);
            holidayPolicy.IsNonWorkingDay(firstOfJanuary).Returns(true);
            var dateShiftPolicy = new ForwardDateShiftPolicy(holidayPolicy);
            var secondOfJanuary = new DateTime(2013, 1, 2);
            Assert.That(dateShiftPolicy.ShiftDate(firstOfJanuary), Is.EqualTo(secondOfJanuary));
        }

        [Test]
        public void ShiftDate_SaturdayAndSundayAreWeekends_ReturnsMonday()
        {
            var saturday = new DateTime(2013, 6, 8);
            var sunday = new DateTime(2013, 6, 9);
            var monday = new DateTime(2013, 6, 10);
            var weekendPolicy = Substitute.For<INonWorkingDayPolicy>();
            weekendPolicy.IsNonWorkingDay(saturday).Returns(true);
            weekendPolicy.IsNonWorkingDay(sunday).Returns(true);
            var dateShiftPolicy = new ForwardDateShiftPolicy(weekendPolicy);
            Assert.That(dateShiftPolicy.ShiftDate(saturday), Is.EqualTo(monday));
        }
    }
}
// ReSharper restore InconsistentNaming
