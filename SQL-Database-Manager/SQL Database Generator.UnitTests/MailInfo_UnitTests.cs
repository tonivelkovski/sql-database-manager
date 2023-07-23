using SQL_Database_Generator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SQL_Database_Generator.UnitTests
{
    public class MailInfo_UnitTests
    {
        [Fact]
        public void MailMessage_GivenNullSenderMailAddress_ThrowsArgumentNullException()
        {
            var mailInfo = new MailInfo()
            {
                SenderAddress = null
            };

            void act()
            {
                var message = mailInfo.MailMessage;
            }

            var ex = Assert.Throws<ArgumentNullException>(act);
            Assert.Contains("SenderAddress", ex.Message);
        }

        [Fact]
        public void MailMessage_GivenEmptySenderMailAddress_ThrowsArgumentException()
        {
            var mailInfo = new MailInfo
            {
                SenderAddress = "",
                RecepientAddresses = new List<string>()
            };

            void act()
            {
                var message = mailInfo.MailMessage;
            }

            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void MailMessage_GivenInvalidSenderMailAddress_ThrowsFormatException()
        {
            var mailInfo = new MailInfo
            {
                SenderAddress = "ttomasic20student.foi.hr",
                RecepientAddresses = new List<string>() { "ttomasic20@student.foi.hr" },
                Subject = "TIKPP Obavijest",
                Message = "Tekst poruke ovdje."
            };

            void act()
            {
                var message = mailInfo.MailMessage;
            }

            Assert.Throws<FormatException>(act);
        }

        [Fact]
        public void MailMessage_GivenNullRecepientMailAddresses_ThrowsArgumentNullException()
        {
            var mailInfo = new MailInfo
            {
                SenderAddress = "ttomasic20@student.foi.hr",
                RecepientAddresses = null
            };

            void act()
            {
                var message = mailInfo.MailMessage;
            }

            var ex = Assert.Throws<ArgumentNullException>(act);
            Assert.Contains("RecepientAddresses", ex.Message);
        }

        [Fact]
        public void MailMessage_GivenEmptyRecepientMailAddresses_ThrowsArgumentException()
        {
            var mailInfo = new MailInfo
            {
                SenderAddress = "ttomasic20@student.foi.hr",
                RecepientAddresses = new List<string>(),
                Subject = "TIKPP Obavijest",
                Message = "Tekst ide ovdje."
            };

            void act()
            {
                var message = mailInfo.MailMessage;
            }

            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void MailMessage_GivenNullRecepientMailAddresses_ThrowsArgumentException()
        {
            var mailInfo = new MailInfo
            {
                SenderAddress = "ttomasic20@student.foi.hr",
                RecepientAddresses = new List<string> { null, "" }
            };

            void act()
            {
                var message = mailInfo.MailMessage;
            }

            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void MailMessage_GivenInvalidRecepientMailAddresses_ThrowsFormatException()
        {
            var mailInfo = new MailInfo
            {
                SenderAddress = "ttomasic20@student.foi.hr",
                RecepientAddresses = new List<string> { "tin.tomasicAgmail.com" },
                Subject = "TIKPP Obavijest",
                Message = "Tekst poruke ovdje."
            };

            void act()
            {
                var message = mailInfo.MailMessage;
            }

            Assert.Throws<FormatException>(act);
        }

        [Fact]
        public void MailMessage_GivenNullBccMailAddresses_ReturnsMailMessageWithNoBccRecepients()
        {
            var mailInfo = new MailInfo
            {
                SenderAddress = "ttomasic20@student.foi.hr",
                RecepientAddresses = new List<string> { "tin.tomasic@gmail.com" },
                BccRecepientAddress = null,
                Subject = "TIKPP Obavijest",
                Message = "Tekst poruke ovdje."
            };

            var message = mailInfo.MailMessage;

            Assert.NotNull(message);
            Assert.Empty(message.Bcc);
        }

        [Fact]
        public void MailMessage_GivenInvalidBccMailAddresses_ThrowsFormatException()
        {
            var mailInfo = new MailInfo
            {
                SenderAddress = "ttomasic20@student.foi.hr",
                RecepientAddresses = new List<string> { "tin.tomasic@gmail.com" },
                BccRecepientAddress = new List<string> { "tin.tomasicAgmail.com" },
                Subject = "TIKPP Obavijest",
                Message = "Tekst poruke ovdje."
            };

            void act()
            {
                var message = mailInfo.MailMessage;
            }

            Assert.Throws<FormatException>(act);
        }

        [Fact]
        public void MailMessage_GivenNullMailSubject_ThrowsArgumentNullException()
        {
            var mailInfo = new MailInfo
            {
                SenderAddress = "ttomasic20@student.foi.hr",
                RecepientAddresses = new List<string> { "tin.tomasic@gmail.com" },
                Subject = null
            };

            void act()
            {
                var message = mailInfo.MailMessage;
            }

            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void MailMessage_GivenEmptyMailSubject_ThrowsArgumentException()
        {
            var mailInfo = new MailInfo
            {
                SenderAddress = "ttomasic20@student.foi.hr",
                RecepientAddresses = new List<string> { "tin.tomasic@gmail.com" },
                Subject = ""
            };

            void act()
            {
                var message = mailInfo.MailMessage;
            }

            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void MailMessage_GivenNullMailMessage_ThrowsArgumentNullException()
        {
            var mailInfo = new MailInfo
            {
                SenderAddress = "ttomasic20@student.foi.hr",
                RecepientAddresses = new List<string> { "tin.tomasic@gmail.com" },
                Subject = "TIKPP Obavijest",
                Message = null
            };

            void act()
            {
                var message = mailInfo.MailMessage;
            }

            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void MailMessage_GivenEmptyMailMessage_ThrowsArgumentException()
        {
            var mailInfo = new MailInfo
            {
                SenderAddress = "ttomasic20@student.foi.hr",
                RecepientAddresses = new List<string> { "tin.tomasic@gmail.com" },
                Subject = "TIKPP Obavijest",
                Message = ""
            };

            void act()
            {
                var message = mailInfo.MailMessage;
            }

            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void MailMessage_GivenSimpleValidMailInfo_ReturnsMailMessage()
        {
            var mailInfo = new MailInfo
            {
                SenderAddress = "ttomasic20@student.foi.hr",
                RecepientAddresses = new List<string> { "tin.tomasic@gmail.com" },
                Subject = "TIKPP Obavijest",
                Message = "Tekst poruke ovdje."
            };

            var message = mailInfo.MailMessage;

            Assert.NotNull(message);
            Assert.Equal("ttomasic20@student.foi.hr", message.From.Address);
            Assert.Single(message.To);
            Assert.Equal("tin.tomasic@gmail.com", message.To.First().Address);
            Assert.Empty(message.Bcc);
            Assert.Equal("TIKPP Obavijest", message.Subject);
            Assert.Equal("Tekst poruke ovdje.", message.Body);
        }

        [Fact]
        public void MailMessage_GivenComplexValidMailInfo_ReturnsMailMessage()
        {
            var mailInfo = new MailInfo
            {
                SenderAddress = "ttomasic20@student.foi.hr",
                RecepientAddresses = new List<string>
                {
                    "tin.tomasic@gmail.com",
                    "toni.velkovski@gmail.com",
                    "daniel.skrlac@gmail.com"
                },
                BccRecepientAddress = new List<string>
                {
                    "pero.kos@foi.hr"
                },
                Subject = "[ TIKPP ] Pristup bazi podataka",
                Message = "Tekst poruke ovdje.\nNovi red ovdje.\nUsername: pkos123\nLozinka:0sf12'2!2#"
            };

            var message = mailInfo.MailMessage;

            Assert.NotNull(message);
            Assert.Equal("ttomasic20@student.foi.hr", message.From.Address);
            Assert.Equal(3, message.To.Count);
            Assert.Equal("tin.tomasic@gmail.com", message.To.First().Address);
            Assert.Single(message.Bcc);
            Assert.Equal("pero.kos@foi.hr", message.Bcc.First().Address);
            Assert.Equal("[ TIKPP ] Pristup bazi podataka", message.Subject);
            Assert.Equal("Tekst poruke ovdje.\nNovi red ovdje.\nUsername: pkos123\nLozinka:0sf12'2!2#", message.Body);
        }
    }
}
