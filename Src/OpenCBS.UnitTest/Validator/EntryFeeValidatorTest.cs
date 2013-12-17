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
    public class EntryFeeValidatorTest
    {
        private EntryFeeValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new EntryFeeValidator();
        }

        [Test]
        public void Validate_EntryFeeIsEmpty_ConsidersInvalid()
        {
            var entryFeeDto = new EntryFeeDto();
            _validator.Validate(entryFeeDto);
            Assert.AreEqual(4, entryFeeDto.Notification.Count);
        }

        [Test]
        public void Validate_CodeIsNotAlphanumeric_ConsidersInvalid()
        {
            var entryFeeDto = new EntryFeeDto
            {
                Name = "Loan Processing Fee",
                Code = "L P F",
                ValueMin = 100,
                ValueMax = 200,
                Rate = false
            };
            _validator.Validate(entryFeeDto);
            Assert.AreEqual(1, entryFeeDto.Notification.Count);
        }

        [Test]
        public void Validate_EntryFeeIsValid_ConsidersValid()
        {
            var entryFeeDto = new EntryFeeDto
            {
                Name = "Loan Processing Fee",
                Code = "LPF",
                ValueMin = 100,
                ValueMax = 200,
                Rate = false
            };
            _validator.Validate(entryFeeDto);
            Assert.AreEqual(0, entryFeeDto.Notification.Count);
        }
    }
}
// ReSharper restore InconsistentNaming
