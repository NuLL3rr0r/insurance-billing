namespace Insurance
{
    partial class frmBackup
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbxBackup = new System.Windows.Forms.GroupBox();
            this.lblBackupPath = new System.Windows.Forms.Label();
            this.lblLastBackup = new System.Windows.Forms.Label();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.txtLastBackupDate = new System.Windows.Forms.TextBox();
            this.txtLastBackupTime = new System.Windows.Forms.TextBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.gbxRestore = new System.Windows.Forms.GroupBox();
            this.lblRestorePath = new System.Windows.Forms.Label();
            this.lblLastRestore = new System.Windows.Forms.Label();
            this.txtRestorePath = new System.Windows.Forms.TextBox();
            this.txtLastRestoreDate = new System.Windows.Forms.TextBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.txtLastRestoreTime = new System.Windows.Forms.TextBox();
            this.fbdBackup = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdRestore = new System.Windows.Forms.FolderBrowserDialog();
            this.gbxBackup.SuspendLayout();
            this.gbxRestore.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(16, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbxBackup
            // 
            this.gbxBackup.Controls.Add(this.lblBackupPath);
            this.gbxBackup.Controls.Add(this.lblLastBackup);
            this.gbxBackup.Controls.Add(this.txtBackupPath);
            this.gbxBackup.Controls.Add(this.txtLastBackupDate);
            this.gbxBackup.Controls.Add(this.txtLastBackupTime);
            this.gbxBackup.Controls.Add(this.btnBackup);
            this.gbxBackup.Location = new System.Drawing.Point(10, 8);
            this.gbxBackup.Name = "gbxBackup";
            this.gbxBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbxBackup.Size = new System.Drawing.Size(520, 150);
            this.gbxBackup.TabIndex = 0;
            this.gbxBackup.TabStop = false;
            this.gbxBackup.Text = "تهيه نسخه ي پشتيبان";
            // 
            // lblBackupPath
            // 
            this.lblBackupPath.AutoSize = true;
            this.lblBackupPath.Location = new System.Drawing.Point(411, 64);
            this.lblBackupPath.Name = "lblBackupPath";
            this.lblBackupPath.Size = new System.Drawing.Size(85, 13);
            this.lblBackupPath.TabIndex = 0;
            this.lblBackupPath.Text = "مسير آخرين تهيه";
            // 
            // lblLastBackup
            // 
            this.lblLastBackup.AutoSize = true;
            this.lblLastBackup.Location = new System.Drawing.Point(375, 36);
            this.lblLastBackup.Name = "lblLastBackup";
            this.lblLastBackup.Size = new System.Drawing.Size(121, 13);
            this.lblLastBackup.TabIndex = 0;
            this.lblLastBackup.Text = "تاريخ و ساعت آخرين تهيه";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(24, 88);
            this.txtBackupPath.MaxLength = 255;
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.ReadOnly = true;
            this.txtBackupPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBackupPath.Size = new System.Drawing.Size(472, 21);
            this.txtBackupPath.TabIndex = 3;
            // 
            // txtLastBackupDate
            // 
            this.txtLastBackupDate.Location = new System.Drawing.Point(192, 32);
            this.txtLastBackupDate.Name = "txtLastBackupDate";
            this.txtLastBackupDate.ReadOnly = true;
            this.txtLastBackupDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLastBackupDate.Size = new System.Drawing.Size(160, 21);
            this.txtLastBackupDate.TabIndex = 2;
            // 
            // txtLastBackupTime
            // 
            this.txtLastBackupTime.Location = new System.Drawing.Point(24, 32);
            this.txtLastBackupTime.Name = "txtLastBackupTime";
            this.txtLastBackupTime.ReadOnly = true;
            this.txtLastBackupTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLastBackupTime.Size = new System.Drawing.Size(160, 21);
            this.txtLastBackupTime.TabIndex = 1;
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(6, 121);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBackup.TabIndex = 4;
            this.btnBackup.Text = "تهيه";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // gbxRestore
            // 
            this.gbxRestore.Controls.Add(this.lblRestorePath);
            this.gbxRestore.Controls.Add(this.lblLastRestore);
            this.gbxRestore.Controls.Add(this.txtRestorePath);
            this.gbxRestore.Controls.Add(this.txtLastRestoreDate);
            this.gbxRestore.Controls.Add(this.btnRestore);
            this.gbxRestore.Controls.Add(this.txtLastRestoreTime);
            this.gbxRestore.Location = new System.Drawing.Point(10, 168);
            this.gbxRestore.Name = "gbxRestore";
            this.gbxRestore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbxRestore.Size = new System.Drawing.Size(520, 150);
            this.gbxRestore.TabIndex = 0;
            this.gbxRestore.TabStop = false;
            this.gbxRestore.Text = "بازيابي نسخه ي پشتيبان";
            // 
            // lblRestorePath
            // 
            this.lblRestorePath.AutoSize = true;
            this.lblRestorePath.Location = new System.Drawing.Point(400, 64);
            this.lblRestorePath.Name = "lblRestorePath";
            this.lblRestorePath.Size = new System.Drawing.Size(96, 13);
            this.lblRestorePath.TabIndex = 0;
            this.lblRestorePath.Text = "مسير آخرين بازيابي";
            // 
            // lblLastRestore
            // 
            this.lblLastRestore.AutoSize = true;
            this.lblLastRestore.Location = new System.Drawing.Point(364, 36);
            this.lblLastRestore.Name = "lblLastRestore";
            this.lblLastRestore.Size = new System.Drawing.Size(132, 13);
            this.lblLastRestore.TabIndex = 0;
            this.lblLastRestore.Text = "تاريخ و ساعت آخرين بازيابي";
            // 
            // txtRestorePath
            // 
            this.txtRestorePath.Location = new System.Drawing.Point(24, 88);
            this.txtRestorePath.MaxLength = 255;
            this.txtRestorePath.Name = "txtRestorePath";
            this.txtRestorePath.ReadOnly = true;
            this.txtRestorePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRestorePath.Size = new System.Drawing.Size(472, 21);
            this.txtRestorePath.TabIndex = 7;
            // 
            // txtLastRestoreDate
            // 
            this.txtLastRestoreDate.Location = new System.Drawing.Point(192, 32);
            this.txtLastRestoreDate.Name = "txtLastRestoreDate";
            this.txtLastRestoreDate.ReadOnly = true;
            this.txtLastRestoreDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLastRestoreDate.Size = new System.Drawing.Size(160, 21);
            this.txtLastRestoreDate.TabIndex = 6;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(6, 121);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 8;
            this.btnRestore.Text = "بازيابي";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // txtLastRestoreTime
            // 
            this.txtLastRestoreTime.Location = new System.Drawing.Point(24, 32);
            this.txtLastRestoreTime.Name = "txtLastRestoreTime";
            this.txtLastRestoreTime.ReadOnly = true;
            this.txtLastRestoreTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLastRestoreTime.Size = new System.Drawing.Size(160, 21);
            this.txtLastRestoreTime.TabIndex = 5;
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 366);
            this.Controls.Add(this.gbxRestore);
            this.Controls.Add(this.gbxBackup);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تهيه / بازيابي پشتيبان";
            this.Load += new System.EventHandler(this.frmBackup_Load);
            this.Shown += new System.EventHandler(this.frmBackup_Shown);
            this.gbxBackup.ResumeLayout(false);
            this.gbxBackup.PerformLayout();
            this.gbxRestore.ResumeLayout(false);
            this.gbxRestore.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbxBackup;
        private System.Windows.Forms.GroupBox gbxRestore;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.TextBox txtLastBackupDate;
        private System.Windows.Forms.TextBox txtLastBackupTime;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.TextBox txtRestorePath;
        private System.Windows.Forms.TextBox txtLastRestoreDate;
        private System.Windows.Forms.TextBox txtLastRestoreTime;
        private System.Windows.Forms.Label lblBackupPath;
        private System.Windows.Forms.Label lblLastBackup;
        private System.Windows.Forms.Label lblRestorePath;
        private System.Windows.Forms.Label lblLastRestore;
        private System.Windows.Forms.FolderBrowserDialog fbdBackup;
        private System.Windows.Forms.FolderBrowserDialog fbdRestore;
    }
}