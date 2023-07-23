namespace SQL_Database_Generator.Forms
{
    partial class FrmSettings
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
            this.gbMail = new System.Windows.Forms.GroupBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.txtDefaultSubject = new System.Windows.Forms.TextBox();
            this.lblDefaultSubject = new System.Windows.Forms.Label();
            this.txtDefaultBCCs = new System.Windows.Forms.TextBox();
            this.lblDefaultBCCs = new System.Windows.Forms.Label();
            this.lblDefaultSender = new System.Windows.Forms.Label();
            this.txtDefaultSender = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbMail.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMail
            // 
            this.gbMail.Controls.Add(this.btnSaveChanges);
            this.gbMail.Controls.Add(this.txtDefaultSubject);
            this.gbMail.Controls.Add(this.lblDefaultSubject);
            this.gbMail.Controls.Add(this.txtDefaultBCCs);
            this.gbMail.Controls.Add(this.lblDefaultBCCs);
            this.gbMail.Controls.Add(this.lblDefaultSender);
            this.gbMail.Controls.Add(this.txtDefaultSender);
            this.gbMail.Location = new System.Drawing.Point(12, 12);
            this.gbMail.Name = "gbMail";
            this.gbMail.Size = new System.Drawing.Size(400, 154);
            this.gbMail.TabIndex = 0;
            this.gbMail.TabStop = false;
            this.gbMail.Text = "Mail settings";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(307, 118);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(75, 23);
            this.btnSaveChanges.TabIndex = 6;
            this.btnSaveChanges.Text = "Save";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.BtnSaveChanges_Click);
            // 
            // txtDefaultSubject
            // 
            this.txtDefaultSubject.Location = new System.Drawing.Point(91, 88);
            this.txtDefaultSubject.Name = "txtDefaultSubject";
            this.txtDefaultSubject.Size = new System.Drawing.Size(291, 20);
            this.txtDefaultSubject.TabIndex = 5;
            // 
            // lblDefaultSubject
            // 
            this.lblDefaultSubject.AutoSize = true;
            this.lblDefaultSubject.Location = new System.Drawing.Point(6, 91);
            this.lblDefaultSubject.Name = "lblDefaultSubject";
            this.lblDefaultSubject.Size = new System.Drawing.Size(81, 13);
            this.lblDefaultSubject.TabIndex = 4;
            this.lblDefaultSubject.Text = "Default subject:";
            // 
            // txtDefaultBCCs
            // 
            this.txtDefaultBCCs.Location = new System.Drawing.Point(91, 57);
            this.txtDefaultBCCs.Name = "txtDefaultBCCs";
            this.txtDefaultBCCs.Size = new System.Drawing.Size(291, 20);
            this.txtDefaultBCCs.TabIndex = 3;
            // 
            // lblDefaultBCCs
            // 
            this.lblDefaultBCCs.AutoSize = true;
            this.lblDefaultBCCs.Location = new System.Drawing.Point(6, 60);
            this.lblDefaultBCCs.Name = "lblDefaultBCCs";
            this.lblDefaultBCCs.Size = new System.Drawing.Size(73, 13);
            this.lblDefaultBCCs.TabIndex = 2;
            this.lblDefaultBCCs.Text = "Default BCCs:";
            // 
            // lblDefaultSender
            // 
            this.lblDefaultSender.AutoSize = true;
            this.lblDefaultSender.Location = new System.Drawing.Point(6, 30);
            this.lblDefaultSender.Name = "lblDefaultSender";
            this.lblDefaultSender.Size = new System.Drawing.Size(79, 13);
            this.lblDefaultSender.TabIndex = 1;
            this.lblDefaultSender.Text = "Default sender:";
            // 
            // txtDefaultSender
            // 
            this.txtDefaultSender.Location = new System.Drawing.Point(91, 27);
            this.txtDefaultSender.Name = "txtDefaultSender";
            this.txtDefaultSender.Size = new System.Drawing.Size(291, 20);
            this.txtDefaultSender.TabIndex = 0;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 183);
            this.Controls.Add(this.gbMail);
            this.Name = "FrmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.gbMail.ResumeLayout(false);
            this.gbMail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMail;
        private System.Windows.Forms.Label lblDefaultSender;
        private System.Windows.Forms.TextBox txtDefaultSender;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblDefaultBCCs;
        private System.Windows.Forms.TextBox txtDefaultSubject;
        private System.Windows.Forms.Label lblDefaultSubject;
        private System.Windows.Forms.TextBox txtDefaultBCCs;
        private System.Windows.Forms.Button btnSaveChanges;
    }
}