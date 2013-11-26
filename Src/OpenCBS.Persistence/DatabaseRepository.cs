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
using Dapper;
using OpenCBS.Interface.Repository;

namespace OpenCBS.Persistence
{
    public class DatabaseRepository : Repository, IDatabaseRepository
    {
        public DatabaseRepository(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        {
        }

        public IList<string> FindAll()
        {
            const string sql = @"
                DECLARE @databases TABLE
                (
                    Name NVARCHAR(MAX),
                    Version NVARCHAR(MAX),
                    BranchCode NVARCHAR(MAX)
                )
                DECLARE @name NVARCHAR(MAX)
                DECLARE @version NVARCHAR(MAX)
                DECLARE @branch NVARCHAR(MAX)
                DECLARE @query NVARCHAR(MAX)
                DECLARE databaseCursor CURSOR FOR
                SELECT name FROM sys.databases
                OPEN databaseCursor

                FETCH databaseCursor INTO @name
                WHILE @@FETCH_STATUS = 0
                BEGIN
                    IF NOT OBJECT_ID(@name + '..TechnicalParameters') IS NULL
                    BEGIN
                        SET @query = N'USE ' + @name + '; SELECT @versionOut = value FROM dbo.TechnicalParameters WHERE name = ''version'''
                        EXEC sp_executesql @query, N'@versionOut NVARCHAR(MAX) OUTPUT', @versionOut = @version OUTPUT
                        SET @query = N'USE ' + @name + ';SELECT TOP 1 @branchOut = code FROM dbo.Branches'
                        EXEC sp_executesql @query, N'@branchOut NVARCHAR(MAX) OUTPUT', @branchOut = @branch OUTPUT
                        INSERT INTO @databases VALUES (@name, @version, @branch)
                    END
                    FETCH databaseCursor INTO @name
                END

                CLOSE databaseCursor
                DEALLOCATE databaseCursor

                SELECT db.Name Name --, db.Version, db.BranchCode, 0 DataFileSize, 0 LogFileSize
                FROM @databases db
            ";
            using (var connection = GetConnection())
            {
                return connection.Query<string>(sql).ToList().AsReadOnly();
            }
        }
    }
}
