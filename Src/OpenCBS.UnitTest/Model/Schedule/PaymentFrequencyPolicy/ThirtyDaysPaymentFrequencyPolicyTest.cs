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
using OpenCBS.Model.Schedule.PaymentFrequencyPolicy;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Model.Schedule.PaymentFrequencyPolicy
{
    [TestFixture]
    public class ThirtyDaysPaymentFrequencyPolicyTest
    {
        [Test]
        public void GetNextDate_ReturnsCorrectNextDate()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new ThirtyDaysPaymentFrequencyPolicy();
            Assert.AreEqual(new DateTime(2013, 7, 7), policy.GetNextDate(date));
        }

        [Test]
        public void GetPreviousDate_ReturnsCorrectPreviousDate()
        {
            var date = new DateTime(2013, 6, 7);
            var policy = new ThirtyDaysPaymentFrequencyPolicy();
            Assert.AreEqual(new DateTime(2013, 5, 8), policy.GetPreviousDate(date));
        }

        [Test]
        public void GetNumberOfDays_Returns30()
        {
            var policy = new ThirtyDaysPaymentFrequencyPolicy();
            Assert.AreEqual(30, policy.GetNumberOfDays(DateTime.Today));
        }

        [Test]
        public void GetNumberOfPeriodsInYear_Returns12()
        {
            var yearPolicy = Substitute.For<IYearPolicy>();
            yearPolicy.GetNumberOfDays(Arg.Any<DateTime>()).Returns(360);
            var policy = new ThirtyDaysPaymentFrequencyPolicy();
            Assert.AreEqual(12, policy.GetNumberOfPeriodsInYear(DateTime.Today, yearPolicy));
        }
    }
}
// ReSharper restore InconsistentNaming
