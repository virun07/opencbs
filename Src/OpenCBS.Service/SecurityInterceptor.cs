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

namespace OpenCBS.Service
{
    public static class SecurityInterceptor
    {
        public static object Intercept<T>(
            T proxiedObject,
            string methodName,
            object[] parameters,
            EmitProxyExecute<T> execute)
        {
            var serviceInterface = proxiedObject
                .GetType()
                .GetInterfaces().FirstOrDefault(i => i.Name.EndsWith("Service"));
            if (serviceInterface == null)
                throw new ArgumentException("SecurityInterceptor: Class does not implement any service interface.");

            System.Diagnostics.Debug.WriteLine(serviceInterface.Name + "." + methodName);
            return execute(proxiedObject, parameters);
        }
    }
}
