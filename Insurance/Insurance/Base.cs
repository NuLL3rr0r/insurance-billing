using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;

namespace Insurance
{
    static class Base
    {
        #region Variables & Properties

        public static string backslash = Path.DirectorySeparatorChar.ToString();
        public static string nLine = Environment.NewLine;

        public static string path;

        public static string legal = "GNUr00t/.?";

        private static string _pw = string.Empty;
        public static string pw
        {
            get
            {
                return _pw;
            }
            set
            {
                _pw = value;
            }
        }

        private static string _theme = string.Empty;
        public static string theme
        {
            get
            {
                return _theme;
            }
            set
            {
                _theme = value;
            }
        }

        private static byte _PercentTE = 0;
        public static byte PercentTE
        {
            get
            {
                return _PercentTE;
            }
            set
            {
                _PercentTE = value;
            }
        }

        private static byte _PercentKDNMJA = 0;
        public static byte PercentKDNMJA
        {
            get
            {
                return _PercentKDNMJA;
            }
            set
            {
                _PercentKDNMJA = value;
            }
        }

        private static byte _PercentKD = 0;
        public static byte PercentKD
        {
            get
            {
                return _PercentKD;
            }
            set
            {
                _PercentKD = value;
            }
        }

        private static string _BackupPath = string.Empty;
        public static string BackupPath
        {
            get
            {
                return _BackupPath;
            }
            set
            {
                _BackupPath = value;
            }
        }

        private static string _RestorePath = string.Empty;
        public static string RestorePath
        {
            get
            {
                return _RestorePath;
            }
            set
            {
                _RestorePath = value;
            }
        }

        private static string _LastBackupDate = string.Empty;
        public static string LastBackupDate
        {
            get
            {
                return _LastBackupDate;
            }
            set
            {
                _LastBackupDate = value;
            }
        }

        private static string _LastRestoreDate = string.Empty;
        public static string LastRestoreDate
        {
            get
            {
                return _LastRestoreDate;
            }
            set
            {
                _LastRestoreDate = value;
            }
        }

        private static string _LastBackupTime = string.Empty;
        public static string LastBackupTime
        {
            get
            {
                return _LastBackupTime;
            }
            set
            {
                _LastBackupTime = value;
            }
        }

        private static string _LastRestoreTime = string.Empty;
        public static string LastRestoreTime
        {
            get
            {
                return _LastRestoreTime;
            }
            set
            {
                _LastRestoreTime = value;
            }
        }

        private static string dbPw = "H6V90doX54mt3GolEafL";
        private static string dbFile = @"root.sqlite";
        public static string dbHashKey = "§";
        public static string dbCnnStr = string.Empty;
        
        //public static int maxInt32Bound = 2147483647;

        #endregion

        #region Messages & Errors

        public const string msgTitle = "Insurance Billing v1.0";

        public const string errFile = "امكان دسترسي به فايل ذيل، از منابع برنامه وجود ندارد\n\n{0}\n\n\nپيشنهاد مي شود اقدام به نصب مجدد برنامه نمائيد\n\nجهت خروج از برنامه كليد تائيد را بفشاريد";
        public const string errFileHeader = "عدم دسترسي به منابع برنامه";
        public const string errDoubleInstance = "كاربر گرامي\n\tدر حال حاضر نسخه ديگري از برنامه در حال اجراست\n\n\nپيشنهاد جهت رفع خطا\n\tممكن است پنجره برنامه را كوچك نمائي نموده باشيد\nنگاهي به سيني سيستم واقع در نوار وظيفه ويندوز بياندازيد";
        public const string errDoubleInstanceHeader = "اجراي مجدد برنامه";

        #endregion

        static Base()
        {
            //Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

            path = Environment.CurrentDirectory;
            path += path.EndsWith(Base.backslash) ? string.Empty : Base.backslash;

            dbFile = String.Concat(path, dbFile);
            dbCnnStr = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1};", dbFile, dbPw);
        }

        #region Theme

        public static SkinSoft.OSSkin.SkinStyle GetCurrentTheme()
        {
            return GetCurrentTheme(_theme);
        }

        public static SkinSoft.OSSkin.SkinStyle GetCurrentTheme(string theme)
        {
            _theme = theme;

            switch (theme)
            {
                case "XPBLUE": return SkinSoft.OSSkin.SkinStyle.XpBlue;
                case "XPOLIVE": return SkinSoft.OSSkin.SkinStyle.XpOlive;
                case "XPSILVER": return SkinSoft.OSSkin.SkinStyle.XpSilver;
                case "XPROYALE": return SkinSoft.OSSkin.SkinStyle.XpRoyale;
                case "OFFICEBLUE": return SkinSoft.OSSkin.SkinStyle.Office2007Blue;
                case "OFFICEBLACK": return SkinSoft.OSSkin.SkinStyle.Office2007Black;
                case "VISTAAERO": return SkinSoft.OSSkin.SkinStyle.VistaAero;
                case "OSXAQUA": return SkinSoft.OSSkin.SkinStyle.MacOSXAqua;
                case "OSXBRUSHED": return SkinSoft.OSSkin.SkinStyle.MacOSXBrushed;
                case "OSXSILVER": return SkinSoft.OSSkin.SkinStyle.MacOSXSilver;
                default: return SkinSoft.OSSkin.SkinStyle.Office2007Black;
            }
        }

        #endregion

        #region Common Tools

        public static string NameGen()
        {
            Random rnd = new Random();
            String key = String.Empty;
            int min = -1, max = -1;

            for (int i = 0; i < 33; i++)
            {
                switch (rnd.Next(2))
                {
                    case 0:
                        min = 48;
                        max = 58;
                        break;
                    case 1:
                        min = 97;
                        max = 123;
                        break;
                    default:
                        break;
                }
                key = String.Concat(key, Convert.ToChar(rnd.Next(min, max)));
            }

            return key;
        }

        #endregion

        #region Shell & OS Environement Tools

        public static string GetTempPath()
        {
            string path = System.IO.Path.GetTempPath();
            path += path.EndsWith(Base.backslash) ? string.Empty : Base.backslash;
            return path;
        }

        public static string CreateTempPath()
        {
            string path = Base.GetTempPath();

            while (true)
            {
                path += Base.NameGen() + "\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    break;
                }
            }

            return path;
        }

        #endregion

        #region DB Tools

        public static void CleanTable(string tbl, string cnnStr)
        {
            try
            {
                string sqlStr = "SELECT * FROM " + tbl;

                OleDbConnection cnn = new OleDbConnection(cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                oda.Fill(ds, tbl);
                dt = ds.Tables[tbl];

                foreach (DataRow dr in dt.Rows)
                    dr.Delete();

                oda.DeleteCommand = ocb.GetDeleteCommand();

                if (oda.Update(ds, tbl) == 1)
                    ds.AcceptChanges();
                else
                    ds.RejectChanges();

                cnn.Close();

                dt.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                dt = null;
                ds = null;
                ocb = null;
                oda = null;
                cnn = null;

                sqlStr = null;
            }
            catch
            {
            }
            finally
            {
            }
        }

        public static void CompactJetDB(string connectionString, string mdwFilename)
        {
            try
            {
                string tmpFile = Base.path + @"tmp.pak";

                object[] oParams;
                object objJRO = Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine"));
                oParams = new object[] { connectionString, String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1};Jet OLEDB:Engine Type=5", tmpFile, dbPw) };
                objJRO.GetType().InvokeMember("CompactDatabase", System.Reflection.BindingFlags.InvokeMethod, null, objJRO, oParams);

                System.IO.File.Delete(mdwFilename);
                System.IO.File.Move(tmpFile, mdwFilename);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(objJRO);
                objJRO = null;
            }
            catch
            {
            }
            finally
            {
            }
        }

        public static void CleanAndRepair()
        {
            //CleanTable(tblReports, cnnStrReports);
            CompactJetDB(dbCnnStr, dbFile);
        }

        #endregion

        #region Date Conversations & Formatting

        public static string GetPersianDate()
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

            DateTime dt = DateTime.Now;

            string y = pc.GetYear(dt).ToString();
            string m = pc.GetMonth(dt).ToString();
            string d = pc.GetDayOfMonth(dt).ToString();

            if (m.Length != 2)
                m = "0" + m;
            if (d.Length != 2)
                d = "0" + d;

            //{0} = Year
            //{1} = Month
            //{2} = Day
            return FormatNumsToPersian(String.Format("{0}/{1}/{2}", y, m, d));
        }

        public static bool IsValidDate(string strDate)
        {
            int len = strDate.Length;
            if (len != 10)
                return false;

            string num;
            for (int i = 0; i < len; i++)
            {
                num = strDate.Substring(i, 1);
                if (i != 4 && i != 7)
                {
                    switch (num)
                    {
                        case "0":
                            break;
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                        case "4":
                            break;
                        case "5":
                            break;
                        case "6":
                            break;
                        case "7":
                            break;
                        case "8":
                            break;
                        case "9":
                            break;
                        default:
                            return false;
                            //break;
                    }
                }
                else
                {
                    if (num != "/")
                        return false;
                }
            }

            return true;
        }

        public static bool IsDateChars(string strDate)
        {
            int len = strDate.Length;
            if (len > 10)
                return false;

            string num;
            for (int i = 0; i < len; i++)
            {
                num = strDate.Substring(i, 1);
                if (i != 4 && i != 7)
                {
                    switch (num)
                    {
                        case "0":
                            break;
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                        case "4":
                            break;
                        case "5":
                            break;
                        case "6":
                            break;
                        case "7":
                            break;
                        case "8":
                            break;
                        case "9":
                            break;
                        default:
                            return false;
                            //break;
                    }

                    if (i == 0 && num != "1")
                        return false;

                    if (i == 1 && (Convert.ToInt32(num) < 3 || Convert.ToInt32(num) > 4))
                        return false;

                    if (i == 2 && (strDate.Substring(i - 1, 1) == "3" && Convert.ToInt32(num) < 8))
                        return false;

                    if (i == 3 && (strDate.Substring(i - 2, 1) == "3" && strDate.Substring(i - 1, 1) == "8" && Convert.ToInt32(num) < 8))
                        return false;

                    if (i == 5 && (num != "0" && num != "1"))
                        return false;

                    if (i == 6 && ((strDate.Substring(i - 1, 1) == "0" && num == "0") || (strDate.Substring(i - 1, 1) == "1" && Convert.ToInt32(num) > 2)))
                        return false;

                    if (i == 8 && (num != "0" && num != "1" && num != "2" && num != "3"))
                        return false;

                    if (i == 9 && ((strDate.Substring(i - 1, 1) == "0" && num == "0") || (strDate.Substring(i - 1, 1) == "3" && Convert.ToInt32(num) > 1)))
                        return false;
                }
                else
                {
                    if (num != "/")
                        return false;
                }
            }

            return true;
        }

        #endregion

        #region Localizations

        public static string FormatNumsToPersian(string strNum)
        {
            int len = strNum.Length;
            string strOut = string.Empty;
            string num;
            for (int i = 0; i < len; i++)
            {
                num = strNum.Substring(i, 1);
                switch (num)
                {
                    case "0":
                        strOut += "\u06F0";
                        break;
                    case "1":
                        strOut += "\u06F1";
                        break;
                    case "2":
                        strOut += "\u06F2";
                        break;
                    case "3":
                        strOut += "\u06F3";
                        break;
                    case "4":
                        strOut += "\u06F4";
                        break;
                    case "5":
                        strOut += "\u06F5";
                        break;
                    case "6":
                        strOut += "\u06F6";
                        break;
                    case "7":
                        strOut += "\u06F7";
                        break;
                    case "8":
                        strOut += "\u06F8";
                        break;
                    case "9":
                        strOut += "\u06F9";
                        break;
                    default:
                        strOut += num;
                        break;
                }
            }
            return strOut;
        }

        public static string FormatNumsToEnglish(string strNum)
        {
            int len = strNum.Length;
            string strOut = string.Empty;
            string num;
            for (int i = 0; i < len; i++)
            {
                num = strNum.Substring(i, 1);
                switch (num)
                {
                    case "\u06F0":
                        strOut += "0";
                        break;
                    case "\u06F1":
                        strOut += "1";
                        break;
                    case "\u06F2":
                        strOut += "2";
                        break;
                    case "\u06F3":
                        strOut += "3";
                        break;
                    case "\u06F4":
                        strOut += "4";
                        break;
                    case "\u06F5":
                        strOut += "5";
                        break;
                    case "\u06F6":
                        strOut += "6";
                        break;
                    case "\u06F7":
                        strOut += "7";
                        break;
                    case "\u06F8":
                        strOut += "8";
                        break;
                    case "\u06F9":
                        strOut += "9";
                        break;
                    default:
                        strOut += num;
                        break;
                }
            }
            return strOut;
        }

        #endregion
    }
}
