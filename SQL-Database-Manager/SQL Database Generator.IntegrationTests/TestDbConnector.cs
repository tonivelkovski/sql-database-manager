using SQL_Database_Generator.Repositories;
using System.Data.Common;
using System.Data.SqlClient;
using Testcontainers.MsSql;

namespace SQL_Database_Generator.IntegrationTests
{
    public class TestDbConnector : IDbConnector
    {
        private static TestDbConnector _instance;
        private readonly SqlConnection _connection;

        private TestDbConnector()
        {
            var connectionString = $"server=localhost,{MsSqlBuilder.MsSqlPort};user id={MsSqlBuilder.DefaultUsername};password={MsSqlBuilder.DefaultPassword};database={MsSqlBuilder.DefaultDatabase}";
            _connection = new SqlConnection(connectionString);
            _connection.Open();

            InitDb();
        }

        private void InitDb()
        {
            ExecuteQuery("CREATE DATABASE StudentskeBaze;");
            ExecuteQuery("CREATE TABLE StudentskeBaze.dbo.Databases (Id int IDENTITY(0,1) NOT NULL,TeamNumber varchar(50) NOT NULL,Name varchar(50) NOT NULL,CreationDate datetime NOT NULL,Username varchar(50) NOT NULL,Password varchar(50) NOT NULL,Note text NULL,ContactEmail varchar(200) NULL,EmailSent int DEFAULT 0 NOT NULL,Archived int DEFAULT 0 NOT NULL);");
            ExecuteQuery("CREATE TABLE StudentskeBaze.dbo.MailSettings(Lock char(1) NOT NULL CONSTRAINT DF_MailSettings_Lock DEFAULT 'X',Sender varchar(70) NOT NULL DEFAULT 'noreply_pi@foi.hr',BccRecepients varchar(200) NOT NULL DEFAULT 'mmijac@foi.hr',Subject varchar(70) NOT NULL DEFAULT 'Baza podataka za projekt iz Programskog inzenjerstva',CONSTRAINT PK_MailSettings PRIMARY KEY (Lock),CONSTRAINT CK_MailSettings_Locked CHECK (Lock='X'));");
            ExecuteQuery("INSERT INTO StudentskeBaze.dbo.MailSettings DEFAULT VALUES;");
        }

        public static TestDbConnector Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TestDbConnector();
                }
                return _instance;
            }
        }

        public static void Destory()
        {
            _instance = null;
        }

        public DbDataReader GetDataReader(string sqlQuery) =>
            new SqlCommand(sqlQuery, _connection).ExecuteReader();

        public int ExecuteQuery(string sqlQuery) =>
            new SqlCommand(sqlQuery, _connection).ExecuteNonQuery();

        public object ExecuteScalar(string sqlQuery) =>
            new SqlCommand(sqlQuery, _connection).ExecuteScalar();
    }
}
