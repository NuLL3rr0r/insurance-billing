namespace Insurance
{
    partial class frmInsuranceKDNMJA
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
            this.btnInsertEdit = new System.Windows.Forms.Button();
            this.lblOrgShare = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblTreatmentArea = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblBookletCode = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtOrgShare = new System.Windows.Forms.TextBox();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.txtBookletCode = new System.Windows.Forms.TextBox();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmbDateDay = new System.Windows.Forms.ComboBox();
            this.cmbDateMonth = new System.Windows.Forms.ComboBox();
            this.cmbDateYear = new System.Windows.Forms.ComboBox();
            this.cmbTreatmentArea = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInsertEdit
            // 
            this.btnInsertEdit.Location = new System.Drawing.Point(93, 204);
            this.btnInsertEdit.Name = "btnInsertEdit";
            this.btnInsertEdit.Size = new System.Drawing.Size(75, 23);
            this.btnInsertEdit.TabIndex = 10;
            this.btnInsertEdit.Text = "درج";
            this.btnInsertEdit.UseVisualStyleBackColor = true;
            this.btnInsertEdit.Click += new System.EventHandler(this.btnInsertEdit_Click);
            // 
            // lblOrgShare
            // 
            this.lblOrgShare.AutoSize = true;
            this.lblOrgShare.Location = new System.Drawing.Point(213, 172);
            this.lblOrgShare.Name = "lblOrgShare";
            this.lblOrgShare.Size = new System.Drawing.Size(69, 13);
            this.lblOrgShare.TabIndex = 0;
            this.lblOrgShare.Text = "سهم سازمان";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(212, 145);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(70, 13);
            this.lblTotalCost.TabIndex = 0;
            this.lblTotalCost.Text = "مبلغ کل - ریال";
            // 
            // lblTreatmentArea
            // 
            this.lblTreatmentArea.AutoSize = true;
            this.lblTreatmentArea.Location = new System.Drawing.Point(218, 93);
            this.lblTreatmentArea.Name = "lblTreatmentArea";
            this.lblTreatmentArea.Size = new System.Drawing.Size(64, 13);
            this.lblTreatmentArea.TabIndex = 0;
            this.lblTreatmentArea.Text = "نواحی درمان";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(218, 119);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(64, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "تاریخ مراجعه";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Location = new System.Drawing.Point(193, 41);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(89, 13);
            this.lblPatientName.TabIndex = 0;
            this.lblPatientName.Text = "نام و نام خانوادگی";
            // 
            // lblBookletCode
            // 
            this.lblBookletCode.AutoSize = true;
            this.lblBookletCode.Location = new System.Drawing.Point(206, 67);
            this.lblBookletCode.Name = "lblBookletCode";
            this.lblBookletCode.Size = new System.Drawing.Size(76, 13);
            this.lblBookletCode.TabIndex = 0;
            this.lblBookletCode.Text = "کد بیمه درمانی";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(253, 15);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(29, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ردیف";
            // 
            // txtOrgShare
            // 
            this.txtOrgShare.Location = new System.Drawing.Point(12, 169);
            this.txtOrgShare.Name = "txtOrgShare";
            this.txtOrgShare.ReadOnly = true;
            this.txtOrgShare.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtOrgShare.Size = new System.Drawing.Size(175, 21);
            this.txtOrgShare.TabIndex = 9;
            this.txtOrgShare.Text = "0";
            this.txtOrgShare.Enter += new System.EventHandler(this.txtID_Enter);
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(12, 142);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalCost.Size = new System.Drawing.Size(175, 21);
            this.txtTotalCost.TabIndex = 8;
            this.txtTotalCost.Text = "0";
            this.txtTotalCost.TextChanged += new System.EventHandler(this.txtTotalCost_TextChanged);
            this.txtTotalCost.Leave += new System.EventHandler(this.txtNum_Leave);
            this.txtTotalCost.Enter += new System.EventHandler(this.txtID_Enter);
            // 
            // txtBookletCode
            // 
            this.txtBookletCode.Location = new System.Drawing.Point(12, 64);
            this.txtBookletCode.MaxLength = 25;
            this.txtBookletCode.Name = "txtBookletCode";
            this.txtBookletCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBookletCode.Size = new System.Drawing.Size(175, 21);
            this.txtBookletCode.TabIndex = 3;
            this.txtBookletCode.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtPersian_PreviewKeyDown);
            this.txtBookletCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPersian_KeyPress);
            this.txtBookletCode.Enter += new System.EventHandler(this.txtID_Enter);
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(12, 38);
            this.txtPatientName.MaxLength = 35;
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPatientName.Size = new System.Drawing.Size(175, 21);
            this.txtPatientName.TabIndex = 2;
            this.txtPatientName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtPersian_PreviewKeyDown);
            this.txtPatientName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPersian_KeyPress);
            this.txtPatientName.Enter += new System.EventHandler(this.txtID_Enter);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(12, 12);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtID.Size = new System.Drawing.Size(175, 21);
            this.txtID.TabIndex = 1;
            this.txtID.Enter += new System.EventHandler(this.txtID_Enter);
            // 
            // cmbDateDay
            // 
            this.cmbDateDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateDay.FormattingEnabled = true;
            this.cmbDateDay.Location = new System.Drawing.Point(135, 116);
            this.cmbDateDay.MaxDropDownItems = 13;
            this.cmbDateDay.MaxLength = 2;
            this.cmbDateDay.Name = "cmbDateDay";
            this.cmbDateDay.Size = new System.Drawing.Size(52, 21);
            this.cmbDateDay.TabIndex = 7;
            // 
            // cmbDateMonth
            // 
            this.cmbDateMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateMonth.FormattingEnabled = true;
            this.cmbDateMonth.Location = new System.Drawing.Point(81, 116);
            this.cmbDateMonth.MaxDropDownItems = 13;
            this.cmbDateMonth.MaxLength = 2;
            this.cmbDateMonth.Name = "cmbDateMonth";
            this.cmbDateMonth.Size = new System.Drawing.Size(52, 21);
            this.cmbDateMonth.TabIndex = 6;
            // 
            // cmbDateYear
            // 
            this.cmbDateYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateYear.FormattingEnabled = true;
            this.cmbDateYear.Location = new System.Drawing.Point(12, 116);
            this.cmbDateYear.MaxDropDownItems = 13;
            this.cmbDateYear.MaxLength = 4;
            this.cmbDateYear.Name = "cmbDateYear";
            this.cmbDateYear.Size = new System.Drawing.Size(67, 21);
            this.cmbDateYear.TabIndex = 5;
            // 
            // cmbTreatmentArea
            // 
            this.cmbTreatmentArea.FormattingEnabled = true;
            this.cmbTreatmentArea.Location = new System.Drawing.Point(12, 90);
            this.cmbTreatmentArea.MaxDropDownItems = 13;
            this.cmbTreatmentArea.MaxLength = 35;
            this.cmbTreatmentArea.Name = "cmbTreatmentArea";
            this.cmbTreatmentArea.Size = new System.Drawing.Size(175, 21);
            this.cmbTreatmentArea.TabIndex = 4;
            this.cmbTreatmentArea.Enter += new System.EventHandler(this.txtID_Enter);
            this.cmbTreatmentArea.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtPersian_PreviewKeyDown);
            this.cmbTreatmentArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPersian_KeyPress);
            // 
            // frmInsuranceKDNMJA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 239);
            this.Controls.Add(this.cmbTreatmentArea);
            this.Controls.Add(this.cmbDateDay);
            this.Controls.Add(this.cmbDateMonth);
            this.Controls.Add(this.cmbDateYear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInsertEdit);
            this.Controls.Add(this.lblOrgShare);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.lblTreatmentArea);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblBookletCode);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtOrgShare);
            this.Controls.Add(this.txtTotalCost);
            this.Controls.Add(this.txtBookletCode);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.txtID);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInsuranceKDNMJA";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "درج رکورد جدید";
            this.Load += new System.EventHandler(this.frmInsuranceKDNMJA_Load);
            this.Shown += new System.EventHandler(this.frmInsuranceKDNMJA_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInsertEdit;
        private System.Windows.Forms.Label lblOrgShare;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblTreatmentArea;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblBookletCode;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtOrgShare;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.TextBox txtBookletCode;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cmbDateDay;
        private System.Windows.Forms.ComboBox cmbDateMonth;
        private System.Windows.Forms.ComboBox cmbDateYear;
        private System.Windows.Forms.ComboBox cmbTreatmentArea;
    }
}