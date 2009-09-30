namespace Insurance
{
    partial class frmReports
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
            this.btnReport = new System.Windows.Forms.Button();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.cmbToDay = new System.Windows.Forms.ComboBox();
            this.cmbToMonth = new System.Windows.Forms.ComboBox();
            this.cmbToYear = new System.Windows.Forms.ComboBox();
            this.cmbFromDay = new System.Windows.Forms.ComboBox();
            this.cmbFromMonth = new System.Windows.Forms.ComboBox();
            this.cmbFromYear = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 76);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(93, 76);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 7;
            this.btnReport.Text = "گزارش";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(316, 42);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(37, 13);
            this.lblToDate.TabIndex = 0;
            this.lblToDate.Text = "تا تاریخ";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(315, 15);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(38, 13);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "از تاریخ";
            // 
            // cmbToDay
            // 
            this.cmbToDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToDay.FormattingEnabled = true;
            this.cmbToDay.Location = new System.Drawing.Point(214, 39);
            this.cmbToDay.MaxDropDownItems = 13;
            this.cmbToDay.Name = "cmbToDay";
            this.cmbToDay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbToDay.Size = new System.Drawing.Size(95, 21);
            this.cmbToDay.TabIndex = 6;
            // 
            // cmbToMonth
            // 
            this.cmbToMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToMonth.FormattingEnabled = true;
            this.cmbToMonth.Location = new System.Drawing.Point(113, 39);
            this.cmbToMonth.MaxDropDownItems = 13;
            this.cmbToMonth.Name = "cmbToMonth";
            this.cmbToMonth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbToMonth.Size = new System.Drawing.Size(95, 21);
            this.cmbToMonth.TabIndex = 5;
            // 
            // cmbToYear
            // 
            this.cmbToYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToYear.FormattingEnabled = true;
            this.cmbToYear.Location = new System.Drawing.Point(12, 39);
            this.cmbToYear.MaxDropDownItems = 13;
            this.cmbToYear.Name = "cmbToYear";
            this.cmbToYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbToYear.Size = new System.Drawing.Size(95, 21);
            this.cmbToYear.TabIndex = 4;
            // 
            // cmbFromDay
            // 
            this.cmbFromDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromDay.FormattingEnabled = true;
            this.cmbFromDay.Location = new System.Drawing.Point(214, 12);
            this.cmbFromDay.MaxDropDownItems = 13;
            this.cmbFromDay.Name = "cmbFromDay";
            this.cmbFromDay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbFromDay.Size = new System.Drawing.Size(95, 21);
            this.cmbFromDay.TabIndex = 3;
            // 
            // cmbFromMonth
            // 
            this.cmbFromMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromMonth.FormattingEnabled = true;
            this.cmbFromMonth.Location = new System.Drawing.Point(113, 12);
            this.cmbFromMonth.MaxDropDownItems = 13;
            this.cmbFromMonth.Name = "cmbFromMonth";
            this.cmbFromMonth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbFromMonth.Size = new System.Drawing.Size(95, 21);
            this.cmbFromMonth.TabIndex = 2;
            // 
            // cmbFromYear
            // 
            this.cmbFromYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromYear.FormattingEnabled = true;
            this.cmbFromYear.Location = new System.Drawing.Point(12, 12);
            this.cmbFromYear.MaxDropDownItems = 13;
            this.cmbFromYear.Name = "cmbFromYear";
            this.cmbFromYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbFromYear.Size = new System.Drawing.Size(95, 21);
            this.cmbFromYear.TabIndex = 1;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 110);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.cmbToDay);
            this.Controls.Add(this.cmbToMonth);
            this.Controls.Add(this.cmbToYear);
            this.Controls.Add(this.cmbFromDay);
            this.Controls.Add(this.cmbFromMonth);
            this.Controls.Add(this.cmbFromYear);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "گزارشات";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.Shown += new System.EventHandler(this.frmReports_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.ComboBox cmbToDay;
        private System.Windows.Forms.ComboBox cmbToMonth;
        private System.Windows.Forms.ComboBox cmbToYear;
        private System.Windows.Forms.ComboBox cmbFromDay;
        private System.Windows.Forms.ComboBox cmbFromMonth;
        private System.Windows.Forms.ComboBox cmbFromYear;
    }
}