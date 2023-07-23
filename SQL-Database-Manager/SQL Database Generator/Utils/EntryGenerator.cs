namespace SQL_Database_Generator.Utils
{
    public static class EntryGenerator
    {
        private const string _databasePrefix = "";
        private const string _databaseSuffix = "_DB";

        private const string _usernamePrefix = "";
        private const string _usernameSuffix = "_User";

        public static string GenerateName(string teamNumber) =>
            GenerateName(_databasePrefix, teamNumber, _databaseSuffix);

        public static string GenerateName(string prefix, string teamNumber, string suffix) =>
            prefix + teamNumber + suffix;

        public static string GenerateUsername(string teamNumber) =>
            GenerateName(_usernamePrefix, teamNumber, _usernameSuffix);

        public static string GeneratePassword() =>
            System.Web.Security.Membership.GeneratePassword(8, 0);
    }
}
