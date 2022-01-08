using DungeonMapperStandard.DataAccess;
using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.IO;

namespace DungeonMapperAndroidForms.Utilities
{
    public class DatabaseConnectionHandler : IDatabaseConnectionHandler
    {
        public IDbConnection CreateDatabaseConnection(string appDataPath)
        {
            return new SqliteConnection($"Filename={Path.Combine(appDataPath, "storage.db")}");
        }

        public IDbCommand CreateSqlCommand(string sql, IDbConnection databaseConnection)
        {
            if (!(databaseConnection is SqliteConnection))
                throw new Exception("wrong database connection");
            return new SqliteCommand(sql, databaseConnection as SqliteConnection);
        }
    }
}
