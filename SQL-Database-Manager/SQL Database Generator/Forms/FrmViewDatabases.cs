using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SQL_Database_Generator.Models;
using SQL_Database_Generator.Services;
using SQL_Database_Generator.Repositories;

namespace SQL_Database_Generator.Forms
{
    public partial class FrmViewDatabases : Form
    {
        private List<Database> Databases { get; set; }
        private readonly DatabasesViewService _databasesViewService;
        private readonly IMailSettingsService _mailSettingsService;
        private readonly SqlExecutor _sqlExecutor;

        public FrmViewDatabases()
        {
            InitializeComponent();

            var databaseRepository = new DatabaseRepository(DbConnector.Instance);
            _databasesViewService = new DatabasesViewService(databaseRepository);
            _mailSettingsService = new MailSettingsService();
            _sqlExecutor = new SqlExecutor();
        }

        private void FrmViewDatabases_Load(object sender, EventArgs e)
        {
            SelectCurrentYear();
            RefreshDataPerYear();
        }

        private void SelectCurrentYear()
        {
            int currentYear = DateTime.Now.Year;
            for (int i = 0; i < cmbAcademicYear.Items.Count; i++)
            {
                var academicYear = cmbAcademicYear.Items[i].ToString();
                if (academicYear.Split('/')[1] == currentYear.ToString())
                {
                    cmbAcademicYear.SelectedIndex = i;
                    break;
                }
            }
        }

        private void BtnSendMail_Click(object sender, EventArgs e)
        {
            if (dgvDatabases.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a database record.");
                return;
            }

            Database selectedDatabase = dgvDatabases.CurrentRow.DataBoundItem as Database;

            FrmSendEmail frmSendEmail = new FrmSendEmail(selectedDatabase);
            frmSendEmail.ShowDialog();

            RefreshDataPerYear();
        }

        private void RefreshData(string searchText = "")
        {
            dgvDatabases.DataSource = null;
            if (string.IsNullOrEmpty(searchText))
            {
                RefreshDataPerYear();
            }
            else
            {
                try
                {
                    var filteredList = _databasesViewService.
                        FilterDatabasesBasedOnSearchText(Databases, searchText);

                    dgvDatabases.DataSource = filteredList;
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TxtSearchText_TextChanged(object sender, EventArgs e)
        {
            RefreshData(TxtSearchText.Text);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the database?", "Warning!",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dgvDatabases.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a database record.");
                    return;
                }

                foreach (DataGridViewRow row in dgvDatabases.SelectedRows)
                {
                    Database selectedDatabase = row.DataBoundItem as Database;

                    try
                    {
                        _sqlExecutor.ExecuteCompleteDeleteStatement(selectedDatabase);
                        Databases.Remove(selectedDatabase);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                RefreshDataPerYear();
            }
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            TxtSearchText.Text = string.Empty;
            RefreshDataPerYear();
        }

        private void RefreshDataPerYear()
        {
            string academicYear = GetSelectedAcademicYear();

            try
            {
                Databases = _databasesViewService.GetDatabases(academicYear);
                dgvDatabases.DataSource = Databases.ToList();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetSelectedAcademicYear()
        {
            string academicYear = cmbAcademicYear.SelectedItem.ToString();
            academicYear = academicYear.Split('/')[1];
            return academicYear;
        }

        private void BtnSendAllEmails_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to send an email to all selected students/teams?", "Warning!",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dgvDatabases.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a database record.");
                    return;
                }

                var mailer = new MailService();
                foreach (DataGridViewRow row in dgvDatabases.SelectedRows)
                {
                    var db = row.DataBoundItem as Database;
                    mailer.Send(db, _mailSettingsService.GetSettings());
                }

                MessageBox.Show($"Successfully sent {dgvDatabases.SelectedRows.Count} emails!");
            }
        }

        private void BtnArchive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to archive the database?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dgvDatabases.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a database record.");
                    return;
                }

                foreach (DataGridViewRow row in dgvDatabases.SelectedRows)
                {
                    Database selectedDatabase = row.DataBoundItem as Database;

                    try
                    {
                        _sqlExecutor.ExecuteCompleteArchiveStatement(selectedDatabase);
                        Databases.Remove(selectedDatabase);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                RefreshDataPerYear();
            }
        }
    }
}
