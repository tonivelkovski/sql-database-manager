using SQL_Database_Generator.Repositories;
using System;
using System.Windows.Forms;

namespace SQL_Database_Generator.Forms
{
    public partial class FrmPrijava : Form
    {
        public FrmPrijava()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            DbConnector.Server = txtDatabaseServer.Text;
            DbConnector.AdminUsername = txtUsername.Text;
            DbConnector.AdminPassword = txtPassword.Text;

            try
            {
                FrmInitial frmInitial = new FrmInitial();
                frmInitial.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while connecting to the database! Please check the entered " +
                    "information!");
            }
        }
    }
}
