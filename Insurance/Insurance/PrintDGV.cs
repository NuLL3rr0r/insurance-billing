using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Text;
using System.IO;
using System.Data.OleDb;

namespace Insurance
{
    class PrintDGV
    {
        private static int totalCosts = 0;
        private static int totalCostsTop = 0;
        private static int totalCostsWidth = 0;
        private static int allTotalCosts = 0;
        
        private static int allTotalCostsKD1 = 0;
        private static int allTotalCostsKD2 = 0;
        private static int allTotalCostsKD3 = 0;
        private static int allTotalCostsKD4 = 0;

        private static int sessionNumsKD1 = 0;
        private static int sessionNumsKD2 = 0;
        private static int sessionNumsKD3 = 0;
        private static int sessionNumsKD4 = 0;

        private static int pageNoKD = 0;
        private static double totalPagesKD = 0;
        private static double rowsPerPageKD = 29;

        //private static bool resetPageNum = true;

        //private static int sessionsNum = 0;
        private static bool writeAllTotalCostsPage = false;

        private static DataTable dtKhadamatDarmani = new DataTable();
        private static string boxTypeKD = string.Empty;
        //private static bool startNewBoxKD = false;

        public static List<string> GetSelectedColumns()
        {
            List<string> lst = new List<string>();

            string[] arr = { };
            switch (((DataTable)dgv.DataSource).TableName) {
                case "Tamin_e_Ejtemaei":
                    arr = frmMain.colsTE;
                    break;
                case "Khadamaat_e_Darmaani_NMJA":
                    arr = frmMain.colsKDNMJA;
                    break;
                case "Khadamaat_e_Darmaani":
                    arr = frmMain.colsKD;
                    arr[arr.Length - 1] = "مبلغ تعدیلات";
                    break;
                default:
                    break;
            }

            foreach (object item in arr)
            {
                lst.Add(item.ToString());
            }
            return lst;
        }

        private static string _rptMonth = string.Empty;
        public static string rptMonth
        {
            get
            {
                return _rptMonth;
            }
            set
            {
                _rptMonth = value;
            }
        }

        private static string _rptYear = string.Empty;
        public static string rptYear
        {
            get
            {
                return _rptYear;
            }
            set
            {
                _rptYear = value;
            }
        }

        private static string GetValueFromKey(string str, string key)
        {
            int start = str.IndexOf(key);
            start = str.IndexOf("{", start) + 1;
            int len = str.IndexOf("}", start) - start;

            return str.Substring(start, len);
        }

        private static string crtClinic = "**X DEMO X**";
        private static string crtClinicCode = string.Empty;
        private static string crtFounder = string.Empty;
        private static string crtTechLiable = string.Empty;
        private static string crtCity = string.Empty;
        private static string crtTel = string.Empty;
        private static string crtAddr = string.Empty;
        private static string crtFinancialCode = string.Empty;
        private static string crtAccountCode = string.Empty;
        private static string crtBank = string.Empty;

        private static bool ReadLicense()
        {
            try
            {
                string path = Environment.CurrentDirectory;
                if (!path.EndsWith(Base.backslash))
                    path += Base.backslash;
                string file = path + "license.crt";

                string result = string.Empty;

                using (StreamReader sr = new StreamReader(file))
                {
                    result = EncDec.Decrypt(sr.ReadToEnd(), "§");
                }

                crtClinic = GetValueFromKey(result, "Clinic");
                /*crtClinicCode = GetValueFromKey(result, "ClinicCode");
                crtFounder = GetValueFromKey(result, "Founder");
                crtTechLiable = GetValueFromKey(result, "TechLiable");
                crtCity = GetValueFromKey(result, "City");
                crtTel = GetValueFromKey(result, "Tel");
                crtAddr = GetValueFromKey(result, "Addr");
                crtFinancialCode = GetValueFromKey(result, "FinancialCode");
                crtAccountCode = GetValueFromKey(result, "AccountCode");
                crtBank = GetValueFromKey(result, "Bank");*/

                string tbl = string.Empty;
                switch (((DataTable)dgv.DataSource).TableName)
                {
                    case "Tamin_e_Ejtemaei":
                        tbl = "PrintInfo_TE";
                        break;
                    case "Khadamaat_e_Darmaani_NMJA":
                        tbl = "PrintInfo_KDNMJA";
                        break;
                    case "Khadamaat_e_Darmaani":
                        tbl = "PrintInfo_KD";
                        break;
                    default:
                        break;
                }

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
                        crtClinicCode = drr["crtClinicCode"].ToString();
                        crtFounder = drr["crtFounder"].ToString();
                        crtTechLiable = drr["crtTechLiable"].ToString();
                        crtCity = drr["crtCity"].ToString();
                        crtTel = drr["crtTel"].ToString();
                        crtAddr = drr["crtAddr"].ToString();
                        crtFinancialCode = drr["crtFinancialCode"].ToString();
                        crtAccountCode = drr["crtAccountCode"].ToString();
                        crtBank = drr["crtBank"].ToString();
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
                    return false;
                }
                finally
                {
                    sqlStr = null;
                }
            }
            catch
            {
                MessageBox.Show("Your license has problems!! Please contact your administrator.");
                crtClinic = "**X DEMO X**";
                return false;
            }

            return true;
        }

        private static void SetBoxType(string box)
        {
            DataTable dt = dtKhadamatDarmani.Clone();

            int col = dtKhadamatDarmani.Columns.Count - 1;
            DataRow dr;

            int id = -1;

            for (int i = 0; i < dtKhadamatDarmani.Rows.Count; ++i)
            {
                dr = dtKhadamatDarmani.Rows[i];
                if (dr[col].ToString() == box)
                {
                    dt.Rows.Add(dr.ItemArray);
                    dt.Rows[++id][0] = id + 1;
                }
            }

            dt.Columns.RemoveAt(col);
            dt.Columns.Add("مبلغ تعدیلات", Type.GetType("System.String"));

            dt.AcceptChanges();

            dgv.DataSource = dt;

            boxTypeKD = box;
            totalCostsWidth = 0;
            //startNewBoxKD = true;
            NewPage = true;
            RowPos = 0;

            //if (boxTypeKD == "کارکنان دولت")
                //resetPageNum = false;
        }

        private static StringFormat StrFormat;  // Holds content of a TextBox Cell to write by DrawString
        private static StringFormat StrFormatComboBox; // Holds content of a Boolean Cell to write by DrawImage
        private static Button CellButton;       // Holds the Contents of Button Cell
        private static CheckBox CellCheckBox;   // Holds the Contents of CheckBox Cell 
        private static ComboBox CellComboBox;   // Holds the Contents of ComboBox Cell

        private static int TotalWidth;          // Summation of Columns widths
        private static int RowPos;              // Position of currently printing row 
        private static bool NewPage;            // Indicates if a new page reached
        private static int PageNo;              // Number of pages to print
        private static ArrayList ColumnLefts = new ArrayList();  // Left Coordinate of Columns
        private static ArrayList ColumnWidths = new ArrayList(); // Width of Columns
        private static ArrayList ColumnTypes = new ArrayList();  // DataType of Columns
        private static int CellHeight;          // Height of DataGrid Cell
        private static int RowsPerPage;         // Number of Rows per Page
        private static System.Drawing.Printing.PrintDocument printDoc =
                       new System.Drawing.Printing.PrintDocument();  // PrintDocumnet Object used for printing

        private static string PrintTitle = "";  // Header of pages
        private static DataGridView dgv;        // Holds DataGridView Object to print its contents
        private static List<string> SelectedColumns = new List<string>();   // The Columns Selected by user to print.
        private static List<string> AvailableColumns = new List<string>();  // All Columns avaiable in DataGrid 
        private static bool PrintAllRows = true;   // True = print all rows,  False = print selected rows    
        private static bool FitToPageWidth = true; // True = Fits selected columns to page width ,  False = Print columns as showed    
        private static int HeaderHeight = 0;

        public static void Print_DataGridView(DataGridView dgv1)
        {
            //reinitialize everything

            writeAllTotalCostsPage = false;
            StrFormat = new StringFormat();  // Holds content of a TextBox Cell to write by DrawString
            StrFormatComboBox = new StringFormat(); // Holds content of a Boolean Cell to write by DrawImage
            CellButton = new Button();       // Holds the Contents of Button Cell
            CellCheckBox = new CheckBox();   // Holds the Contents of CheckBox Cell 
            CellComboBox = new ComboBox();   // Holds the Contents of ComboBox Cell

            TotalWidth = 0;          // Summation of Columns widths
            RowPos = 0;              // Position of currently printing row 
            NewPage = false;            // Indicates if a new page reached
            PageNo = 0;              // Number of pages to print
            ColumnLefts = new ArrayList();  // Left Coordinate of Columns
            ColumnWidths = new ArrayList(); // Width of Columns
            ColumnTypes = new ArrayList();  // DataType of Columns
            CellHeight = 0;          // Height of DataGrid Cell
            RowsPerPage = 0;         // Number of Rows per Page
            printDoc = new System.Drawing.Printing.PrintDocument();  // PrintDocumnet Object used for printing

            PrintTitle = "";  // Header of pages
            dgv = new DataGridView();        // Holds DataGridView Object to print its contents
            SelectedColumns = new List<string>();   // The Columns Selected by user to print.
            AvailableColumns = new List<string>();  // All Columns avaiable in DataGrid 
            PrintAllRows = true;   // True = print all rows,  False = print selected rows    
            FitToPageWidth = true; // True = Fits selected columns to page width ,  False = Print columns as showed    
            HeaderHeight = 0;

            /////////////////////////


            ///////////////
            totalCosts = 0;
            totalCostsTop = 0;
            totalCostsWidth = 0;
            allTotalCosts = 0;
            allTotalCostsKD1 = 0;
            allTotalCostsKD2 = 0;
            allTotalCostsKD3 = 0;
            allTotalCostsKD4 = 0;
            sessionNumsKD1 = 0;
            sessionNumsKD2 = 0;
            sessionNumsKD3 = 0;
            sessionNumsKD4 = 0;
            //sessionsNum = 0;
            pageNoKD = 0;
            totalPagesKD = 0;
            rowsPerPageKD = 29;
            //ReadLicense();
            ///////////////

            PrintPreviewDialog ppvw;
            try 
	        {	
                // Getting DataGridView object to print
                dgv = dgv1;
                ReadLicense();

                //////////
                switch (((DataTable)dgv.DataSource).TableName)
                {
                    case "Tamin_e_Ejtemaei":
                        break;
                    case "Khadamaat_e_Darmaani_NMJA":
                        break;
                    case "Khadamaat_e_Darmaani":
                        //totalPagesKD = ((DataTable)dgv.DataSource).Rows.Count;
                        dtKhadamatDarmani = ((DataTable)dgv.DataSource).Copy();


                        //////
                        double tpKD = 0;
                        totalPagesKD = 0;

                        SetBoxType("کارکنان دولت");
                        tpKD = Math.Ceiling((double)((((DataTable)dgv.DataSource).Rows.Count) / rowsPerPageKD));
                        if (tpKD == 0 && ((DataTable)dgv.DataSource).Rows.Count != 0)
                            totalPagesKD += 1;
                        else
                            totalPagesKD += tpKD;

                        SetBoxType("خویش فرمایان");
                        tpKD = Math.Ceiling((double)((((DataTable)dgv.DataSource).Rows.Count) / rowsPerPageKD));
                        if (tpKD == 0 && ((DataTable)dgv.DataSource).Rows.Count != 0)
                            totalPagesKD += 1;
                        else
                            totalPagesKD += tpKD;

                        SetBoxType("سایر اقشار");
                        tpKD = Math.Ceiling((double)((((DataTable)dgv.DataSource).Rows.Count) / rowsPerPageKD));
                        if (tpKD == 0 && ((DataTable)dgv.DataSource).Rows.Count != 0)
                            totalPagesKD += 1;
                        else
                            totalPagesKD += tpKD;

                        SetBoxType("روستائیان");
                        tpKD = Math.Ceiling((double)((((DataTable)dgv.DataSource).Rows.Count) / rowsPerPageKD));
                        if (tpKD == 0 && ((DataTable)dgv.DataSource).Rows.Count != 0)
                            totalPagesKD += 1;
                        else
                            totalPagesKD += tpKD;
                        //////


                        SetBoxType("کارکنان دولت");

                        bool done = false;
                        while (!done)
                        {
                            switch (boxTypeKD)
                            {
                                case "کارکنان دولت":
                                    if (((DataTable)dgv.DataSource).Rows.Count == 0)
                                        SetBoxType("خویش فرمایان");
                                    else
                                        done = true;
                                    break;
                                case "خویش فرمایان":
                                    if (((DataTable)dgv.DataSource).Rows.Count == 0)
                                        SetBoxType("سایر اقشار");
                                    else
                                        done = true;
                                    break;
                                case "سایر اقشار":
                                    if (((DataTable)dgv.DataSource).Rows.Count == 0)
                                        SetBoxType("روستائیان");
                                    else
                                        done = true;
                                    break;
                                case "روستائیان":
                                    //boxTypeKD = "done!!";
                                    done = true;
                                    break;
                                default:
                                    done = true;
                                    break;
                            }
                        }

                        /*((DataTable)dgv.DataSource).Columns.RemoveAt(((DataTable)dgv.DataSource).Columns.Count - 1);
                        ((DataTable)dgv.DataSource).Columns.Add("مبلغ تعدیلات", Type.GetType("System.String"));
                        ((DataTable)dgv.DataSource).AcceptChanges();*/
                        /*
                        dgv.Columns.RemoveAt(dgv.Columns.Count - 1);
                        dgv.Columns.Add("مبلغ تعدیلات", "مبلغ تعدیلات");
                        dgv.Refresh();
                        */
                        break;
                    default:
                        break;
                }

                //////////

                // Getting all Coulmns Names in the DataGridView
                AvailableColumns.Clear();
                for (int ix = dgv.Columns.Count - 1; ix > -1; ix--)
                {
                    DataGridViewColumn c = dgv.Columns[ix];
                    if (!c.Visible) continue;
                    AvailableColumns.Add(c.HeaderText);
                }

                // Showing the PrintOption Form
                /*PrintOptions dlg = new PrintOptions(AvailableColumns);
                if (dlg.ShowDialog() != DialogResult.OK) return;

                PrintTitle = dlg.PrintTitle;
                PrintAllRows = dlg.PrintAllRows;
                FitToPageWidth = dlg.FitToPageWidth;
                SelectedColumns = dlg.GetSelectedColumns();
                */

                //////

                StringBuilder sb = new StringBuilder();

                string singleSpace = " ";
                string minSpace = "   ";
                string maxSpace = "       ";

                switch (((DataTable)dgv.DataSource).TableName)
                {
                    case "Tamin_e_Ejtemaei":
                        sb.Append("مشخصات بیماران فیزیوتراپی:");
                        sb.Append(minSpace);
                        sb.Append(crtClinic);
                        sb.Append(maxSpace);
                        sb.Append("بیمه شده تامین اجتماعی در:");
                        sb.Append(minSpace);
                        sb.Append(_rptMonth);
                        sb.Append(singleSpace);
                        sb.Append("ماه");
                        sb.Append(maxSpace);
                        sb.Append("سال");
                        sb.Append(singleSpace);
                        sb.Append(_rptYear);
                        sb.Append(Base.nLine);
                        sb.Append("آدرس:");
                        sb.Append(minSpace);
                        sb.Append(crtAddr);
                        sb.Append(maxSpace);
                        sb.Append("تلفن:");
                        sb.Append(minSpace);
                        sb.Append(crtTel);
                        break;
                    case "Khadamaat_e_Darmaani_NMJA":
                        sb.Append("سازمان خدمات درمانی ن م جا");
                        sb.Append(maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace);
                        sb.Append("لیست نسخ مراکز طرف قرارداد");
                        sb.Append(Base.nLine);
                        sb.Append("نام مرکز:");
                        sb.Append(minSpace);
                        sb.Append(crtClinic);
                        sb.Append(maxSpace + maxSpace + maxSpace);
                        sb.Append("نوع مرکز:");
                        sb.Append(minSpace);
                        sb.Append("فیزیوتراپی");
                        sb.Append(maxSpace + maxSpace + maxSpace);
                        sb.Append("نوع نسخه:");
                        sb.Append(minSpace);
                        sb.Append("فیزیوتراپی");
                        sb.Append(maxSpace + maxSpace + maxSpace);
                        sb.Append("ماه:");
                        sb.Append(minSpace);
                        sb.Append(_rptMonth);
                        sb.Append(maxSpace + maxSpace + maxSpace);
                        sb.Append("سال:");
                        sb.Append(minSpace);
                        sb.Append(_rptYear);
                        break;
                    case "Khadamaat_e_Darmaani":
                        sb.Append("سازمان بیمه خدمات درمانی");
                        sb.Append(minSpace);
                        sb.Append("-");
                        sb.Append(minSpace);
                        sb.Append("اداره کل بیمه خدمات درمانی");
                        sb.Append(Base.nLine);
                        sb.Append("فرم فهرست نسخ فیزوتراپی همکار");
                        //sb.Append(maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace);
                        sb.Append(maxSpace + maxSpace + maxSpace);
                        sb.Append("کد مدرک");
                        sb.Append(minSpace);
                        sb.Append(maxSpace + maxSpace + maxSpace);
                        //sb.Append("\u0030\u0036 FM \u0030\u0036 \u0030\u0030");
                        //sb.Append(Base.nLine);
                        sb.Append(maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace);
                        sb.Append("فهرست نسخ");
                        sb.Append(maxSpace);
                        sb.Append("ماه:");
                        sb.Append(minSpace);
                        sb.Append(_rptMonth);
                        sb.Append(maxSpace);
                        sb.Append("سال:");
                        sb.Append(minSpace);
                        sb.Append(_rptYear);
                        sb.Append(maxSpace + maxSpace + maxSpace);
                        //sb.Append(maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace + maxSpace);
                        sb.Append("نوع صندوق:");
                        sb.Append(minSpace);
                        sb.Append("{boxType}");
                        break;
                    default:
                        break;
                }

                PrintTitle = sb.ToString();
                PrintAllRows = true;
                FitToPageWidth = true;
                SelectedColumns = GetSelectedColumns();
                //////

                RowsPerPage = 0;

                ppvw = new PrintPreviewDialog();
                //////
                printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 826, 1169);

/*                switch (((DataTable)dgv.DataSource).TableName)
                {
                    case "Tamin_e_Ejtemaei":
                        printDoc.DefaultPageSettings.Landscape = true;
                        break;
                    case "Khadamaat_e_Darmaani_NMJA":
                        printDoc.DefaultPageSettings.Landscape = false;
                        break;
                    case "Khadamaat_e_Darmaani":
                        printDoc.DefaultPageSettings.Landscape = true;
                        break;
                    default:
                        printDoc.DefaultPageSettings.Landscape = false;
                        break;
                }*/
                printDoc.DefaultPageSettings.Landscape = true;

                System.Drawing.Printing.Margins margins;

                switch (((DataTable)dgv.DataSource).TableName)
                {
                    case "Tamin_e_Ejtemaei":
                        margins = new System.Drawing.Printing.Margins(50, 50, 75, 65);
                        break;
                    case "Khadamaat_e_Darmaani_NMJA":
                        margins = new System.Drawing.Printing.Margins(50, 50, 75, 65);
                        break;
                    case "Khadamaat_e_Darmaani":
                        margins = new System.Drawing.Printing.Margins(50, 50, 75/*95*/, 65);
                        break;
                    default:
                        margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
                        break;
                }

                printDoc.DefaultPageSettings.Margins = margins;
                /////
                ppvw.Document = printDoc;

                ////
                //((Form)ppvw).WindowState = FormWindowState.Maximized;
                //((Form)ppvw).Location = new Point(0, 0);
                //SkinSoft.OSSkin.OSSkin.RemoveSkin(ppvw);
                //ppvw.Location = new Point(0, 0);
                ppvw.MaximizeBox = false;
                ppvw.MinimizeBox = false;
                ppvw.Shown += new System.EventHandler(ppvwMaximize);
                /////

                ////

                // Showing the Print Preview Page
                printDoc.BeginPrint +=new System.Drawing.Printing.PrintEventHandler(PrintDoc_BeginPrint);
                printDoc.PrintPage +=new System.Drawing.Printing.PrintPageEventHandler(PrintDoc_PrintPage);
                if (ppvw.ShowDialog() != DialogResult.OK)
                {
                    printDoc.BeginPrint -= new System.Drawing.Printing.PrintEventHandler(PrintDoc_BeginPrint);
                    printDoc.PrintPage -= new System.Drawing.Printing.PrintPageEventHandler(PrintDoc_PrintPage);
                    return;
                }

                // Printing the Documnet
                printDoc.Print();
                printDoc.BeginPrint -= new System.Drawing.Printing.PrintEventHandler(PrintDoc_BeginPrint);
                printDoc.PrintPage -= new System.Drawing.Printing.PrintPageEventHandler(PrintDoc_PrintPage);
	        }
	        catch (Exception ex)
	        {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);        		
	        }
            finally
            {

            }
        }

        ///////
        private static void ppvwMaximize(object sender, EventArgs e)
        {
            PrintPreviewDialog ppvw = (PrintPreviewDialog)sender;
            ppvw.WindowState = FormWindowState.Maximized;
            ppvw.Activate();
            ppvw.Select();
            ppvw.Focus();
        }
        ///////

        private static void PrintDoc_BeginPrint(object sender, 
                    System.Drawing.Printing.PrintEventArgs e) 
        {
            try
	        {
                // Formatting the Content of Text Cell to print
                StrFormat = new StringFormat();
                StrFormat.Alignment = StringAlignment.Near;
                StrFormat.LineAlignment = StringAlignment.Center;
                StrFormat.Trimming = StringTrimming.EllipsisCharacter;

                // Formatting the Content of Combo Cells to print
                StrFormatComboBox = new StringFormat();
                StrFormatComboBox.LineAlignment = StringAlignment.Center;
                StrFormatComboBox.FormatFlags = StringFormatFlags.NoWrap;
                StrFormatComboBox.Trimming = StringTrimming.EllipsisCharacter;

                ColumnLefts.Clear();
                ColumnWidths.Clear();
                ColumnTypes.Clear();
                CellHeight = 0;
                RowsPerPage = 0;

                // For various column types
                CellButton = new Button();
                CellCheckBox = new CheckBox();
                CellComboBox = new ComboBox();

                // Calculating Total Widths
                TotalWidth = 0;
//                foreach (DataGridViewColumn GridCol in dgv.Columns)
                for (int ix = dgv.Columns.Count - 1; ix > -1; ix--)
                {
                    DataGridViewColumn GridCol = dgv.Columns[ix];
                    if (!GridCol.Visible) continue;
                    if (!PrintDGV.SelectedColumns.Contains(GridCol.HeaderText)) continue;
                    TotalWidth += GridCol.Width;
                }

                //if (resetPageNum)
                    PageNo = 1;
                NewPage = true;
                RowPos = 0;
	        }
	        catch (Exception ex)
	        {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);        		
	        }
        }

        private static void PrintDoc_PrintPage(object sender, 
                    System.Drawing.Printing.PrintPageEventArgs e) 
        {
            ////
            if (writeAllTotalCostsPage)
            {
                DrawTotal(e);
                e.HasMorePages = false;
                return;
            }
            ////

            /*if (startNewBoxKD)
            {
                startNewBoxKD = false;
            }*/

            int tmpWidth, i;
            int tmpTop = e.MarginBounds.Top;
            int tmpLeft = e.MarginBounds.Left;

            try 
	        {	        
                // Before starting first page, it saves Width & Height of Headers and CoulmnType
                if (PageNo == 1) 
                {
                    for (int ix = dgv.Columns.Count - 1; ix > -1; ix--)
                    {
                        DataGridViewColumn GridCol = dgv.Columns[ix];
                        if (!GridCol.Visible) continue;
                        // Skip if the current column not selected
                        if (!PrintDGV.SelectedColumns.Contains(GridCol.HeaderText)) continue;

                        // Detemining whether the columns are fitted to page or not.
                        if (FitToPageWidth) 
                            tmpWidth = (int)(Math.Floor((double)((double)GridCol.Width / 
                                       (double)TotalWidth * (double)TotalWidth * 
                                       ((double)e.MarginBounds.Width / (double)TotalWidth))));
                        else
                            tmpWidth = GridCol.Width;

                        HeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, tmpWidth).Height) + 11;
                        
                        // Save width & height of headres and ColumnType
                        ColumnLefts.Add(tmpLeft);
                        ColumnWidths.Add(tmpWidth);
                        ColumnTypes.Add(GridCol.GetType());
                        tmpLeft += tmpWidth;

                        /////
                        totalCostsWidth += tmpWidth;
                        /////
                    }
                }

                // Printing Current Page, Row by Row
                while (RowPos <= dgv.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgv.Rows[RowPos];
                    if (GridRow.IsNewRow || (!PrintAllRows && !GridRow.Selected))
                    {
                        RowPos++;
                        continue;
                    }

                    CellHeight = GridRow.Height;

                    if (tmpTop + CellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        DrawFooter(e, RowsPerPage);
                        NewPage = true;
                        PageNo++;
                        e.HasMorePages = true;
                        return;
                    }
                    else
                    {
                        if (NewPage)
                        {
                            ///
                            pageNoKD++;
                            ///

                            // Draw Header
/*                            e.Graphics.DrawString(PrintTitle, new Font(dgv.Font, FontStyle.Bold), 
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                            e.Graphics.MeasureString(PrintTitle, new Font(dgv.Font, 
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);*/

                            //String s = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //////
                            //String s = Base.FormatNumsToPersian(Base.GetPersianDate());
                            //////

                            /*e.Graphics.DrawString(s, new Font(dgv.Font, FontStyle.Bold), 
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - 
                                    e.Graphics.MeasureString(s, new Font(dgv.Font, 
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top - 
                                    e.Graphics.MeasureString(PrintTitle, new Font(new Font(dgv.Font, 
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);*/

                            /////////

                            DrawWatermark(e);

                            StringFormat sf = new StringFormat();
                            sf.Alignment = StringAlignment.Center;
                            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                            e.Graphics.DrawString(boxTypeKD == string.Empty ? PrintTitle : PrintTitle.Replace("{boxType}", boxTypeKD), new Font(dgv.Font, FontStyle.Bold),
                                                                Brushes.Black, e.PageBounds.Width / 2, e.MarginBounds.Top -
                                                        e.Graphics.MeasureString(PrintTitle, new Font(dgv.Font,
                                                                FontStyle.Bold), e.MarginBounds.Width).Height - 13, sf);
                            if (((DataTable)dgv.DataSource).TableName == "Khadamaat_e_Darmaani")
                            {
                                e.Graphics.DrawString("06 FM 06 00", new Font(new Font("Times New Roman", 8.25F), FontStyle.Bold), Brushes.Black, e.PageBounds.Left + 708, e.MarginBounds.Top - 34, sf);
                            }

                            /////////

                            // Draw Columns
                            tmpTop = e.MarginBounds.Top;
                            i = 0;
                            for (int ix = dgv.Columns.Count - 1; ix > -1; ix--)
                            {
                                DataGridViewColumn GridCol = dgv.Columns[ix];
                                if (!GridCol.Visible) continue;
                                if (!PrintDGV.SelectedColumns.Contains(GridCol.HeaderText))
                                    continue;

                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)ColumnLefts[i], tmpTop,
                                    (int)ColumnWidths[i], HeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)ColumnLefts[i], tmpTop,
                                    (int)ColumnWidths[i], HeaderHeight));

                                StrFormat.Alignment = StringAlignment.Center;

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)ColumnLefts[i], tmpTop,
                                    (int)ColumnWidths[i], HeaderHeight), StrFormat);
                                i++;
                            }
                            NewPage = false;
                            tmpTop += HeaderHeight;
                        }

                        // Draw Columns Contents
                        i = 0;
                        for (int ix = GridRow.Cells.Count - 1; ix > -1; ix--)
                        {
                            DataGridViewCell Cel = GridRow.Cells[ix];
                            if (!Cel.OwningColumn.Visible) continue;
                            if (!SelectedColumns.Contains(Cel.OwningColumn.HeaderText))
                                continue;

                            // For the TextBox Column
                            if (((Type)ColumnTypes[i]).Name == "DataGridViewTextBoxColumn" ||
                                ((Type)ColumnTypes[i]).Name == "DataGridViewLinkColumn")
                            {
                                StrFormat.Alignment = StringAlignment.Far;
                                /////
                                if (Cel.OwningColumn.Name == "سهم سازمان")
                                    totalCosts += Convert.ToInt32(Base.FormatNumsToEnglish(Cel.Value.ToString()));
                                /////
                                e.Graphics.DrawString(Base.FormatNumsToPersian((Cel.Value.ToString())), Cel.InheritedStyle.Font,
                                        new SolidBrush(Cel.InheritedStyle.ForeColor),
                                        new RectangleF((int)ColumnLefts[i], (float)tmpTop,
                                        (int)ColumnWidths[i], (float)CellHeight), StrFormat);
                            }
                            // For the Button Column
                            else if (((Type)ColumnTypes[i]).Name == "DataGridViewButtonColumn")
                            {
                                CellButton.Text = Cel.Value.ToString();
                                CellButton.Size = new Size((int)ColumnWidths[i], CellHeight);
                                Bitmap bmp = new Bitmap(CellButton.Width, CellButton.Height);
                                CellButton.DrawToBitmap(bmp, new Rectangle(0, 0,
                                        bmp.Width, bmp.Height));
                                e.Graphics.DrawImage(bmp, new Point((int)ColumnLefts[i], tmpTop));
                            }
                            // For the CheckBox Column
                            else if (((Type)ColumnTypes[i]).Name == "DataGridViewCheckBoxColumn")
                            {
                                CellCheckBox.Size = new Size(14, 14);
                                CellCheckBox.Checked = (bool)Cel.Value;
                                Bitmap bmp = new Bitmap((int)ColumnWidths[i], CellHeight);
                                Graphics tmpGraphics = Graphics.FromImage(bmp);
                                tmpGraphics.FillRectangle(Brushes.White, new Rectangle(0, 0,
                                        bmp.Width, bmp.Height));
                                CellCheckBox.DrawToBitmap(bmp,
                                        new Rectangle((int)((bmp.Width - CellCheckBox.Width) / 2),
                                        (int)((bmp.Height - CellCheckBox.Height) / 2),
                                        CellCheckBox.Width, CellCheckBox.Height));
                                e.Graphics.DrawImage(bmp, new Point((int)ColumnLefts[i], tmpTop));
                            }
                            // For the ComboBox Column
                            else if (((Type)ColumnTypes[i]).Name == "DataGridViewComboBoxColumn")
                            {
                                CellComboBox.Size = new Size((int)ColumnWidths[i], CellHeight);
                                Bitmap bmp = new Bitmap(CellComboBox.Width, CellComboBox.Height);
                                CellComboBox.DrawToBitmap(bmp, new Rectangle(0, 0,
                                        bmp.Width, bmp.Height));
                                e.Graphics.DrawImage(bmp, new Point((int)ColumnLefts[i], tmpTop));
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                        new SolidBrush(Cel.InheritedStyle.ForeColor),
                                        new RectangleF((int)ColumnLefts[i] + 1, tmpTop, (int)ColumnWidths[i]
                                        - 16, CellHeight), StrFormatComboBox);
                            }
                            // For the Image Column
                            else if (((Type)ColumnTypes[i]).Name == "DataGridViewImageColumn")
                            {
                                Rectangle CelSize = new Rectangle((int)ColumnLefts[i],
                                        tmpTop, (int)ColumnWidths[i], CellHeight);
                                Size ImgSize = ((Image)(Cel.FormattedValue)).Size;
                                e.Graphics.DrawImage((Image)Cel.FormattedValue,
                                        new Rectangle((int)ColumnLefts[i] + (int)((CelSize.Width - ImgSize.Width) / 2),
                                        tmpTop + (int)((CelSize.Height - ImgSize.Height) / 2),
                                        ((Image)(Cel.FormattedValue)).Width, ((Image)(Cel.FormattedValue)).Height));

                            }

                            // Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)ColumnLefts[i],
                                    tmpTop, (int)ColumnWidths[i], CellHeight));

                            i++;

                        }
                        tmpTop += CellHeight;

                        /////
                        totalCostsTop = tmpTop;
                        /////
                    }

                    RowPos++;
                    // For the first page it calculates Rows per Page
                    if (PageNo == 1) RowsPerPage++;



                    /////////
                    if (((DataTable)dgv.DataSource).TableName == "Khadamaat_e_Darmaani")
                    {
                        switch (boxTypeKD)
                        {
                            case "کارکنان دولت":
                                allTotalCostsKD1 += totalCosts;
                                sessionNumsKD1++;
                                break;
                            case "خویش فرمایان":
                                allTotalCostsKD2 += totalCosts;
                                sessionNumsKD2++;
                                break;
                            case "سایر اقشار":
                                allTotalCostsKD3 += totalCosts;
                                sessionNumsKD3++;
                                break;
                            case "روستائیان":
                                allTotalCostsKD4 += totalCosts;
                                sessionNumsKD4++;
                                break;
                            default:
                                break;
                        }
                        totalCosts = 0;
                    }
                    //////////////////
                }

                if (RowsPerPage == 0) return;

                // Write Footer (Page Number)
                DrawFooter(e, RowsPerPage);

                /////
                switch (((DataTable)dgv.DataSource).TableName)
                {
                    case "Tamin_e_Ejtemaei":
                        break;
                    case "Khadamaat_e_Darmaani_NMJA":
                        break;
                    case "Khadamaat_e_Darmaani":
                        bool done = false;
                        while (!done)
                        {
                            switch (boxTypeKD)
                            {
                                case "کارکنان دولت":
                                    SetBoxType("خویش فرمایان");
                                    if (((DataTable)dgv.DataSource).Rows.Count > 0)
                                    {
                                        e.HasMorePages = true;
                                        return;
                                    }
                                    break;
                                case "خویش فرمایان":
                                    SetBoxType("سایر اقشار");
                                    if (((DataTable)dgv.DataSource).Rows.Count > 0)
                                    {
                                        e.HasMorePages = true;
                                        return;
                                    }
                                    break;
                                case "سایر اقشار":
                                    SetBoxType("روستائیان");
                                    if (((DataTable)dgv.DataSource).Rows.Count > 0)
                                    {
                                        e.HasMorePages = true;
                                        return;
                                    }
                                    break;
                                case "روستائیان":
                                    //boxTypeKD = "done!!";
                                    done = true;
                                    break;
                                default:
                                    done = true;
                                    break;
                            }
                        }
                        break;
                    default:
                        break;
                }

                writeAllTotalCostsPage = true;
                e.PageSettings.Landscape = false;
                e.PageSettings.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
                e.HasMorePages = true;
                return; //return is necessary
                /////

                //e.HasMorePages = false;
	        }
	        catch (Exception ex)
	        {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);        		
	        }
        }

        private static void DrawFooter(System.Drawing.Printing.PrintPageEventArgs e, 
                    int RowsPerPage)
        {
            //////////////////
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            sf.Alignment = StringAlignment.Far;

            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, totalCostsTop, totalCostsWidth, HeaderHeight));

            e.Graphics.DrawString("جمع کل هزینه سهم سازمان:   " + totalCosts.ToString() + "  ریال", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + 12, totalCostsTop + 6, sf);

            allTotalCosts += totalCosts;
            totalCosts = 0;
            totalCostsTop = 0;
            //totalCostsWidht = 0;


            string footer = string.Empty;
            switch (((DataTable)dgv.DataSource).TableName)
            {
                case "Tamin_e_Ejtemaei":
                    footer = "مهر و امضا مسئول فنی";
                    break;
                case "Khadamaat_e_Darmaani_NMJA":
                    footer = "مهر و امضا مسئول فنی                                                                          مهر مرکز";
                    break;
                case "Khadamaat_e_Darmaani":
                    footer = "مهر و امضا مسئول فنی";
                    break;
                default:
                    break;
            }

            sf.Alignment = StringAlignment.Center;
            //////////////////


            double cnt = 0; 

            // Detemining rows number to print
            if (PrintAllRows)
            {
                if (dgv.Rows[dgv.Rows.Count - 1].IsNewRow) 
                    cnt = dgv.Rows.Count - 2; // When the DataGridView doesn't allow adding rows
                else
                    cnt = dgv.Rows.Count - 1; // When the DataGridView allows adding rows
            }
            else
                cnt = dgv.SelectedRows.Count;

            // Writing the Page Number on the Bottom of Page
            /*string PageNum = PageNo.ToString() + " of " + 
                Math.Ceiling((double)(cnt / RowsPerPage)).ToString();

            e.Graphics.DrawString(PageNum, dgv.Font, Brushes.Black, 
                e.MarginBounds.Left + (e.MarginBounds.Width - 
                e.Graphics.MeasureString(PageNum, dgv.Font, 
                e.MarginBounds.Width).Width) / 2, e.MarginBounds.Top + 
                e.MarginBounds.Height + 31);*/


            ////
            double total = Math.Ceiling((double)(cnt / RowsPerPage));
            if (total == 0)
                total = 1;

            string PageNum = "صفحه " + PageNo.ToString() + " از " + total.ToString();

            if (((DataTable)dgv.DataSource).TableName == "Khadamaat_e_Darmaani")
            {
//                totalPagesKD = Math.Ceiling((double)((dtKhadamatDarmani.Rows.Count - 1) / rowsPerPageKD));
//                if (totalPagesKD == 0)
//                    totalPagesKD = 1;

                PageNum = "صفحه " + pageNoKD.ToString() + " از " + totalPagesKD.ToString();
            }

            e.Graphics.DrawString(footer + Base.nLine + PageNum, dgv.Font, Brushes.Black, 
                e.MarginBounds.Left + (e.MarginBounds.Width - 
                e.Graphics.MeasureString(PageNum, dgv.Font, 
                e.MarginBounds.Width).Width) / 2, e.MarginBounds.Top + 
                e.MarginBounds.Height + 15, sf);
            ////
        }

        private static void DrawTotal(System.Drawing.Printing.PrintPageEventArgs e)
        {
            DrawWatermark(e);

            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            sf.Alignment = StringAlignment.Center;

            int tableWidth = e.MarginBounds.Right - e.MarginBounds.Left;
            int celSize = 0;

            switch (((DataTable)dgv.DataSource).TableName)
            {
                case "Tamin_e_Ejtemaei":
                    sf.Alignment = StringAlignment.Far;
                    e.Graphics.DrawString("کد فرم:   F-\u0030\u0037-\u0030\u0032\u0036", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Left + 65, e.MarginBounds.Top, sf);
                    sf.Alignment = StringAlignment.Center;
                    e.Graphics.DrawString("سازمان تامین اجتماعی\nدفتر رسیدگی به اسناد پزشکی استان کرمانشاه\nفرم فرم تحویل نسخ پاراکلینیک استان کرمانشاه\nمربوط به   ماه:   " + _rptMonth + "       سال:   " + _rptYear, new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Width / 2, e.MarginBounds.Top + 40, sf);

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 155, tableWidth, 65));

                    //celSize = (int)Math.Ceiling((decimal)(tableWidth / 4));
                    celSize = tableWidth / 4;

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 220, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 220, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2, e.MarginBounds.Top + 220, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3, e.MarginBounds.Top + 220, celSize + 2, 40));

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 260, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 260, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2, e.MarginBounds.Top + 260, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3, e.MarginBounds.Top + 260, celSize + 2, 40));

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 300, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 300, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2, e.MarginBounds.Top + 300, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3, e.MarginBounds.Top + 300, celSize + 2, 40));

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 340, tableWidth, 85));


                    sf.Alignment = StringAlignment.Near;
                    e.Graphics.DrawString("نام پاراکلینیک:   فیزیوتراپی  " + crtClinic + "       کد پاراکلینیک:   " + crtClinicCode + "       نام شهرستان:   " + crtCity + "       تلفن:   " + crtTel + "\nشماره حساب:   " + crtAccountCode + "       شعبه بانک:   " + crtBank + "       تعداد کل نسخ:   " + Base.FormatNumsToPersian(((DataTable)dgv.DataSource).Rows.Count.ToString()) + "       تعداد اوراق لیست:   " + PageNo, new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 62, e.MarginBounds.Top + 168, sf);

                    sf.Alignment = StringAlignment.Center;

                    e.Graphics.DrawString("مبلغ سهم سازمان", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize / 2, e.MarginBounds.Top + 229, sf);
                    e.Graphics.DrawString("مبلغ کل", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 2 - celSize / 2, e.MarginBounds.Top + 229, sf);
                    e.Graphics.DrawString("تعداد نسخ", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 3 - celSize / 2, e.MarginBounds.Top + 229, sf);
                    e.Graphics.DrawString("نوع نسخ", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 - celSize / 2, e.MarginBounds.Top + 229, sf);

                    e.Graphics.DrawString(Base.FormatNumsToPersian(allTotalCosts.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize / 2, e.MarginBounds.Top + 269, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(((int)Math.Round(allTotalCosts * 100.0 / Base.PercentTE)).ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 2 - celSize / 2, e.MarginBounds.Top + 269, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(((DataTable)dgv.DataSource).Rows.Count.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 3 - celSize / 2, e.MarginBounds.Top + 269, sf);
                    e.Graphics.DrawString("نسخ عادی", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 - celSize / 2, e.MarginBounds.Top + 269, sf);

                    e.Graphics.DrawString(Base.FormatNumsToPersian(allTotalCosts.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize / 2, e.MarginBounds.Top + 309, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(((int)Math.Round(allTotalCosts * 100.0 / Base.PercentTE)).ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 2 - celSize / 2, e.MarginBounds.Top + 309, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(((DataTable)dgv.DataSource).Rows.Count.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 3 - celSize / 2, e.MarginBounds.Top + 309, sf);
                    e.Graphics.DrawString("جمع کل", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 - celSize / 2, e.MarginBounds.Top + 309, sf);

                    sf.Alignment = StringAlignment.Near;
                    e.Graphics.DrawString("مهر و امضا مسئول فنی", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 72, e.MarginBounds.Top + 375, sf);

                    break;
                case "Khadamaat_e_Darmaani_NMJA":
                    e.Graphics.DrawString("سازمان خدمات درمانی نیروهای مسلح\nاداره کل منطقه غرب کشور", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Width / 2, e.MarginBounds.Top, sf);
                    sf.Alignment = StringAlignment.Near;
                    e.Graphics.DrawString("فیزیوتراپی:   " + crtClinic, new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 55, e.MarginBounds.Top + 100, sf);
                    e.Graphics.DrawString("نام و نام خانوادگی موسس:   " + crtFounder, new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 55, e.MarginBounds.Top + 125, sf);
                    e.Graphics.DrawString("نام و نام خانوادگی مسئول فنی:   " + crtTechLiable, new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 55, e.MarginBounds.Top + 150, sf);
                    e.Graphics.DrawString("آدرس:   " + crtAddr, new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 55, e.MarginBounds.Top + 175, sf);
                    e.Graphics.DrawString("تلفن:   " + crtTel, new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 55, e.MarginBounds.Top + 200, sf);
                    e.Graphics.DrawString("کد حساب داری:   " + crtFinancialCode + "           شماره حساب و شعبه:   " + crtBank + "٬   " + crtAccountCode, new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 55, e.MarginBounds.Top + 260, sf);
                    e.Graphics.DrawString("ماه:   " + _rptMonth + "           سال:   " + _rptYear, new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 55, e.MarginBounds.Top + 285, sf);
                    e.Graphics.DrawString("تعداد ویزیت:   " + Base.FormatNumsToPersian(((DataTable)dgv.DataSource).Rows.Count.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 55, e.MarginBounds.Top + 310, sf);
                    e.Graphics.DrawString("مبلغ:   " + allTotalCosts, new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 55, e.MarginBounds.Top + 335, sf);
                    e.Graphics.DrawString("فرم شماره ۲", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 55, e.MarginBounds.Top + 500, sf);
                    sf.Alignment = StringAlignment.Far;
                    e.Graphics.DrawString("مهر و امضا", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Left + 65, e.MarginBounds.Top + 500, sf);
                    break;
                case "Khadamaat_e_Darmaani":
                    e.Graphics.DrawString("سازمان بیمه خدمات درمانی - اداره کل بیمه خدمات درمانی", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Width / 2, e.MarginBounds.Top, sf);
                    sf.Alignment = StringAlignment.Near;
                    e.Graphics.DrawString("فرم برگ درخواست هزینه و صورتحساب داروخانه ها و پاراکلینیک ها", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 65, e.MarginBounds.Top + 25, sf);
                    sf.Alignment = StringAlignment.Far;
                    //                    e.Graphics.DrawString("کد مدرک:   \u0030\u0036 FM \u0030\u0034 \u0030\u0031", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Left + 65, e.MarginBounds.Top + 25, sf);
                    e.Graphics.DrawString("کد مدرک:   ", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Left + 142, e.MarginBounds.Top + 25, sf);
                    e.Graphics.DrawString("06 FM 04 01", new Font(new Font("Times New Roman", 8.25F), FontStyle.Bold), Brushes.Black, e.PageBounds.Left + 65, e.MarginBounds.Top + 28, sf);

                    e.Graphics.DrawString("کد کامپیوتری:\nشماره پذیرش:", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Left + 142, e.MarginBounds.Top + 55, sf);

                    sf.Alignment = StringAlignment.Near;
                    e.Graphics.DrawString("اداره کل بیمه خدمات درمانی استان کرمانشاه", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 55, e.MarginBounds.Top + 95, sf);
                    e.Graphics.DrawString("احتراما به پیوست تعداد   " + Base.FormatNumsToPersian((sessionNumsKD1 + sessionNumsKD2 + sessionNumsKD3 + sessionNumsKD4).ToString()) + "   نسخه و   " + totalPagesKD + "   برگ فهرست نسخ به مبلغ   " + Base.FormatNumsToPersian((allTotalCostsKD1 + allTotalCostsKD2 + allTotalCostsKD3 + allTotalCostsKD4).ToString()) + "   ریال مربوط به بیمه شدگان آن سازمان در ماه   " + _rptMonth + "   سال   " + _rptYear + "\nبشرح جدول زیر شامل نسخ   فیزیوتراپی   جهت رسیدگی به اسناد پزشکی و دستور پرداخت ارسال می گردد.", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 55, e.MarginBounds.Top + 125, sf);
                    sf.Alignment = StringAlignment.Center;
                    e.Graphics.DrawString("مهر و امضای\nموسس و مسئول فنی", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Left + 142, e.MarginBounds.Top + 180, sf);

                    celSize = tableWidth / 5;

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 265, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 265, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2, e.MarginBounds.Top + 265, celSize / 3, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2 + celSize / 3, e.MarginBounds.Top + 265, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3 + celSize / 3, e.MarginBounds.Top + 265, celSize / 3, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3 + celSize / 3 * 2, e.MarginBounds.Top + 265, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 4 + celSize / 3 * 2, e.MarginBounds.Top + 265, celSize / 3, 40));

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 305, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 305, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2, e.MarginBounds.Top + 305, celSize / 3, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2 + celSize / 3, e.MarginBounds.Top + 305, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3 + celSize / 3, e.MarginBounds.Top + 305, celSize / 3, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3 + celSize / 3 * 2, e.MarginBounds.Top + 305, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 4 + celSize / 3 * 2, e.MarginBounds.Top + 305, celSize / 3, 40));

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 345, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 345, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2, e.MarginBounds.Top + 345, celSize / 3, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2 + celSize / 3, e.MarginBounds.Top + 345, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3 + celSize / 3, e.MarginBounds.Top + 345, celSize / 3, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3 + celSize / 3 * 2, e.MarginBounds.Top + 345, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 4 + celSize / 3 * 2, e.MarginBounds.Top + 345, celSize / 3, 40));

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 385, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 385, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2, e.MarginBounds.Top + 385, celSize / 3, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2 + celSize / 3, e.MarginBounds.Top + 385, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3 + celSize / 3, e.MarginBounds.Top + 385, celSize / 3, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3 + celSize / 3 * 2, e.MarginBounds.Top + 385, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 4 + celSize / 3 * 2, e.MarginBounds.Top + 385, celSize / 3, 40));

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 425, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 425, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2, e.MarginBounds.Top + 425, celSize / 3, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2 + celSize / 3, e.MarginBounds.Top + 425, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3 + celSize / 3, e.MarginBounds.Top + 425, celSize / 3, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3 + celSize / 3 * 2, e.MarginBounds.Top + 425, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 4 + celSize / 3 * 2, e.MarginBounds.Top + 425, celSize / 3, 40));

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 465, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 465, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2, e.MarginBounds.Top + 465, celSize / 3, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2 + celSize / 3, e.MarginBounds.Top + 465, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3 + celSize / 3, e.MarginBounds.Top + 465, celSize / 3, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3 + celSize / 3 * 2, e.MarginBounds.Top + 465, celSize + celSize / 3, 40));

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 505, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 505, celSize + celSize / 3, 40));

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 545, celSize, 40));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 545, celSize + celSize / 3, 40));

                    sf.Alignment = StringAlignment.Center;

                    e.Graphics.DrawString("مبلغ قابل پرداخت", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize / 2, e.MarginBounds.Top + 275, sf);
                    e.Graphics.DrawString("مبلغ تعدیل شده", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 2 - celSize / 2, e.MarginBounds.Top + 275, sf);
                    e.Graphics.DrawString("تعداد‌نسخ\nتعدیل‌شده", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 3 - celSize + celSize / 6, e.MarginBounds.Top + 267, sf);
                    e.Graphics.DrawString("مبلغ درخواستی (ریال)", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 - celSize - celSize / 6, e.MarginBounds.Top + 275, sf);
                    e.Graphics.DrawString("تعداد‌نسخ\nدرخواستی", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 - celSize + celSize / 2, e.MarginBounds.Top + 267, sf);
                    e.Graphics.DrawString("نوع صندوق", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 + celSize / 5, e.MarginBounds.Top + 275, sf);
                    e.Graphics.DrawString("ردیف", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 5 - celSize / 6, e.MarginBounds.Top + 275, sf);



                    e.Graphics.DrawString("کارکنان دولت", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 + celSize / 5, e.MarginBounds.Top + 315, sf);
                    e.Graphics.DrawString("خویش فرمایان", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 + celSize / 5, e.MarginBounds.Top + 355, sf);
                    e.Graphics.DrawString("سایر اقشار", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 + celSize / 5, e.MarginBounds.Top + 395, sf);
                    e.Graphics.DrawString("روستائیان", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 + celSize / 5, e.MarginBounds.Top + 435, sf);
                    e.Graphics.DrawString("جمع کل", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 + celSize / 5, e.MarginBounds.Top + 475, sf);

                    e.Graphics.DrawString("مبلغ ۵٪ مالیات", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 2 - celSize / 3, e.MarginBounds.Top + 515, sf);
                    e.Graphics.DrawString("مبلغ قابل پرداخت پس از کسر مالیات", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 2 - celSize / 3, e.MarginBounds.Top + 555, sf);


                    e.Graphics.DrawString(Base.FormatNumsToPersian(sessionNumsKD1.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 - celSize / 2, e.MarginBounds.Top + 315, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(sessionNumsKD2.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 - celSize / 2, e.MarginBounds.Top + 355, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(sessionNumsKD3.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 - celSize / 2, e.MarginBounds.Top + 395, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(sessionNumsKD4.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 - celSize / 2, e.MarginBounds.Top + 435, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian((sessionNumsKD1 + sessionNumsKD2 + sessionNumsKD3 + sessionNumsKD4).ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 4 - celSize / 2, e.MarginBounds.Top + 475, sf);

                    e.Graphics.DrawString(Base.FormatNumsToPersian(allTotalCostsKD1.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 3 - celSize / 6, e.MarginBounds.Top + 315, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(allTotalCostsKD2.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 3 - celSize / 6, e.MarginBounds.Top + 355, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(allTotalCostsKD3.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 3 - celSize / 6, e.MarginBounds.Top + 395, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(allTotalCostsKD4.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 3 - celSize / 6, e.MarginBounds.Top + 435, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian((allTotalCostsKD1 + allTotalCostsKD2 + allTotalCostsKD3 + allTotalCostsKD4).ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 3 - celSize / 6, e.MarginBounds.Top + 475, sf);


                    sf.Alignment = StringAlignment.Near;
                    e.Graphics.DrawString("شرح کسورات", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 55, e.MarginBounds.Top + 590, sf);

                    celSize = tableWidth / 11;

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 610, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 610, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2, e.MarginBounds.Top + 610, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3, e.MarginBounds.Top + 610, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 4, e.MarginBounds.Top + 610, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 5, e.MarginBounds.Top + 610, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 6, e.MarginBounds.Top + 610, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 7, e.MarginBounds.Top + 610, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 8, e.MarginBounds.Top + 610, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 9, e.MarginBounds.Top + 610, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 10, e.MarginBounds.Top + 610, celSize, 35));

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 645, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 645, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2, e.MarginBounds.Top + 645, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3, e.MarginBounds.Top + 645, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 4, e.MarginBounds.Top + 645, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 5, e.MarginBounds.Top + 645, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 6, e.MarginBounds.Top + 645, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 7, e.MarginBounds.Top + 645, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 8, e.MarginBounds.Top + 645, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 9, e.MarginBounds.Top + 645, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 10, e.MarginBounds.Top + 645, celSize, 35));

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 680, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 680, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2, e.MarginBounds.Top + 680, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3, e.MarginBounds.Top + 680, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 4, e.MarginBounds.Top + 680, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 5, e.MarginBounds.Top + 680, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 6, e.MarginBounds.Top + 680, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 7, e.MarginBounds.Top + 680, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 8, e.MarginBounds.Top + 680, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 9, e.MarginBounds.Top + 680, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 10, e.MarginBounds.Top + 680, celSize, 35));

                    sf.Alignment = StringAlignment.Center;

                    e.Graphics.DrawString("سایر", new Font(dgv.Font, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + celSize / 2, e.MarginBounds.Top + 617, sf);
                    e.Graphics.DrawString("نسخ‌پزشک‌یا‌بیمار\nکاربنی و کپی", new Font(dgv.Font, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + celSize * 2 - celSize / 2, e.MarginBounds.Top + 609, sf);
                    e.Graphics.DrawString("نسخ مربوط به\nسایر سازمانها", new Font(dgv.Font, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + celSize * 3 - celSize / 2, e.MarginBounds.Top + 609, sf);
                    e.Graphics.DrawString("فاقد مهر\nو امضا لازم", new Font(dgv.Font, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + celSize * 4 - celSize / 2, e.MarginBounds.Top + 609, sf);
                    e.Graphics.DrawString("مخدوش بودن\nتاریخ‌و‌متن‌نسخه", new Font(dgv.Font, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + celSize * 5 - celSize / 2, e.MarginBounds.Top + 609, sf);
                    e.Graphics.DrawString("فاقد\nتاریخ اعتبار", new Font(dgv.Font, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + celSize * 6 - celSize / 2, e.MarginBounds.Top + 609, sf);
                    e.Graphics.DrawString("عدم تعهد\nسازمان", new Font(dgv.Font, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + celSize * 7 - celSize / 2, e.MarginBounds.Top + 609, sf);
                    e.Graphics.DrawString("فاقد\nتائیدیه سازمان", new Font(dgv.Font, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + celSize * 8 - celSize / 2, e.MarginBounds.Top + 609, sf);
                    e.Graphics.DrawString("اشتباه در\nمحاسبه نرخ", new Font(dgv.Font, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + celSize * 9 - celSize / 2, e.MarginBounds.Top + 609, sf);
                    e.Graphics.DrawString("اضافه قیمت", new Font(dgv.Font, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + celSize * 10 - celSize / 2, e.MarginBounds.Top + 617, sf);
                    e.Graphics.DrawString("علت", new Font(dgv.Font, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + celSize * 11 - celSize / 2, e.MarginBounds.Top + 617, sf);

                    e.Graphics.DrawString("تعداد", new Font(dgv.Font, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + celSize * 11 - celSize / 2, e.MarginBounds.Top + 652, sf);
                    e.Graphics.DrawString("مبلغ", new Font(dgv.Font, FontStyle.Regular), Brushes.Black, e.MarginBounds.Left + celSize * 11 - celSize / 2, e.MarginBounds.Top + 687, sf);


                    e.Graphics.DrawString("امضا کارشناس                                                       امضا کارشناس مسئول                                                       رئیس اسناد پزشکی", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Width / 2, e.MarginBounds.Top + 728, sf);


                    e.Graphics.DrawLine(Pens.Black, new Point(e.MarginBounds.Left, e.MarginBounds.Top + 775), new Point(e.MarginBounds.Right, e.MarginBounds.Top + 775));

                    sf.Alignment = StringAlignment.Near;
                    e.Graphics.DrawString("ریاست محترم اسناد پزشکی\nاداره کل بیمه خدمات درمانی استان کرمانشاه", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 62, e.MarginBounds.Top + 795, sf);

                    sf.Alignment = StringAlignment.Far;
                    e.Graphics.DrawString("کد شناسائی", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Left + 115, e.MarginBounds.Top + 795, sf);

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 845, tableWidth, 95));

                    sf.Alignment = StringAlignment.Near;

                    e.Graphics.DrawString("احتراما بپیوست   " + totalPagesKD + "   برگ لیست٬ به ضمیمه   " + Base.FormatNumsToPersian((sessionNumsKD1 + sessionNumsKD2 + sessionNumsKD3 + sessionNumsKD4).ToString()) + "   تعداد نسخ مربوط به   " + "\nبه شرح جدول زیر در ماه   " + _rptMonth + "   سال   " + _rptYear + "   تقدیم میگردد. خواهشمند است پس از رسیدگی و کنترل٬ وجه را به\nحساب جاری شماره   " + crtAccountCode + "   نزد بانک رفاه شعبه شهید جعفری واریز نمائید.", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Right - 65, e.MarginBounds.Top + 855, sf);

                    sf.Alignment = StringAlignment.Far;

                    e.Graphics.DrawString("مهر و امضا", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.PageBounds.Left + 65, e.MarginBounds.Top + 915, sf);



                    celSize = tableWidth / 12;

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 965, celSize * 2, 45));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2, e.MarginBounds.Top + 965, celSize * 2, 45));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 4, e.MarginBounds.Top + 965, celSize * 2, 45));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 6, e.MarginBounds.Top + 965, celSize * 2, 45));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 8, e.MarginBounds.Top + 965, celSize * 2, 45));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 10, e.MarginBounds.Top + 965, celSize * 2 + 5, 45));

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 1010, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 1010, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2, e.MarginBounds.Top + 1010, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3, e.MarginBounds.Top + 1010, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 4, e.MarginBounds.Top + 1010, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 5, e.MarginBounds.Top + 1010, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 6, e.MarginBounds.Top + 1010, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 7, e.MarginBounds.Top + 1010, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 8, e.MarginBounds.Top + 1010, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 9, e.MarginBounds.Top + 1010, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 10, e.MarginBounds.Top + 1010, celSize * 2 + 5, 35));

                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top + 1045, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize, e.MarginBounds.Top + 1045, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 2, e.MarginBounds.Top + 1045, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 3, e.MarginBounds.Top + 1045, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 4, e.MarginBounds.Top + 1045, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 5, e.MarginBounds.Top + 1045, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 6, e.MarginBounds.Top + 1045, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 7, e.MarginBounds.Top + 1045, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 8, e.MarginBounds.Top + 1045, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 9, e.MarginBounds.Top + 1045, celSize, 35));
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.MarginBounds.Left + celSize * 10, e.MarginBounds.Top + 1045, celSize * 2 + 5, 35));

                    sf.Alignment = StringAlignment.Center;

                    string headerRow2 = "\nت نسخ              م نسخ";

                    e.Graphics.DrawString("جمع صندوقها" + headerRow2, new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize, e.MarginBounds.Top + 966, sf);
                    e.Graphics.DrawString("روستائی" + headerRow2, new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 3, e.MarginBounds.Top + 966, sf);
                    e.Graphics.DrawString("خویش فرما" + headerRow2, new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 5, e.MarginBounds.Top + 966, sf);
                    e.Graphics.DrawString("سایر اقشار" + headerRow2, new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 7, e.MarginBounds.Top + 966, sf);
                    e.Graphics.DrawString("کارکنان دولت" + headerRow2, new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 9, e.MarginBounds.Top + 966, sf);

                    e.Graphics.DrawString("ویزیت", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 11, e.MarginBounds.Top + 1018, sf);
                    e.Graphics.DrawString("هرگونه خدمات", new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 11, e.MarginBounds.Top + 1053, sf);


                    e.Graphics.DrawString(Base.FormatNumsToPersian(sessionNumsKD1.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 9 + celSize / 2, e.MarginBounds.Top + 1018, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(sessionNumsKD2.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 7 + celSize / 2, e.MarginBounds.Top + 1018, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(sessionNumsKD3.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 5 + celSize / 2, e.MarginBounds.Top + 1018, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(sessionNumsKD4.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 3 + celSize / 2, e.MarginBounds.Top + 1018, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian((sessionNumsKD1 + sessionNumsKD2 + sessionNumsKD3 + sessionNumsKD4).ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize + celSize / 2, e.MarginBounds.Top + 1018, sf);

                    e.Graphics.DrawString(Base.FormatNumsToPersian(allTotalCostsKD1.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 9 - celSize / 2, e.MarginBounds.Top + 1018, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(allTotalCostsKD2.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 7 - celSize / 2, e.MarginBounds.Top + 1018, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(allTotalCostsKD3.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 5 - celSize / 2, e.MarginBounds.Top + 1018, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian(allTotalCostsKD4.ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize * 3 - celSize / 2, e.MarginBounds.Top + 1018, sf);
                    e.Graphics.DrawString(Base.FormatNumsToPersian((allTotalCostsKD1 + allTotalCostsKD2 + allTotalCostsKD3 + allTotalCostsKD4).ToString()), new Font(dgv.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + celSize - celSize / 2, e.MarginBounds.Top + 1018, sf);
                    
                    break;
                default:
                    break;
            }
        }

        private static void DrawWatermark(System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            if (e.PageSettings.Landscape)
                sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            else
                sf.FormatFlags = StringFormatFlags.DirectionVertical;

            e.Graphics.DrawString(crtClinic, new Font(dgv.Font.Name, 133.33F, FontStyle.Bold), Brushes.LightGray, e.PageBounds.Width / 2, e.PageBounds.Height / 2, sf);
        }
    }
}
