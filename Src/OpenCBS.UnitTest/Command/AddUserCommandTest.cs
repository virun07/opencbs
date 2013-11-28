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
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Service.Command;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Command
{
    [TestFixture]
    public class AddUserCommandTest
    {
        private IUserPresenter _presenter;
        private IUserService _userService;
        private IApplicationController _appController;
        private AddUserCommand _command;
     
        [SetUp]
        public void SetUp()
        {
            _presenter = Substitute.For<IUserPresenter>();
            _userService = Substitute.For<IUserService>();
            _appController = Substitute.For<IApplicationController>();
            _command = new AddUserCommand(_presenter, _userService, _appController);
        }

        [Test]
        public void Execute_CommandResultIsNotOk_DoesNotAddUser()
        {
            _presenter.Get(Arg.Any<UserDto>()).Returns(new Result<UserDto>(CommandResult.Cancel, null));
        }
    }
}
// ReSharper restore InconsistentNaming
