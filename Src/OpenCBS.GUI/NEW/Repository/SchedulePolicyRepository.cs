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
using System.Linq;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.GUI.NEW.Repository
{
    public class SchedulePolicyRepository : PolicyRepository, ISchedulePolicyRepository
    {
        [ImportMany(typeof(IInstallmentCalculationPolicy))]
        private Lazy<IInstallmentCalculationPolicy, IDictionary<string, object>>[] Policies { get; set; }

        public IEnumerable<IInstallmentCalculationPolicy> FindAll()
        {
            return from policy in Policies
                   orderby policy.Metadata.ContainsKey("Order") ? policy.Metadata["Order"] : 0
                   select policy.Value;
        }

        public IInstallmentCalculationPolicy FindByName(string name)
        {
            return (from policy in Policies
                    where policy.Value.Name == name
                    select policy.Value).FirstOrDefault();
        }

        public IEnumerable<IInstallmentCalculationPolicy> FindNonDeleted()
        {
            throw new NotImplementedException();
        }

        public IInstallmentCalculationPolicy FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IInstallmentCalculationPolicy entity)
        {
            throw new NotImplementedException();
        }

        public void Add(IInstallmentCalculationPolicy entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(IInstallmentCalculationPolicy entity)
        {
            throw new NotImplementedException();
        }
    }
}
