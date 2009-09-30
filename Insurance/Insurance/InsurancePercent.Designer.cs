namespace Insurance
{
    partial class frmInsurancePercent
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
            this.lblTaminEjtemaei = new System.Windows.Forms.Label();
            this.lblKhadamaatDarmaaniNMJA = new System.Windows.Forms.Label();
            this.numTaminEjtemaei = new System.Windows.Forms.NumericUpDown();
            this.numKhadamaatDarmaaniNMJA = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numKhadamaatDarmaani = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numTaminEjtemaei)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKhadamaatDarmaaniNMJA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKhadamaatDarmaani)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTaminEjtemaei
            // 
            this.lblTaminEjtemaei.AutoSize = true;
            this.lblTaminEjtemaei.Location = new System.Drawing.Point(137, 14);
            this.lblTaminEjtemaei.Name = "lblTaminEjtemaei";
            this.lblTaminEjtemaei.Size = new System.Drawing.Size(99, 13);
            this.lblTaminEjtemaei.TabIndex = 0;
            this.lblTaminEjtemaei.Text = "درصد تامین اجتمائی";
            // 
            // lblKhadamaatDarmaaniNMJA
            // 
            this.lblKhadamaatDarmaaniNMJA.AutoSize = true;
            this.lblKhadamaatDarmaaniNMJA.Location = new System.Drawing.Point(103, 41);
            this.lblKhadamaatDarmaaniNMJA.Name = "lblKhadamaatDarmaaniNMJA";
            this.lblKhadamaatDarmaaniNMJA.Size = new System.Drawing.Size(133, 13);
            this.lblKhadamaatDarmaaniNMJA.TabIndex = 0;
            this.lblKhadamaatDarmaaniNMJA.Text = "درصد خدمات درمانی ن م جا";
            // 
            // numTaminEjtemaei
            // 
            this.numTaminEjtemaei.Location = new System.Drawing.Point(12, 12);
            this.numTaminEjtemaei.Name = "numTaminEjtemaei";
            this.numTaminEjtemaei.Size = new System.Drawing.Size(85, 21);
            this.numTaminEjtemaei.TabIndex = 1;
            this.numTaminEjtemaei.Enter += new System.EventHandler(this.numTaminEjtemaei_Enter);
            // 
            // numKhadamaatDarmaaniNMJA
            // 
            this.numKhadamaatDarmaaniNMJA.Location = new System.Drawing.Point(12, 39);
            this.numKhadamaatDarmaaniNMJA.Name = "numKhadamaatDarmaaniNMJA";
            this.numKhadamaatDarmaaniNMJA.Size = new System.Drawing.Size(85, 21);
            this.numKhadamaatDarmaaniNMJA.TabIndex = 2;
            this.numKhadamaatDarmaaniNMJA.Enter += new System.EventHandler(this.numTaminEjtemaei_Enter);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(93, 93);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "تائيد";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 93);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numKhadamaatDarmaani
            // 
            this.numKhadamaatDarmaani.Location = new System.Drawing.Point(12, 66);
            this.numKhadamaatDarmaani.Name = "numKhadamaatDarmaani";
            this.numKhadamaatDarmaani.Size = new System.Drawing.Size(85, 21);
            this.numKhadamaatDarmaani.TabIndex = 3;
            this.numKhadamaatDarmaani.Enter += new System.EventHandler(this.numTaminEjtemaei_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "درصد خدمات درمانی";
            // 
            // frmInsurancePercent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 128);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.numKhadamaatDarmaani);
            this.Controls.Add(this.numKhadamaatDarmaaniNMJA);
            this.Controls.Add(this.numTaminEjtemaei);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblKhadamaatDarmaaniNMJA);
            this.Controls.Add(this.lblTaminEjtemaei);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInsurancePercent";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تعیین درصد بیمه";
            this.Load += new System.EventHandler(this.frmInsurancePercent_Load);
            this.Shown += new System.EventHandler(this.frmInsurancePercent_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numTaminEjtemaei)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKhadamaatDarmaaniNMJA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKhadamaatDarmaani)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTaminEjtemaei;
        private System.Windows.Forms.Label lblKhadamaatDarmaaniNMJA;
        private System.Windows.Forms.NumericUpDown numTaminEjtemaei;
        private System.Windows.Forms.NumericUpDown numKhadamaatDarmaaniNMJA;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numKhadamaatDarmaani;
        private System.Windows.Forms.Label label1;
    }
}