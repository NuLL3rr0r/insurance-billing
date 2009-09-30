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
    public partial class frmInsuranceTE : Form
    {
        PersianKeyboard kb = new PersianKeyboard();

        private int _totalCost = 0;
        private int _sessionQTY = 0;
        private string _date = string.Empty;
        private string _dateChars = string.Empty;
        
        bool _editMode = false;

        public int id
        {
            set
            {
                txtID.Text = Base.FormatNumsToPersian(value.ToString());
            }
        }

        public DataGridViewCellCollection row
        {
            set
            {
                txtID.Text = value[0].Value.ToString().Trim();
                txtPatientName.Text = value[1].Value.ToString().Trim();
                txtBookletCode.Text = value[2].Value.ToString().Trim();
//                txtTreatmentCode.Text = value[3].Value.ToString().Trim();
                txtSessionQTY.Text = value[3].Value.ToString().Trim();
                cmbTreatmentArea.Text = value[4].Value.ToString().Trim();
                
                //txtDate.Text = value[5].Value.ToString().Trim();
                SetDateFields(value[5].Value.ToString().Trim());

                cmbDoctorName.Text = value[6].Value.ToString().Trim();
                txtTotalCost.Text = value[7].Value.ToString().Trim();
//                txtPatientShare.Text = value[9].Value.ToString().Trim();
                txtOrgShare.Text = Base.FormatNumsToPersian(value[8].Value.ToString().Trim());
                _editMode = true;
            }
        }

        private DataTable _docList = new DataTable();
        public DataTable docList
        {
            set
            {
                _docList = value;
            }
        }

        private DataTable _trArea = new DataTable();
        public DataTable trArea
        {
            set
            {
                _trArea = value;
            }
        }

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

        public frmInsuranceTE()
        {
            InitializeComponent();

            kb.usePersianNums = true;


            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            DateTime now = DateTime.Now;
            int minYear = 1388, maxYear = pc.GetYear(now);

            for (int i = minYear; i <= maxYear; ++i)
            {
                cmbDateYear.Items.Add(Base.FormatNumsToPersian(i.ToString()));
            }
            for (int i = 1; i <= 12; ++i)
            {
                cmbDateMonth.Items.Add((i < 10 ? Base.FormatNumsToPersian("0") : string.Empty) + Base.FormatNumsToPersian(i.ToString()));
            }
            for (int i = 1; i <= 31; ++i)
            {
                cmbDateDay.Items.Add((i < 10 ? Base.FormatNumsToPersian("0") : string.Empty) + Base.FormatNumsToPersian(i.ToString()));
            }
        }

        private void txtPersian_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            kb.shiftPressed = e.Shift;
        }

        private void txtPersian_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                kb.TransformInputChar((TextBox)sender, e);
            }
            catch
            {
                kb.TransformInputChar((ComboBox)sender, e);
            }
        }

        private void CloseDialog()
        {
            this.Close();
            this.Dispose();
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            try
            {
                ((TextBox)sender).SelectAll();
            }
            catch
            {
                ((ComboBox)sender).SelectAll();
            }
        }

/*        private void numSessionQTY_Enter(object sender, EventArgs e)
        {
            NumericUpDown obj = (NumericUpDown)sender;
            obj.Select(0, obj.Value.ToString().Length);
        }*/

        private void frmInsuranceTE_Shown(object sender, EventArgs e)
        {
            this.Activate();
            txtPatientName.Focus();
        }

        private void SetDateCMBItem(ComboBox cmb, string item)
        {
            for (int i = 0; i < cmb.Items.Count; ++i)
            {
                if (cmb.Items[i].ToString() == item)
                {
                    cmb.SelectedIndex = i;
                    break;
                }
            }
        }

        private void SetDateFields(string date)
        {
            SetDateCMBItem(cmbDateYear, date.Substring(0, 4));
            SetDateCMBItem(cmbDateMonth, date.Substring(5, 2));
            SetDateCMBItem(cmbDateDay, date.Substring(8, 2));
        }

        private string GetDateFields()
        {
            return string.Format("{0}/{1}/{2}", cmbDateYear.Text, cmbDateMonth.Text, cmbDateDay.Text);
        }

        private void InitializeCustomInputs()
        {
            //txtDate.Text = Base.GetPersianDate();
            SetDateFields(Base.GetPersianDate());

            HandleTyping(txtTotalCost);
            //HandleTyping(txtSessionQTY);
            HandleTyping(txtSessionQTY, "10");
        }

        private void frmInsuranceTE_Load(object sender, EventArgs e)
        {
            if (!_editMode)
            {
                InitializeCustomInputs();
            }
            else
            {
                this.Text = "ویرایش رکورد";
                btnInsertEdit.Text = "ویرایش";
            }

            for (int i = 0; i < _docList.Rows.Count; ++i)
            {
                cmbDoctorName.Items.Add(_docList.Rows[i][0].ToString());
            }
            for (int i = 0; i < _trArea.Rows.Count; ++i)
            {
                cmbTreatmentArea.Items.Add(_trArea.Rows[i][0].ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseDialog();
        }

        private void HandleTyping(TextBox textBox)
        {
            HandleTyping(textBox, textBox.Text.Trim());
        }

        private void HandleTyping(TextBox textBox, int val)
        {
            HandleTyping(textBox, val.ToString());
        }

        private void HandleTyping(TextBox textBox, string str)
        {
            textBox.Text = Base.FormatNumsToPersian(str.Trim());
            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
            textBox.Refresh();
        }

        private void txtNum_Leave(object sender, EventArgs e)
        {
            HandleTyping((TextBox)sender);
        }
        
        private void txtSessionQTY_TextChanged(object sender, EventArgs e)
        {
            TextBox obj = (TextBox)sender;
            HandleTyping(obj);

            try
            {
                if (obj.Text != string.Empty)
                {
                    byte val;
                    if (byte.TryParse(Base.FormatNumsToEnglish(obj.Text), out val))
                    {
                        obj.Text = Base.FormatNumsToPersian(val.ToString());
                        _sessionQTY = val;
                    }
                    else
                    {
                        HandleTyping(obj, _sessionQTY);
                    }
                }
                else
                    HandleTyping(obj, "0");
            }
            catch
            {
                HandleTyping(obj, _sessionQTY);
            }
            finally
            {
            }
        }

        private void txtTotalCost_TextChanged(object sender, EventArgs e)
        {
            TextBox obj = (TextBox)sender;
            HandleTyping(obj);

            try
            {
                if (obj.Text != string.Empty)
                {
                    int val;
                    if (int.TryParse(Base.FormatNumsToEnglish(obj.Text), out val))
                    {
                        /*if (val > Base.maxInt32Bound)
                            val = Base.maxInt32Bound;*/

                        obj.Text = Base.FormatNumsToPersian(val.ToString());
                        //txtPatientShare.Text = Base.FormatNumsToPersian(((int)Math.Round((val * ((100 - Base.PercentTE) / 100.0)))).ToString());
                        txtOrgShare.Text = Base.FormatNumsToPersian(((int)Math.Round((val * (Base.PercentTE / 100.0)))).ToString());
                        _totalCost = val;
                    }
                    else
                    {
                        HandleTyping(obj, _totalCost);
                    }
                }
                else
                    HandleTyping(obj, "0");
            }
            catch
            {
                HandleTyping(obj, _totalCost);
            }
            finally
            {
            }
        }

        /*private void txtDate_Leave(object sender, EventArgs e)
        {
            TextBox obj = (TextBox)sender;
            if (!Base.IsValidDate(obj.Text))
                obj.Text = _date;
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            TextBox obj = (TextBox)sender;

            if (obj.Text.Length > 10)
            {
                obj.Text = _date;
                return;
            }

            if (_date != obj.Text)
            {
                if (Base.IsValidDate(Base.FormatNumsToEnglish(obj.Text)))
                {
                    if (Base.IsDateChars(Base.FormatNumsToEnglish(obj.Text)))
                        _date = obj.Text;
                    else
                        obj.Text = _dateChars;
                }
                else
                {
                    if (Base.IsDateChars(Base.FormatNumsToEnglish(obj.Text)))
                    {
                        _dateChars = obj.Text;
                        if (_dateChars.Length == 10)
                            _date = _dateChars;
                    }
                    else
                    {
                        HandleTyping(obj, _dateChars);
                    }
                }
            }
        }*/

        private void AddRecord()
        {
            string tbl = "Tamin_e_Ejtemaei";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.dbCnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
                cnn.Open();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];
                dr = dt.NewRow();
                dr["id"] = Base.FormatNumsToEnglish(txtID.Text);
                dr["PatientName"] = txtPatientName.Text.Trim();
                dr["BookletCode"] = txtBookletCode.Text.Trim();
                //dr["TreatmentCode"] = txtTreatmentCode.Text.Trim();
                dr["SessionQTY"] = Base.FormatNumsToEnglish(txtSessionQTY.Text.Trim());
                dr["TreatmentArea"] = cmbTreatmentArea.Text.Trim();
                //dr["Date"] = Base.FormatNumsToEnglish(txtDate.Text.Trim());
                dr["Date"] = GetDateFields();
                dr["DoctorName"] = cmbDoctorName.Text.Trim();
                dr["TotalCost"] = Base.FormatNumsToEnglish(txtTotalCost.Text.Trim());
                //dr["PatientShare"] = Base.FormatNumsToEnglish(txtPatientShare.Text.Trim());
                dr["OrgShare"] = Base.FormatNumsToEnglish(txtOrgShare.Text.Trim());
                dt.Rows.Add(dr);

                oda.InsertCommand = ocb.GetInsertCommand();

                if (oda.Update(ds, tbl) == 1)
                    ds.AcceptChanges();
                else
                    ds.RejectChanges();

                //MessageBox.Show("اطلاعات جديد با موفقيت اضافه شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Text = Base.FormatNumsToPersian((Convert.ToInt32(Base.FormatNumsToEnglish(txtID.Text)) + 1).ToString());
                txtPatientName.Clear();
                txtBookletCode.Clear();
                //txtTreatmentCode.Clear();
                txtSessionQTY.Text = Base.FormatNumsToPersian("10");
                cmbTreatmentArea.Text = string.Empty;
                //txtDate.Clear();
                SetDateFields(Base.GetPersianDate());
                cmbDoctorName.Text = string.Empty;
                txtTotalCost.Text = Base.FormatNumsToPersian("0");
                //txtPatientShare.Text = Base.FormatNumsToPersian("0");
                txtOrgShare.Text = Base.FormatNumsToPersian("0");
                txtPatientName.Focus();

                ((DataTable)dgv.DataSource).Rows.Add(dr.ItemArray);
                ((DataTable)dgv.DataSource).AcceptChanges();

                InitializeCustomInputs();

                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cnn = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlStr = null;
                tbl = null;
            }
        }

        private void EditRecord()
        {
            DialogResult result = MessageBox.Show("آيا مايل به ويرايش اطلاعات مورد نظر مي باشيد", Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            switch (result)
            {
                case DialogResult.OK:
                    string tbl = "Tamin_e_Ejtemaei";
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

                        int id = -1;

                        while (drr.Read())
                        {
                            ++id;
                            if (drr["id"].ToString().Trim() == Base.FormatNumsToEnglish(txtID.Text))
                            {
                                dt = ds.Tables[tbl];
                                dr = dt.Rows[id];
                                dr.BeginEdit();
                                dr["PatientName"] = txtPatientName.Text.Trim();
                                dr["BookletCode"] = txtBookletCode.Text.Trim();
                                //dr["TreatmentCode"] = txtTreatmentCode.Text.Trim();
                                dr["SessionQTY"] = Base.FormatNumsToEnglish(txtSessionQTY.Text.Trim());
                                dr["TreatmentArea"] = cmbTreatmentArea.Text.Trim();
                                //dr["Date"] = Base.FormatNumsToEnglish(txtDate.Text.Trim());
                                dr["Date"] = Base.FormatNumsToEnglish(GetDateFields());
                                dr["DoctorName"] = cmbDoctorName.Text.Trim();
                                dr["TotalCost"] = Base.FormatNumsToEnglish(txtTotalCost.Text.Trim());
                                //dr["PatientShare"] = Base.FormatNumsToEnglish(txtPatientShare.Text.Trim());
                                dr["OrgShare"] = Base.FormatNumsToEnglish(txtOrgShare.Text.Trim());
                                dr.EndEdit();

                                oda.UpdateCommand = ocb.GetUpdateCommand();

                                if (oda.Update(ds, tbl) == 1)
                                    ds.AcceptChanges();
                                else
                                    ds.RejectChanges();

                                break;
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

                        MessageBox.Show("اطلاعات مورد نظر با موفقيت ويرايش شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        sqlStr = null;
                        tbl = null;
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnInsertEdit_Click(object sender, EventArgs e)
        {
            if (!_editMode)
            {
                AddRecord();
                frmMain.haveNewRow = true;
            }
            else
            {
                EditRecord();
                CloseDialog();
            }
        }
    }
}
