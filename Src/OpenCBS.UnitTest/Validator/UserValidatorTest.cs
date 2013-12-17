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
    public class UserValidatorTest
    {
        private UserValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new UserValidator();
        }

        [Test]
        public void Validate_UserIsEmpty_ConsidersInvalid()
        {
            var userDto = new UserDto();
            _validator.Validate(userDto);
            Assert.AreEqual(4, userDto.Notification.Count);
        }

        [Test]
        public void Validate_PasswordsDoNotMatch_ConsidersInvalid()
        {
            var userDto = new UserDto
            {
                FirstName = "Homer",
                LastName = "Simpson",
                Username = "homer",
                Password = "doh",
                PasswordConfirmation = ""
            };
            _validator.Validate(userDto);
            Assert.AreEqual(1, userDto.Notification.Count);
        }

        [Test]
        public void Validate_UserIsValid_ConsidersValid()
        {
            var userDto = new UserDto
            {
                FirstName = "Homer",
                LastName = "Simpson",
                Username = "homer",
                Password = "doh",
                PasswordConfirmation = "doh"
            };
            _validator.Validate(userDto);
            Assert.AreEqual(0, userDto.Notification.Count);
        }
    }
}
// ReSharper restore InconsistentNaming
