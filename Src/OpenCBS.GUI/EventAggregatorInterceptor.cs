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
using System.Linq;
using OpenCBS.Interfaces;
using StructureMap;
using StructureMap.Interceptors;

namespace OpenCBS.GUI
{
    public class EventAggregatorInterceptor : TypeInterceptor
    {
        public bool MatchesType(Type type)
        {
            if (type.IsGenericType) return false;

            var templateType = typeof(IEventHandler<>);
            return type.GetInterfaces().Any(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == templateType);
        }

        public object Process(object target, IContext context)
        {
            var eventPublisher = context.GetInstance<IEventPublisher>();
            eventPublisher.Subscribe(target);
            return target;
        }
    }
}
