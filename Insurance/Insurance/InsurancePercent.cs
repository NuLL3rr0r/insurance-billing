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
    public partial class frmInsurancePercent : Form
    {
        public frmInsurancePercent()
        {
            InitializeComponent();
        }

        private void frmInsurancePercent_Load(object sender, EventArgs e)
        {
            numTaminEjtemaei.Value = Base.PercentTE;
            numKhadamaatDarmaaniNMJA.Value = Base.PercentKDNMJA;
            numKhadamaatDarmaani.Value = Base.PercentKD;
        }


        private void frmInsurancePercent_Shown(object sender, EventArgs e)
        {
            this.Activate();
            numTaminEjtemaei.Focus();
            numTaminEjtemaei.Select(0, numTaminEjtemaei.ToString().Length);
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
            if (SetPercent())
            {
                MessageBox.Show("درصدها با موفقيت تعیین شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                CloseDialog();
            }
        }

        public bool SetPercent()
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

                dt = ds.Tables[tbl];
                dr = dt.Rows[0];
                dr.BeginEdit();
                dr["PercentTE"] = numTaminEjtemaei.Value;
                dr["PercentKDNMJA"] = numKhadamaatDarmaaniNMJA.Value;
                dr["PercentKD"] = numKhadamaatDarmaani.Value;
                dr.EndEdit();

                oda.UpdateCommand = ocb.GetUpdateCommand();

                if (oda.Update(ds, tbl) == 1)
                {
                    ds.AcceptChanges();
                    Base.PercentTE = (byte)numTaminEjtemaei.Value;
                    Base.PercentKDNMJA = (byte)numKhadamaatDarmaaniNMJA.Value;
                    Base.PercentKD = (byte)numKhadamaatDarmaani.Value;
                }
                else
                    ds.RejectChanges();

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

        private void numTaminEjtemaei_Enter(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            nud.Select(0, nud.ToString().Length);
        }
    }
}
