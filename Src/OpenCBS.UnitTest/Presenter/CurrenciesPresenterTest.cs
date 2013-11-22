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
using OpenCBS.DataContract.CommandData;
using OpenCBS.Interface;
using OpenCBS.Interface.Service;
using OpenCBS.Interface.View;
using OpenCBS.Presenter;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Presenter
{
    [TestFixture]
    public class CurrenciesPresenterTest
    {
        private CurrenciesPresenter _presenter;
        private ICurrenciesView _currenciesView;
        private ICurrencyService _currencyService;
        private IApplicationController _appController;

        [SetUp]
        public void SetUp()
        {
            _currenciesView = Substitute.For<ICurrenciesView>();
            _currencyService = Substitute.For<ICurrencyService>();
            _appController = Substitute.For<IApplicationController>();
            _presenter = new CurrenciesPresenter(_currenciesView, _currencyService, _appController);
        }

        [Test]
        public void Run_CallsAttachAndRunOnView()
        {
            _presenter.Run();
            _currenciesView.Received().Attach(_presenter);
            _currenciesView.Received().Run();
        }

        [Test]
        public void Run_ShowsCurrencies()
        {
            _presenter.Run();
            _currencyService.Received().FindAll();
        }

        [Test]
        public void Add_ExecutesCommand()
        {
            _presenter.Add();
            _appController.Received().Execute(Arg.Any<AddCurrencyData>());
        }
    }
}
// ReSharper restore InconsistentNaming
