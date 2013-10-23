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

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.GUI.NEW.Repository
{
    public class PolicyRepository : IPolicyRepository
    {
        [ImportMany(typeof(IPolicy))]
        private Lazy<IPolicy, IPolicyAttribute>[] Policies { get; set; }

        public PolicyRepository()
        {
            var fileName = Assembly.GetExecutingAssembly().Location;
            fileName = Path.GetDirectoryName(fileName);
            fileName = Path.Combine(fileName, "OpenCBS.Engine.dll");
            var catalog = new AssemblyCatalog(fileName);
            var container = new CompositionContainer(catalog);
            container.SatisfyImportsOnce(this);
        }

        private T FindByName<T>(string policyName)
        {
            return (T) (from policy in Policies
                        where policy.Metadata.Implementation == policyName
                              && policy.Value.GetType().GetInterfaces().Contains(typeof (T))
                        select policy.Value).FirstOrDefault();
        }

        private IEnumerable<string> FindNames(Type t)
        {
            return from policy in Policies
                   where policy.Value.GetType().GetInterfaces().Contains(t)
                   select policy.Metadata.Implementation;
        }

        public IEnumerable<string> FindPaymentFrequencyPolicyNames()
        {
            return FindNames(typeof (IPeriodPolicy));
        }

        public IEnumerable<string> FindSchedulePolicyNames()
        {
            return FindNames(typeof (IInstallmentCalculationPolicy));
        }

        public IEnumerable<string> FindYearPolicyNames()
        {
            return FindNames(typeof (IYearPolicy));
        }

        public IEnumerable<string> FindDateShiftPolicyNames()
        {
            return FindNames(typeof (IDateShiftPolicy));
        }

        public IEnumerable<string> FindRoundingPolicyNames()
        {
            return FindNames(typeof (IRoundingPolicy));
        }
    }
}
