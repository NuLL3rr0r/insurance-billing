using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Insurance
{
    public partial class frmBackup : Form
    {
        string tempPath = Base.CreateTempPath();

        public frmBackup()
        {
            InitializeComponent();
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            txtBackupPath.Text = Base.BackupPath;
            txtRestorePath.Text = Base.RestorePath;
            txtLastBackupDate.Text = Base.FormatNumsToPersian(Base.LastBackupDate);
            txtLastRestoreDate.Text = Base.FormatNumsToPersian(Base.LastRestoreDate);
            txtLastBackupTime.Text = Base.FormatNumsToPersian(Base.LastBackupTime);
            txtLastRestoreTime.Text = Base.FormatNumsToPersian(Base.LastRestoreTime);
        }

        private void frmBackup_Shown(object sender, EventArgs e)
        {
            this.Activate();
            btnBackup.Focus();
        }

        private void CloseDialog()
        {
            try
            {
                Directory.Delete(tempPath, true);
            }
            catch
            {
            }
            finally
            {
            }

            this.Close();
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseDialog();
        }

        private bool SaveEventTime(string path, string time, string date, string eventName)
        {
            string tbl = "admin";
            string sqlStr = "SELECT * FROM " + tbl;

            string pField = eventName + "Path";
            string tField = "Last" + eventName + "Time";
            string dField = "Last" + eventName + "Date";

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.dbCnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                while (drr.Read())
                {
                    dt = ds.Tables[tbl];
                    dr = dt.Rows[0];
                    dr.BeginEdit();
                    dr[pField] = path;
                    dr[tField] = time;
                    dr[dField] = date;
                    dr.EndEdit();

                    oda.UpdateCommand = ocb.GetUpdateCommand();

                    if (oda.Update(ds, tbl) == 1)
                    {
                        ds.AcceptChanges();
                        switch (eventName)
                        {
                            case "Backup":
                                Base.BackupPath = path;
                                Base.LastBackupTime = time;
                                Base.LastBackupDate = date;
                                break;
                            case "Restore":
                                Base.RestorePath = path;
                                Base.LastRestoreTime = time;
                                Base.LastRestoreDate = date;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                        ds.RejectChanges();
                    break;
                }
                drr.Close();
                drr.Dispose();
                drr = null;

                cnn.Close();

                cmd.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                cmd = null;
                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cnn = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return false;
            }
            finally
            {
                sqlStr = null;
            }

            return true;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                fbdBackup.SelectedPath = txtBackupPath.Text;
                DialogResult result = fbdBackup.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DateTime dt = DateTime.Now;

                    if (!BackupToTemp("Tamin_e_Ejtemaei"))
                        return;
                    if (!BackupToTemp("Khadamaat_e_Darmaani_NMJA"))
                        return;
                    if (!BackupToTemp("Khadamaat_e_Darmaani"))
                        return;
                    if (!BackupToTemp("DocNames"))
                        return;
                    if (!BackupToTemp("TreatmentArea"))
                        return;
                    if (!BackupToTemp("PrintInfo_TE"))
                        return;
                    if (!BackupToTemp("PrintInfo_KDNMJA"))
                        return;
                    if (!BackupToTemp("PrintInfo_KD"))
                        return;
                    if (!BackupToPath("Tamin_e_Ejtemaei", dt))
                        return;
                    if (!BackupToPath("Khadamaat_e_Darmaani_NMJA", dt))
                        return;
                    if (!BackupToPath("Khadamaat_e_Darmaani", dt))
                        return;
                    if (!BackupToPath("DocNames", dt))
                        return;
                    if (!BackupToPath("TreatmentArea", dt))
                        return;
                    if (!BackupToPath("PrintInfo_TE", dt))
                        return;
                    if (!BackupToPath("PrintInfo_KDNMJA", dt))
                        return;
                    if (!BackupToPath("PrintInfo_KD", dt))
                        return;

                    MessageBox.Show("پشتیبان با موفقیت ایجاد شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private bool BackupToTemp(string tbl)
        {
            string sqlStr = "SELECT * FROM " + tbl;

            string xmlFile = string.Concat(tempPath, tbl, ".bak");
            string xsdFile = string.Concat(tempPath, tbl, ".bk");

            try
            {
                if (File.Exists(xmlFile))
                    File.Delete(xmlFile);
                if (File.Exists(xsdFile))
                    File.Delete(xsdFile);

                OleDbConnection cnn = new OleDbConnection(Base.dbCnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                DataSet ds = new DataSet();

                cnn.Open();

                oda.Fill(ds, tbl);

                ds.WriteXmlSchema(xsdFile);
                ds.WriteXml(xmlFile);

                cnn.Close();

                oda.Dispose();
                cnn.Dispose();

                oda = null;
                cnn = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                sqlStr = null;
            }

            return true;
        }

        private bool BackupToPath(string tbl, DateTime dt)
        {
            try
            {
                string xmlFile = string.Concat(tempPath, tbl, ".bak");
                string xsdFile = string.Concat(tempPath, tbl, ".bk");

                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

                string y = pc.GetYear(dt).ToString();
                string m = pc.GetMonth(dt).ToString();
                string d = pc.GetDayOfMonth(dt).ToString();

                if (m.Length != 2)
                    m = "0" + m;
                if (d.Length != 2)
                    d = "0" + d;

                string hh = pc.GetHour(dt).ToString();
                string mm = pc.GetMinute(dt).ToString();
                string ss = pc.GetSecond(dt).ToString();

                if (hh.Length != 2)
                    hh = "0" + hh;
                if (mm.Length != 2)
                    mm = "0" + mm;
                if (ss.Length != 2)
                    ss = "0" + ss;

                string bakFolder = String.Format("{0}_{1}_{2} # {3}_{4}_{5}", y, m, d, hh, mm, ss);

                string path = string.Concat(!fbdBackup.SelectedPath.EndsWith(Base.backslash) ? fbdBackup.SelectedPath + Base.backslash : fbdBackup.SelectedPath, bakFolder, Base.backslash);

                string xmlZip = string.Concat(path, tbl, ".xmz");
                string xsdZip = string.Concat(path, tbl, ".xsz");

                Directory.CreateDirectory(path);

                if (!Zipper.Compress(xsdFile, xsdZip, "solid"))
                    return false;

                if (!Zipper.Compress(xmlFile, xmlZip, "solid"))
                    return false;

                string time = bakFolder.Remove(0, 13).Replace('_', ':');
                string date = bakFolder.Remove(10).Replace('_', '/');

                if (!SaveEventTime(path, time, date, "Backup"))
                    return false;

                txtBackupPath.Text = path;
                txtLastBackupTime.Text = Base.FormatNumsToPersian(time);
                txtLastBackupDate.Text = Base.FormatNumsToPersian(date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
            }

            return true;
        }

        private bool RestoreFromPath(string tbl)
        {
            try
            {
                string path = string.Concat(!fbdRestore.SelectedPath.EndsWith(Base.backslash) ? fbdRestore.SelectedPath + Base.backslash : fbdRestore.SelectedPath);

                string xmlZip = string.Concat(path, tbl, ".xmz");
                string xsdZip = string.Concat(path, tbl, ".xsz");

                string xmlFile = string.Concat(tempPath, tbl, ".bak");
                string xsdFile = string.Concat(tempPath, tbl, ".bk");

                if (!Zipper.Decompress(xsdZip, xsdFile, "solid"))
                    return false;

                if (!Zipper.Decompress(xmlZip, xmlFile, "solid"))
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
            }

            return true;
        }

        private bool RestoreFromTemp(string tbl, DateTime dt)
        {
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                string xmlFile = string.Concat(tempPath, tbl, ".bak");
                string xsdFile = string.Concat(tempPath, tbl, ".bk");

                OleDbConnection cnn = new OleDbConnection(Base.dbCnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                DataSet ds = new DataSet();

                cnn.Open();

                oda.Fill(ds, tbl);

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                int counter = -1;
                while (drr.Read())
                    ds.Tables[tbl].Rows[++counter].Delete();

                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";

                oda.DeleteCommand = ocb.GetDeleteCommand();

                if (oda.Update(ds, tbl) == 1)
                    ds.AcceptChanges();
                else
                    ds.RejectChanges();

                ds.ReadXmlSchema(xsdFile);
                ds.ReadXml(xmlFile);

                if (oda.Update(ds, tbl) == 1)
                    ds.AcceptChanges();
                else
                    ds.RejectChanges();

                cnn.Close();

                oda.Dispose();
                cnn.Dispose();

                oda = null;
                cnn = null;

                string path = string.Concat(!fbdRestore.SelectedPath.EndsWith(Base.backslash) ? fbdRestore.SelectedPath + Base.backslash : fbdRestore.SelectedPath);

                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

                string y = pc.GetYear(dt).ToString();
                string m = pc.GetMonth(dt).ToString();
                string d = pc.GetDayOfMonth(dt).ToString();

                if (m.Length != 2)
                    m = "0" + m;
                if (d.Length != 2)
                    d = "0" + d;

                string hh = pc.GetHour(dt).ToString();
                string mm = pc.GetMinute(dt).ToString();
                string ss = pc.GetSecond(dt).ToString();

                if (hh.Length != 2)
                    hh = "0" + hh;
                if (mm.Length != 2)
                    mm = "0" + mm;
                if (ss.Length != 2)
                    ss = "0" + ss;

                string time = string.Format("{0}:{1}:{2}", hh, mm, ss);
                string date = string.Format("{0}/{1}/{2}", y, m, d);

                if (!SaveEventTime(path, time, date, "Restore"))
                    return false;

                txtRestorePath.Text = path;
                txtLastRestoreTime.Text = Base.FormatNumsToPersian(time);
                txtLastRestoreDate.Text = Base.FormatNumsToPersian(date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                sqlStr = null;
            }

            return true;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            fbdRestore.SelectedPath = txtRestorePath.Text;
            DialogResult result = fbdRestore.ShowDialog();
            if (result == DialogResult.OK)
            {
                DateTime dt = DateTime.Now;

                if (!RestoreFromPath("Tamin_e_Ejtemaei"))
                    return;
                if (!RestoreFromPath("Khadamaat_e_Darmaani_NMJA"))
                    return;
                if (!RestoreFromPath("Khadamaat_e_Darmaani"))
                    return;
                if (!RestoreFromPath("DocNames"))
                    return;
                if (!RestoreFromPath("TreatmentArea"))
                    return;
                if (!RestoreFromPath("PrintInfo_TE"))
                    return;
                if (!RestoreFromPath("PrintInfo_KDNMJA"))
                    return;
                if (!RestoreFromPath("PrintInfo_KD"))
                    return;
                if (!RestoreFromTemp("Tamin_e_Ejtemaei", dt))
                    return;
                if (!RestoreFromTemp("Khadamaat_e_Darmaani_NMJA", dt))
                    return;
                if (!RestoreFromTemp("Khadamaat_e_Darmaani", dt))
                    return;
                if (!RestoreFromTemp("DocNames", dt))
                    return;
                if (!RestoreFromTemp("TreatmentArea", dt))
                    return;
                if (!RestoreFromTemp("PrintInfo_TE", dt))
                    return;
                if (!RestoreFromTemp("PrintInfo_KDNMJA", dt))
                    return;
                if (!RestoreFromTemp("PrintInfo_KD", dt))
                    return;

                MessageBox.Show("پشتیبان با موفقیت بازیابی شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
        }
    }
}
