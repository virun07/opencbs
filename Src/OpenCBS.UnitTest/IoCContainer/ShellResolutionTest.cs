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

using NUnit.Framework;
using OpenCBS.Interface;
using OpenCBS.Service.Shell;
using StructureMap;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.IoCContainer
{
    [TestFixture]
    public class ShellResolutionTest
    {
        private IContainer _container;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _container = new Container(new DefaultRegistry());
        }

        [Test]
        public void GetInstance_ApplicationController_Resolves()
        {
            var appController = _container.GetInstance<IApplicationController>();
            Assert.IsInstanceOf<ApplicationController>(appController);
        }

        [Test]
        public void GetInstance_EventPublisher_Resolves()
        {
            var eventPublisher = _container.GetInstance<IEventPublisher>();
            Assert.IsInstanceOf<EventPublisher>(eventPublisher);
        }
        
        [Test]
        public void GetInstance_Translator_Resolves()
        {
            var translator = _container.GetInstance<ITranslator>();
            Assert.IsInstanceOf<JsonTranslator>(translator);
        }
    }
}
// ReSharper restore InconsistentNaming
