using SQL_Database_Generator.Models;
using SQL_Database_Generator.Utils;
using System;
using Xunit;

namespace SQL_Database_Generator.UnitTests
{
    public class SqlGenerator_UnitTests
    {
        [Fact]
        public void CreateDatabaseStatement_GivenCorrectDatabaseName_ReturnsCorrectSQLStatement()
        {
            var db = new Database
            {
                Name = "TestDB"
            };

            var sqlGenerator = new SqlGenerator();
            var result = sqlGenerator.CreateDatabaseStatement(db);

            Assert.Equal("CREATE DATABASE [TestDB];", result);
        }

        [Fact]
        public void CreateLoginStatement_GivenCorrectLoginData_ReturnsCorrectSQLStatement()
        {
            var db = new Database
            {
                Username = "TestUser",
                Password = "password",
                Name = "TestDB"
            };

            var sqlGenerator = new SqlGenerator();
            var result = sqlGenerator.CreateLoginStatement(db);

            Assert.Equal("CREATE LOGIN [TestUser] WITH PASSWORD='password', " +
                "DEFAULT_DATABASE=[TestDB], DEFAULT_LANGUAGE=[hrvatski], " +
                "CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF", result);
        }

        [Fact]
        public void CreateUserStatement_GivenCorrectUserData_ReturnsCorrectSQLStatement()
        {
            var db = new Database
            {
                Username = "TestUser",
                Name = "TestDB"
            };

            var sqlGenerator = new SqlGenerator();
            var result = sqlGenerator.CreateUserStatement(db);

            var expected = $"USE [TestDB];{Environment.NewLine}" +
                $"CREATE USER [TestUser] FOR LOGIN [TestUser] WITH DEFAULT_SCHEMA=[dbo];{Environment.NewLine}" +
                $"USE [TestDB];{Environment.NewLine}" +
                $"EXEC sp_addrolemember N'db_datareader', N'TestUser';{Environment.NewLine}" +
                $"USE [TestDB];{Environment.NewLine}" +
                $"EXEC sp_addrolemember N'db_datawriter', N'TestUser';{Environment.NewLine}" +
                $"USE [TestDB];{Environment.NewLine}" +
                $"EXEC sp_addrolemember N'db_owner', N'TestUser';{Environment.NewLine}";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DatabaseInsertStatement_GivenCorrectDataToInsert_ReturnsCorrectSQLStatement()
        {
            var db = new Database
            {
                TeamNumber = "123",
                Name = "TestDB",
                Username = "TestUser",
                Password = "password"
            };
            var sqlGenerator = new SqlGenerator();
            var result = sqlGenerator.DatabaseInsertStatement(db);

            var expected = "INSERT INTO StudentskeBaze.dbo.Databases (TeamNumber, Name, CreationDate, Username, Password) VALUES " +
                "('" + db.TeamNumber + "', '" + db.Name + "', GETDATE(), '" + db.Username + "', '" + db.Password + "')";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CompleteSqlStatement_GivenCorrectData_ReturnsCorrectSQLStatement()
        {
            var db = new Database
            {
                Name = "TestDB",
                Username = "TestUser",
                Password = "password"
            };

            var sqlGenerator = new SqlGenerator();
            var result  = sqlGenerator.CompleteSqlStatement(db);
            var expected = "CREATE DATABASE [TestDB];" + Environment.NewLine + Environment.NewLine +
                "CREATE LOGIN [TestUser] WITH PASSWORD='password', " +
                "DEFAULT_DATABASE=[TestDB], DEFAULT_LANGUAGE=[hrvatski], " +
                "CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF" + Environment.NewLine + Environment.NewLine +
                $"USE [TestDB];{Environment.NewLine}" +
                $"CREATE USER [TestUser] FOR LOGIN [TestUser] WITH DEFAULT_SCHEMA=[dbo];{Environment.NewLine}" +
                $"USE [TestDB];{Environment.NewLine}" +
                $"EXEC sp_addrolemember N'db_datareader', N'TestUser';{Environment.NewLine}" +
                $"USE [TestDB];{Environment.NewLine}" +
                $"EXEC sp_addrolemember N'db_datawriter', N'TestUser';{Environment.NewLine}" +
                $"USE [TestDB];{Environment.NewLine}" +
                $"EXEC sp_addrolemember N'db_owner', N'TestUser';";

            Assert.Equal(expected.TrimEnd(), result.TrimEnd());
        }

        [Fact]
        public void UpdateMailStatement_GivenCorrectTeamNumber_ReturnsCorrectSQLStatement()
        {
            var teamNumber = "User";

            var sqlGenerator = new SqlGenerator();
            var result = sqlGenerator.UpdateMailStatement(teamNumber);
            var expected = $"UPDATE StudentskeBaze.dbo.Databases SET EmailSent = 1 WHERE TeamNumber='User';";
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CreateDropUserStatement_GivenUsernameIsValid_ReturnsCorrectSQLStatement()
        {
            var sqlGenerator = new SqlGenerator();
            var username = "username";
            var expectedSqlStatement = $"DROP USER IF EXISTS \"{username}\";";

            var generatedSql = sqlGenerator.CreateDropUserStatement(username);

            Assert.Equal(expectedSqlStatement, generatedSql);
        }

        [Fact]
        public void CreateDropLoginStatement_GivenUsernameIsValid_ReturnsCorrectSQLStatement()
        {
            var sqlGenerator = new SqlGenerator();
            var username = "username";
            var expectedSqlStatement = $"DROP LOGIN \"{username}\";";

            var generatedSql = sqlGenerator.CreateDropLoginStatement(username);

            Assert.Equal(expectedSqlStatement, generatedSql);
        }

        [Fact]
        public void CreateDropDatabaseStatement_GivenDatabaseNameIsValid_ReturnsCorrectSQLStatement()
        {
            var sqlGenerator = new SqlGenerator();
            var databaseName = "db_name";
            var expectedSqlStatement = $"DROP DATABASE IF EXISTS \"{databaseName}\";";

            var generatedSql = sqlGenerator.CreateDropDatabaseStatement(databaseName);

            Assert.Equal(expectedSqlStatement, generatedSql);
        }

        [Fact]
        public void CreateDeleteDatabaseRecordStatement_GivenTeamNumberIsValid_ReturnsCorrectSQLStatement()
        {
            var sqlGenerator = new SqlGenerator();
            var teamNumber = "01_TM";
            var expectedSqlStatement =
                $"DELETE FROM StudentskeBaze.dbo.Databases WHERE TeamNumber = '{teamNumber}';";

            var generatedSql = sqlGenerator.CreateDeleteDatabaseRecordStatement(teamNumber);

            Assert.Equal(expectedSqlStatement, generatedSql);
        }

        [Fact]
        public void CreateSqlCloseConnectionStatement_GivenTeamNumberIsValid_ReturnsCorrectSQLStatement()
        {
            var sqlGenerator = new SqlGenerator();
            var databaseName = "database";
            var expectedSqlStatement =
                "USE [master];" + Environment.NewLine +
                "DECLARE @kill varchar(8000) = '';" + Environment.NewLine +
                "SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'" + Environment.NewLine +
                "FROM sys.dm_exec_sessions" + Environment.NewLine +
                $"WHERE database_id  = db_id('{databaseName}') AND is_user_process = 1" + Environment.NewLine +
                "EXEC(@kill);";

            var generatedSql = sqlGenerator.CreateSqlCloseConnectionStatement(databaseName);

            Assert.Equal(expectedSqlStatement, generatedSql);
        }

        [Fact]
        public void CreateArchiveDatabaseOnServerStatement_GivenDatabaseNameIsValid_ReturnsCorrectSQLStatement()
        {
            var sqlGenerator = new SqlGenerator();
            var databaseName = "01_TM";
            var expectedSqlStatement =
                "USE [master];" + Environment.NewLine +
                $"IF EXISTS (SELECT name FROM sys.databases WHERE name = '{databaseName}') " +
                $"EXEC sp_detach_db '{databaseName}';" + Environment.NewLine;

            var generatedSql = sqlGenerator.CreateArchiveDatabaseOnServerStatement(databaseName);

            Assert.Equal(expectedSqlStatement, generatedSql);
        }

        [Fact]
        public void CreateArchiveDatabaseInTableStatement_GivenTeamNumberIsValid_ReturnsCorrectSQLStatement()
        {
            var sqlGenerator = new SqlGenerator();
            var teamNumber = "01_TM";
            var expectedSqlStatement =
                $"UPDATE StudentskeBaze.dbo.Databases SET Archived = 1 WHERE TeamNumber='{teamNumber}';";

            var generatedSql = sqlGenerator.CreateArchiveDatabaseInTableStatement(teamNumber);

            Assert.Equal(expectedSqlStatement, generatedSql);
        }
    }
}
