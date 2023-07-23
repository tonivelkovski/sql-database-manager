using SQL_Database_Generator.Models;
using SQL_Database_Generator.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace SQL_Database_Generator.IntegrationTests
{
    public class DataImporter_IntegrationTests
    {
        [Fact]
        public void Import_GivenEmptyTestDataFile_ReturnsEmptyDatabaseList()
        {
            string fileName = "EmptyFile.csv";
            string[] students = ParseCSVFile(fileName);

            var result = DataImporter.Import(students);

            Assert.IsType<List<Database>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public void Import_GivenTestDataFileWithOneUser_ReturnsImportedUser()
        {
            string fileName = "SingleUser.csv";
            string[] students = ParseCSVFile(fileName);

            var result = DataImporter.Import(students);

            Assert.Single(result);
            Assert.Equal("User", result[0].TeamNumber);
            Assert.Equal("User_DB", result[0].Name);
            Assert.Equal("User", result[0].Username);
            Assert.NotNull(result[0].Password);
        }

        [Fact]
        public void Import_GivenTestDataFileWithMultipleUsers_MultipleUsersAreAdded()
        {
            string fileName = "MultipleUsersFile.csv";
            string[] students = ParseCSVFile(fileName);

            var result = DataImporter.Import(students);

            Assert.NotEmpty(result);
            Assert.Equal(4, result.Count);
            Assert.Equal("User", result[0].Username);
            Assert.Equal("Tim2", result[1].Username);
            Assert.Equal("Tim3", result[2].Username);
            Assert.Equal("Tim4", result[3].Username);
        }

        [Fact]
        public void Import_GivenTestDataFileWithWrongDelimiters_UserDataIsNotImported()
        {
            string fileName = "WrongDelimiter.csv";
            string[] students = ParseCSVFile(fileName);

            var result = DataImporter.Import(students);

            Assert.Empty(result);
        }

        [Fact]
        public void Import_GivenTestDataFileWithMoreOrLessAttributesThanExpected_UserDataIsNotImported()
        {
            string fileName = "FileWithMoreOrLessAttributes.csv";
            string[] students = ParseCSVFile(fileName);

            var result = DataImporter.Import(students);

            Assert.Empty(result);
        }

        private string[] ParseCSVFile(string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\TestData", fileName);

            using (StreamReader streamReader = new StreamReader(path))
            {
                string fileContent = streamReader.ReadToEnd();

                char[] delims = new[] { '\r', '\n' };
                string[] students = fileContent.Split(delims, StringSplitOptions.RemoveEmptyEntries);

                return students;
            }
        }
    }
}
