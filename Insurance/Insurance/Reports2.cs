using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Insurance
{
    public partial class frmReports2 : Form
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

                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                DateTime now = DateTime.Now;

                int minYear = 1388, maxYear = pc.GetYear(now);

                for (int i = minYear; i <= maxYear; ++i)
                {
                    cmbYear.Items.Add(Base.FormatNumsToPersian(i.ToString()));
                }
                cmbYear.SelectedIndex = cmbYear.Items.Count - 1;

                for (int i = 1; i <= 12; ++i)
                {
                    cmbMonth.Items.Add(Base.FormatNumsToPersian(i < 10 ? "0" + i.ToString() : i.ToString()));
                }
                cmbMonth.SelectedIndex = pc.GetMonth(now) - 1;
            }
        }

        public frmReports2()
        {
            InitializeComponent();
        }

        private void frmReports2_Load(object sender, EventArgs e)
        {
            if (dgv.Rows.Count <= 1)
            {
                btnReport.Enabled = false;
            }
        }

        private void frmReports2_Shown(object sender, EventArgs e)
        {
            this.Activate();
            cmbMonth.Focus();
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

        private void btnReport_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgv.DataSource;

            byte col = 0;
            switch (dt.TableName)
            {
                case "Tamin_e_Ejtemaei":
                    col = 5;
                    break;
                case "Khadamaat_e_Darmaani_NMJA":
                    col = 4;
                    break;
                case "Khadamaat_e_Darmaani":
                    col = 5;
                    break;
                default:
                    break;
            }

            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            DateTime from = pc.ToDateTime(Convert.ToInt32(Base.FormatNumsToEnglish(cmbYear.Text)), Convert.ToInt32(Base.FormatNumsToEnglish(cmbMonth.Text)), 1, 0, 0, 0, 0);
            DateTime to =   pc.ToDateTime(Convert.ToInt32(Base.FormatNumsToEnglish(cmbYear.Text)), Convert.ToInt32(Base.FormatNumsToEnglish(cmbMonth.Text)), pc.GetDaysInMonth(Convert.ToInt32(Base.FormatNumsToEnglish(cmbYear.Text)), Convert.ToInt32(Base.FormatNumsToEnglish(cmbMonth.Text))), 0, 0, 0, 0);

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                string date = Base.FormatNumsToEnglish(dt.Rows[i][col].ToString());

                try
                {
                    DateTime cur = pc.ToDateTime(Convert.ToInt32(date.Substring(0, 4)), Convert.ToInt32(date.Substring(5, 2)), Convert.ToInt32(date.Substring(8, 2)), 0, 0, 0, 0);

                    if (!(from <= cur && cur <= to))
                        dt.Rows[i].Delete();
                }
                catch
                {
                    dt.Rows[i].Delete();
                }
            }

            dt.AcceptChanges();
            for (int i = 0; i < dt.Rows.Count; ++i)
                dt.Rows[i][0] = i + 1;
            dt.AcceptChanges();

            ((DataTable)dgv.DataSource).Columns.Add("چاپ", Type.GetType("System.Boolean"));

            for (int i = 0; i < dgv.Rows.Count - 1; ++i)
            {
                string val = (i + 1).ToString();
                for (int j = val.Length; j < dgv.Rows.Count.ToString().Length; ++j)
                    val = "0" + val;
                dgv.Rows[i].Cells[0].Value = Base.FormatNumsToPersian(val);
                dgv.Rows[i].Cells[dgv.Columns.Count - 1].Value = true;
            }


            frmReportsPre prv = new frmReportsPre();
            prv.dgv = dgv;
            prv.ShowDialog();
            dgv.DataSource = (DataTable)prv.dgv.DataSource;
            /*dt = (DataTable)prv.dgv.DataSource;

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                try
                {
                    if (Convert.ToBoolean(dt.Rows[i][dt.Columns.Count - 1]) == false)
                    {
                        dt.Rows[i].Delete();
                    }
                }
                catch
                {
                    dt.Rows[i].Delete();
                }
            }

            dt.AcceptChanges();
            for (int i = 0; i < dt.Rows.Count; ++i)
                dt.Rows[i][0] = i + 1;
            dt.AcceptChanges();
            */

            for (int i = 0; i < dgv.Rows.Count; ++i)
            {
                try
                {
                    if (Convert.ToBoolean(dgv.Rows[i].Cells[dgv.Columns.Count - 1].Value) == false)
                    {
                        dgv.Rows.RemoveAt(i);
                        i = i - 1;
                        continue;
                    }
                }
                catch
                {
                }
                finally
                {
                }
            }

            dgv.Columns.RemoveAt(dgv.Columns.Count - 1);

            for (int i = 0; i < dgv.Rows.Count - 1; ++i)
            {
                string val = (i + 1).ToString();
                for (int j = val.Length; j < dgv.Rows.Count.ToString().Length; ++j)
                    val = "0" + val;
                dgv.Rows[i].Cells[0].Value = Base.FormatNumsToPersian(val);
            }

            for (int i = 1; i < dgv.Columns.Count; i++)
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgv.Font = new System.Drawing.Font("B Traffic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dgv.Sort(dgv.Columns[col], System.ComponentModel.ListSortDirection.Ascending);

            string[] months = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

            PrintDGV.rptYear = cmbYear.Text;
            PrintDGV.rptMonth = months[cmbMonth.SelectedIndex];

            PrintDGV.Print_DataGridView(dgv);
            CloseDialog();

            dgv.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            for (int i = 1; i < dgv.Columns.Count; i++)
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
