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
using OpenCBS.DataContract.AppEvent;
using OpenCBS.DataContract.CommandData;
using OpenCBS.Interface;
using OpenCBS.Interface.Presenter;
using OpenCBS.Interface.Service;
using OpenCBS.Service.Command;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Command
{
    [TestFixture]
    public class AddLoanProductCommandTest
    {
        private ILoanProductPresenter _presenter;
        private ILoanProductService _loanProductService;
        private IApplicationController _appController;
        private AddLoanProductCommand _command;

        [SetUp]
        public void SetUp()
        {
            _presenter = Substitute.For<ILoanProductPresenter>();
            _loanProductService = Substitute.For<ILoanProductService>();
            _appController = Substitute.For<IApplicationController>();
            _command = new AddLoanProductCommand(_presenter, _loanProductService, _appController);
        }

        [Test]
        public void Execute_CommandResultIsNotOk_DoesNotAddLoanProduct()
        {
            _presenter.Get(Arg.Any<LoanProductDto>()).Returns(new Result<LoanProductDto>(CommandResult.Cancel, null));
            _command.Execute(new AddLoanProductData());
            _loanProductService.DidNotReceive().Add(Arg.Any<LoanProductDto>());
            _appController.DidNotReceive().Raise(Arg.Any<LoanProductSavedEvent>());
        }

        [Test]
        public void Execute_CommandResultIsOk_AddsLoanProduct()
        {
            _presenter.Get(Arg.Any<LoanProductDto>()).Returns(new Result<LoanProductDto>(CommandResult.Ok, new LoanProductDto()));
            _command.Execute(new AddLoanProductData());
            _loanProductService.Received().Add(Arg.Any<LoanProductDto>());
            _appController.Received().Raise(Arg.Any<LoanProductSavedEvent>());
        }
    }
}
// ReSharper restore InconsistentNaming
