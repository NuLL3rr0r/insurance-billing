using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Insurance
{
    public partial class frmReportsPre : Form
    {
        private DataGridView _dgv = new DataGridView();
        public DataGridView dgv
        {
            get
            {
                return _dgv;
            }
            set
            {
                _dgv = value;
            }
        }

        public frmReportsPre()
        {
            InitializeComponent();
        }

        private void frmReportsPre_Load(object sender, EventArgs e)
        {
            dgvMain.DataSource = ((DataTable)dgv.DataSource);
            dgvMain.ReadOnly = false;
            for (int i = 1; i < dgvMain.Columns.Count - 1; i++)
                dgvMain.Columns[i].ReadOnly = true;
            dgvMain.Columns[dgvMain.Columns.Count - 1].ReadOnly = false;
            dgvMain.AllowUserToAddRows = false;
            dgvMain.AllowUserToDeleteRows = false;
            for (int i = 1; i < dgvMain.Columns.Count; i++)
                dgvMain.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgvMain_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //needed for bug discovered by myself // it dosn't accept the last change in grid (last column)
            if (dgvMain.CurrentCell.ColumnIndex == dgvMain.Columns.Count - 1)
            {
                dgvMain.CurrentCell.Value = !Convert.ToBoolean(dgvMain.CurrentCell.Value);
                dgvMain.Update();
                dgvMain.Refresh();
            }
        }
    }
}
