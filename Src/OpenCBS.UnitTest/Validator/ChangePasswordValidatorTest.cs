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
using OpenCBS.DataContract;
using OpenCBS.Interface.Repository;
using OpenCBS.Service.Validator;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Validator
{
    [TestFixture]
    public class ChangePasswordValidatorTest
    {
        private IUserRepository _userRepository;
        private ChangePasswordValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _validator = new ChangePasswordValidator(_userRepository);
        }

        [Test]
        public void Validate_Empty_ConsidersInvalid()
        {
            var dto = new ChangePasswordDto { Id = 1 };
            _validator.Validate(dto);
            Assert.AreEqual(2, dto.Notification.Count);
        }

        [Test]
        public void Validate_InvalidPassword_ConsidersInvalid()
        {
            var dto = new ChangePasswordDto
            {
                Id = 1, 
                CurrentPassword = "test", 
                NewPassword = "new", 
                NewPasswordConfirmation = "new"
            };
            _userRepository.UserExists(1, "test").Returns(false);
            _validator.Validate(dto);
            Assert.AreEqual(1, dto.Notification.Count);
        }

        [Test]
        public void Validate_PasswordsDoNotMatch_ConsidersInvalid()
        {
            var dto = new ChangePasswordDto
            {
                Id = 1,
                CurrentPassword = "test",
                NewPassword = "new",
                NewPasswordConfirmation = ""
            };
            _userRepository.UserExists(1, "test").Returns(true);
            _validator.Validate(dto);
            Assert.AreEqual(1, dto.Notification.Count);
        }

        [Test]
        public void Validate_Valid_ConsidersValid()
        {
            var dto = new ChangePasswordDto
            {
                Id = 1,
                CurrentPassword = "test",
                NewPassword = "new",
                NewPasswordConfirmation = "new"
            };
            _userRepository.UserExists(1, "test").Returns(true);
            _validator.Validate(dto);
            Assert.AreEqual(0, dto.Notification.Count);
        }
    }
}
// ReSharper restore InconsistentNaming
