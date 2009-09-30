namespace Insurance
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.lnk13x17 = new System.Windows.Forms.LinkLabel();
            this.lnkAofz = new System.Windows.Forms.LinkLabel();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblAbout = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.picMyPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMyPic)).BeginInit();
            this.SuspendLayout();
            // 
            // lnk13x17
            // 
            this.lnk13x17.AutoSize = true;
            this.lnk13x17.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnk13x17.Location = new System.Drawing.Point(163, 70);
            this.lnk13x17.Name = "lnk13x17";
            this.lnk13x17.Size = new System.Drawing.Size(121, 13);
            this.lnk13x17.TabIndex = 1;
            this.lnk13x17.TabStop = true;
            this.lnk13x17.Text = "http://www.Babaei.net/";
            this.lnk13x17.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk13x17_LinkClicked);
            // 
            // lnkAofz
            // 
            this.lnkAofz.AutoSize = true;
            this.lnkAofz.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkAofz.Location = new System.Drawing.Point(140, 88);
            this.lnkAofz.Name = "lnkAofz";
            this.lnkAofz.Size = new System.Drawing.Size(170, 13);
            this.lnkAofz.TabIndex = 2;
            this.lnkAofz.TabStop = true;
            this.lnkAofz.Text = "mailto:ace.of.zerosync@gmail.com";
            this.lnkAofz.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAofz_LinkClicked);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(190, 126);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Font = new System.Drawing.Font("Times New Roman", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout.Location = new System.Drawing.Point(122, 12);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(68, 14);
            this.lblAbout.TabIndex = 0;
            this.lblAbout.Text = "Designed By:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblName.Location = new System.Drawing.Point(186, 44);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(76, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "M.S. Babaei";
            // 
            // picMyPic
            // 
            this.picMyPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMyPic.Image = ((System.Drawing.Image)(resources.GetObject("picMyPic.Image")));
            this.picMyPic.Location = new System.Drawing.Point(12, 12);
            this.picMyPic.Name = "picMyPic";
            this.picMyPic.Size = new System.Drawing.Size(104, 137);
            this.picMyPic.TabIndex = 0;
            this.picMyPic.TabStop = false;
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 191);
            this.ControlBox = false;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lnkAofz);
            this.Controls.Add(this.lnk13x17);
            this.Controls.Add(this.picMyPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "13x17.net, 13x17.com, 13x17.org";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picMyPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picMyPic;
        private System.Windows.Forms.LinkLabel lnk13x17;
        private System.Windows.Forms.LinkLabel lnkAofz;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label lblName;

    }
}