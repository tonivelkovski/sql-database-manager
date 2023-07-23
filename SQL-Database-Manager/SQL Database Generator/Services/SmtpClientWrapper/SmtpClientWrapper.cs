using System.Net.Mail;

namespace SQL_Database_Generator.Services.SmtpClientWrapper
{
    public class SmtpClientWrapper : ISmtpClient
    {
        private readonly SmtpClient _client;
        public SmtpClientWrapper(SmtpClient smtpClient)
        {
            _client = smtpClient;
        }

        public void Send(MailMessage mailMessage)
        {
            _client.Send(mailMessage);
        }
    }
}
