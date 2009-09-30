namespace Insurance
{
    partial class frmPwChange
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
            this.txtCurrentPw = new System.Windows.Forms.TextBox();
            this.txtNewPw = new System.Windows.Forms.TextBox();
            this.txtConfirmPw = new System.Windows.Forms.TextBox();
            this.lblCurrentPw = new System.Windows.Forms.Label();
            this.lblNewPw = new System.Windows.Forms.Label();
            this.lblConfirmPw = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCurrentPw
            // 
            this.txtCurrentPw.Location = new System.Drawing.Point(12, 12);
            this.txtCurrentPw.Name = "txtCurrentPw";
            this.txtCurrentPw.Size = new System.Drawing.Size(156, 21);
            this.txtCurrentPw.TabIndex = 1;
            this.txtCurrentPw.UseSystemPasswordChar = true;
            this.txtCurrentPw.TextChanged += new System.EventHandler(this.txtConfirmPw_TextChanged);
            // 
            // txtNewPw
            // 
            this.txtNewPw.Location = new System.Drawing.Point(12, 38);
            this.txtNewPw.Name = "txtNewPw";
            this.txtNewPw.Size = new System.Drawing.Size(156, 21);
            this.txtNewPw.TabIndex = 2;
            this.txtNewPw.UseSystemPasswordChar = true;
            this.txtNewPw.TextChanged += new System.EventHandler(this.txtConfirmPw_TextChanged);
            // 
            // txtConfirmPw
            // 
            this.txtConfirmPw.Location = new System.Drawing.Point(12, 64);
            this.txtConfirmPw.Name = "txtConfirmPw";
            this.txtConfirmPw.Size = new System.Drawing.Size(156, 21);
            this.txtConfirmPw.TabIndex = 3;
            this.txtConfirmPw.UseSystemPasswordChar = true;
            this.txtConfirmPw.TextChanged += new System.EventHandler(this.txtConfirmPw_TextChanged);
            // 
            // lblCurrentPw
            // 
            this.lblCurrentPw.AutoSize = true;
            this.lblCurrentPw.Location = new System.Drawing.Point(174, 15);
            this.lblCurrentPw.Name = "lblCurrentPw";
            this.lblCurrentPw.Size = new System.Drawing.Size(81, 13);
            this.lblCurrentPw.TabIndex = 0;
            this.lblCurrentPw.Text = "كلمه عبور فعلي";
            // 
            // lblNewPw
            // 
            this.lblNewPw.AutoSize = true;
            this.lblNewPw.Location = new System.Drawing.Point(178, 41);
            this.lblNewPw.Name = "lblNewPw";
            this.lblNewPw.Size = new System.Drawing.Size(77, 13);
            this.lblNewPw.TabIndex = 0;
            this.lblNewPw.Text = "كلمه عبور جديد";
            // 
            // lblConfirmPw
            // 
            this.lblConfirmPw.AutoSize = true;
            this.lblConfirmPw.Location = new System.Drawing.Point(181, 67);
            this.lblConfirmPw.Name = "lblConfirmPw";
            this.lblConfirmPw.Size = new System.Drawing.Size(74, 13);
            this.lblConfirmPw.TabIndex = 0;
            this.lblConfirmPw.Text = "تائيد كلمه عبور";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 91);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(93, 91);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "تائيد";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmPwChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 125);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblConfirmPw);
            this.Controls.Add(this.lblNewPw);
            this.Controls.Add(this.lblCurrentPw);
            this.Controls.Add(this.txtConfirmPw);
            this.Controls.Add(this.txtNewPw);
            this.Controls.Add(this.txtCurrentPw);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPwChange";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تغيير كلمه ي عبور";
            this.Load += new System.EventHandler(this.frmPwChange_Load);
            this.Shown += new System.EventHandler(this.frmPwChange_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCurrentPw;
        private System.Windows.Forms.TextBox txtNewPw;
        private System.Windows.Forms.TextBox txtConfirmPw;
        private System.Windows.Forms.Label lblCurrentPw;
        private System.Windows.Forms.Label lblNewPw;
        private System.Windows.Forms.Label lblConfirmPw;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}