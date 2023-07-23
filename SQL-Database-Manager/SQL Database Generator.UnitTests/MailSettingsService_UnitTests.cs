using FakeItEasy;
using SQL_Database_Generator.Models;
using SQL_Database_Generator.Repositories;
using SQL_Database_Generator.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace SQL_Database_Generator.UnitTests
{
    public class MailSettingsService_UnitTests
    {
        private readonly IMailSettingsRepository _mailSettingsRepository;
        private readonly MailSettingsService _mailSettingsService;

        public MailSettingsService_UnitTests()
        {
            _mailSettingsRepository = A.Fake<IMailSettingsRepository>();
            _mailSettingsService = new MailSettingsService(_mailSettingsRepository);
        }

        [Fact]
        public void GetSettings_ShouldReturnSettingsFromRepository()
        {
            var expectedSettings = new MailSettings
            {
                DefaultSender = "noreply@foi.hr",
                DefaultBccRecepients = new List<string> { "mmijac@foi.hr" },
                DefaultSubject = "Baza podataka"
            };
            A.CallTo(() => _mailSettingsRepository.GetSettings()).Returns(expectedSettings);

            var actualSettings = _mailSettingsService.GetSettings();

            Assert.Equal(expectedSettings.DefaultSender, actualSettings.DefaultSender);
            Assert.Equal(expectedSettings.DefaultBccRecepients.Count, actualSettings.DefaultBccRecepients.Count);
            Assert.Equal(expectedSettings.DefaultBccRecepients[0], actualSettings.DefaultBccRecepients[0]);
            Assert.Equal(expectedSettings.DefaultSubject, actualSettings.DefaultSubject);
        }

        [Fact]
        public void UpdateSettings_GivenValidMailSettings_ShouldCallUpdateSettingsOnRepository()
        {
            var settings = new MailSettings
            {
                DefaultSender = "noreply@foi.hr",
                DefaultBccRecepients = new List<string> { "mmijac@foi.hr" },
                DefaultSubject = "Baza podataka"
            };

            _mailSettingsService.UpdateSettings(settings);

            A.CallTo(() => _mailSettingsRepository.UpdateSettings(settings)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void UpdateSettings_GivenNull_ThrowsArgumentNullException()
        {
            void act()
            {
                _mailSettingsService.UpdateSettings(null);
            }

            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
