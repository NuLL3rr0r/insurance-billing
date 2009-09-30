using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Insurance
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            osSkin1.Style = Base.GetCurrentTheme();

            kb.usePersianNums = true;
        }

        #region Global Variables & Properties

        PersianKeyboard kb = new PersianKeyboard();

        private bool allowClose = false;

        private DataTable dtMaster = new DataTable();
        string tblCurrent = string.Empty;
        byte colSearch = 0;

        const string tblNameTE = "Tamin_e_Ejtemaei";
        const string tblNameKDNMJA = "Khadamaat_e_Darmaani_NMJA";
        const string tblNameKD = "Khadamaat_e_Darmaani";

        /*public static string[] colsTE = { "ردیف", "نام و نام خانوادگی بیمار", "کد دفترچه درمانی بیمه شده", "کد درمان و شرح خدمات", "تعداد جلسه", "نواحی درمان", "تاریخ", "نام پزشک معالج", "هزینه کل", "سهم بیمار", "سهم سازمان" };
        public static string[] colsKDNMJA = { "ردیف", "کد بیمه درمانی", "نام و نام خانوادگی", "تاریخ مراجعه", "شرح نسخه / خدمت", "مبلغ کل", "سهم بیمار", "سهم سازمان" };*/
        public static string[] colsTE = { "ردیف", "نام و نام خانوادگی", "کد بیمه", "تعداد جلسه", "نواحی درمان", "تاریخ", "نام پزشک", "هزینه کل", "سهم سازمان" };
        public static string[] colsKDNMJA = { "ردیف", "نام و نام خانوادگی", "کد بیمه", "نواحی درمان", "تاریخ", "هزینه کل", "سهم سازمان" };
        public static string[] colsKD = { "ردیف", "نام و نام خانوادگی", "کد بیمه", "تعداد جلسه", "نواحی درمان", "تاریخ", "تاریخ ترخیص", "هزینه کل", "سهم سازمان", "نوع صندوق" };

        DataTable docList;
        DataTable trArea;

        private static bool _haveNewRow;
        public static bool haveNewRow
        {
            set
            {
                _haveNewRow = value;
            }
        }

        #endregion

        #region Skins

        public bool SetTheme(string theme)
        {
            string tbl = "admin";
            string sqlStr = "SELECT * FROM " + tbl;

            OleDbConnection cnn = new OleDbConnection(Base.dbCnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;

            try
            {
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
                    dr["theme"] = theme;
                    dr.EndEdit();

                    oda.UpdateCommand = ocb.GetUpdateCommand();

                    if (oda.Update(ds, tbl) == 1)
                    {
                        ds.AcceptChanges();
                        osSkin1.Style = Base.GetCurrentTheme(theme);
                    }
                    else
                        ds.RejectChanges();
                    break;
                }
                drr.Close();
                drr.Dispose();
                drr = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return false;
            }
            finally
            {
                sqlStr = null;

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

            return true;
        }

        private void tbSkin_Clicked(object sender, EventArgs e)
        {
            // Get menu item
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;



            // Select appropiate skin
            SetTheme((string)menuItem.Tag);
        }

        #endregion

        #region Pw

        private void mItemChangePw_Click(object sender, EventArgs e)
        {
            using (frmPwChange dlg = new frmPwChange())
            {
                dlg.ShowDialog(this.ParentForm);
            }
        }

        #endregion

        #region Form Operations

        private void txtSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            kb.shiftPressed = e.Shift;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            kb.TransformInputChar(txtSearch, e);
        }

        private void Protect()
        {
            if (Base.pw != string.Empty)
            {
                using (frmPw dlg = new frmPw())
                {
                    dlg.cboxCloseVisible = false;
                    dlg.ShowDialog(this);
                }
            }
            else
            {
                MessageBox.Show("هشدار\nبرای برنامه کلمه عبور در نظر گرفته نشده است\n\nجهت تنظیم کلمه عبور می توانید از منوی تنظیمات دستور تغییر کلمه عبور را صادر نمائید", "هشدار امنیتی", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
        }

        private void SelectSearchCol(ToolStripMenuItem mItem)
        {
/*            switch (tblCurrent)
            {
                case tblNameTE:
                    if (mItem.ShortcutKeys == Keys.F3)
                        colSearch = 2;
                    else
                        colSearch = 1;
                    break;
                case tblNameKDNMJA:
                    if (mItem.ShortcutKeys == Keys.F3)
                        colSearch = 1;
                    else
                        colSearch = 2;
                    break;
                default:
                    break;
            }*/
            if (mItem.ShortcutKeys == Keys.F3)
                colSearch = 1;
            else
                colSearch = 2;
        }

        private void FocusOnSearchBox(object sender, EventArgs e)
        {
            ToolStripMenuItem mItem = (ToolStripMenuItem)sender;
            ToolStripMenuItem parentItem = (ToolStripMenuItem)mItem.OwnerItem;

            parentItem.Text = string.Format("{0} ({1})", parentItem.Tag, mItem.Tag);

            for (int i = parentItem.DropDownItems.Count; i > 0; i--)
                ((ToolStripMenuItem)parentItem.DropDownItems[i - 1]).Checked = false;
           
            mItem.Checked = true;

            SelectSearchCol(mItem);

            txtSearch.Focus();
        }

        private void ClearMenues(ToolStripMenuItem mItem)
        {
            for (int i = mItem.DropDownItems.Count; i > 0; i--)
                mItem.DropDownItems.RemoveAt(i - 1);
        }

        private void DrawMenues(ToolStripMenuItem mItem, string[] nodes, Keys[] shortcuts, System.EventHandler func)
        {
            ToolStripMenuItem newItem;

            mItem.Enabled = true;

            for (int i = 0; i < nodes.Length; ++i)
            {
                newItem = new ToolStripMenuItem(nodes[i]);
                newItem.ShortcutKeys = shortcuts[i];
                newItem.Tag = nodes[i] + "   " +shortcuts[i].ToString();
                if (i == 0)
                {
                    newItem.Checked = true;
                    mItem.Text = string.Format("{0} ({1})", mItem.Tag, newItem.Tag);
                    SelectSearchCol(newItem);
                }
                newItem.Click += new System.EventHandler(func);
                mItem.DropDownItems.Add(newItem);
            }
        }

        private void ResetForm()
        {
            dgvMaster.DataSource = null;
            mItemNew.Enabled = false;
            mItemEdit.Enabled = false;
            mItemErase.Enabled = false;

            mItemSearch.Enabled = false;
            mItemReports.Enabled = false;
            
            ClearMenues(mItemSearch);

            /*switch (tblCurrent)
            {
                case tblNameTE:
                    DrawMenues(mItemSearch, new string[] { "کد دفترچه درمانی", "نام بیمار" }, new Keys[] { Keys.F3, Keys.F4 }, this.FocusOnSearchBox);
                    break;
                case tblNameKDNMJA:
                    DrawMenues(mItemSearch, new string[] { "کد بیمه درمانی", "نام و نام خانوادگی" }, new Keys[] { Keys.F3, Keys.F4 }, this.FocusOnSearchBox);
                    break;
                default:
                    break;
            }*/
            DrawMenues(mItemSearch, new string[] { "کد بیمه", "نام و نام خانوادگی" }, new Keys[] { Keys.F3, Keys.F4 }, this.FocusOnSearchBox);
        }

        /*private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }*/

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //dgvMaster.AllowUserToAddRows = false;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            ResetForm();
            GetDocList();
            GetTrArea();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowClose)
            {
                e.Cancel = true;
                DoExit();
            }
        }

        public void DoExit()
        {
            allowClose = true;
            this.Hide();
            frmSplashScreen frm = new frmSplashScreen();
            frm.shutdown = true;
            frm.Show();
            this.Close();
            this.Dispose();
        }

        private void mItemExit_Click(object sender, EventArgs e)
        {
            DoExit();
        }

        private void mItemAbout_Click(object sender, EventArgs e)
        {
            using (frmAbout dlg = new frmAbout())
            {
                dlg.ShowDialog(this.ParentForm);
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            ResizeColumns();
        }

        #endregion

        private void GetDocList()
        {
            string tbl = "DocNames";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.dbCnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                DataSet ds = new DataSet();

                cnn.Open();

                oda.Fill(ds, tbl);

                docList = ds.Tables[tbl].Copy();

                oda.Dispose();
                cnn.Dispose();

                oda = null;
                cnn = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlStr = null;
            }
        }
        private void GetTrArea()
        {
            string tbl = "TreatmentArea";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.dbCnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                DataSet ds = new DataSet();

                cnn.Open();

                oda.Fill(ds, tbl);

                trArea = ds.Tables[tbl].Copy();

                oda.Dispose();
                cnn.Dispose();

                oda = null;
                cnn = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlStr = null;
            }
        }

        private DataTable GetInsuranceList(string tbl)
        {
            DataTable dtResult = new DataTable();

            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.dbCnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                cnn.Open();

                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];

                cnn.Close();

                dtResult = dt.Clone();
                for (int i = 0; i < dtResult.Columns.Count; ++i)
                    dtResult.Columns[i].DataType = Type.GetType("System.String");

                DataRow dr;

                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    object[] arr = dt.Rows[i].ItemArray;

                    dr = dtResult.NewRow();
                    for (int j = 0; j < arr.Length; ++j)
                    {
                        dr[j] = Base.FormatNumsToPersian(arr[j].ToString());
                    }
                    dtResult.Rows.Add(dr);
                    dr.AcceptChanges();
                }

                dtResult.AcceptChanges();

                oda.Dispose();
                cnn.Dispose();

                oda = null;
                cnn = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlStr = null;
            }

            return dtResult;
        }

        private void RenameColumns(string[] cols)
        {
            try
            {
                for (int i = 0; i < cols.Length; ++i)
                    dtMaster.Columns[i].ColumnName = cols[i];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void ResizeColumns()
        {
            int colsNum = dgvMaster.Columns.Count;
            if (colsNum >= 1)
            {
                int colSize = (dgvMaster.Width - 69) / colsNum;

                for (int i = 1; i < dgvMaster.Columns.Count; i++)
                {
                    dgvMaster.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

/*                dgvMaster.Columns[0].Width = colSize;
                for (int i = 1; i < dgvMaster.Columns.Count; i++)
                {
                    dgvMaster.Columns[i].Width = colSize;
                }*/
            }
        }

        private void ClearInsuranceList()
        {
            this.Focus();
            txtSearch.Clear();
            dgvMaster.DataSource = null;
            this.Focus();
        }

        private void RestoreInsuranceList()
        {
            try
            {
                if (tblCurrent == string.Empty)
                    return;

                ResetForm();
                dtMaster = GetInsuranceList(tblCurrent);

                switch (tblCurrent)
                {
                    case tblNameTE:
                        RenameColumns(colsTE);
                        break;
                    case tblNameKDNMJA:
                        RenameColumns(colsKDNMJA);
                        break;
                    case tblNameKD:
                        RenameColumns(colsKD);
                        break;
                    default:
                        break;
                }

                dgvMaster.DataSource = dtMaster;

                ResizeColumns();

                //dgvMaster.Sort(dgvMaster.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                this.Activate();
                mItemNew.Enabled = true;
                mItemReports.Enabled = true;
                txtSearch.Focus();
                txtSearch.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void RestoreInsuranceList(object sender)
        {
            try
            {
                RestoreInsuranceList();
                mItemInsurance.Text = string.Format("{0} ({1})", mItemInsurance.Tag, ((ToolStripMenuItem)sender).Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void mItemInsurancePercent_Click(object sender, EventArgs e)
        {
            using (frmInsurancePercent frm = new frmInsurancePercent())
            {
                frm.ShowDialog();
            }
        }

        private void mItemTaminEjtemaei_Click(object sender, EventArgs e)
        {
            tblCurrent = tblNameTE;
            RestoreInsuranceList(sender);
            mItemTaminEjtemaei.Checked = true;
            mItemKhadamaatDarmaaniNMJA.Checked = false;
            mItemKhadamaatDarmaani.Checked = false;
        }

        private void mItemKhadamaatDarmaaniNMJA_Click(object sender, EventArgs e)
        {
            tblCurrent = tblNameKDNMJA;
            RestoreInsuranceList(sender);
            mItemTaminEjtemaei.Checked = false;
            mItemKhadamaatDarmaaniNMJA.Checked = true;
            mItemKhadamaatDarmaani.Checked = false;
        }

        private void mItemKhadamaatDarmaani_Click(object sender, EventArgs e)
        {
            tblCurrent = tblNameKD;
            RestoreInsuranceList(sender);
            mItemTaminEjtemaei.Checked = false;
            mItemKhadamaatDarmaaniNMJA.Checked = false;
            mItemKhadamaatDarmaani.Checked = true;
        }

        private void dgvMaster_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (!dgvMaster.CurrentRow.IsNewRow)
                {
                    mItemEdit.Enabled = true;
                    mItemErase.Enabled = true;
                }
                else
                {
                    mItemEdit.Enabled = false;
                    mItemErase.Enabled = false;
                }
            }
            catch
            {
                /*mItemEdit.Enabled = false;
                mItemErase.Enabled = false;*/
            }
            finally
            {
            }
        }

        private void mItemNew_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            //ClearInsuranceList();
            switch (tblCurrent)
            {
                case tblNameTE:
                    using (frmInsuranceTE frm = new frmInsuranceTE())
                    {
                        frm.docList = docList;
                        frm.trArea = trArea;
                        frm.id = dtMaster.Rows.Count + 1;
                        frm.dgv = dgvMaster;
                        frm.ShowDialog();
                    }
                    break;
                case tblNameKDNMJA:
                    using (frmInsuranceKDNMJA frm = new frmInsuranceKDNMJA())
                    {
                        frm.trArea = trArea;
                        frm.id = dtMaster.Rows.Count + 1;
                        frm.dgv = dgvMaster;
                        frm.ShowDialog();
                    }
                    break;
                case tblNameKD:
                    using (frmInsuranceKD frm = new frmInsuranceKD())
                    {
                        frm.trArea = trArea;
                        frm.id = dtMaster.Rows.Count + 1;
                        frm.dgv = dgvMaster;
                        frm.ShowDialog();
                    }
                    break;
                default:
                    break;
            }
            //RestoreInsuranceList();
            timer1.Enabled = false;
        }

        private void mItemEdit_Click(object sender, EventArgs e)
        {
            switch (tblCurrent)
            {
                case tblNameTE:
                    using (frmInsuranceTE dlg = new frmInsuranceTE())
                    {
                        dlg.row = dgvMaster.CurrentRow.Cells;
                        ClearInsuranceList();
                        dlg.ShowDialog(this.ParentForm);
                    }
                    break;
                case tblNameKDNMJA:
                    using (frmInsuranceKDNMJA dlg = new frmInsuranceKDNMJA())
                    {
                        dlg.row = dgvMaster.CurrentRow.Cells;
                        ClearInsuranceList();
                        dlg.ShowDialog(this.ParentForm);
                    }
                    break;
                case tblNameKD:
                    using (frmInsuranceKD dlg = new frmInsuranceKD())
                    {
                        dlg.row = dgvMaster.CurrentRow.Cells;
                        ClearInsuranceList();
                        dlg.ShowDialog(this.ParentForm);
                    }
                    break;
                default:
                    break;
            }
            RestoreInsuranceList();
        }

        private void mItemErase_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("آيا مايل به حذف رکورد مورد نظر مي باشيد", Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            switch (result)
            {
                case DialogResult.OK:
                    int wh = Convert.ToInt32(Base.FormatNumsToEnglish(dgvMaster.CurrentRow.Cells[0].Value.ToString()));
                    ClearInsuranceList();
                    string tbl = tblCurrent;
                    string sqlStr = "SELECT * FROM " + tbl;

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

                        bool isDeleted = false;

                        dt = ds.Tables[tbl];

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dr = dt.Rows[i];

                            if (isDeleted)
                            {
                                dr.BeginEdit();
                                dr["id"] = i + 1;
                                dr.EndEdit();

                                oda.UpdateCommand = ocb.GetUpdateCommand();

                                if (oda.Update(ds, tbl) == 1)
                                    ds.AcceptChanges();
                                else
                                    ds.RejectChanges();
                            }
                            else if (Convert.ToInt32(dr["id"]) == wh)
                            {
                                dr.Delete();

                                oda.DeleteCommand = ocb.GetDeleteCommand();

                                if (oda.Update(ds, tbl) == 1)
                                    ds.AcceptChanges();
                                else
                                    ds.RejectChanges();

                                dt = ds.Tables[tbl];

                                isDeleted = true;
                                --i;
                            }
                        }

                        drr.Close();
                        drr.Dispose();
                        drr = null;

                        cnn.Close();

                        cmd.Dispose();
                        ds.Dispose();
                        oda.Dispose();
                        cnn.Dispose();

                        cmd = null;
                        ds = null;
                        oda = null;
                        cnn = null;

                        MessageBox.Show("رکورد مورد نظر با موفقيت حذف شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        sqlStr = null;
                        tbl = null;

                        RestoreInsuranceList();
                    }
                    break;
                default:
                    break;
            }
        }

        private void mItemProtect_Click(object sender, EventArgs e)
        {
            ClearInsuranceList();
            Protect();
            RestoreInsuranceList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string phrase = txtSearch.Text.Trim();
            if (phrase != string.Empty)
            {
                mItemReports.Enabled = false;
                DataTable dt = dtMaster.Clone();
                for (int i = 0; i < dtMaster.Rows.Count; i++)
                {
                    if (dtMaster.Rows[i][colSearch].ToString().Trim().IndexOf(phrase) > -1)
                    {
                        object[] row = dtMaster.Rows[i].ItemArray;
                        dt.Rows.Add(row);
                    }
                }
                dgvMaster.DataSource = dt;
                dgvMaster.Sort(dgvMaster.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            }
            else
            {
                dgvMaster.DataSource = dtMaster;
                mItemReports.Enabled = true;
            }
        }

        private void mItemBackup_Click(object sender, EventArgs e)
        {
            if (tblCurrent != string.Empty)
                ClearInsuranceList();

            using (frmBackup frm = new frmBackup())
            {
                frm.ShowDialog();
            }

            if (tblCurrent != string.Empty)
                RestoreInsuranceList();
        }

        private void mItemReports_Click(object sender, EventArgs e)
        {
            /*using (frmReports dlg = new frmReports())
            {
                RestoreInsuranceList();
                dlg.dgv = dgvMaster;
                dlg.ShowDialog();
                RestoreInsuranceList();
            }*/
            using (frmReports2 dlg = new frmReports2())
            {
                RestoreInsuranceList();
                dlg.dgv = dgvMaster;
                dlg.ShowDialog();
                RestoreInsuranceList();
            }
        }

        private void mItemReportsFreeDate_Click(object sender, EventArgs e)
        {
            using (frmReports dlg = new frmReports())
            {
                RestoreInsuranceList();
                dlg.dgv = dgvMaster;
                dlg.ShowDialog();
                RestoreInsuranceList();
            }
        }

        private bool CleanTable(string tbl)
        {
            bool success = true;

            try
            {
                string sqlStr = "SELECT * FROM " + tbl;

                OleDbConnection cnn = new OleDbConnection(Base.dbCnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                oda.Fill(ds, tbl);
                dt = ds.Tables[tbl];

                foreach (DataRow dr in dt.Rows)
                    dr.Delete();

                oda.DeleteCommand = ocb.GetDeleteCommand();

                if (oda.Update(ds, tbl) == 1)
                    ds.AcceptChanges();
                else
                    ds.RejectChanges();

                cnn.Close();

                dt.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                dt = null;
                ds = null;
                ocb = null;
                oda = null;
                cnn = null;

                sqlStr = null;
            }
            catch
            {
                success = false;
            }
            finally
            {
            }

            return success;
        }

        private void CatchDocNameChanges(DataTable dtList)
        {
            try
            {
                string tbl = "DocNames";
                string sqlStr = "SELECT * FROM " + tbl;

                if (!CleanTable(tbl))
                {
                    MessageBox.Show("خطا در ذخیره لیست اسامی", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                DataRow drList;

                OleDbConnection cnn = new OleDbConnection(Base.dbCnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                oda.Fill(ds, tbl);
                dt = ds.Tables[tbl];

                if (dtList.Rows.Count > 0)
                {
                    for (int i = 0; i < dtList.Rows.Count; i++)
                    {
                        dr = dt.NewRow();
                        drList = dtList.Rows[i];

                        dr["docname"] = drList[0].ToString().Trim();

                        dt.Rows.Add(dr);

                        oda.InsertCommand = ocb.GetInsertCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                        }
                        else
                        {
                            ds.RejectChanges();
                            MessageBox.Show("خطا در ذخیره لیست اسامی", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                }

                MessageBox.Show("لیست اسامی با موقیت ذخیره شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                docList = dtList;

                cnn.Close();

                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                dr = null;
                dt = null;
                ds = null;
                ocb = null;
                oda = null;
                cnn = null;

                tbl = null;
                sqlStr = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
            }
        }


        private void CatchTrAreaChanges(DataTable dtList)
        {
            try
            {
                string tbl = "TreatmentArea";
                string sqlStr = "SELECT * FROM " + tbl;

                if (!CleanTable(tbl))
                {
                    MessageBox.Show("خطا در ذخیره لیست نواحی درمان", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                DataRow drList;

                OleDbConnection cnn = new OleDbConnection(Base.dbCnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                oda.Fill(ds, tbl);
                dt = ds.Tables[tbl];

                if (dtList.Rows.Count > 0)
                {
                    for (int i = 0; i < dtList.Rows.Count; i++)
                    {
                        dr = dt.NewRow();
                        drList = dtList.Rows[i];

                        dr["treatmentarea"] = drList[0].ToString().Trim();

                        dt.Rows.Add(dr);

                        oda.InsertCommand = ocb.GetInsertCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                        }
                        else
                        {
                            ds.RejectChanges();
                            MessageBox.Show("خطا در ذخیره لیست نواحی درمان", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                }

                MessageBox.Show("لیست نواحی درمان با موقیت ذخیره شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                trArea = dtList;

                cnn.Close();

                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                dr = null;
                dt = null;
                ds = null;
                ocb = null;
                oda = null;
                cnn = null;

                tbl = null;
                sqlStr = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
            }
        }

        private void mItemDefDocName_Click(object sender, EventArgs e)
        {
            using (frmDefDocName frm = new frmDefDocName())
            {
                frm.docList = docList.Copy();
                frm.ShowDialog(this);

                if (frm.hasChanged)
                {
                    CatchDocNameChanges(frm.docList);
                }
            }
        }

        private void mItemDefTreatmentArea_Click(object sender, EventArgs e)
        {
            using (frmDefTreatmentArea frm = new frmDefTreatmentArea())
            {
                frm.trArea = trArea.Copy();
                frm.ShowDialog(this);

                if (frm.hasChanged)
                {
                    CatchTrAreaChanges(frm.trArea);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_haveNewRow)
            {
                dgvMaster.FirstDisplayedScrollingRowIndex = dgvMaster.NewRowIndex - 1;
                dgvMaster.Refresh();
                dgvMaster.CurrentCell = dgvMaster.Rows[dgvMaster.NewRowIndex - 1].Cells[1];
                dgvMaster.Rows[dgvMaster.NewRowIndex - 1].Selected = true;
                _haveNewRow = false;
            }
        }

        private void mItemInsurancePrintInfoTe_Click(object sender, EventArgs e)
        {
            using (frmInsurancePrintInfo frm = new frmInsurancePrintInfo())
            {
                frm.tbl = "PrintInfo_TE";
                frm.ShowDialog(this);
            }
        }

        private void mItemInsurancePrintInfoKDNMJA_Click(object sender, EventArgs e)
        {
            using (frmInsurancePrintInfo frm = new frmInsurancePrintInfo())
            {
                frm.tbl = "PrintInfo_KDNMJA";
                frm.ShowDialog(this);
            }
        }

        private void mItemInsurancePrintInfoKD_Click(object sender, EventArgs e)
        {
            using (frmInsurancePrintInfo frm = new frmInsurancePrintInfo())
            {
                frm.tbl = "PrintInfo_KD";
                frm.ShowDialog(this);
            }
        }
    }
}
