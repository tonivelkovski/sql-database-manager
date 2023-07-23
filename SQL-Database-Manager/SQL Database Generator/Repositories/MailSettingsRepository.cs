using SQL_Database_Generator.Models;
using SQL_Database_Generator.Utils;
using System.Linq;

namespace SQL_Database_Generator.Repositories
{
    public class MailSettingsRepository : IMailSettingsRepository
    {
        private readonly IDbConnector _dbConnector;
        private readonly SqlGenerator _sqlGenerator;

        public MailSettingsRepository(IDbConnector dbConnector)
        {
            _dbConnector = dbConnector;
            _sqlGenerator = new SqlGenerator();
        }

        public MailSettingsRepository() : this(DbConnector.Instance)
        { }

        public MailSettings GetSettings()
        {
            var sql = _sqlGenerator.CreateGetMailSettingsStatement();
            var dr = _dbConnector.GetDataReader(sql);

            dr.Read();
            var settings = new MailSettings
            {
                DefaultSender = dr["Sender"].ToString(),
                DefaultBccRecepients = dr["BccRecepients"].ToString().Split(';').ToList(),
                DefaultSubject = dr["Subject"].ToString()
            };
            dr.Close();

            return settings;
        }

        public void UpdateSettings(MailSettings settings)
        {
            var sql = _sqlGenerator.CreateUpdateMailSettingsStatement(settings);
            _dbConnector.ExecuteQuery(sql);
        }
    }
}
