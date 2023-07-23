using SQL_Database_Generator.Repositories;
using System;
using System.Windows.Forms;

namespace SQL_Database_Generator.Forms
{
    public partial class FrmInitial : Form
    {
        public FrmInitial()
        {
            InitializeComponent();
        }

        private void FrmInitial_Load(object sender, EventArgs e)
        {
            slbServer.Text = DbConnector.Server;
            slbUser.Text = DbConnector.AdminUsername;
        }

        private void ServerDatabasesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmViewDatabases frmViewDatabases = new FrmViewDatabases
            {
                MdiParent = this
            };
            frmViewDatabases.Show();
        }

        private void GeneratingDatabasesforStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMain frmMain = new FrmMain
            {
                MdiParent = this
            };
            frmMain.Show();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.ShowDialog();
            DisposeAllButThis();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmInitial_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void DisposeAllButThis()
        {
            foreach (Form frm in MdiChildren)
            {
                if (frm != this)
                {
                    frm.Dispose();
                    frm.Close();
                }
            }
        }
    }
}
