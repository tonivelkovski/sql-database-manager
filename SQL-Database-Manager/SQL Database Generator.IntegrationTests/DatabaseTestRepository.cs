using SQL_Database_Generator.Models;
using SQL_Database_Generator.Repositories;
using SQL_Database_Generator.Utils;
using System;
using System.Runtime.InteropServices;

namespace SQL_Database_Generator.IntegrationTests
{
    public class DatabaseTestRepository
    {
        public DatabaseTestRepository() { }

        public void ExecuteCompleteCreateStatement(Database database)
        {
            var sqlGenerator = new SqlGenerator();

            string databaseCreate = sqlGenerator.CreateDatabaseStatement(database);
            TestDbConnector.Instance.ExecuteQuery(databaseCreate);

            string loginCreate = sqlGenerator.CreateLoginStatement(database);
            TestDbConnector.Instance.ExecuteQuery(loginCreate);

            string userCreate = sqlGenerator.CreateUserStatement(database);
            TestDbConnector.Instance.ExecuteQuery(userCreate);

            string sqlInsert = sqlGenerator.DatabaseInsertStatement(database);
            TestDbConnector.Instance.ExecuteQuery(sqlInsert);

            string sql = sqlGenerator.CreateSqlCloseConnectionStatement(database.Name);
            TestDbConnector.Instance.ExecuteQuery(sql);
        }

        public void ExecuteCompleteDeleteStatement(Database database)
        {
            var sqlGenerator = new SqlGenerator();

            string sql = sqlGenerator.CreateSqlCloseConnectionStatement(database.Name);
            TestDbConnector.Instance.ExecuteQuery(sql);

            string sqlUser = sqlGenerator.CreateDropUserStatement(database.Username);
            TestDbConnector.Instance.ExecuteQuery(sqlUser);

            string sqlLogin = sqlGenerator.CreateDropLoginStatement(database.Username);
            TestDbConnector.Instance.ExecuteQuery(sqlLogin);

            string sqlDatabase = sqlGenerator.CreateDropDatabaseStatement(database.Name);
            TestDbConnector.Instance.ExecuteQuery(sqlDatabase);

            string sqlDelete = sqlGenerator.CreateDeleteDatabaseRecordStatement(database.TeamNumber);
            TestDbConnector.Instance.ExecuteQuery(sqlDelete);
        }

        public void ExecuteCompleteArchiveStatement(Database database)
        {
            var sqlGenerator = new SqlGenerator();

            string sqlArchiveOnServer = sqlGenerator.CreateArchiveDatabaseOnServerStatement(database.Name);
            TestDbConnector.Instance.ExecuteQuery(sqlArchiveOnServer);

            string sqlArchiveInDatabase = sqlGenerator.CreateArchiveDatabaseInTableStatement(database.TeamNumber);
            TestDbConnector.Instance.ExecuteQuery(sqlArchiveInDatabase);

            string sql = sqlGenerator.CreateSqlCloseConnectionStatement(database.Name);
            TestDbConnector.Instance.ExecuteQuery(sql);
        }

        public bool GetFromServer(string property, string name)
        {
            string sql =
                "USE [master];" + Environment.NewLine +
                $"IF EXISTS (SELECT 1 FROM {property} WHERE name = '{name}') " +
                "SELECT 1 AS DatabaseExists; " +
                "ELSE SELECT 0 AS DatabaseExists;";

            int result = Convert.ToInt32(TestDbConnector.Instance.ExecuteScalar(sql));

            return result == 1;
        }
    }
}
