using SQL_Database_Generator.Models;
using SQL_Database_Generator.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SQL_Database_Generator.Forms
{
    public partial class FrmSendEmail : Form
    {
        private readonly Database _database;
        private readonly MailService _mailService;
        private readonly IMailSettingsService _mailSettingsService;

        public FrmSendEmail(Database database)
        {
            InitializeComponent();
            _database = database;
            _mailService = new MailService();
            _mailSettingsService = new MailSettingsService();
        }

        private void FrmSendEmail_Load(object sender, EventArgs e)
        {
            var settings = _mailSettingsService.GetSettings();

            txtFrom.Text = settings.DefaultSender;
            txtBcc.Text = string.Join(", ", settings.DefaultBccRecepients);
            txtTo.Text = _database.ContactEmail;
            txtSubject.Text = settings.DefaultSubject;
            txtMessage.Text = _database.GetInfo();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                _mailService.Send(new MailInfo
                {
                    SenderAddress = txtFrom.Text,
                    BccRecepientAddress = txtBcc.Text.Split(';').ToList(),
                    Message = txtMessage.Text,
                    RecepientAddresses = txtTo.Text.Split(';').ToList(),
                    Subject = txtSubject.Text,
                });
                var sqlExecutor = new SqlExecutor();
                sqlExecutor.MarkMailAsSent(_database.TeamNumber);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            Close();
        }
    }
}
