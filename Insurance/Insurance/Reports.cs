using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Insurance
{
    public partial class frmReports : Form
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

/*                if (dgv.Rows.Count > 1)
                {
                    numFromID.Minimum = 1;
                    numFromID.Maximum = _dgv.Rows.Count - 1;
                    numToID.Minimum = 1;
                    numToID.Maximum = _dgv.Rows.Count - 1;
                    numToID.Value = numToID.Maximum;
                }
                else
                {
                    numFromID.Minimum = 0;
                    numFromID.Maximum = 0;
                    numToID.Minimum = 0;
                    numToID.Maximum = 0;
                    rdbByID.Enabled = false;
                }*/

/*                int minYear = 1388, maxYear = minYear;

                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    if (Convert.ToInt32(Base.FormatNumsToEnglish(dt.Rows[i][col].ToString())) > maxYear)
                    {
                        maxYear = Convert.ToInt32(Base.FormatNumsToEnglish(dt.Rows[i][col].ToString()));
                    }
                }*/

                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                DateTime now = DateTime.Now;


                //int minYear = 1388, maxYear = Convert.ToInt32(Base.FormatNumsToEnglish(Base.GetPersianDate().Substring(0, 4)));
                int minYear = 1388, maxYear = pc.GetYear(now);

                for (int i = minYear; i <= maxYear; ++i)
                {
                    cmbFromYear.Items.Add(Base.FormatNumsToPersian(i.ToString()));
                    cmbToYear.Items.Add(Base.FormatNumsToPersian(i.ToString()));
                }
                cmbFromYear.SelectedIndex = cmbFromYear.Items.Count - 1;
                cmbToYear.SelectedIndex = cmbToYear.Items.Count - 1;

                for (int i = 1; i <= 12; ++i)
                {
                    cmbFromMonth.Items.Add(Base.FormatNumsToPersian(i < 10 ? "0" + i.ToString() : i.ToString()));
                    cmbToMonth.Items.Add(Base.FormatNumsToPersian(i < 10 ? "0" + i.ToString() : i.ToString()));
                }
                //cmbFromMonth.SelectedIndex = Convert.ToInt32(Base.FormatNumsToEnglish(Base.GetPersianDate().Substring(5, 2))) - 1;
                cmbFromMonth.SelectedIndex = pc.GetMonth(now) - 1;
                cmbToMonth.SelectedIndex = cmbFromMonth.SelectedIndex;

                for (int i = 1; i <= 31; ++i)
                {
                    cmbFromDay.Items.Add(Base.FormatNumsToPersian(i < 10 ? "0" + i.ToString() : i.ToString()));
                    cmbToDay.Items.Add(Base.FormatNumsToPersian(i < 10 ? "0" + i.ToString() : i.ToString()));
                }
                cmbFromDay.SelectedIndex = 0;
                //cmbToDay.SelectedIndex = 30;
                cmbToDay.SelectedIndex = pc.GetDaysInMonth(pc.GetYear(now), pc.GetMonth(now)) - 1;
            }
        }

        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            /*
            if (dgv.Rows.Count > 1)
                ChangeReportType(true);
            else
            {
                //rdbByDate.Enabled = false;
                //rdbByID.Enabled = false;
                btnReport.Enabled = false;
            }*/
            if (dgv.Rows.Count <= 1)
            {
                btnReport.Enabled = false;
            }
        }

        private void frmReports_Shown(object sender, EventArgs e)
        {
            this.Activate();
            cmbFromYear.Focus();
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

        /*private void ChangeReportType(bool flag)
        {
            numFromID.Enabled = !flag;
            numToID.Enabled = !flag;
            cmbFromYear.Enabled = flag;
            cmbFromMonth.Enabled = flag;
            cmbFromDay.Enabled = flag;
            cmbToYear.Enabled = flag;
            cmbToMonth.Enabled = flag;
            cmbToDay.Enabled = flag;
        }*/

        /*private void rdbByDate_CheckedChanged(object sender, EventArgs e)
        {
            switch (((RadioButton)sender).Name)
            {
                case "rdbByDate":
                    ChangeReportType(true);
                    break;
                case "rdbByID":
                    ChangeReportType(false);
                    break;
                default:
                    break;
            }
        }*/

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgv.DataSource;

                /*if (rdbByID.Checked)
                {
                    for (int i = 0; i < numFromID.Value - 1; ++i)
                    {
                        dt.Rows[i].Delete();
                    }

                    for (int i = dt.Rows.Count - 1; i >= numToID.Value; --i)
                    {
                        dt.Rows[i].Delete();
                    }
                }
                else
                {*/
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

                    for (int i = 0; i < dt.Rows.Count; ++i)
                    {
                        string date = Base.FormatNumsToEnglish(dt.Rows[i][col].ToString());

                        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                        try
                        {

                            DateTime from = pc.ToDateTime(Convert.ToInt32(Base.FormatNumsToEnglish(cmbFromYear.Text)), Convert.ToInt32(Base.FormatNumsToEnglish(cmbFromMonth.Text)), Convert.ToInt32(Base.FormatNumsToEnglish(cmbFromDay.Text)), 0, 0, 0, 0);
                            DateTime cur = pc.ToDateTime(Convert.ToInt32(date.Substring(0, 4)), Convert.ToInt32(date.Substring(5, 2)), Convert.ToInt32(date.Substring(8, 2)), 0, 0, 0, 0);
                            DateTime to = pc.ToDateTime(Convert.ToInt32(Base.FormatNumsToEnglish(cmbToYear.Text)), Convert.ToInt32(Base.FormatNumsToEnglish(cmbToMonth.Text)), Convert.ToInt32(Base.FormatNumsToEnglish(cmbToDay.Text)), 0, 0, 0, 0);

                            if (!(from <= cur && cur <= to))
                                dt.Rows[i].Delete();
                        }
                        catch
                        {
                            dt.Rows[i].Delete();
                        }
                    }
                /*}*/

                dt.AcceptChanges();
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    dt.Rows[i][0] = i + 1;
                }
                dt.AcceptChanges();

                dgv.Font = new System.Drawing.Font("B Traffic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                dgv.Sort(dgv.Columns[col], System.ComponentModel.ListSortDirection.Ascending);
                for (int i = 0; i < dgv.Rows.Count - 1; ++i)
                {
                    string val = (i + 1).ToString();
                    for (int j = val.Length; j < dgv.Rows.Count.ToString().Length; ++j)
                        val = "0" + val;
                    dgv.Rows[i].Cells[0].Value = val;
                }
                for (int i = 1; i < dgv.Columns.Count; i++)
                    dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                string[] months = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

                PrintDGV.rptYear = cmbToYear.Text;
                PrintDGV.rptMonth = months[cmbToMonth.SelectedIndex];

                PrintDGV.Print_DataGridView(dgv);
                CloseDialog();

                dgv.Font = new System.Drawing.Font("B Traffic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                for (int i = 1; i < dgv.Columns.Count; i++)
                    dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        /*private void numFromID_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown obj = (NumericUpDown)sender;
            if (numFromID.Value > numToID.Value && obj.Name == "numFromID")
                numToID.Value = numFromID.Value;
            else if (numToID.Value < numFromID.Value && obj.Name == "numToID")
                numFromID.Value = numToID.Value;
        }*/
    }
}
