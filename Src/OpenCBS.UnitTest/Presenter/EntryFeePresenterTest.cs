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
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;
using OpenCBS.Presenter;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Presenter
{
    [TestFixture]
    public class EntryFeePresenterTest
    {
        private IEntryFeeView _view;
        private IEntryFeeService _entryFeeService;
        private EntryFeePresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<IEntryFeeView>();
            _entryFeeService = Substitute.For<IEntryFeeService>();
            _presenter = new EntryFeePresenter(_view, _entryFeeService);
        }

        [Test]
        public void Get_RunsAttachAndRunOnView()
        {
            _presenter.Get(null);
            _view.Received().Attach(_presenter);
            _view.Received().Run();
        }

        [Test]
        public void Get_EntryFeeIsNull_InjectsEmptyValues()
        {
            _presenter.Get(null);
            Assert.AreEqual(0, _view.Id);
            Assert.IsNullOrEmpty(_view.Code);
            Assert.IsNullOrEmpty(_view.EntryFeeName);
            Assert.IsNull(_view.ValueMin);
            Assert.IsNull(_view.ValueMax);
        }
        
        [Test]
        public void Get_EntryFeeIsNotNull_InjectsActualValues()
        {
            var entryFeeDto = new EntryFeeDto
            {
                Id = 1,
                Code = "LPF",
                Name = "Loan Processing Fee",
                ValueMin = 1,
                ValueMax = 5,
                Rate = true
            };
            _presenter.Get(entryFeeDto);
            Assert.AreEqual(1, _view.Id);
            Assert.AreEqual("LPF", _view.Code);
            Assert.AreEqual("Loan Processing Fee", _view.EntryFeeName);
            Assert.AreEqual(1, _view.ValueMin);
            Assert.AreEqual(5, _view.ValueMax);
            Assert.IsTrue(_view.Rate);
        }

        [Test]
        public void Ok_EntryFeeIsInvalid_CallsShowNotificationsOnView()
        {
            _entryFeeService
                .When(x => x.Validate(Arg.Any<EntryFeeDto>()))
                .Do(x =>
                {
                    var notification = new Notification();
                    notification.AddError(new Error());
                    x.Arg<EntryFeeDto>().Notification = notification;
                });
            _presenter.Ok();
            _view.Received().ShowNotification(Arg.Any<Notification>());
            _view.DidNotReceive().Stop();
        }

        [Test]
        public void Ok_EntryFeeIsValid_CallsStopOnView()
        {
            _entryFeeService
                .When(x => x.Validate(Arg.Any<EntryFeeDto>()))
                .Do(x =>
                {
                    x.Arg<EntryFeeDto>().Notification = new Notification();
                });
            _presenter.Ok();
            _view.DidNotReceive().ShowNotification(Arg.Any<Notification>());
            _view.Received().Stop();
        }

        [Test]
        public void Cancel_CallsStopOnView()
        {
            _presenter.Cancel();
            _view.Received().Stop();
        }
    }
}
// ReSharper restore InconsistentNaming
