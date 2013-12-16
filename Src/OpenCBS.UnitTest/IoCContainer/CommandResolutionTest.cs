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
using OpenCBS.Interface.View;
using OpenCBS.Service.Command;
using OpenCBS.Service.Shell;
using StructureMap;

// ReSharper disable InconsistentNaming
namespace OpenCBS.UnitTest.IoCContainer
{
    [TestFixture]
    public class CommandResolutionTest
    {
        private IContainer _container;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _container = new Container(new DefaultRegistry());
        }

        [Test]
        public void GetInstance_AddEntryFeeCommand_Resolves()
        {
            var command = _container.GetInstance<ICommand<AddEntryFeeData>>();
            Assert.IsInstanceOf<AddEntryFeeCommand>(command);
        }

        [Test]
        public void GetInstance_AddLoanProductCommand_Resolves()
        {
            var command = _container.GetInstance<ICommand<AddLoanProductData>>();
            Assert.IsInstanceOf<AddLoanProductCommand>(command);
        }

        [Test]
        public void GetInstance_AddRoleCommand_Resolves()
        {
            var command = _container.GetInstance<ICommand<AddRoleData>>();
            Assert.IsInstanceOf<AddRoleCommand>(command);
        }

        [Test]
        public void GetInstance_AddUserCommand_Resolves()
        {
            var command = _container.GetInstance<ICommand<AddUserData>>();
            Assert.IsInstanceOf<AddUserCommand>(command);
        }
        
        [Test]
        public void GetInstance_ChangeLanguageCommand_Resolves()
        {
            var command = _container.GetInstance<ICommand<ChangeLanguageData>>();
            Assert.IsInstanceOf<ChangeLanguageCommand>(command);
        }

        [Test]
        public void GetInstance_DeleteEntryFeeCommand_Resolves()
        {
            var command = _container.GetInstance<ICommand<DeleteEntryFeeData>>();
            Assert.IsInstanceOf<DeleteEntryFeeCommand>(command);
        }

        [Test]
        public void GetInstance_DeleteLoanProductCommand_Resolves()
        {
            var command = _container.GetInstance<ICommand<DeleteLoanProductData>>();
            Assert.IsInstanceOf<DeleteLoanProductCommand>(command);
        }

        [Test]
        public void GetInstance_DeleteRoleCommand_Resolves()
        {
            var command = _container.GetInstance<ICommand<DeleteRoleData>>();
            Assert.IsInstanceOf<DeleteRoleCommand>(command);
        }

        [Test]
        public void GetInstance_DeleteUserCommand_Resolves()
        {
            var command = _container.GetInstance<ICommand<DeleteUserData>>();
            Assert.IsInstanceOf<DeleteUserCommand>(command);
        }

        [Test]
        public void GetInstance_EditEntryFeeCommand_Resolves()
        {
            var command = _container.GetInstance<ICommand<EditEntryFeeData>>();
            Assert.IsInstanceOf<EditEntryFeeCommand>(command);
        }

        [Test]
        public void GetInstance_EditLoanProductCommand_Resolves()
        {
            var command = _container.GetInstance<ICommand<EditLoanProductData>>();
            Assert.IsInstanceOf<EditLoanProductCommand>(command);
        }

        [Test]
        public void GetInstance_EditRoleCommand_Resolves()
        {
            var command = _container.GetInstance<ICommand<EditRoleData>>();
            Assert.IsInstanceOf<EditRoleCommand>(command);
        }

        [Test]
        public void GetInstance_EditUserCommand_Resolves()
        {
            var command = _container.GetInstance<ICommand<EditUserData>>();
            Assert.IsInstanceOf<EditUserCommand>(command);
        }
        
        [Test]
        public void GetInstance_SelectEntryFeeCommand_Resolves()
        {
            var command = _container.GetInstance<ICommand<SelectEntryFeeData>>();
            Assert.IsInstanceOf<SelectEntryFeeCommand>(command);
        }

        [Test]
        public void GetInstance_ShowCurrenciesCommand_Resolves()
        {
            var view = Substitute.For<ICurrenciesView>();
            _container.Inject(view);
            var command = _container.GetInstance<ICommand<ShowCurrenciesData>>();
            Assert.IsInstanceOf<ShowCurrenciesCommand>(command);
        }

        [Test]
        public void GetInstance_ShowEntryFeesCommand_Resolves()
        {
            var view = Substitute.For<IEntryFeesView>();
            _container.Inject(view);
            var command = _container.GetInstance<ICommand<ShowEntryFeesData>>();
            Assert.IsInstanceOf<ShowEntryFeesCommand>(command);
        }

        [Test]
        public void GetInstance_ShowLoanProductsCommand_Resolves()
        {
            var view = Substitute.For<ILoanProductsView>();
            _container.Inject(view);
            var command = _container.GetInstance<ICommand<ShowLoanProductsData>>();
            Assert.IsInstanceOf<ShowLoanProductsCommand>(command);
        }

        [Test]
        public void GetInstance_ShowRolesCommand_Resolves()
        {
            var view = Substitute.For<IRolesView>();
            _container.Inject(view);
            var command = _container.GetInstance<ICommand<ShowRolesData>>();
            Assert.IsInstanceOf<ShowRolesCommand>(command);
        }

        [Test]
        public void GetInstance_ShowUserCommand_Resolves()
        {
            var view = Substitute.For<IUsersView>();
            _container.Inject(view);
            var command = _container.GetInstance<ICommand<ShowUsersData>>();
            Assert.IsInstanceOf<ShowUsersCommand>(command);
        }

        [Test]
        public void GetInstance_ChangePasswordCommand_Resolves()
        {
            var command = _container.GetInstance<ICommand<ChangePasswordData>>();
            Assert.IsInstanceOf<ChangePasswordCommand>(command);
        }
    }
}
// ReSharper restore InconsistentNaming
