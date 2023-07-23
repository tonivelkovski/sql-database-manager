using SQL_Database_Generator.Extensions;
using SQL_Database_Generator.Models;
using SQL_Database_Generator.Repositories;

namespace SQL_Database_Generator.Services
{
    public class MailSettingsService : IMailSettingsService
    {
        private readonly IMailSettingsRepository _mailSettingsRepository;

        public MailSettingsService(IMailSettingsRepository repository)
        {
            _mailSettingsRepository = repository;
        }

        public MailSettingsService() : this(new MailSettingsRepository())
        { }

        public MailSettings GetSettings() =>
            _mailSettingsRepository.GetSettings();

        public void UpdateSettings(MailSettings settings)
        {
            settings.ThrowIfNull(nameof(settings));
            _mailSettingsRepository.UpdateSettings(settings);
        }
    }
}
