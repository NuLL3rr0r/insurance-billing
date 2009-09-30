using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace InsuranceCertification
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
                        try
            {
                StringBuilder sb = new StringBuilder();
                string newLine = Environment.NewLine;
                string sepChar = Path.DirectorySeparatorChar.ToString();

                sb.Append(string.Concat("Clinic: {", txtClinic.Text, "}", newLine));

                
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                if (!path.EndsWith(sepChar))
                    path += sepChar;

                string file = path + "license.crt";

                using (StreamWriter sw = new StreamWriter(file, false, Encoding.UTF8))
                {
                    sw.Write(EncDec.Encrypt(sb.ToString(), "§"));
                }

                string explorer = Environment.GetEnvironmentVariable("SystemRoot"); // or windir
                explorer += (explorer.EndsWith(sepChar) ? string.Empty : sepChar) + "explorer.exe";

                Process p = new Process();
                p.StartInfo.Arguments = string.Format("/select,\"{0}\"", file);
                p.StartInfo.FileName = explorer;
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
