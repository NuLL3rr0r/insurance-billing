namespace InsuranceCertification
{
    partial class Form2
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
            this.txtClinic = new System.Windows.Forms.TextBox();
            this.lblClinic = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtClinic
            // 
            this.txtClinic.Location = new System.Drawing.Point(12, 12);
            this.txtClinic.Name = "txtClinic";
            this.txtClinic.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtClinic.Size = new System.Drawing.Size(275, 20);
            this.txtClinic.TabIndex = 3;
            // 
            // lblClinic
            // 
            this.lblClinic.AutoSize = true;
            this.lblClinic.Location = new System.Drawing.Point(312, 15);
            this.lblClinic.Name = "lblClinic";
            this.lblClinic.Size = new System.Drawing.Size(58, 13);
            this.lblClinic.TabIndex = 2;
            this.lblClinic.Text = "فیزیوتراپی";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(12, 38);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 12;
            this.btnRegister.Text = "رجیستر";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 72);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtClinic);
            this.Controls.Add(this.lblClinic);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClinic;
        private System.Windows.Forms.Label lblClinic;
        private System.Windows.Forms.Button btnRegister;
    }
}