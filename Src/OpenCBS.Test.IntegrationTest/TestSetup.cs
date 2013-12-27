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
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace OpenCBS.Test.IntegrationTest
{
    [SetUpFixture]
    public class TestSetup
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            var dropScript = ReadSql("drop.sql");
            var createScript = ReadSql("create.sql");

            var connectionProvider = new TestConnectionStringProvider();
            var connectionString = connectionProvider.GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                using (var command = new SqlCommand(dropScript, connection, transaction))
                {
                    foreach (var sql in SplitSql(dropScript))
                    {
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                    }

                    foreach (var sql in SplitSql(createScript))
                    {
                            command.CommandText = sql;
                            command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
        }

        private static string ReadSql(string path)
        {
            using (var stream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream("OpenCBS.Test.IntegrationTest.Sql." + path))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static IEnumerable<string> SplitSql(string sql)
        {
            var splitter = new[] { "\r\n", "\r", "\n" };
            var lines = sql.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

            var statements = new List<string>();
            var currentStatement = new StringBuilder(1024);
            foreach (var line in lines.Select(x => x.Trim()).Where(line => !string.IsNullOrEmpty(line)))
            {
                if (line.StartsWith("go") || line.StartsWith("GO"))
                {
                    if (currentStatement.Length > 0)
                    {
                        statements.Add(currentStatement.ToString());
                    }
                    currentStatement.Clear();
                    continue;
                }

                if (line.StartsWith("SET QUOTED_IDENTIFIER")) continue;
                if (line.StartsWith("SET ANSI_")) continue;
                if (line.StartsWith("/*")) continue;
                if (line.StartsWith("--")) continue;

                currentStatement.AppendLine(line);
            }

            return statements;
        }
    }
}
