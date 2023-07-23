using SQL_Database_Generator.Extensions;
using SQL_Database_Generator.Models;
using SQL_Database_Generator.Services.SmtpClientWrapper;
using System.Linq;

namespace SQL_Database_Generator.Services
{
    public class MailService
    {
        private readonly ISqlExecutor _sqlExecutor;
        public static ISmtpClient SmtpClient { get; set; }

        public MailService(ISqlExecutor sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
        }

        public MailService() : this(new SqlExecutor()) { }

        public void Send(MailInfo mailInfo)
        {
            mailInfo.ThrowIfNull(nameof(mailInfo));

            SmtpClient.Send(mailInfo.MailMessage);
        }

        public void Send(Database db, MailSettings mailSettings)
        {
            db.ThrowIfNull(nameof(db));
            db.ContactEmail.ThrowIfNullOrWhiteSpace(nameof(db.ContactEmail));
            mailSettings.ThrowIfNull(nameof(mailSettings));

            var mailInfo = new MailInfo
            {
                SenderAddress = mailSettings.DefaultSender,
                RecepientAddresses = db.ContactEmail.Split(';').ToList(),
                Subject = mailSettings.DefaultSubject,
                Message = db.GetInfo(),
                BccRecepientAddress = mailSettings.DefaultBccRecepients
            };

            Send(mailInfo);

            _sqlExecutor.MarkMailAsSent(db.TeamNumber);
        }
    }
}
