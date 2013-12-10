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

using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using OpenCBS.DataContract;
using OpenCBS.DataContract.AppEvent;
using OpenCBS.DataContract.CommandData;
using OpenCBS.Interface;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;
using OpenCBS.Presenter;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Presenter
{
    [TestFixture]
    public class LoanProductPresenterTest
    {
        private ILoanProductView _view;
        private ILoanProductService _loanProductService;
        private IEntryFeeService _entryFeeService;
        private IApplicationController _appController;
        private LoanProductPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<ILoanProductView>();
            _loanProductService = Substitute.For<ILoanProductService>();
            _entryFeeService = Substitute.For<IEntryFeeService>();
            _appController = Substitute.For<IApplicationController>();
            _presenter = new LoanProductPresenter(_view, _loanProductService, _entryFeeService, _appController);

            _loanProductService.GetReferenceData().Returns(new LoanProductReferenceDataDto());
        }

        [Test]
        public void Get_RunsAttachOnView()
        {
            _presenter.Get(null);
            _view.Received().Attach(_presenter);
        }

        [Test]
        public void Get_LoadsReferenceData()
        {
            _presenter.Get(null);
            _loanProductService.Received().GetReferenceData();
            _view.Received().ShowCurrencies(Arg.Any<Dictionary<int, string>>());
            _view.Received().ShowSchedulePolicies(Arg.Any<IList<string>>());
            _view.Received().ShowPaymentFrequencyPolicies(Arg.Any<IList<string>>());
            _view.Received().ShowYearPolicies(Arg.Any<IList<string>>());
            _view.Received().ShowDateShiftPolicies(Arg.Any<IList<string>>());
            _view.Received().ShowRoundingPolicies(Arg.Any<IList<string>>());
            _view.Received().ShowLateFeePolicies(Arg.Any<IList<string>>());
        }

        [Test]
        public void Get_CallsRunOnView()
        {
            _presenter.Get(null);
            _view.Received().Run();
        }

        [Test]
        public void Get_LoanProductIsNull_InjectsEmptyValues()
        {
            _presenter.Get(null);
            Assert.AreEqual(0, _view.Id);
            Assert.IsNullOrEmpty(_view.Code);
            Assert.IsNullOrEmpty(_view.LoanProductName);
            Assert.IsNullOrEmpty(_view.SchedulePolicy);
        }

        [Test]
        public void Get_LoanProductIsNotNull_InectsActualValues()
        {
            var loanProductDto = new LoanProductDto
            {
                Id = 1,
                Code = "EXPRESS",
                Name = "Express Loan",
                SchedulePolicy = "Flat"
            };
            _presenter.Get(loanProductDto);
            Assert.AreEqual(1, _view.Id);
            Assert.AreEqual("EXPRESS", _view.Code);
            Assert.AreEqual("Express Loan", _view.LoanProductName);
            Assert.AreEqual("Flat", _view.SchedulePolicy);
        }

        [Test]
        public void AddEntryFee_ExecutesCommand()
        {
            _presenter.AddEntryFee();
            _appController.Received().Execute(Arg.Any<SelectEntryFeeData>());
        }

        [Test]
        public void RemoveEntryFee_SelectedEntryFeeIdIsNull_DoesNotRemove()
        {
            _view.EntryFees = new List<EntryFeeDto>
            {
                new EntryFeeDto { Id = 1 }
            };
            _view.SelectedEntryFeeId.Returns(x => null);
            _presenter.RemoveEntryFee();
            Assert.AreEqual(1, _view.EntryFees.Count);
        }

        [Test]
        public void RemoveEntryFee_SelectedEntryFeeIdIsNotNull_Removes()
        {
            _view.EntryFees = new List<EntryFeeDto>
            {
                new EntryFeeDto { Id = 1 },
                new EntryFeeDto { Id = 2 }
            };
            _view.SelectedEntryFeeId.Returns(1);
            _presenter.RemoveEntryFee();
            Assert.AreEqual(1, _view.EntryFees.Count);
        }

        [Test]
        public void Ok_LoanProductIsInvalid_CallsShowNotificationsOnView()
        {
            _loanProductService
                .When(x => x.Validate(Arg.Any<LoanProductDto>()))
                .Do(x =>
                {
                    var notification = new Notification();
                    notification.AddError(new Error());
                    x.Arg<LoanProductDto>().Notification = notification;
                });
            _presenter.Ok();
            _view.Received().ShowNotification(Arg.Any<Notification>());
            _view.DidNotReceive().Stop();
        }

        [Test]
        public void Ok_LoanProductIsValid_CallsStopOnView()
        {
            _loanProductService
                .When(x => x.Validate(Arg.Any<LoanProductDto>()))
                .Do(x =>
                {
                    x.Arg<LoanProductDto>().Notification = new Notification();
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

        [Test]
        public void Close_Unsubscribes()
        {
            _presenter.Close();
            _appController.Received().Unsubscribe(_presenter);
        }

        [Test]
        public void Handle_EntryFeeSelectedEvent_ExistingId()
        {
            _view.EntryFees = new List<EntryFeeDto>
            {
                new EntryFeeDto { Id = 1 }
            };
            _presenter.Handle(new EntryFeeSelectedEvent { Id = 1 });
            _entryFeeService.DidNotReceive().FindById(Arg.Is<int>(id => id == 1));
            Assert.AreEqual(1, _view.EntryFees.Count);
        }

        [Test]
        public void Handle_EntryFeeSelectedEvent_NewId()
        {
            _view.EntryFees = new List<EntryFeeDto>
            {
                new EntryFeeDto { Id = 1}
            };
            _entryFeeService.FindById(Arg.Is<int>(id => id == 2)).Returns(new EntryFeeDto { Id = 2 });
            _presenter.Handle(new EntryFeeSelectedEvent { Id = 2 });
            Assert.AreEqual(2, _view.EntryFees.Count);
        }

        [Test]
        public void ChangeSelectedEntryFee_SelectedEntryFeeIdIsNull_CannotRemove()
        {
            _view.SelectedEntryFeeId.Returns(x => null);
            _presenter.ChangeSelectedEntryFee();
            Assert.IsFalse(_view.CanRemoveEntryFee);
        }

        [Test]
        public void ChangeSelectedEntryFee_SelectedEntryFeeIdIsNotNull_CanRemove()
        {
            _view.SelectedEntryFeeId.Returns(1);
            _presenter.ChangeSelectedEntryFee();
            Assert.IsTrue(_view.CanRemoveEntryFee);
        }
    }
}
// ReSharper restore InconsistentNaming
