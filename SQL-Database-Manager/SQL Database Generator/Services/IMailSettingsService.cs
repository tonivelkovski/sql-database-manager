using SQL_Database_Generator.Models;

namespace SQL_Database_Generator.Services
{
    public interface IMailSettingsService
    {
        MailSettings GetSettings();
        void UpdateSettings(MailSettings settings);
    }
}
