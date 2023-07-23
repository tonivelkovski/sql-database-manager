using SQL_Database_Generator.Models;
using SQL_Database_Generator.Repositories;
using SQL_Database_Generator.Services;
using SQL_Database_Generator.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SQL_Database_Generator.Forms
{
    public partial class FrmMain : Form
    {
        public List<Database> Databases { get; set; }
        public string ImportFileContents { get; set; }

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Databases = new List<Database>();

            txtTeamNumber.Focus();

            HandleTextboxState();
        }

        private void BtnAddDatabase_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTeamNumber.Text) && !string.IsNullOrEmpty(txtUserPassword.Text))
            {
                Database d = new Database
                {
                    TeamNumber = txtTeamNumber.Text,
                    Name = txtDatabaseName.Text,
                    Username = txtUsername.Text,
                    Password = txtUserPassword.Text,
                };

                if (new DatabaseRepository(DbConnector.Instance).CheckIfExists(d.Name) == false)
                {
                    Databases.Add(d);

                    ClearSingleDatabaseFields();

                    txtTeamNumber.Focus();

                    RefreshData();
                }
                else
                {
                    MessageBox.Show("The database with the name " + d.Name + " already exists on the server!");
                }
            }
        }

        private void ClearSingleDatabaseFields()
        {
            txtTeamNumber.Clear();
            txtDatabaseName.Clear();
            txtUsername.Clear();
            txtUserPassword.Clear();
        }

        private void BtnAddMultipleDatabases_Click(object sender, EventArgs e)
        {
            int.TryParse(txtFirstTeamNumber.Text, out int firstTeamNumber);
            int.TryParse(txtLastTeamNumber.Text, out int lastTeamNumber);

            if (IsTeamNumberValid(firstTeamNumber, lastTeamNumber))
            {
                for (int i = firstTeamNumber; i <= lastTeamNumber; i++)
                {
                    string prefix = txtDatabasePrefix.Text;
                    string suffix = txtDatabaseSufix.Text;
                    string teamNumber = i.ToString("D2");
                    Databases.Add(new Database
                    {
                        TeamNumber = teamNumber,
                        Name = EntryGenerator.GenerateName(prefix, teamNumber, suffix),
                        Username = EntryGenerator.GenerateName(prefix, teamNumber, "_User"),
                        Password = EntryGenerator.GeneratePassword()
                    });
                }
                RefreshData();
            }
            else
            {
                MessageBox.Show("First and last team numbers must be integers, with first number being smaller than " +
                    "the last number!");
            }
        }

        private bool IsTeamNumberValid(int firstTeamNumber, int lastTeamNumber) =>
            firstTeamNumber != 0 && lastTeamNumber != 0
            && firstTeamNumber < lastTeamNumber
            && lastTeamNumber - firstTeamNumber < 100;

        private void RefreshData()
        {
            dgvDatabases.Rows.Clear();

            string[] row;

            foreach (Database database in Databases)
            {
                row = new string[] { database.TeamNumber, database.Name, database.Username, database.Password,
                    database.CreationDate.ToString() };
                int rowIndex = dgvDatabases.Rows.Add(row);
                dgvDatabases.Rows[rowIndex].Tag = database;
            }

            lblTotalEntries.Text = "Total entries: " + dgvDatabases.Rows.Count;
        }

        private void DgvDatabases_Click(object sender, EventArgs e)
        {
            if (dgvDatabases.SelectedRows.Count > 0)
            {
                Database db = dgvDatabases.SelectedRows[0].Tag as Database;
                ShowMail(db);
                ShowSql(db);
            }
        }

        private void ShowMail(Database db)
        {
            txtMail.Clear();
            txtMail.Text = db.GetInfo();
        }

        private void ShowSql(Database db)
        {
            var sqlGenerator = new SqlGenerator();
            txtSql.Text = sqlGenerator.CompleteSqlStatement(db);
        }

        private void BtnGenerateDatabases_Click(object sender, EventArgs e)
        {
            foreach (Database db in Databases)
            {
                if (new DatabaseRepository(DbConnector.Instance).CheckIfExists(db.Name) == false)
                {
                    var sqlExecutor = new SqlExecutor();
                    sqlExecutor.ExecuteCompleteCreateStatement(db);
                }
                else
                {
                    MessageBox.Show("The database with the name " + db.Name + " already exists on the server!");
                }
            }
        }

        private void HandleTextboxState()
        {
            txtDatabaseName.ReadOnly = chkSuggestNames.Checked;
            txtUsername.ReadOnly = chkSuggestNames.Checked;
            txtUserPassword.ReadOnly = chkSuggestNames.Checked;
        }

        private void ChkSuggestNames_CheckedChanged(object sender, EventArgs e)
        {
            HandleTextboxState();
            if (chkSuggestNames.Checked)
            {
                GenerateEntries();
            }
            else
            {
                txtDatabaseName.Clear();
                txtUsername.Clear();
            }
        }

        private void TxtTeamNumber_TextChanged(object sender, EventArgs e)
        {
            if (chkSuggestNames.Checked)
            {
                GenerateEntries();
            }
        }

        private void GenerateEntries()
        {
            if (!string.IsNullOrEmpty(txtTeamNumber.Text))
            {
                txtDatabaseName.Text = EntryGenerator.GenerateName(txtTeamNumber.Text);
                txtUsername.Text = EntryGenerator.GenerateUsername(txtTeamNumber.Text);

                if (string.IsNullOrEmpty(txtUserPassword.Text))
                {
                    txtUserPassword.Text = EntryGenerator.GeneratePassword();
                }
            }
        }

        private void BtnDeleteDatabase_Click(object sender, EventArgs e)
        {
            if (dgvDatabases.CurrentRow != null)
            {
                var selectedDatabase = dgvDatabases.CurrentRow.Tag as Database;
                Databases.Remove(selectedDatabase);
                RefreshData();
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (ofdImportCSV.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = null;
                string filePath = ofdImportCSV.FileName;
                try
                {
                    streamReader = new StreamReader(filePath);
                    ImportFileContents = streamReader.ReadToEnd();

                    txtFilePath.Text = filePath;
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occurred while reading the file!");
                }
                streamReader?.Close();
            }
        }

        private void BtnAddEntriesFromFile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ImportFileContents))
            {
                char[] delims = new[] { '\r', '\n' };
                string[] students = ImportFileContents.Split(delims, StringSplitOptions.RemoveEmptyEntries);

                Databases = DataImporter.Import(students);

                RefreshData();
            }
        }
    }
}
