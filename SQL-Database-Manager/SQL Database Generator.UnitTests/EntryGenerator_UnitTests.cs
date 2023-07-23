using SQL_Database_Generator.Utils;
using Xunit;

namespace SQL_Database_Generator.UnitTests
{
    public class EntryGenerator_UnitTests
    {
        [Fact]
        public void GenerateName_GivenTeamnumberIsCorrect_ReturnsGeneratedName()
        {
            string teamNumber = "123";

            string generatedName = EntryGenerator.GenerateName(teamNumber);

            Assert.Equal("123_DB", generatedName);
        }

        [Fact]
        public void GenerateName_GivenTeamnumberIsNull_GeneratedNameContainsOnlySuffix()
        {
            string teamNumber = null;

            string generatedName = EntryGenerator.GenerateName(teamNumber);

            Assert.Equal("_DB", generatedName);
        }

        [Fact]
        public void GenerateName_GivenPrefixAndTeamnumberAndSuffixIsCorrect_NameIsGenerated()
        {
            string prefix = "DB";
            string teamNumber = "User";
            string customSuffix = "_DB";
             
            string actualName = EntryGenerator.GenerateName(prefix, teamNumber, customSuffix);

            Assert.Equal("DBUser_DB", actualName);
        }

        [Fact]
        public void GenerateName_GivenPrefixAndTeamnumberAndSuffixAreNull_GeneratedNameIsEmpty()
        {       
            string actualName = EntryGenerator.GenerateName(string.Empty, string.Empty, string.Empty);

            Assert.Equal(string.Empty, actualName);
        }

        [Fact]
        public void GenerateUsername_GivenCorrectTeamnumber_UsernameIsGenerated()
        {
            string teamNumber = "User";

            string actualUsername = EntryGenerator.GenerateUsername(teamNumber);

            Assert.Equal("User_User", actualUsername);
        }

        [Fact]
        public void GenerateUsername_GivenTeamnumberIsNull_GeneratedUsernameContainsOnlySuffix()
        {
            string teamNumber = null;

            string actualUsername = EntryGenerator.GenerateUsername(teamNumber);

            Assert.Equal("_User", actualUsername);
        }

        [Fact]
        public void GeneratePassword_GivenMethodIsCalled_PasswordIsGeneratedAndNotNull()
        {
            string password = EntryGenerator.GeneratePassword();

            Assert.NotNull(password);
            Assert.NotEmpty(password);
        }

        [Fact]
        public void GeneratePassword_GivenMethodIsCalled_PasswordLengthIsEightCharacters()
        {
            string password = EntryGenerator.GeneratePassword();

            Assert.NotNull(password);
            Assert.Equal(8, password.Length);
        }
    }
}
