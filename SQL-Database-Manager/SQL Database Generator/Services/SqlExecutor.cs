using SQL_Database_Generator.Extensions;
using SQL_Database_Generator.Models;
using SQL_Database_Generator.Repositories;
using SQL_Database_Generator.Utils;
using System;

namespace SQL_Database_Generator.Services
{
    public class SqlExecutor : ISqlExecutor
    {
        private readonly SqlGenerator _sqlGenerator;

        public SqlExecutor()
        {
            _sqlGenerator = new SqlGenerator();
        }

        public void ExecuteCompleteCreateStatement(Database db)
        {
            CheckIfDatabasePropertiesAreNull(db);
            db.Password.ThrowIfNullOrWhiteSpace(nameof(db.Password));

            string databaseCreate = _sqlGenerator.CreateDatabaseStatement(db);
            DbConnector.Instance.ExecuteQuery(databaseCreate);

            string loginCreate = _sqlGenerator.CreateLoginStatement(db);
            DbConnector.Instance.ExecuteQuery(loginCreate);

            string userCreate = _sqlGenerator.CreateUserStatement(db);
            DbConnector.Instance.ExecuteQuery(userCreate);

            string sqlInsert = _sqlGenerator.DatabaseInsertStatement(db);
            DbConnector.Instance.ExecuteQuery(sqlInsert);

            CloseConnections(db);
        }

        public void ExecuteCompleteDeleteStatement(Database db)
        {
            CheckIfDatabasePropertiesAreNull(db);

            CloseConnections(db);

            string sqlUser = _sqlGenerator.CreateDropUserStatement(db.Username);
            DbConnector.Instance.ExecuteQuery(sqlUser);

            string sqlLogin = _sqlGenerator.CreateDropLoginStatement(db.Username);
            DbConnector.Instance.ExecuteQuery(sqlLogin);

            string sqlDatabase = _sqlGenerator.CreateDropDatabaseStatement(db.Name);
            DbConnector.Instance.ExecuteQuery(sqlDatabase);

            string sqlDelete = _sqlGenerator.CreateDeleteDatabaseRecordStatement(db.TeamNumber);
            DbConnector.Instance.ExecuteQuery(sqlDelete);
        }

        private static void CheckIfDatabasePropertiesAreNull(Database db)
        {
            db.ThrowIfNull(nameof(db));
            db.TeamNumber.ThrowIfNullOrWhiteSpace(nameof(db.TeamNumber));
            db.Name.ThrowIfNullOrWhiteSpace(nameof(db.Name));
            db.Username.ThrowIfNullOrWhiteSpace(nameof(db.Username));
        }

        private void CloseConnections(Database db)
        {
            string sql = _sqlGenerator.CreateSqlCloseConnectionStatement(db.Name);

            DbConnector.Instance.ExecuteQuery(sql);
        }

        public void MarkMailAsSent(string teamNumber)
        {
            DbConnector.Instance.ExecuteQuery(_sqlGenerator.UpdateMailStatement(teamNumber));
        }

        public void ExecuteCompleteArchiveStatement(Database db)
        {
            CheckIfDatabasePropertiesAreNull(db);

            string sqlArchiveOnServer = _sqlGenerator.CreateArchiveDatabaseOnServerStatement(db.Name);
            DbConnector.Instance.ExecuteQuery(sqlArchiveOnServer);

            string sqlArchiveInDatabase = _sqlGenerator.CreateArchiveDatabaseInTableStatement(db.TeamNumber);
            DbConnector.Instance.ExecuteQuery(sqlArchiveInDatabase);

            CloseConnections(db);
        }
    }
}
