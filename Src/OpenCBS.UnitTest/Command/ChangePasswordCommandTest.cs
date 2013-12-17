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
using OpenCBS.DataContract.CommandData;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Service.Command;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Command
{
    [TestFixture]
    public class ChangePasswordCommandTest
    {
        private IChangePasswordPresenter _presenter;
        private IUserService _userService;
        private ChangePasswordCommand _command;

        [SetUp]
        public void SetUp()
        {
            _presenter = Substitute.For<IChangePasswordPresenter>();
            _userService = Substitute.For<IUserService>();
            _command = new ChangePasswordCommand(_presenter, _userService);
        }

        [Test]
        public void Execute_CommandResultIsNotOk_DoesNotChangePassword()
        {
            _presenter.Get(Arg.Any<int>()).Returns(new Result<PasswordDto>(CommandResult.Cancel, null));
            _command.Execute(new ChangePasswordData { UserId = 1 });
            _userService.DidNotReceive().ChangePassword(1, Arg.Any<string>());
        }

        [Test]
        public void Execute_CommandResultIsOk_ChangesPassword()
        {
            var dto = new PasswordDto
            {
                Id = 1,
                NewPassword = "test"
            };
            UserDto.Current = new UserDto { Id = 1 };
            _presenter.Get(Arg.Is<int>(id => id == 1)).Returns(new Result<PasswordDto>(CommandResult.Ok, dto));
            _command.Execute(new ChangePasswordData { UserId = 1 });
            _userService.Received().ChangeMyPassword("test");
        }

        [Test]
        public void Execute_CommandResultIsOkAndDifferentUser_ChangesPassword()
        {
            var dto = new PasswordDto
            {
                Id = 2,
                NewPassword = "test"
            };
            UserDto.Current = new UserDto { Id = 1 };
            _presenter.Get(Arg.Is<int>(id => id == 1)).Returns(new Result<PasswordDto>(CommandResult.Ok, dto));
            _command.Execute(new ChangePasswordData { UserId = 1 });
            _userService.Received().ChangePassword(2, "test");
        }
    }
}
// ReSharper restore InconsistentNaming
