using SQL_Database_Generator.Models;
using SQL_Database_Generator.Services;
using System;
using Xunit;

namespace SQL_Database_Generator.UnitTests
{
    public class SqlExecutor_UnitTests
    {
        [Fact]
        public void ExecuteCompleteDeleteStatement_GivenDatabaseIsNull_ThrowsArgumentNullException()
        {
            var sqlExecutor = new SqlExecutor();

            void actNull() => sqlExecutor.ExecuteCompleteDeleteStatement(null);

            Assert.Throws<ArgumentNullException>(actNull);
        }

        [Fact]
        public void ExecuteCompleteDeleteStatement_GivenDatabaseNameIsNull_ThrowsArgumentNullException()
        {
            var sqlExecutor = new SqlExecutor();
            var database = new Database
            {
                Username = "daniel",
                Name = null,
                TeamNumber = "T1",
            };

            void actNull() => sqlExecutor.ExecuteCompleteDeleteStatement(database);

            Assert.Throws<ArgumentNullException>(actNull);
        }

        [Fact]
        public void ExecuteCompleteDeleteStatement_GivenDatabaseNameIsEmpty_ThrowsArgumentException()
        {
            var sqlExecutor = new SqlExecutor();
            var database = new Database
            {
                Username = "daniel",
                Name = "",
                TeamNumber = "T1",
            };

            void actNull() => sqlExecutor.ExecuteCompleteDeleteStatement(database);

            Assert.Throws<ArgumentException>(actNull);
        }

        [Fact]
        public void ExecuteCompleteCreateStatement_GivenDatabaseIsNull_ThrowsArgumentNullException()
        {
            var sqlExecutor = new SqlExecutor();

            void actNull() => sqlExecutor.ExecuteCompleteCreateStatement(null);

            Assert.Throws<ArgumentNullException>(actNull);
        }

        [Fact]
        public void ExecuteCompleteCreateStatement_GivenDatabasePasswordIsNull_ThrowsArgumentNullException()
        {
            var sqlExecutor = new SqlExecutor();
            var database = new Database
            {
                Username = "pero",
                Name = "kos",
                TeamNumber = "T1",
                Password = null
            };

            void actNull() => sqlExecutor.ExecuteCompleteCreateStatement(database);

            Assert.Throws<ArgumentNullException>(actNull);
        }      

        [Fact]
        public void ExecuteCompleteCreateStatement_GivenDatabaseTeamnumberIsEmpty_ThrowsArgumentException()
        {
            var sqlExecutor = new SqlExecutor();
            var database = new Database
            {
                Username = "pero",
                Name = "kos",
                TeamNumber = "",
                Password = "žnj"
            };

            void actNull() => sqlExecutor.ExecuteCompleteCreateStatement(database);

            Assert.Throws<ArgumentException>(actNull);
        }

        [Fact]
        public void ExecuteCompleteArchiveStatement_GivenDatabaseIsNull_ThrowsArgumentNullException()
        {
            var sqlExecutor = new SqlExecutor();
            Database database = null;

            void actNull() => sqlExecutor.ExecuteCompleteArchiveStatement(database);

            Assert.Throws<ArgumentNullException>(actNull);
        }

        [Fact]
        public void ExecuteCompleteArchiveStatement_GivenDatabaseTeamNumberIsNull_ThrowsArgumentNullException()
        {
            var sqlExecutor = new SqlExecutor();
            var database = new Database
            {
                Username = "pero",
                Name = "kos",
                TeamNumber = null,
                Password = "žnj"
            };

            void actNull() => sqlExecutor.ExecuteCompleteArchiveStatement(database);

            Assert.Throws<ArgumentNullException>(actNull);
        }

        [Fact]
        public void ExecuteCompleteArchiveStatement_GivenDatabaseTeamNumberIsEmpty_ThrowsArgumentException()
        {
            var sqlExecutor = new SqlExecutor();
            var database = new Database
            {
                Username = "pero",
                Name = "kos",
                TeamNumber = "",
                Password = "žnj"
            };

            void actNull() => sqlExecutor.ExecuteCompleteArchiveStatement(database);

            Assert.Throws<ArgumentException>(actNull);
        }
    }
}
