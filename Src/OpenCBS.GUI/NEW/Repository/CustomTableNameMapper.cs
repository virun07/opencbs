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

using DapperExtensions.Mapper;

namespace OpenCBS.GUI.NEW.Repository
{
    public class CustomTableNameMapper<T> : AutoClassMapper<T> where T : class
    {
        public override void Table(string tableName)
        {
            if (tableName.EndsWith("Dto"))
                tableName = tableName.Substring(0, tableName.Length - 3);
            base.Table(tableName);
        }
    }
}
