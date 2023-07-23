using FakeItEasy;
using SQL_Database_Generator.Models;
using SQL_Database_Generator.Repositories;
using System.Collections.Generic;
using System.Data.Common;
using Xunit;

namespace SQL_Database_Generator.UnitTests
{
    public class MailSettingsRepository_UnitTests
    {
        [Fact]
        public void GetSettings_GivenMethodIsCalled_ReturnsCorrectMailSettings()
        {
            var dr = A.Fake<DbDataReader>();
            var expectedSettings = new MailSettings
            {
                DefaultSender = "noreply@foi.hr",
                DefaultBccRecepients = new List<string> { "mmijac@foi.hr" },
                DefaultSubject = "Baza podataka"
            };
            A.CallTo(() => dr.Read()).Returns(true);
            A.CallTo(() => dr["Sender"]).Returns(expectedSettings.DefaultSender);
            A.CallTo(() => dr["BccRecepients"]).Returns(expectedSettings.DefaultBccRecepients[0]);
            A.CallTo(() => dr["Subject"]).Returns(expectedSettings.DefaultSubject);

            var dbConnector = A.Fake<IDbConnector>();
            A.CallTo(() => dbConnector.GetDataReader(A<string>.Ignored)).Returns(dr);

            var mailSettingsRepository = new MailSettingsRepository(dbConnector);

            var actualSettings = mailSettingsRepository.GetSettings();

            Assert.Equal(expectedSettings.DefaultSender, actualSettings.DefaultSender);
            Assert.Equal(expectedSettings.DefaultBccRecepients.Count, actualSettings.DefaultBccRecepients.Count);
            Assert.Equal(expectedSettings.DefaultBccRecepients[0], actualSettings.DefaultBccRecepients[0]);
            Assert.Equal(expectedSettings.DefaultSubject, actualSettings.DefaultSubject);
        }

        [Fact]
        public void UpdateSettings_GivenSampleMailSettings_SuccessfullySavesSettings()
        {
            var dbConnector = A.Fake<IDbConnector>();
            A.CallTo(() => dbConnector.ExecuteQuery(A<string>.Ignored)).Returns(1);
            var mailSettingsRepository = new MailSettingsRepository(dbConnector);

            mailSettingsRepository.UpdateSettings(new MailSettings
            {
                DefaultSender = "noreply@foi.hr",
                DefaultBccRecepients = new List<string> { "mmijac@foi.hr" },
                DefaultSubject = "Baza podataka"
            });

            A.CallTo(() => dbConnector.ExecuteQuery(A<string>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void UpdateSettings_GivenEdgeCaseMailSettings_SuccessfullySavesSettings()
        {
            var dbConnector = A.Fake<IDbConnector>();
            A.CallTo(() => dbConnector.ExecuteQuery(A<string>.Ignored)).Returns(1);
            var mailSettingsRepository = new MailSettingsRepository(dbConnector);

            mailSettingsRepository.UpdateSettings(new MailSettings
            {
                DefaultSender = "",
                DefaultBccRecepients = null,
                DefaultSubject = ""
            });

            A.CallTo(() => dbConnector.ExecuteQuery(A<string>.Ignored)).MustHaveHappenedOnceExactly();
        }
    }
}
