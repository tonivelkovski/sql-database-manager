using SQL_Database_Generator.Models;

namespace SQL_Database_Generator.Repositories
{
    public interface IMailSettingsRepository
    {
        MailSettings GetSettings();
        void UpdateSettings(MailSettings settings);
    }
}
