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
using OpenCBS.DataContract.AppEvent;
using OpenCBS.DataContract.CommandData;
using OpenCBS.Interface;
using OpenCBS.Service.Command;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.Command
{
    [TestFixture]
    public class ChangeLanguageCommandTest
    {
        private ITranslator _translator;
        private IApplicationController _appController;
        private ChangeLanguageCommand _command;

        [SetUp]
        public void SetUp()
        {
            _translator = Substitute.For<ITranslator>();
            _appController = Substitute.For<IApplicationController>();
            _command = new ChangeLanguageCommand(_translator, _appController);
        }

        [Test]
        public void Execute_ReloadsTranslator()
        {
            _command.Execute(new ChangeLanguageData { Name = "en-US" });
            _translator.Received().Reload();
        }

        [Test]
        public void Execute_RaisesEvent()
        {
            _command.Execute(new ChangeLanguageData { Name = "en-US" });
            _appController.Received().Raise(Arg.Any<LanguageChangedEvent>());
        }
    }
}
// ReSharper restore InconsistentNaming
