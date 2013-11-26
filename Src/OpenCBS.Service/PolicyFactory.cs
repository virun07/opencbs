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
using System.Linq;
using OpenCBS.Model.Interface;
using StructureMap;

namespace OpenCBS.Service
{
    public class PolicyFactory : IPolicyFactory
    {
        private readonly IContainer _container;

        public PolicyFactory(IContainer container)
        {
            _container = container;
        }

        private IList<string> GetPolicyNames<T>()
        {
            return _container.Model.AllInstances
                             .Where(x => x.PluginType == typeof (T))
                             .Select(x => x.Name).ToList().AsReadOnly();
        }

        private T GetPolicy<T>(string name)
        {
            return _container.GetInstance<T>(name);
        }

        public IList<string> GetLateFeePolicyNames()
        {
            return GetPolicyNames<ILateFeePolicy>();
        }

        public IList<string> GetPaymentFrequencyPolicyNames()
        {
            return GetPolicyNames<IPaymentFrequencyPolicy>();
        }

        public IList<string> GetYearPolicyNames()
        {
            return GetPolicyNames<IYearPolicy>();
        }

        public IList<string> GetRoundingPolicyNames()
        {
            return GetPolicyNames<IRoundingPolicy>();
        }

        public IList<string> GetDateShiftPolicyNames()
        {
            return GetPolicyNames<IDateShiftPolicy>();
        }

        public IList<string> GetSchedulePolicyNames()
        {
            return GetPolicyNames<ISchedulePolicy>();
        }

        public ILateFeePolicy GetLateFeePolicy(string name)
        {
            return GetPolicy<ILateFeePolicy>(name);
        }

        public IPaymentFrequencyPolicy GetPaymentFrequencyPolicy(string name)
        {
            return GetPolicy<IPaymentFrequencyPolicy>(name);
        }

        public IYearPolicy GetYearPolicy(string name)
        {
            return GetPolicy<IYearPolicy>(name);
        }

        public IRoundingPolicy GetRoundingPolicy(string name)
        {
            return GetPolicy<IRoundingPolicy>(name);
        }

        public IDateShiftPolicy GetDateShiftPolicy(string name)
        {
            return GetPolicy<IDateShiftPolicy>(name);
        }

        public ISchedulePolicy GetSchedulePolicy(string name)
        {
            return GetPolicy<ISchedulePolicy>(name);
        }
    }
}
