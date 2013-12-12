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

using NUnit.Framework;
using OpenCBS.DataContract;
using OpenCBS.Service.Validator;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Validator
{
    [TestFixture]
    public class LoanProductValidatorTest
    {
        private LoanProductValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new LoanProductValidator();
        }

        [Test]
        public void Validate_LoanProudctIsEmpty_ClassifiesAsInvalid()
        {
            var loanProductDto = new LoanProductDto();
            _validator.Validate(loanProductDto);
            Assert.AreEqual(26, loanProductDto.Notification.Count);
        }

        [Test]
        public void Validate_LoanProductIsValid_ClassifiesAsValid()
        {
            var loanProductDto = new LoanProductDto
            {
                Name = "Express Loan",
                Code = "EXPRESS",
                SchedulePolicy = "Flat",
                PaymentFrequencyPolicy = "Monthly",
                YearPolicy = "Actual",
                DateShiftPolicy = "Forward",
                RoundingPolicy = "Two decimals",
                AmountMin = 10000,
                AmountMax = 100000,
                InterestRateMin = 24,
                InterestRateMax = 36,
                MaturityMin = 6,
                MaturityMax = 24,
                GracePeriodMin = 0,
                GracePeriodMax = 2,
                CurrencyId = 1,
                LateFeeAmountRateMin = 0,
                LateFeeAmountRateMax = 0,
                LateFeeOlbRateMin = 0,
                LateFeeOlbRateMax = 0,
                LateFeeLatePrincipalRateMin = 0,
                LateFeeLatePrincipalRateMax = 0,
                LateFeeLateInterestRateMin = 0,
                LateFeeLateInterestRateMax = 0,
                LateFeeGracePeriod = 0,
                LateFeePolicy = "Always accrue"
            };
            _validator.Validate(loanProductDto);
            Assert.AreEqual(0, loanProductDto.Notification.Count);
        }
    }
}
// ReSharper restore InconsistentNaming
