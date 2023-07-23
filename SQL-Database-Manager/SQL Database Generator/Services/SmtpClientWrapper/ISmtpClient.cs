using System.Net.Mail;

namespace SQL_Database_Generator.Services.SmtpClientWrapper
{
    public interface ISmtpClient
    {
        void Send(MailMessage mailMessage);
    }
}
