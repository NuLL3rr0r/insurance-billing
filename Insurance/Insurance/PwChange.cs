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
    public partial class frmPwChange : Form
    {
        public frmPwChange()
        {
            InitializeComponent();
        }

        private void frmPwChange_Load(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
        }

        private void frmPwChange_Shown(object sender, EventArgs e)
        {
            this.Activate();
            txtCurrentPw.Focus();
        }

        private void txtConfirmPw_TextChanged(object sender, EventArgs e)
        {
            if (txtNewPw.Text != txtConfirmPw.Text || Base.pw != txtCurrentPw.Text || txtNewPw.Text == txtCurrentPw.Text)
                btnOK.Enabled = false;
            else
                btnOK.Enabled = true;
        }

        private void CloseDialog()
        {
            this.Close();
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtNewPw.Text == txtConfirmPw.Text)
            {
                if (Base.pw == txtCurrentPw.Text)
                {
                    if (SetPw(txtNewPw.Text))
                    {
                        MessageBox.Show("كلمه ي عبور جديد با موفقيت جايگزين شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        CloseDialog();
                    }
                }
                else
                {
                    MessageBox.Show("لطفا كلمه عبور فعلي را وارد نمائيد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    txtCurrentPw.Focus();
                    txtCurrentPw.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("لطفا كلمه ي عبور جديد را تائيد نمائيد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                txtConfirmPw.Focus();
                txtConfirmPw.SelectAll();
            }
        }

        public bool SetPw(string npw)
        {
            string tbl = "admin";
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

                while (drr.Read())
                {
                    dt = ds.Tables[tbl];
                    dr = dt.Rows[0];
                    dr.BeginEdit();
                    dr["pw"] = EncDec.Encrypt(npw, Base.dbHashKey);
                    dr.EndEdit();

                    oda.UpdateCommand = ocb.GetUpdateCommand();

                    if (oda.Update(ds, tbl) == 1)
                    {
                        ds.AcceptChanges();
                        Base.pw = npw;
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
    }
}
