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
    public class LoanProductsPresenterTest
    {
        private ILoanProductsView _view;
        private ILoanProductService _loanProductService;
        private IApplicationController _appController;
        private IAuthService _authService;
        private LoanProductsPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<ILoanProductsView>();
            _loanProductService = Substitute.For<ILoanProductService>();
            _appController = Substitute.For<IApplicationController>();
            _authService = Substitute.For<IAuthService>();
            _presenter = new LoanProductsPresenter(_view, _appController, _loanProductService, _authService);
        }

        [Test]
        public void Run_CallsAttachAndShowLoanProductsAndRunOnView()
        {
            _presenter.Run();
            _view.Received().Attach(_presenter);
            _view.Received().ShowLoanProducts(Arg.Any<IList<LoanProductDto>>());
            _view.Received().Run();
        }

        [Test]
        public void Run_ChecksPermissions()
        {
            _presenter.Run();
            _authService.Received().Can("LoanProduct.Add");
            _authService.Received().Can("LoanProduct.Edit");
            _authService.Received().Can("LoanProduct.Delete");
        }

        [Test]
        public void Run_HasAddPermission_CanAdd()
        {
            _authService.Can("LoanProduct.Add").Returns(true);
            _presenter.Run();
            Assert.IsTrue(_view.AllowAdding);
        }

        [Test]
        public void Run_HasEditPermission_CanEdit()
        {
            _authService.Can("LoanProduct.Edit").Returns(true);
            _presenter.Run();
            Assert.IsTrue(_view.AllowEditing);
        }

        [Test]
        public void Run_HasDeletePermission_CanDelete()
        {
            _authService.Can("LoanProduct.Delete").Returns(true);
            _presenter.Run();
            Assert.IsTrue(_view.AllowDeleting);
        }

        [Test]
        public void Refresh_ShowsLoanProducts()
        {
            _presenter.Refresh();
            _loanProductService.Received().FindAll();
        }

        [Test]
        public void Refresh_ShowDeletedIsFalse_ShowsOnlyNonDeletedLoanProducts()
        {
            var loanProducts = new List<LoanProductDto>
            {
                new LoanProductDto { Id = 1, Deleted = false },
                new LoanProductDto { Id = 2, Deleted = true }
            };
            _loanProductService.FindAll().Returns(loanProducts);
            _view.ShowDeleted.Returns(false);
            _presenter.Refresh();
            _view.Received().ShowLoanProducts(Arg.Is<IList<LoanProductDto>>(x => x.Count == 1));
        }

        [Test]
        public void Refresh_ShowDeletedIsTrue_ShowsAll()
        {
            var loanProducts = new List<LoanProductDto>
            {
                new LoanProductDto { Id = 1, Deleted = false },
                new LoanProductDto { Id = 2, Deleted = true }
            };
            _loanProductService.FindAll().Returns(loanProducts);
            _view.ShowDeleted.Returns(true);
            _presenter.Refresh();
            _view.Received().ShowLoanProducts(Arg.Is<IList<LoanProductDto>>(x => x.Count == 2));
        }

        [Test]
        public void Add_ExecutesCommand()
        {
            _presenter.Add();
            _appController.Received().Execute(Arg.Any<AddLoanProductData>());
        }

        [Test]
        public void Edit_IdIsNull_DoesNotExecuteCommand()
        {
            _view.SelectedLoanProductId.Returns(x => null);
            _presenter.Edit();
            _appController.DidNotReceive().Execute(Arg.Any<EditLoanProductData>());
        }

        [Test]
        public void Edit_IdIsNotNull_ExecutesCommand()
        {
            _view.SelectedLoanProductId.Returns(1);
            _presenter.Edit();
            _appController.Received().Execute(Arg.Is<EditLoanProductData>(data => data.Id == 1));
        }

        [Test]
        public void Delete_IdIsNull_DoesNotExecuteCommand()
        {
            _view.SelectedLoanProductId.Returns(x => null);
            _presenter.Delete();
            _appController.DidNotReceive().Execute(Arg.Any<DeleteLoanProductData>());
        }

        [Test]
        public void Delete_IdIsNotNull_ExecutesCommand()
        {
            _view.SelectedLoanProductId.Returns(1);
            _presenter.Delete();
            _appController.Received().Execute(Arg.Is<DeleteLoanProductData>(data => data.Id == 1));
        }

        [Test]
        public void ChangeSelection_IdIsNull_EditingAndDeletingDisabled()
        {
            _view.SelectedLoanProductId.Returns(x => null);
            _presenter.ChangeSelection();
            Assert.IsFalse(_view.CanEdit);
            Assert.IsFalse(_view.CanDelete);
        }

        [Test]
        public void ChangeSelection_IdIsNotNull_EditingAndDeletingEnabled()
        {
            _view.SelectedLoanProductId.Returns(1);
            _presenter.ChangeSelection();
            Assert.IsTrue(_view.CanEdit);
            Assert.IsTrue(_view.CanDelete);
        }

        [Test]
        public void Close_Unsubscribes()
        {
            _presenter.Close();
            _appController.Received().Unsubscribe(_presenter);
        }

        [Test]
        public void Handle_LoanProductSavedEvent()
        {
            _presenter.Handle(new LoanProductSavedEvent());
            _view.Received().ShowLoanProducts(Arg.Any<IList<LoanProductDto>>());
        }

        [Test]
        public void Handle_LoanProductDeletedEvent()
        {
            _presenter.Handle(new LoanProductDeletedEvent());
            _view.Received().ShowLoanProducts(Arg.Any<IList<LoanProductDto>>());
        }

        [Test]
        public void Handle_LanguageChangeEvent()
        {
            _presenter.Handle(new LanguageChangedEvent());
            _view.Received().Translate();
            _view.Received().ShowLoanProducts(Arg.Any<IList<LoanProductDto>>());
        }
    }
}
// ReSharper restore InconsistentNaming
