namespace SQL_Database_Generator.Forms
{
    partial class FrmInitial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpcijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.popisBazaNaServeruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GeneratingDatabasesforStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.slbServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.slbUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpcijeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OpcijeToolStripMenuItem
            // 
            this.OpcijeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popisBazaNaServeruToolStripMenuItem,
            this.GeneratingDatabasesforStudentsToolStripMenuItem,
            this.toolStripSeparator1,
            this.settingsToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.OpcijeToolStripMenuItem.Name = "OpcijeToolStripMenuItem";
            this.OpcijeToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.OpcijeToolStripMenuItem.Text = "Options";
            // 
            // popisBazaNaServeruToolStripMenuItem
            // 
            this.popisBazaNaServeruToolStripMenuItem.Name = "popisBazaNaServeruToolStripMenuItem";
            this.popisBazaNaServeruToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.popisBazaNaServeruToolStripMenuItem.Text = "Databases on the server list";
            this.popisBazaNaServeruToolStripMenuItem.Click += new System.EventHandler(this.ServerDatabasesListToolStripMenuItem_Click);
            // 
            // GeneratingDatabasesforStudentsToolStripMenuItem
            // 
            this.GeneratingDatabasesforStudentsToolStripMenuItem.Name = "GeneratingDatabasesforStudentsToolStripMenuItem";
            this.GeneratingDatabasesforStudentsToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.GeneratingDatabasesforStudentsToolStripMenuItem.Text = "Generating databases for students";
            this.GeneratingDatabasesforStudentsToolStripMenuItem.Click += new System.EventHandler(this.GeneratingDatabasesforStudentsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(250, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.slbServer,
            this.statusLabel1,
            this.slbUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 415);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel1.Text = "Server:";
            // 
            // slbServer
            // 
            this.slbServer.Name = "slbServer";
            this.slbServer.Size = new System.Drawing.Size(39, 17);
            this.slbServer.Text = "Server";
            // 
            // statusLabel1
            // 
            this.statusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(36, 17);
            this.statusLabel1.Text = "User:";
            // 
            // slbUser
            // 
            this.slbUser.Name = "slbUser";
            this.slbUser.Size = new System.Drawing.Size(30, 17);
            this.slbUser.Text = "User";
            // 
            // FrmInitial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 437);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmInitial";
            this.Text = "Initial form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmInitial_FormClosed);
            this.Load += new System.EventHandler(this.FrmInitial_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpcijeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem popisBazaNaServeruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GeneratingDatabasesforStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel slbUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel slbServer;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}