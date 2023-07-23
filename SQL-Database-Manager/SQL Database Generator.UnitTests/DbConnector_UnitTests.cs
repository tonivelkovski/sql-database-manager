using SQL_Database_Generator.Repositories;
using System;
using Xunit;

namespace SQL_Database_Generator.UnitTests
{
    public class DbConnector_UnitTests
    {
        [Fact]
        public void DbConnector_GivenNullServer_ThrowsArgumentNullException()
        {
            DbConnector.Server = null;

            void act()
            {
                var instance = DbConnector.Instance;
            }

            var ex = Assert.Throws<ArgumentNullException>(act);
            Assert.Contains("Server", ex.Message);
        }

        [Fact]
        public void DbConnector_GivenEmptyServer_ThrowsArgumentException()
        {
            DbConnector.Server = "";

            void act()
            {
                var instance = DbConnector.Instance;
            }

            var ex = Assert.Throws<ArgumentException>(act);
            Assert.Contains("Server", ex.Message);
        }

        [Fact]
        public void DbConnector_GivenNullUsername_ThrowsArgumentNullException()
        {
            DbConnector.Server = "localhost";
            DbConnector.AdminUsername = null;

            void act()
            {
                var instance = DbConnector.Instance;
            }

            var ex = Assert.Throws<ArgumentNullException>(act);
            Assert.Contains("Username", ex.Message);
        }

        [Fact]
        public void DbConnector_GivenEmptyUsername_ThrowsArgumentException()
        {
            DbConnector.Server = "localhost";
            DbConnector.AdminUsername = "";

            void act()
            {
                var instance = DbConnector.Instance;
            }

            var ex = Assert.Throws<ArgumentException>(act);
            Assert.Contains("Username", ex.Message);
        }

        [Fact]
        public void DbConnector_GivenNullPassword_ThrowsArgumentNullException()
        {
            DbConnector.Server = "localhost";
            DbConnector.AdminUsername = "pero";
            DbConnector.AdminPassword = null;

            void act()
            {
                var instance = DbConnector.Instance;
            }

            var ex = Assert.Throws<ArgumentNullException>(act);
            Assert.Contains("Password", ex.Message);
        }

        [Fact]
        public void DbConnector_GivenEmptyPassword_ThrowsArgumentException()
        {
            DbConnector.Server = "localhost";
            DbConnector.AdminUsername = "pero";
            DbConnector.AdminPassword = "";

            void act()
            {
                var instance = DbConnector.Instance;
            }

            var ex = Assert.Throws<ArgumentException>(act);
            Assert.Contains("Password", ex.Message);
        }
    }
}
