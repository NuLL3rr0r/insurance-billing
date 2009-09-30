using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Insurance
{
    class BasicIO
    {
        public static string ExtractExt(string file)
        {
            return file.Contains(".") ? file.Substring(file.LastIndexOf(".")) : string.Empty;
        }

        public static int GetFileSize(string file)
        {
            try
            {
                return (int)new FileInfo(file).Length;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
            }
        }

        public static byte[] ReadStreamFromFile(string file)
        {
            try
            {
                int len = GetFileSize(file);
                byte[] data = new byte[len];

                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    fs.Read(data, 0, len);
                    fs.Close();
                }

                return data;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
            }
        }

        public static bool WriteStreamToFile(string file, byte[] data)
        {
            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(data, 0, data.Length);
                    fs.Close();
                }

                return true;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
            }
        }
    }
}
