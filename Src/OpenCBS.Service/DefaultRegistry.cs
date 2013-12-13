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
using OpenCBS.Interface;
using OpenCBS.Interface.Service;
using OpenCBS.Service;
using StructureMap.Configuration.DSL;

namespace OpenCBS.GUI
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(scanner =>
            {
                scanner.Assembly("OpenCBS.Service");
                scanner.Assembly("OpenCBS.Persistence");
                scanner.Assembly("OpenCBS.Presenter");
                scanner.Assembly("OpenCBS.View");
                scanner.TheCallingAssembly();
                scanner.WithDefaultConventions();
                scanner.ConnectImplementationsToTypesClosing(typeof (ICommand<>));
            });

            For<ApplicationContext>().Use<AppContext>();
            For<IApplicationController>().Singleton().Use<ApplicationController>();
            For<IEventPublisher>().Singleton().Use<EventPublisher>();

            For<IEntryFeeService>().EnrichAllWith(x => x.Proxy(SecurityInterceptor.Intercept)).Use<EntryFeeService>();
            For<ILoanProductService>().EnrichAllWith(x => x.Proxy(SecurityInterceptor.Intercept)).Use<LoanProductService>();
            For<IUserService>().EnrichAllWith(x => x.Proxy(SecurityInterceptor.Intercept)).Use<UserService>();
            For<IRoleService>().EnrichAllWith(x => x.Proxy(SecurityInterceptor.Intercept)).Use<RoleService>();
            
            For<ITranslator>().Singleton().Use<JsonTranslator>();

            RegisterInterceptor(new EventAggregatorInterceptor());
        }
    }
}
