using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Insurance
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void lnk13x17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.babaei.net/");
            }
            catch
            {
            }
            finally
            {
            }
        }

        private void lnkAofz_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:ace.of.zerosync@gmail.com");
            }
            catch
            {
            }
            finally
            {
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}