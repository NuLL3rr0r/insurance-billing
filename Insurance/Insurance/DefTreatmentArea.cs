using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Insurance
{
    public partial class frmDefTreatmentArea : Form
    {
        private string tblName = "TreatmentArea";

        private bool goForChange = false;
        private DataTable _trArea = new DataTable();
        private bool _retryMode = false;

        public DataTable trArea
        {
            get
            {
                return _trArea;
            }
            set
            {
                _trArea = value;
                _trArea.AcceptChanges();
            }
        }

        public frmDefTreatmentArea()
        {
            InitializeComponent();
        }

        public bool hasChanged
        {
            get
            {
                return btnOK.Enabled;
            }
            set
            {
                btnOK.Enabled = value;
            }
        }

        public bool retryMode
        {
            get
            {
                return _retryMode;
            }
            set
            {
                _retryMode = value;
            }
        }

        private void doReturn()
        {
            this.Close();
        }

        private void frmDefTreatmentArea_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnOK.Enabled)
            {
                if (!goForChange)
                {
                    if (MessageBox.Show("تغييرات ذخيره نشده است، آيا مايل به لغو تغييرات و بازگشت به صفحه ي اصلي مي باشيد؟", Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                    {
                        dgvTreatmentArea.Focus();
                        e.Cancel = true;
                    }
                    else
                        btnOK.Enabled = false;
                }
            }
        }

        private void frmDefTreatmentArea_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = _trArea;
            dt.Columns[0].ColumnName = "ناحیه درمان";

            dgvTreatmentArea.DataSource = dt;
            dgvTreatmentArea.Sort(dgvTreatmentArea.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

            dgvTreatmentArea.Columns[0].Width = 225;

            if (!_retryMode)
                btnOK.Enabled = false;
            else
                btnOK.Enabled = true;
        }

        private void frmDefTreatmentArea_Shown(object sender, EventArgs e)
        {
            this.Activate();
            dgvTreatmentArea.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            doReturn();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int len = dgvTreatmentArea.Rows.Count - 1;

            //trim spaces
            for (int i = 0; i < len; i++)
            {
                string doc = dgvTreatmentArea.Rows[i].Cells[0].Value.ToString().Trim();
                dgvTreatmentArea.Rows[i].Cells[0].Value = doc;
            }

            bool hasDuplicate = false;
            bool isZeroFillDoc = false;

            string ZeroFillDoc = string.Empty;

            for (int i = 0; i < len; i++)
            {
                string cDoc = dgvTreatmentArea.Rows[i].Cells[0].Value.ToString().Trim();
                string nDoc;

                if (i != len - 1)
                {
                    nDoc = dgvTreatmentArea.Rows[i + 1].Cells[0].Value.ToString().Trim();

                    if (cDoc == nDoc)
                    {
                        hasDuplicate = true;
                        break;
                    }
                }

                if (cDoc == string.Empty)
                {
                    isZeroFillDoc = true;
                    break;
                }
            }

            if (!hasDuplicate && !isZeroFillDoc)
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("treatmentarea");

                dt.TableName = tblName;

                DataRow dr;

                for (int i = 0; i < len; i++)
                {
                    string TreatmentArea = dgvTreatmentArea.Rows[i].Cells[0].Value.ToString().Trim();

                    dr = dt.NewRow();

                    dr[0] = TreatmentArea;

                    dt.Rows.Add(dr);
                }

                dt.AcceptChanges();

                _trArea = dt;
                _trArea.AcceptChanges();

                goForChange = true;
                doReturn();
            }
            else if (hasDuplicate)
                MessageBox.Show("در ليست نام تكراري وجود دارد؛ امكان درج وجود ندارد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            else if (isZeroFillDoc)
                MessageBox.Show("خطا!! امکان درج نام خالی وجود ندارد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void dgvTreatmentArea_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void dgvTreatmentArea_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            btnOK.Enabled = true;
        }
    }
}
