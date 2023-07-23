using SQL_Database_Generator.Forms;
using SQL_Database_Generator.Services;
using SQL_Database_Generator.Services.SmtpClientWrapper;
using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace SQL_Database_Generator
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InjectDependencies();

            Application.Run(new FrmPrijava());
        }

        private static void InjectDependencies()
        {
            MailService.SmtpClient = new SmtpClientWrapper(new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "mail.foi.hr"
            });
        }
    }
}
