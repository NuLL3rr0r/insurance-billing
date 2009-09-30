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
    public partial class frmInsurancePrintInfo : Form
    {
        private string _tbl = string.Empty;
        public string tbl
        {
            get
            {
                return _tbl;
            }
            set
            {
                _tbl = value;
            }
        }

        PersianKeyboard kb = new PersianKeyboard();

        public frmInsurancePrintInfo()
        {
            InitializeComponent();
        }
        /*private string crtClinicCodeTE = string.Empty;
        private string crtFounderTE = string.Empty;
        private string crtTechLiableTE = string.Empty;
        private string crtCityTE = string.Empty;
        private string crtTelTE = string.Empty;
        private string crtAddrTE = string.Empty;
        private string crtFinancialCodeTE = string.Empty;
        private string crtAccountCodeTE = string.Empty;
        private string crtBankTE = string.Empty;

        private string crtClinicCodeKDNMJA = string.Empty;
        private string crtFounderKDNMJA = string.Empty;
        private string crtTechLiableKDNMJA = string.Empty;
        private string crtCityKDNMJA = string.Empty;
        private string crtTelKDNMJA = string.Empty;
        private string crtAddrKDNMJA = string.Empty;
        private string crtFinancialCodeKDNMJA = string.Empty;
        private string crtAccountCodeKDNMJA = string.Empty;
        private string crtBankKDNMJA = string.Empty;

        private string crtClinicCodeKD = string.Empty;
        private string crtFounderKD = string.Empty;
        private string crtTechLiableKD = string.Empty;
        private string crtCityKD = string.Empty;
        private string crtTelKD = string.Empty;
        private string crtAddrKD = string.Empty;
        private string crtFinancialCodeKD = string.Empty;
        private string crtAccountCodeKD = string.Empty;
        private string crtBankKD = string.Empty;*/


        private void frmInsurancePrintInfo_Load(object sender, EventArgs e)
        {
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
                    txtClinicCode.Text = drr["crtClinicCode"].ToString();
                    txtFounder.Text = drr["crtFounder"].ToString();
                    txtTechLiable.Text = drr["crtTechLiable"].ToString();
                    txtCity.Text = drr["crtCity"].ToString();
                    txtTel.Text = drr["crtTel"].ToString();
                    txtAddr.Text = drr["crtAddr"].ToString();
                    txtFinancialCode.Text = drr["crtFinancialCode"].ToString();
                    txtAccountCode.Text = drr["crtAccountCode"].ToString();
                    txtBank.Text = drr["crtBank"].ToString();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                sqlStr = null;
            }
        }

        private void frmInsurancePrintInfo_Shown(object sender, EventArgs e)
        {
            this.Activate();
            txtClinicCode.Focus();
        }

        private void CloseDialog()
        {
            this.Close();
            this.Dispose();
        }

        private void frmInsurancePrintInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //CloseDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
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

                dt = ds.Tables[tbl];

                if (dt.Rows.Count == 0)
                    dr = dt.NewRow();
                else
                {
                    dr = dt.Rows[0];
                    dr.BeginEdit();
                }

                dr["crtClinicCode"] = txtClinicCode.Text.Trim();
                dr["crtFounder"] = txtFounder.Text.Trim();
                dr["crtTechLiable"] = txtTechLiable.Text.Trim();
                dr["crtCity"] = txtCity.Text.Trim();
                dr["crtTel"] = txtTel.Text.Trim();
                dr["crtAddr"] = txtAddr.Text.Trim();
                dr["crtFinancialCode"] = txtFinancialCode.Text.Trim();
                dr["crtAccountCode"] = txtAccountCode.Text.Trim();
                dr["crtBank"] = txtBank.Text.Trim();

                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add(dr);
                    oda.InsertCommand = ocb.GetInsertCommand();
                }
                else
                {
                    dr.EndEdit();
                    oda.UpdateCommand = ocb.GetUpdateCommand();
                }


                if (oda.Update(ds, tbl) == 1)
                {
                    ds.AcceptChanges();
                }
                else
                    ds.RejectChanges();

                drr.Close();
                drr.Dispose();
                drr = null;

                MessageBox.Show("اطلاعات با موفقيت تعیین شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                CloseDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseDialog();
        }

        private void txtClinicCode_Enter(object sender, EventArgs e)
        {
            try
            {
                ((TextBox)sender).SelectAll();
            }
            catch
            {
            }
        }

        private void txtClinicCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                kb.TransformInputChar((TextBox)sender, e);
            }
            catch
            {
            }
        }

        private void txtClinicCode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            kb.shiftPressed = e.Shift;
        }
    }
}
