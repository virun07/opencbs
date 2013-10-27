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

using System.Windows.Forms;
using OpenCBS.GUI.NEW.AppController;
using OpenCBS.GUI.NEW.Command;
using OpenCBS.GUI.NEW.CommandData;
using OpenCBS.GUI.NEW.EventAggregator;
using OpenCBS.GUI.NEW.Mapper;
using OpenCBS.GUI.NEW.Presenter;
using OpenCBS.GUI.NEW.Repository;
using OpenCBS.GUI.NEW.Service;
using OpenCBS.GUI.NEW.Validator;
using OpenCBS.GUI.NEW.View;
using OpenCBS.GUI.NEW.View.LoanProduct;
using StructureMap.Configuration.DSL;

namespace OpenCBS.GUI.NEW
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            For<ApplicationContext>().Use<AppContext>();
            For<IApplicationController>().Singleton().Use<ApplicationController>();
            For<IEventPublisher>().Singleton().Use<EventPublisher>();

            // Views / presenters
            For<ILoanProductsView>().Use<LoanProductsView>();
            For<ILoanProductsPresenter>().Use<LoanProductsPresenter>();
            For<ILoanProductView>().Use<LoanProductView>();
            For<ILoanProductPresenter>().Use<LoanProductPresenter>();

            // Commands
            For<ICommand<ShowLoanProductsData>>().Use<ShowLoanProductsCommand>();
            For<ICommand<AddLoanProductData>>().Use<AddLoanProductCommand>();
            For<ICommand<EditLoanProductData>>().Use<EditLoanProductCommand>();
            For<ICommand<DeleteLoanProductData>>().Use<DeleteLoanProductCommand>();

            // Repositories
            For<IConnectionProvider>().Use<SqlConnectionProvider>();
            For<ILoanProductRepository>().Use<LoanProductRepository>();
            For<IPolicyRepository>().Use<PolicyRepository>();

            // Services
            For<ILoanProductService>().Use<LoanProductService>();

            // Validators
            For<ILoanProductValidator>().Use<LoanProductValidator>();

            // Mappers
            For<ILoanProductMapper>().Use<LoanProductMapper>();

            RegisterInterceptor(new EventAggregatorInterceptor());
        }
    }
}
