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
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;
using OpenCBS.Presenter;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Presenter
{
    [TestFixture]
    public class ChangePasswordPresenterTest
    {
        private IChangePasswordView _view;
        private IApplicationController _appController;
        private IUserService _service;
        private ChangePasswordPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<IChangePasswordView>();
            _appController = Substitute.For<IApplicationController>();
            _service = Substitute.For<IUserService>();
            _presenter = new ChangePasswordPresenter(_view, _appController, _service);
        }

        [Test]
        public void Get_RunsView()
        {
            _presenter.Get(1);
            _view.Received().Attach(_presenter);
            _view.Received().Run();
        }

        [Test]
        public void Ok_InvalidInput_ShowsNotification()
        {
            _service
                .When(x => x.ValidateChangePassword(Arg.Any<ChangePasswordDto>()))
                .Do(x =>
                {
                    var notification = new Notification();
                    notification.AddError(new Error());
                    x.Arg<ChangePasswordDto>().Notification = notification;
                });
            _presenter.Ok();
            _view.Received().ShowNotification(Arg.Any<Notification>());
            _view.DidNotReceive().Stop();
        }

        [Test]
        public void Ok_ValidInput_StopsView()
        {
            _service
                .When(x => x.ValidateChangePassword(Arg.Any<ChangePasswordDto>()))
                .Do(x =>
                {
                    x.Arg<ChangePasswordDto>().Notification = new Notification();
                });
            _presenter.Ok();
            _view.DidNotReceive().ShowNotification(Arg.Any<Notification>());
            _view.Received().Stop();
        }

        [Test]
        public void Cancel_StopsView()
        {
            _presenter.Cancel();
            _view.Received().Stop();
        }

        [Test]
        public void Close_Unsubscribes()
        {
            _presenter.Close();
            _appController.Received().Unsubscribe(_presenter);
        }
    }
}
// ReSharper restore InconsistentNaming
