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
        private LoanProductsPresenter _presenter;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<ILoanProductsView>();
            _loanProductService = Substitute.For<ILoanProductService>();
            _appController = Substitute.For<IApplicationController>();
            _presenter = new LoanProductsPresenter(_view, _appController, _loanProductService);
        }

        [Test]
        public void Run_CallsAttachAndShowLoanProductsAndRunOnView()
        {
            _presenter.Run();
            _view.Received().Attach(_presenter);
            _view.Received().ShowLoanProducts(Arg.Any<IEnumerable<LoanProductDto>>());
            _view.Received().Run();
        }
    }
}
// ReSharper restore InconsistentNaming
