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

using NSubstitute;
using NUnit.Framework;
using OpenCBS.Model.Interface;
using OpenCBS.Model.Schedule.DateShiftPolicy;
using OpenCBS.Model.Schedule.LateFeePolicy;
using OpenCBS.Model.Schedule.PaymentFrequencyPolicy;
using OpenCBS.Model.Schedule.RoundingPolicy;
using OpenCBS.Model.Schedule.SchedulePolicy;
using OpenCBS.Model.Schedule.YearPolicy;
using OpenCBS.Service;
using StructureMap;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.IoCContainer
{
    public class PolicyFactoryTest
    {
        private PolicyFactory _factory;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            var container = new Container(new PolicyRegistry());
            container.Inject(Substitute.For<INonWorkingDayPolicy>());
            _factory = new PolicyFactory(container);
        }

        [Test]
        public void GetLateFeePolicyNames_ReturnsNames()
        {
            var names = _factory.GetLateFeePolicyNames();
            Assert.That(names, Is.EqualTo(new[] { "Always accrue" }));
        }

        [Test]
        public void GetLateFeePolicy_AlwaysAccrue_ReturnsProperInstance()
        {
            var policy = _factory.GetLateFeePolicy("Always accrue");
            Assert.IsInstanceOf<DefaultLateFeePolicy>(policy);
        }

        [Test]
        public void GetPaymentFrequencyPolicyNames_ReturnsNames()
        {
            var names = _factory.GetPaymentFrequencyPolicyNames();
            Assert.That(names, Is.EqualTo(new[] { "Daily", "Weekly", "Biweekly", "30 days", "Monthly", "Monthly (30 day)" }));
        }

        [Test]
        public void GetPaymentFrequencyPolicy_Daily_ReturnsProperInstance()
        {
            var policy = _factory.GetPaymentFrequencyPolicy("Daily");
            Assert.IsInstanceOf<DailyPaymentFrequencyPolicy>(policy);
        }

        [Test]
        public void GetPaymentFrequencyPolicy_Weekly_ReturnsProperInstance()
        {
            var policy = _factory.GetPaymentFrequencyPolicy("Weekly");
            Assert.IsInstanceOf<WeeklyPaymentFrequencyPolicy>(policy);
        }

        [Test]
        public void GetPaymentFrequencyPolicy_Biweekly_ReturnsProperInstance()
        {
            var policy = _factory.GetPaymentFrequencyPolicy("Biweekly");
            Assert.IsInstanceOf<BiweeklyPaymentFrequencyPolicy>(policy);
        }

        [Test]
        public void GetPaymentFrequencyPolicy_30Days_ReturnsProperInstance()
        {
            var policy = _factory.GetPaymentFrequencyPolicy("30 days");
            Assert.IsInstanceOf<ThirtyDaysPaymentFrequencyPolicy>(policy);
        }

        [Test]
        public void GetPaymentFrequencyPolicy_Monthly_ReturnsProperInstance()
        {
            var policy = _factory.GetPaymentFrequencyPolicy("Monthly");
            Assert.IsInstanceOf<MonthlyPaymentFrequencyPolicy>(policy);
        }

        [Test]
        public void GetPaymentFrequencyPolicy_Monthly30Days_ReturnsProperInstance()
        {
            var policy = _factory.GetPaymentFrequencyPolicy("Monthly (30 day)");
            Assert.IsInstanceOf<Monthly30DayPaymentFrequencyPolicy>(policy);
        }

        [Test]
        public void GetYearPolicyNames_ReturnsNames()
        {
            var names = _factory.GetYearPolicyNames();
            Assert.That(names, Is.EquivalentTo(new[] { "Actual", "360 days", "365 days" }));
        }

        [Test]
        public void GetYearPolicy_Actual_ReturnsProperInstance()
        {
            var policy = _factory.GetYearPolicy("Actual");
            Assert.IsInstanceOf<ActualYearPolicy>(policy);
        }

        [Test]
        public void GetYearPolicy_360days_ReturnsProperInstance()
        {
            var policy = _factory.GetYearPolicy("360 days");
            Assert.IsInstanceOf<ThreeSixtyYearPolicy>(policy);
        }

        [Test]
        public void GetYearPolicy_365days_ReturnsProperInstance()
        {
            var policy = _factory.GetYearPolicy("365 days");
            Assert.IsInstanceOf<ThreeSixtyFiveYearPolicy>(policy);
        }

        [Test]
        public void GetRoundingPolicyNames_ReturnsNames()
        {
            var names = _factory.GetRoundingPolicyNames();
            Assert.That(names, Is.EquivalentTo(new[] { "Whole", "Two decimals" }));
        }

        [Test]
        public void GetRoundingPolicy_Whole_ReturnsProperInstance()
        {
            var policy = _factory.GetRoundingPolicy("Whole");
            Assert.IsInstanceOf<WholeRoundingPolicy>(policy);
        }

        [Test]
        public void GetRoundingPolicy_TwoDecimals_ReturnsProperInstance()
        {
            var policy = _factory.GetRoundingPolicy("Two decimals");
            Assert.IsInstanceOf<TwoDecimalsRoundingPolicy>(policy);
        }

        [Test]
        public void GetDateShiftPolicyNames_ReturnsNames()
        {
            var names = _factory.GetDateShiftPolicyNames();
            Assert.That(names, Is.EquivalentTo(new[] { "No shift", "Forward", "Backward" }));
        }

        [Test]
        public void GetDateShiftPolicy_NoShift_ReturnsProperInstance()
        {
            var policy = _factory.GetDateShiftPolicy("No shift");
            Assert.IsInstanceOf<NoDateShiftPolicy>(policy);
        }

        [Test]
        public void GetDateShiftPolicy_Forward_ReturnsProperInstance()
        {
            var policy = _factory.GetDateShiftPolicy("Forward");
            Assert.IsInstanceOf<ForwardDateShiftPolicy>(policy);
        }

        [Test]
        public void GetDateShiftPolicy_Backward_ReturnsProperInstance()
        {
            var policy = _factory.GetDateShiftPolicy("Backward");
            Assert.IsInstanceOf<BackwardDateShiftPolicy>(policy);
        }

        [Test]
        public void GetSchedulePolicyNames_ReturnsNames()
        {
            var names = _factory.GetSchedulePolicyNames();
            Assert.That(names, Is.EquivalentTo(new[] { "Flat", "Declining balance", "Declining balance (equal payments)" }));
        }

        [Test]
        public void GetSchedulePolicy_Flat_ReturnsProperInstance()
        {
            var policy = _factory.GetSchedulePolicy("Flat");
            Assert.IsInstanceOf<FlatSchedulePolicy>(policy);
        }

        [Test]
        public void GetSchedulePolicy_DecliningBalance_ReturnsProperInstance()
        {
            var policy = _factory.GetSchedulePolicy("Declining balance");
            Assert.IsInstanceOf<DecliningBalanceSchedulePolicy>(policy);
        }

        [Test]
        public void GetSchedulePolicy_DecliningBalanceEqualPayments_ReturnsProperInstance()
        {
            var policy = _factory.GetSchedulePolicy("Declining balance (equal payments)");
            Assert.IsInstanceOf<DecliningBalanceEqualPaymentsSchedulePolicy>(policy);
        }
    }
}
// ReSharper restore InconsistentNaming
