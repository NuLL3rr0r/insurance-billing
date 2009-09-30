using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Insurance
{
    public partial class frmDefDocName : Form
    {
        private string tblName = "DocNames";

        private bool goForChange = false;
        private DataTable _docList = new DataTable();
        private bool _retryMode = false;

        public DataTable docList
        {
            get
            {
                return _docList;
            }
            set
            {
                _docList = value;
                _docList.AcceptChanges();
            }
        }

        public frmDefDocName()
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

        private void frmDefDocName_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnOK.Enabled)
            {
                if (!goForChange)
                {
                    if (MessageBox.Show("تغييرات ذخيره نشده است، آيا مايل به لغو تغييرات و بازگشت به صفحه ي اصلي مي باشيد؟", Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                    {
                        dgvDocName.Focus();
                        e.Cancel = true;
                    }
                    else
                        btnOK.Enabled = false;
                }
            }
        }

        private void frmDefDocName_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = _docList;
            dt.Columns[0].ColumnName = "نام پزشک";

            dgvDocName.DataSource = dt;
            dgvDocName.Sort(dgvDocName.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

            dgvDocName.Columns[0].Width = 225;

            if (!_retryMode)
                btnOK.Enabled = false;
            else
                btnOK.Enabled = true;
        }

        private void frmDefDocName_Shown(object sender, EventArgs e)
        {
            this.Activate();
            dgvDocName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            doReturn();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int len = dgvDocName.Rows.Count - 1;

            //trim spaces
            for (int i = 0; i < len; i++)
            {
                string doc = dgvDocName.Rows[i].Cells[0].Value.ToString().Trim();
                dgvDocName.Rows[i].Cells[0].Value = doc;
            }

            bool hasDuplicate = false;
            bool isZeroFillDoc = false;

            string ZeroFillDoc = string.Empty;

            for (int i = 0; i < len; i++)
            {
                string cDoc = dgvDocName.Rows[i].Cells[0].Value.ToString().Trim();
                string nDoc;

                if (i != len - 1)
                {
                    nDoc = dgvDocName.Rows[i + 1].Cells[0].Value.ToString().Trim();

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

                dt.Columns.Add("docname");

                dt.TableName = tblName;

                DataRow dr;

                for (int i = 0; i < len; i++)
                {
                    string docName = dgvDocName.Rows[i].Cells[0].Value.ToString().Trim();

                    dr = dt.NewRow();

                    dr[0] = docName;

                    dt.Rows.Add(dr);
                }

                dt.AcceptChanges();

                _docList = dt;
                _docList.AcceptChanges();

                goForChange = true;
                doReturn();
            }
            else if (hasDuplicate)
                MessageBox.Show("در ليست نام تكراري وجود دارد؛ امكان درج وجود ندارد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            else if (isZeroFillDoc)
                MessageBox.Show("خطا!! امکان درج نام خالی وجود ندارد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void dgvDocName_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void dgvDocName_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            btnOK.Enabled = true;
        }
    }
}
