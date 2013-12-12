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
using NUnit.Framework;
using OpenCBS.Model.Schedule.YearPolicy;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Model.Schedule
{
    [TestFixture]
    public class YearPolicyTest
    {
        [Test]
        public void GetNumberOfDays_ActualYearPolicy_ReturnsNumberOfDaysInYear()
        {
            var yearPolicy = new ActualYearPolicy();
            var nonLeapYearDate = new DateTime(2013, 6, 7);
            var leapYearDate = new DateTime(2012, 6, 7);
            Assert.That(yearPolicy.GetNumberOfDays(nonLeapYearDate), Is.EqualTo(365));
            Assert.That(yearPolicy.GetNumberOfDays(leapYearDate), Is.EqualTo(366));
        }

        [Test]
        public void GetNumberOfDays_ThreeSixtyYearPolicy_Returns360()
        {
            var yearPolicy = new ThreeSixtyYearPolicy();
            var nonLeapYearDate = new DateTime(2013, 6, 7);
            var leapYearDate = new DateTime(2012, 6, 7);
            Assert.That(yearPolicy.GetNumberOfDays(nonLeapYearDate), Is.EqualTo(360));
            Assert.That(yearPolicy.GetNumberOfDays(leapYearDate), Is.EqualTo(360));
        }

        [Test]
        public void GetNumberOfDays_ThreeSixtyFiveYearPolicy_Returns365()
        {
            var yearPolicy = new ThreeSixtyFiveYearPolicy();
            var nonLeapYearDate = new DateTime(2013, 6, 7);
            var leapYearDate = new DateTime(2012, 6, 7);
            Assert.That(yearPolicy.GetNumberOfDays(nonLeapYearDate), Is.EqualTo(365));
            Assert.That(yearPolicy.GetNumberOfDays(leapYearDate), Is.EqualTo(365));
        }
    }
}
// ReSharper restore InconsistentNaming
