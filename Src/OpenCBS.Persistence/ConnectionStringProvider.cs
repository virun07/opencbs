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

using System.Data.SqlClient;
using OpenCBS.Interface;
using OpenCBS.Interface.Repository;

namespace OpenCBS.Persistence
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly ISettingsProvider _settingsProvider;
        
        public ConnectionStringProvider(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public string GetConnectionString()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                UserID = _settingsProvider.GetDatabaseUsername(),
                Password = _settingsProvider.GetDatabasePassword(),
                DataSource = _settingsProvider.GetDatabaseServerName(),
                PersistSecurityInfo = false,
                InitialCatalog = _settingsProvider.GetDatabaseName(),
                ConnectTimeout = 100
            };
            return connectionStringBuilder.ConnectionString;
        }
    }
}
