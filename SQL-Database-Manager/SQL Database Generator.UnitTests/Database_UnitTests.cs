using SQL_Database_Generator.Models;
using SQL_Database_Generator.Repositories;
using Xunit;

namespace SQL_Database_Generator.UnitTests
{
    public class Database_UnitTests
    {
        [Fact]
        public void GetInfo_GivenTeamnumberAndNameAndUsernameAndPasswordAreCorrect_ReturnsCorrectEmailText()
        {
            var database = new Database
            {
                TeamNumber = "User",
                Name = "User_DB",
                Username = "User",
                Password = "password"
            };

            string expectedEmailText = $"Poštovani,{System.Environment.NewLine}{System.Environment.NewLine}" +
                $"Vaši podaci za bazu su sljedeći: {System.Environment.NewLine}" +
                $"Server Type: Database Engine{System.Environment.NewLine}" +
                $"Server Name: {DbConnector.Server}{System.Environment.NewLine}" +
                $"Authentication: SQL Server Authentication{System.Environment.NewLine}" +
                $"Login: {database.Username}{System.Environment.NewLine}" +
                $"Password: {database.Password}{System.Environment.NewLine}" +
                $"Database: {database.Name}{System.Environment.NewLine}{System.Environment.NewLine}" +
                $"Baza podataka je MS SQL. Preporučamo pristupanje preko klijentske aplikacije Microsoft SQL " +
                $"Management Studio v.18.{System.Environment.NewLine}{System.Environment.NewLine}" +
                $"Lijep pozdrav!";

            string actualEmailText = database.GetInfo();

            Assert.Equal(expectedEmailText, actualEmailText);
        }

        [Fact]
        public void GetInfo_GivenTeamnumberIsNull_ReturnsCorrectEmailText()
        {
            var database = new Database();

            string expectedEmailText = $"Poštovani,{System.Environment.NewLine}{System.Environment.NewLine}" +
                $"Vaši podaci za bazu su sljedeći: {System.Environment.NewLine}" +
                $"Server Type: Database Engine{System.Environment.NewLine}" +
                $"Server Name: {DbConnector.Server}{System.Environment.NewLine}" +
                $"Authentication: SQL Server Authentication{System.Environment.NewLine}" +
                $"Login: {database.Username}{System.Environment.NewLine}" +
                $"Password: {database.Password}{System.Environment.NewLine}" +
                $"Database: {database.Name}{System.Environment.NewLine}{System.Environment.NewLine}" +
                $"Baza podataka je MS SQL. Preporučamo pristupanje preko klijentske aplikacije Microsoft SQL " +
                $"Management Studio v.18.{System.Environment.NewLine}{System.Environment.NewLine}" +
                $"Lijep pozdrav!";

            string actualEmailText = database.GetInfo();

            Assert.Equal(expectedEmailText, actualEmailText);
        }

        [Fact]
        public void EmailSent_GivenEmailSentProperty_DefaultValueIsZero()
        {
            var database = new Database();

            Assert.Equal(0, database.EmailSent);
        }
    }
}
