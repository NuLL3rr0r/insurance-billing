using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Diagnostics;

namespace Insurance
{
    public partial class frmSplashScreen : Form
    {
        #region Global Variables & Properties

        private string loadingStr = "";
        private string loadingChr = "●";

        private bool allowClose = false;

        private string[] fileList = { 
                                      "license.crt",
                                      "root.sqlite",
                                      "SkinSoft.OSSkin.dll",
                                    };

        private bool _shutdown = false;
        public bool shutdown
        {
            set
            {
                _shutdown = value;
            }
        }

        #endregion


        public frmSplashScreen()
        {
            InitializeComponent();

            tmrFadeIn.Enabled = true;
        }

        #region Utilities

        private bool ChkFiles()
        {
            bool found = true;

            foreach (string file in fileList)
            {
                found &= File.Exists(Base.path + file);
                if (!File.Exists(Base.path + file))
                    MessageBox.Show(this, String.Format(Base.errFile, file), Base.errFileHeader, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            return found;
        }

        private static bool IsPrevInstance()
        {
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] instances = Process.GetProcessesByName(processName);
            if (instances.Length > 1)
                return true;
            else
                return false;
        }

        private bool ChkDate()
        {
            if (Convert.ToInt32(Base.FormatNumsToEnglish(Base.GetPersianDate().Substring(0, 4))) >= 1388)
                return true;
            else
                return false;
        }

        #endregion

        #region Form Operations

        private void frmSplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowClose)
                e.Cancel = true;
        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            SkinSoft.OSSkin.OSSkin.RemoveSkin(this);
        }

        private void frmSplashScreen_Shown(object sender, EventArgs e)
        {
            this.Activate();
            if (!_shutdown)
            {
                RunLoader("Loading ", 503);
            }
            else
            {
                RunLoader("Shutting Down ", 468);
            }
        }

        private void RunLoader(string str, int pos)
        {
            loadingStr = str;
            lblLoading.Text = str;
            tmrLoading.Enabled = true;
            lblLoading.Left = pos;
        }

        private void DoExit()
        {
            tmrFadeOut.Enabled = true;
        }

        private void ShutItDown()
        {
            _shutdown = true;
            RunLoader("Shutting Down ", 468);
            DoExit();
        }

        private void ShowGUI()
        {
            tmrFadeOut.Enabled = true;
        }

        #endregion

        #region Admin

        private void AdminPwGet()
        {
            string tbl = "admin";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.dbCnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();

                oda.Fill(ds, tbl);

                while (drr.Read())
                {
                    Base.pw = EncDec.Decrypt(drr["pw"].ToString(), Base.dbHashKey);
                    osSkin1.Style = Base.GetCurrentTheme(drr["Theme"].ToString());
                    Base.PercentTE = Convert.ToByte(drr["PercentTE"]);
                    Base.PercentKDNMJA = Convert.ToByte(drr["PercentKDNMJA"]);
                    Base.PercentKD = Convert.ToByte(drr["PercentKD"]);
                    Base.BackupPath = drr["BackupPath"].ToString();
                    Base.RestorePath = drr["RestorePath"].ToString();
                    Base.LastBackupDate = drr["LastBackupDate"].ToString();
                    Base.LastRestoreDate = drr["LastRestoreDate"].ToString();
                    Base.LastBackupTime = drr["LastBackupTime"].ToString();
                    Base.LastRestoreTime = drr["LastRestoreTime"].ToString();
                    break;
                }

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                oda.Dispose();
                cnn.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                oda = null;
                cnn = null;

                if (Base.pw != string.Empty)
                {
                    using (frmPw dlg = new frmPw())
                    {
                        dlg.cboxCloseVisible = true;
                        dlg.ShowDialog(this);
                        if (dlg.isValid)
                        {
                            Base.CleanAndRepair();
                            ShowGUI();
                        }
                        else
                            //Password is inavlid - User closed the form
                            ShutItDown();
                    }
                }
                else
                {
                    MessageBox.Show("هشدار\nبرای برنامه کلمه عبور در نظر گرفته نشده است\n\nپس از ورد به برنامه جهت تنظیم کلمه عبور می توانید از منوی تنظیمات دستور تغییر کلمه عبور را صادر نمائید", "ریسک امنیتی", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    ShowGUI();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                ShutItDown();
            }
            finally
            {
                tbl = null;
                sqlStr = null;
            }
        }

        #endregion

        #region Timers

        private void tmrLoading_Tick(object sender, EventArgs e)
        {
            if (lblLoading.Text.Length < loadingStr.Length + 6)
                lblLoading.Text += loadingChr;
            else
                lblLoading.Text = loadingStr;
        }

        private void tmrFadeIn_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.01;
            if (this.Opacity >= 1.0)
            {
                tmrFadeIn.Enabled = false;
                this.Opacity = 1.0;

                if (!_shutdown)
                {
                    if (IsPrevInstance())
                    {
                        MessageBox.Show(this, Base.errDoubleInstance, Base.errDoubleInstanceHeader, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        ShutItDown();
                        return;
                    }

                    if (!ChkFiles())
                    {
                        ShutItDown();
                        return;
                    }

                    if (!ChkDate())
                    {
                        MessageBox.Show(this, "تاریخ کامیپوتر شما اشتباه است\n\nتا زمان اصلاح آن امکان ورود به برنامه میسر نمی باشد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        ShutItDown();
                        return;
                    }

                    Base.CleanAndRepair();
                    AdminPwGet();
                }
                else
                {
                    Base.CleanAndRepair();
                    DoExit();
                }
            }
        }

        private void tmrFadeOut_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.01 * 2;
            if (this.Opacity <= 0.0)
            {
                tmrFadeOut.Enabled = false;
                tmrLoading.Enabled = false;
                if (!_shutdown)
                {
                    this.Hide();
                    frmMain frm = new frmMain();
                    frm.Show();
                    //Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
                    this.Close();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        #endregion
    }
}
