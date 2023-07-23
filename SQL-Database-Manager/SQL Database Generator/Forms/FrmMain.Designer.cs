namespace SQL_Database_Generator.Forms
{
    partial class FrmMain
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
            this.dgvDatabases = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTeamNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddDatabase = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSuggestNames = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGenerateDatabases = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddMultipleDatabases = new System.Windows.Forms.Button();
            this.txtDatabaseSufix = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDatabasePrefix = new System.Windows.Forms.TextBox();
            this.txtLastTeamNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFirstTeamNumber = new System.Windows.Forms.TextBox();
            this.btnDeleteDatabase = new System.Windows.Forms.Button();
            this.lblTotalEntries = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddEntriesFromFile = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.ofdImportCSV = new System.Windows.Forms.OpenFileDialog();
            this.Team = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Database = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabases)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDatabases
            // 
            this.dgvDatabases.AllowUserToAddRows = false;
            this.dgvDatabases.AllowUserToDeleteRows = false;
            this.dgvDatabases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatabases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Team,
            this.Database,
            this.Username,
            this.Password,
            this.CreationDate});
            this.dgvDatabases.Location = new System.Drawing.Point(12, 215);
            this.dgvDatabases.MultiSelect = false;
            this.dgvDatabases.Name = "dgvDatabases";
            this.dgvDatabases.ReadOnly = true;
            this.dgvDatabases.RowHeadersVisible = false;
            this.dgvDatabases.RowHeadersWidth = 51;
            this.dgvDatabases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatabases.Size = new System.Drawing.Size(525, 473);
            this.dgvDatabases.TabIndex = 0;
            this.dgvDatabases.Click += new System.EventHandler(this.DgvDatabases_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Databases:";
            // 
            // txtTeamNumber
            // 
            this.txtTeamNumber.Location = new System.Drawing.Point(106, 26);
            this.txtTeamNumber.Name = "txtTeamNumber";
            this.txtTeamNumber.Size = new System.Drawing.Size(141, 20);
            this.txtTeamNumber.TabIndex = 2;
            this.txtTeamNumber.TextChanged += new System.EventHandler(this.TxtTeamNumber_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Team number:";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(106, 104);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(141, 20);
            this.txtUserPassword.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "User password:";
            // 
            // btnAddDatabase
            // 
            this.btnAddDatabase.Location = new System.Drawing.Point(156, 151);
            this.btnAddDatabase.Name = "btnAddDatabase";
            this.btnAddDatabase.Size = new System.Drawing.Size(91, 27);
            this.btnAddDatabase.TabIndex = 6;
            this.btnAddDatabase.Text = "Add entry";
            this.btnAddDatabase.UseVisualStyleBackColor = true;
            this.btnAddDatabase.Click += new System.EventHandler(this.BtnAddDatabase_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSuggestNames);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDatabaseName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnAddDatabase);
            this.groupBox1.Controls.Add(this.txtTeamNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUserPassword);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 184);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add single database:";
            // 
            // chkSuggestNames
            // 
            this.chkSuggestNames.AutoSize = true;
            this.chkSuggestNames.Checked = true;
            this.chkSuggestNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSuggestNames.Location = new System.Drawing.Point(106, 128);
            this.chkSuggestNames.Name = "chkSuggestNames";
            this.chkSuggestNames.Size = new System.Drawing.Size(127, 17);
            this.chkSuggestNames.TabIndex = 11;
            this.chkSuggestNames.Text = "Auto-generate entries";
            this.chkSuggestNames.UseVisualStyleBackColor = true;
            this.chkSuggestNames.CheckedChanged += new System.EventHandler(this.ChkSuggestNames_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(106, 78);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(141, 20);
            this.txtUsername.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Database name:";
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(106, 52);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(141, 20);
            this.txtDatabaseName.TabIndex = 7;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(543, 215);
            this.txtMail.Multiline = true;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(340, 213);
            this.txtMail.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(540, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mail:";
            // 
            // btnGenerateDatabases
            // 
            this.btnGenerateDatabases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnGenerateDatabases.Location = new System.Drawing.Point(761, 694);
            this.btnGenerateDatabases.Name = "btnGenerateDatabases";
            this.btnGenerateDatabases.Size = new System.Drawing.Size(122, 52);
            this.btnGenerateDatabases.TabIndex = 10;
            this.btnGenerateDatabases.Text = "Generate databases";
            this.btnGenerateDatabases.UseVisualStyleBackColor = false;
            this.btnGenerateDatabases.Click += new System.EventHandler(this.BtnGenerateDatabases_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(544, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Sql:";
            // 
            // txtSql
            // 
            this.txtSql.Location = new System.Drawing.Point(543, 447);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(340, 241);
            this.txtSql.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnAddMultipleDatabases);
            this.groupBox2.Controls.Add(this.txtDatabaseSufix);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDatabasePrefix);
            this.groupBox2.Controls.Add(this.txtLastTeamNumber);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtFirstTeamNumber);
            this.groupBox2.Location = new System.Drawing.Point(290, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 184);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add multiple databases:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Database sufix;";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Database prefix:";
            // 
            // btnAddMultipleDatabases
            // 
            this.btnAddMultipleDatabases.Location = new System.Drawing.Point(150, 151);
            this.btnAddMultipleDatabases.Name = "btnAddMultipleDatabases";
            this.btnAddMultipleDatabases.Size = new System.Drawing.Size(91, 27);
            this.btnAddMultipleDatabases.TabIndex = 12;
            this.btnAddMultipleDatabases.Text = "Add entries";
            this.btnAddMultipleDatabases.UseVisualStyleBackColor = true;
            this.btnAddMultipleDatabases.Click += new System.EventHandler(this.BtnAddMultipleDatabases_Click);
            // 
            // txtDatabaseSufix
            // 
            this.txtDatabaseSufix.Location = new System.Drawing.Point(106, 55);
            this.txtDatabaseSufix.Name = "txtDatabaseSufix";
            this.txtDatabaseSufix.Size = new System.Drawing.Size(135, 20);
            this.txtDatabaseSufix.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Last team number:";
            // 
            // txtDatabasePrefix
            // 
            this.txtDatabasePrefix.Location = new System.Drawing.Point(106, 29);
            this.txtDatabasePrefix.Name = "txtDatabasePrefix";
            this.txtDatabasePrefix.Size = new System.Drawing.Size(135, 20);
            this.txtDatabasePrefix.TabIndex = 16;
            // 
            // txtLastTeamNumber
            // 
            this.txtLastTeamNumber.Location = new System.Drawing.Point(106, 125);
            this.txtLastTeamNumber.Name = "txtLastTeamNumber";
            this.txtLastTeamNumber.Size = new System.Drawing.Size(135, 20);
            this.txtLastTeamNumber.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "First team number:";
            // 
            // txtFirstTeamNumber
            // 
            this.txtFirstTeamNumber.Location = new System.Drawing.Point(106, 99);
            this.txtFirstTeamNumber.Name = "txtFirstTeamNumber";
            this.txtFirstTeamNumber.Size = new System.Drawing.Size(135, 20);
            this.txtFirstTeamNumber.TabIndex = 12;
            // 
            // btnDeleteDatabase
            // 
            this.btnDeleteDatabase.Location = new System.Drawing.Point(12, 694);
            this.btnDeleteDatabase.Name = "btnDeleteDatabase";
            this.btnDeleteDatabase.Size = new System.Drawing.Size(91, 27);
            this.btnDeleteDatabase.TabIndex = 12;
            this.btnDeleteDatabase.Text = "Delete entry";
            this.btnDeleteDatabase.UseVisualStyleBackColor = true;
            this.btnDeleteDatabase.Click += new System.EventHandler(this.BtnDeleteDatabase_Click);
            // 
            // lblTotalEntries
            // 
            this.lblTotalEntries.AutoSize = true;
            this.lblTotalEntries.Location = new System.Drawing.Point(454, 694);
            this.lblTotalEntries.Name = "lblTotalEntries";
            this.lblTotalEntries.Size = new System.Drawing.Size(77, 13);
            this.lblTotalEntries.TabIndex = 14;
            this.lblTotalEntries.Text = "Total entries: 0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAddEntriesFromFile);
            this.groupBox3.Controls.Add(this.btnBrowse);
            this.groupBox3.Controls.Add(this.txtFilePath);
            this.groupBox3.Location = new System.Drawing.Point(546, 12);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(336, 184);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add from file:";
            // 
            // btnAddEntriesFromFile
            // 
            this.btnAddEntriesFromFile.Location = new System.Drawing.Point(252, 150);
            this.btnAddEntriesFromFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddEntriesFromFile.Name = "btnAddEntriesFromFile";
            this.btnAddEntriesFromFile.Size = new System.Drawing.Size(80, 24);
            this.btnAddEntriesFromFile.TabIndex = 2;
            this.btnAddEntriesFromFile.Text = "Add entries";
            this.btnAddEntriesFromFile.UseVisualStyleBackColor = true;
            this.btnAddEntriesFromFile.Click += new System.EventHandler(this.BtnAddEntriesFromFile_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(176, 150);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(72, 24);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse file..";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(13, 24);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilePath.Multiline = true;
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(320, 121);
            this.txtFilePath.TabIndex = 0;
            // 
            // ofdImportCSV
            // 
            this.ofdImportCSV.FileName = "openFileDialog1";
            // 
            // Team
            // 
            this.Team.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Team.HeaderText = "Team";
            this.Team.MinimumWidth = 6;
            this.Team.Name = "Team";
            this.Team.ReadOnly = true;
            // 
            // Database
            // 
            this.Database.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Database.HeaderText = "Database";
            this.Database.MinimumWidth = 6;
            this.Database.Name = "Database";
            this.Database.ReadOnly = true;
            // 
            // Username
            // 
            this.Username.HeaderText = "User";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // Password
            // 
            this.Password.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Password.HeaderText = "Password";
            this.Password.MinimumWidth = 6;
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            // 
            // CreationDate
            // 
            this.CreationDate.HeaderText = "Created";
            this.CreationDate.MinimumWidth = 6;
            this.CreationDate.Name = "CreationDate";
            this.CreationDate.ReadOnly = true;
            this.CreationDate.Width = 125;
            // 
            // FrmMain
            // 
            this.AcceptButton = this.btnAddDatabase;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 780);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblTotalEntries);
            this.Controls.Add(this.btnDeleteDatabase);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtSql);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGenerateDatabases);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDatabases);
            this.Name = "FrmMain";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabases)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatabases;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTeamNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddDatabase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGenerateDatabases;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.CheckBox chkSuggestNames;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddMultipleDatabases;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLastTeamNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFirstTeamNumber;
        private System.Windows.Forms.Button btnDeleteDatabase;
        private System.Windows.Forms.Label lblTotalEntries;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDatabaseSufix;
        private System.Windows.Forms.TextBox txtDatabasePrefix;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddEntriesFromFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.OpenFileDialog ofdImportCSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Team;
        private System.Windows.Forms.DataGridViewTextBoxColumn Database;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
    }
}

