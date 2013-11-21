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
using OpenCBS.DataContract.CommandData;
using OpenCBS.Interface;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;
using OpenCBS.Presenter;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Presenter
{
    [TestFixture]
    public class EntryFeesPresenterTest
    {
        private IEntryFeeService _entryFeeService;
        private IApplicationController _appController;
        private IEntryFeesView _entryFeesView;
        private IAuthService _authService;
        private EntryFeesPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _entryFeeService = Substitute.For<IEntryFeeService>();
            _appController = Substitute.For<IApplicationController>();
            _entryFeesView = Substitute.For<IEntryFeesView>();
            _authService = Substitute.For<IAuthService>();
            _presenter = new EntryFeesPresenter(_entryFeesView, _appController, _entryFeeService, _authService);
        }

        [Test]
        public void Run_CallsAttachAndRunOnView()
        {
            _presenter.Run();
            _entryFeesView.Received().Attach(_presenter);
            _entryFeesView.Received().Run();
        }

        [Test]
        public void Run_ShowsEntryFees()
        {
            _entryFeeService.FindAll().Returns(new List<EntryFeeDto>());
            _presenter.Run();
            _entryFeesView.Received().ShowEntryFees(Arg.Any<IList<EntryFeeDto>>());
        }
        
        [Test]
        public void Run_ChecksPermissions()
        {
            _presenter.Run();
            _authService.Received().Can("EntryFee.Add");
            _authService.Received().Can("EntryFee.Edit");
            _authService.Received().Can("EntryFee.Delete");
        }

        [Test]
        public void Run_HasAddPermission_CanAdd()
        {
            _authService.Can("EntryFee.Add").Returns(true);
            _presenter.Run();
            Assert.IsTrue(_entryFeesView.AllowAdding);
        }

        [Test]
        public void Run_HasEditPermission_CanEdit()
        {
            _authService.Can("EntryFee.Edit").Returns(true);
            _presenter.Run();
            Assert.IsTrue(_entryFeesView.AllowEditing);
        }

        [Test]
        public void Run_HasDeletePermissions_CanDelete()
        {
            _authService.Can("EntryFee.Delete").Returns(true);
            _presenter.Run();
            Assert.IsTrue(_entryFeesView.AllowDeleting);
        }

        [Test]
        public void Add_ExecutesCommand()
        {
            _presenter.Add();
            _appController.Received().Execute(Arg.Any<AddEntryFeeData>());
        }

        [Test]
        public void Edit_IdIsNull_DoesNotExecuteCommand()
        {
            _entryFeesView.SelectedEntryFeeId.Returns(x => null);
            _presenter.Edit();
            _appController.DidNotReceive().Execute(Arg.Any<EditEntryFeeData>());
        }

        [Test]
        public void Edit_IdIsNotNull_ExecutesCommand()
        {
            _entryFeesView.SelectedEntryFeeId.Returns(1);
            _presenter.Edit();
            _appController.Received().Execute(Arg.Is<EditEntryFeeData>(x => x.Id == 1));
        }
    }
}
// ReSharper restore InconsistentNaming
