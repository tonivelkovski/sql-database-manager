using FakeItEasy;
using SQL_Database_Generator.Models;
using SQL_Database_Generator.Services.SmtpClientWrapper;
using SQL_Database_Generator.Services;
using System;
using System.Collections.Generic;
using Xunit;
using System.Net.Mail;

namespace SQL_Database_Generator.UnitTests
{
    public class MailService_UnitTests
    {
        [Fact]
        public void Send_GivenNullMailInfo_ThrowsArgumentNullException()
        {
            var mailer = new MailService();
            MailInfo mailInfo = null;

            void act()
            {
                mailer.Send(mailInfo);
            }

            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Send_GivenValidMailInfo_SuccessfullySendsAnEmail()
        {
            MailInfo mailInfo = new MailInfo
            {
                SenderAddress = "tin.tomasic74@gmail.com",
                RecepientAddresses = new List<string> { "tin.tomasic74@gmail.com" },
                Subject = "TIKPP Test",
                Message = "Test body."
            };
            var smtpClient = A.Dummy<ISmtpClient>();
            MailService.SmtpClient = smtpClient;
            var mailer = new MailService();

            mailer.Send(mailInfo);

            A.CallTo(() => smtpClient.Send(A<MailMessage>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void Send_GivenNullDatabase_ThrowsArgumentNullException()
        {
            var mailer = new MailService();
            Database db = null;

            void act()
            {
                mailer.Send(db, A.Dummy<MailSettings>());
            }

            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Send_GivenMailSettingsAreNull_ThrowsArgumentNullException()
        {
            var mailer = new MailService();
            Database db = new Database
            {
                Name = "test",
            };
            MailSettings mailSettings = null;

            void act()
            {
                mailer.Send(db, mailSettings);
            }

            var ex = Assert.Throws<ArgumentNullException>(act);
            Assert.Contains("mail", ex.Message);
        }

        [Fact]
        public void Send_GivenMailerDefaultSenderIsNull_ThrowsArgumentNullException()
        {
            var mailer = new MailService();
            Database db = new Database
            {
                Name = "test",
                ContactEmail = "ttomasic20@student.foi.hr"
            };
            var mailSettings = new MailSettings
            {
                DefaultSender = null
            };

            void act()
            {
                mailer.Send(db, mailSettings);
            }

            var ex = Assert.Throws<ArgumentNullException>(act);
            Assert.Contains("Sender", ex.Message);
        }

        [Fact]
        public void Send_GivenMailerDefaultSubjectIsEmpty_ThrowsArgumentException()
        {
            var mailer = new MailService();
            Database db = new Database
            {
                Name = "test",
                ContactEmail = "ttomasic20@student.foi.hr"
            };
            var mailSettings = new MailSettings
            {
                DefaultSender = "Pero",
                DefaultSubject = ""
            };

            void act()
            {
                mailer.Send(db, mailSettings);
            }

            var ex = Assert.Throws<ArgumentException>(act);
            Assert.Contains("Subject", ex.Message);
        }

        [Fact]
        public void Send_GivenMissingDatabaseContactEmail_ThrowsArgumentNullException()
        {
            var mailer = new MailService();
            Database db = new Database
            {
                Name = "test",
            };

            void act()
            {
                mailer.Send(db, A.Dummy<MailSettings>());
            }

            var ex = Assert.Throws<ArgumentNullException>(act);
            Assert.Contains("ContactEmail", ex.Message);
        }

        [Fact]
        public void Send_GivenValidDatabaseInfo_SuccessfullySendsMail()
        {
            Database db = new Database
            {
                Name = "test",
                ContactEmail = "tin.tomasic74@gmail.com"
            };
            var sqlExecutor = A.Fake<ISqlExecutor>();
            A.CallTo(() => sqlExecutor.MarkMailAsSent(A<string>.Ignored)).DoesNothing();
            var smtpClient = A.Dummy<ISmtpClient>();
            MailService.SmtpClient = smtpClient;
            var mailer = new MailService(sqlExecutor);

            mailer.Send(db, A.Dummy<MailSettings>());

            A.CallTo(() => smtpClient.Send(A<MailMessage>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => sqlExecutor.MarkMailAsSent(A<string>.Ignored)).MustHaveHappenedOnceExactly();
        }
    }
}
