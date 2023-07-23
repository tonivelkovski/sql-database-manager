using SQL_Database_Generator.Models;
using SQL_Database_Generator.Repositories;
using SQL_Database_Generator.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace SQL_Database_Generator.IntegrationTests
{
    [Collection("Sequential")]
    public class MailSettingsService_IntegrationTests : IntegrationTest
    {
        private readonly MailSettings defaultMailSettings = new MailSettings
        {
            DefaultSender = "noreply_pi@foi.hr",
            DefaultBccRecepients = new List<string> { "mmijac@foi.hr" },
            DefaultSubject = "Baza podataka za projekt iz Programskog inzenjerstva"
        };

        [Fact]
        public void GetSettings_GivenMethodIsCalled_ReturnsDefaultMailSettings()
        {
            var dbConnector = TestDbConnector.Instance;
            var mailSettingsRepository = new MailSettingsRepository(dbConnector);
            var mailSettingsService = new MailSettingsService(mailSettingsRepository);

            var actualSettings = mailSettingsService.GetSettings();

            Assert.Equal(defaultMailSettings.DefaultSender, actualSettings.DefaultSender);
            Assert.Equal(defaultMailSettings.DefaultBccRecepients.Count, actualSettings.DefaultBccRecepients.Count);
            Assert.Equal(defaultMailSettings.DefaultBccRecepients[0], actualSettings.DefaultBccRecepients[0]);
            Assert.Equal(defaultMailSettings.DefaultSubject, actualSettings.DefaultSubject);
        }

        [Fact]
        public void UpdateSettings_GivenNullMailSettings_ThrowsArgumentNullException()
        {
            var dbConnector = TestDbConnector.Instance;
            var mailSettingsRepository = new MailSettingsRepository(dbConnector);
            var mailSettingsService = new MailSettingsService(mailSettingsRepository);

            void act()
            {
                mailSettingsService.UpdateSettings(null);
            }

            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void UpdateSettings_GivenFullSampleMailSettings_SuccessfullySavesSettings()
        {
            var dbConnector = TestDbConnector.Instance;
            var mailSettingsRepository = new MailSettingsRepository(dbConnector);
            var mailSettingsService = new MailSettingsService(mailSettingsRepository);
            var newSettings = new MailSettings
            {
                DefaultSender = "noreply@foi.hr",
                DefaultBccRecepients = new List<string> {
                    "dskrlac20@student.foi.hr",
                    "tvelkovsk20@student.foi.hr",
                    "ttomasic20@student.foi.hr"
                },
                DefaultSubject = "Baza podataka za projekt iz Programskog inzenjerstva"
            };

            mailSettingsService.UpdateSettings(newSettings);
            var actualSettings = mailSettingsService.GetSettings();

            Assert.Equal(newSettings.DefaultSender, actualSettings.DefaultSender);
            Assert.Equal(newSettings.DefaultBccRecepients.Count, actualSettings.DefaultBccRecepients.Count);
            Assert.Equal(newSettings.DefaultBccRecepients[0], actualSettings.DefaultBccRecepients[0]);
            Assert.Equal(newSettings.DefaultBccRecepients[1], actualSettings.DefaultBccRecepients[1]);
            Assert.Equal(newSettings.DefaultBccRecepients[2], actualSettings.DefaultBccRecepients[2]);
            Assert.Equal(newSettings.DefaultSubject, actualSettings.DefaultSubject);
        }

        [Fact]
        public void UpdateSettings_GivenPartialSampleMailSettings_SuccessfullySavesSettings()
        {
            var dbConnector = TestDbConnector.Instance;
            var mailSettingsRepository = new MailSettingsRepository(dbConnector);
            var mailSettingsService = new MailSettingsService(mailSettingsRepository);
            var newSettings = new MailSettings
            {
                DefaultSender = null,
                DefaultBccRecepients = null,
                DefaultSubject = "Novi naslov"
            };

            mailSettingsService.UpdateSettings(newSettings);
            var actualSettings = mailSettingsService.GetSettings();

            Assert.Equal(defaultMailSettings.DefaultSender, actualSettings.DefaultSender);
            Assert.Equal(defaultMailSettings.DefaultBccRecepients.Count, actualSettings.DefaultBccRecepients.Count);
            Assert.Equal(defaultMailSettings.DefaultBccRecepients[0], actualSettings.DefaultBccRecepients[0]);
            Assert.Equal(newSettings.DefaultSubject, actualSettings.DefaultSubject);
        }

        [Fact]
        public void UpdateSettings_GivenEdgeCaseMailSettings_SuccessfullySavesSettings()
        {
            var dbConnector = TestDbConnector.Instance;
            var mailSettingsRepository = new MailSettingsRepository(dbConnector);
            var mailSettingsService = new MailSettingsService(mailSettingsRepository);
            var newSettings = new MailSettings
            {
                DefaultSender = "",
                DefaultBccRecepients = null,
                DefaultSubject = ""
            };

            mailSettingsService.UpdateSettings(newSettings);
            var actualSettings = mailSettingsService.GetSettings();

            Assert.Equal(defaultMailSettings.DefaultSender, actualSettings.DefaultSender);
            Assert.Equal(defaultMailSettings.DefaultBccRecepients.Count, actualSettings.DefaultBccRecepients.Count);
            Assert.Equal(defaultMailSettings.DefaultBccRecepients[0], actualSettings.DefaultBccRecepients[0]);
            Assert.Equal(defaultMailSettings.DefaultSubject, actualSettings.DefaultSubject);
        }
    }
}
