using SQL_Database_Generator.Models;
using System;

namespace SQL_Database_Generator.Utils
{
    public class SqlGenerator
    {
        public string CreateDatabaseStatement(Database db) =>
            $"CREATE DATABASE [{db.Name}];";

        public string CreateLoginStatement(Database db) =>
            $"CREATE LOGIN [{db.Username}] WITH PASSWORD='{db.Password}', " +
            $"DEFAULT_DATABASE=[{db.Name}], DEFAULT_LANGUAGE=[hrvatski], " +
            "CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF";

        public string CreateUserStatement(Database db) =>
            $"USE [{db.Name}];" + Environment.NewLine +
            $"CREATE USER [{db.Username}] FOR LOGIN [{db.Username}] WITH DEFAULT_SCHEMA=[dbo];" + Environment.NewLine +
            $"USE [{db.Name}];" + Environment.NewLine +
            $"EXEC sp_addrolemember N'db_datareader', N'{db.Username}';" + Environment.NewLine +
            $"USE [{db.Name}];" + Environment.NewLine +
            $"EXEC sp_addrolemember N'db_datawriter', N'{db.Username}';" + Environment.NewLine +
            $"USE [{db.Name}];" + Environment.NewLine +
            $"EXEC sp_addrolemember N'db_owner', N'{db.Username}';" + Environment.NewLine;

        public string DatabaseInsertStatement(Database db) =>
            "INSERT INTO StudentskeBaze.dbo.Databases (TeamNumber, Name, CreationDate, Username, Password) VALUES " +
            $"('{db.TeamNumber}', '{db.Name}', GETDATE(), '{db.Username}', '{db.Password}')";

        public string CompleteSqlStatement(Database db) =>
            CreateDatabaseStatement(db) + Environment.NewLine + Environment.NewLine +
            CreateLoginStatement(db) + Environment.NewLine + Environment.NewLine +
            CreateUserStatement(db) + Environment.NewLine;

        public string UpdateMailStatement(string teamNumber) =>
            $"UPDATE StudentskeBaze.dbo.Databases SET EmailSent = 1 WHERE TeamNumber='{teamNumber}';";

        public string CreateDropUserStatement(string username) =>
            $"DROP USER IF EXISTS \"{username}\";";

        public string CreateDropLoginStatement(string username) =>
            $"DROP LOGIN \"{username}\";";

        public string CreateDropDatabaseStatement(string name) =>
            $"DROP DATABASE IF EXISTS \"{name}\";";

        public string CreateDeleteDatabaseRecordStatement(string teamNumber) =>
            $"DELETE FROM StudentskeBaze.dbo.Databases WHERE TeamNumber = '{teamNumber}';";

        public string CreateGetDatabasesByAcademicYearStatement(string academicYear) =>
            $"SELECT * FROM StudentskeBaze.dbo.Databases WHERE YEAR(CreationDate) = {academicYear};";

        public string CreateGetDatabasesByNameStatement(string databaseName) =>
            $"SELECT * FROM StudentskeBaze.dbo.Databases WHERE Name = '{databaseName}';";

        public string CreateSqlCloseConnectionStatement(string databaseName) =>
            "USE [master];" + Environment.NewLine +
            "DECLARE @kill varchar(8000) = '';" + Environment.NewLine +
            "SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'" + Environment.NewLine +
            "FROM sys.dm_exec_sessions" + Environment.NewLine +
            $"WHERE database_id  = db_id('{databaseName}') AND is_user_process = 1" + Environment.NewLine +
            "EXEC(@kill);";

        public string CreateArchiveDatabaseOnServerStatement(string databaseName) =>
            "USE [master];" + Environment.NewLine +
            $"IF EXISTS (SELECT name FROM sys.databases WHERE name = '{databaseName}') " +
            $"EXEC sp_detach_db '{databaseName}';" + Environment.NewLine;

        public string CreateArchiveDatabaseInTableStatement(string teamNumber) =>
            $"UPDATE StudentskeBaze.dbo.Databases SET Archived = 1 WHERE TeamNumber='{teamNumber}';";

        public string CreateGetMailSettingsStatement() =>
            "SELECT TOP 1 * FROM StudentskeBaze.dbo.MailSettings;";

        public string CreateUpdateMailSettingsStatement(MailSettings settings)
        {
            string senderSql = string.IsNullOrWhiteSpace(settings.DefaultSender) ?
                string.Empty : settings.DefaultSender.Trim();
            string bccRecepientsSql = settings.DefaultBccRecepients == null ? 
                string.Empty : string.Join(";", settings.DefaultBccRecepients);
            string subjectSql = string.IsNullOrWhiteSpace(settings.DefaultSubject) ?
                string.Empty : settings.DefaultSubject.Trim();

            return "UPDATE StudentskeBaze.dbo.MailSettings SET " +
                $"Sender={CreateUpdateCoalesce("Sender", senderSql)}," +
                $"BccRecepients={CreateUpdateCoalesce("BccRecepients", bccRecepientsSql)}," +
                $"Subject={CreateUpdateCoalesce("Subject", subjectSql)};";
        }

        private string CreateUpdateCoalesce(string param, string value) =>
            $"COALESCE(NULLIF('{value}', ''),{param})";
    }
}
