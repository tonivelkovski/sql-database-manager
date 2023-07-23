using SQL_Database_Generator.Models;
using SQL_Database_Generator.Utils;
using System;
using System.Collections.Generic;
using Xunit;

namespace SQL_Database_Generator.UnitTests
{
    public class DataImporter_UnitTests
    {
        [Fact]
        public void Import_GivenUsersAreImported_ReturnsDatabaseList()
        {
            string[] students = { "User;User_DB;User;žnj", "User2;User2_DB;User2;bla" };

            var result = DataImporter.Import(students);

            Assert.NotNull(result);
            Assert.IsType<List<Database>>(result);
        }

        [Fact]
        public void Import_GivenValidRawUserData_UserIsImported()
        {
            string[] students = { "User;User_DB;User;žnj" };

            var result = DataImporter.Import(students);

            Assert.Equal("User", result[0].TeamNumber);
            Assert.Equal("User_DB", result[0].Name);
            Assert.Equal("User", result[0].Username);
            Assert.NotNull(result[0].Password);
        }

        [Fact]
        public void Import_GivenValidRawUserData_CreationDateIsImported()
        {
            string[] students = { "User;User_DB;User;žnj" };

            var result = DataImporter.Import(students);
            DateTime expectedDate = DateTime.Today;

            Assert.Equal(expectedDate, result[0].CreationDate);
        }

        [Fact]
        public void Import_GivenValidRawUserData_SingleUserIsImported()
        {
            string[] students = { "User;User_DB;User;žnj" };

            var result = DataImporter.Import(students);

            Assert.IsType<List<Database>>(result);
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public void Import_GivenUserWithIncompleteData_UserIsNotImported()
        {
            string[] students = { ";kjčl_DB;ksdhfk;jkjl", "; kjčl_DB; ; jkjl", "kjodfs; kjčl_DB; ksdhfk; jkjl" };

            var result = DataImporter.Import(students);

            Assert.IsType<List<Database>>(result);
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public void Import_GivenUserDataIsMissing_ReturnsEmptyList()
        {
            string[] students = { "User_DB;User;žnj" };

            var result = DataImporter.Import(students);

            Assert.Empty(result);
        }

        [Fact]
        public void Import_GivenDataContainsMoreAttributes_ReturnsEmptyList()
        {
            string[] students = { "User;User_DB;User;žnj;Viška" };

            var result = DataImporter.Import(students);

            Assert.Empty(result);
        }

        [Fact]
        public void Import_GivenDataDelimiterIsNotValid_UserDataIsNotImported()
        {
            string[] students = { "User:User_DB:User:žnj", "User,User_DB,User,žnj" };

            var result = DataImporter.Import(students);

            Assert.Empty(result);
        }
    }
}
