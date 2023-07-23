using SQL_Database_Generator.Models;
using SQL_Database_Generator.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SQL_Database_Generator.Forms
{
    public partial class FrmSettings : Form
    {
        private readonly IMailSettingsService _mailSettingsService;

        public FrmSettings()
        {
            InitializeComponent();
            _mailSettingsService = new MailSettingsService();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            var settings = _mailSettingsService.GetSettings();
            txtDefaultSender.Text = settings.DefaultSender;
            txtDefaultBCCs.Text = string.Join(";", settings.DefaultBccRecepients);
            txtDefaultSubject.Text = settings.DefaultSubject;
        }

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            _mailSettingsService.UpdateSettings(new MailSettings
            {
                DefaultSender = txtDefaultSender.Text,
                DefaultBccRecepients = txtDefaultBCCs.Text.Split(';').ToList(),
                DefaultSubject = txtDefaultSubject.Text
            });
            Close();
        }
    }
}
