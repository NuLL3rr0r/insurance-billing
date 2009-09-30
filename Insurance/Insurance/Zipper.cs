using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

/// <summary>
/// Summary description for Zipper
/// </summary>
namespace Insurance
{
    public class Zipper
    {
        public static byte[] Compress(string data, string mode)
        {
            return Compress(System.Text.Encoding.Unicode.GetBytes(data), mode);
        }

        public static string DecompressToString(byte[] data, string mode)
        {
            return System.Text.Encoding.Unicode.GetString(Decompress(data, mode));
        }

        public static byte[] Compress(byte[] data, string mode)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                Stream s;

                switch (mode)
                {
                    case "solid":
                        s = new DeflateStream(ms, CompressionMode.Compress);
                        break;
                    case "fast":
                        s = new GZipStream(ms, CompressionMode.Compress);
                        break;
                    default:
                        s = new GZipStream(ms, CompressionMode.Compress);
                        break;
                }

                s.Write(data, 0, data.Length);
                s.Close();

                return ms.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static byte[] Decompress(byte[] data, string mode)
        {
            try
            {
                string result = string.Empty;
                byte[] buffer = { };

                MemoryStream ms = new MemoryStream(data);
                Stream s;

                switch (mode)
                {
                    case "solid":
                        s = new DeflateStream(ms, CompressionMode.Decompress);
                        break;
                    case "fast":
                        s = new GZipStream(ms, CompressionMode.Decompress);
                        break;
                    default:
                        s = new GZipStream(ms, CompressionMode.Decompress);
                        break;
                }

                int len = 4096;

                while (true)
                {
                    int oldLen = buffer.Length;
                    Array.Resize(ref buffer, oldLen + len);
                    int size = s.Read(buffer, oldLen, len);
                    if (size != len)
                    {
                        Array.Resize(ref buffer, buffer.Length - (len - size));
                        break;
                    }
                    if (size <= 0)
                        break;
                }
                s.Close();

                return buffer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static bool Compress(string fileIn, string fileOut, string mode)
        {
            if (BasicIO.WriteStreamToFile(fileOut, Compress(BasicIO.ReadStreamFromFile(fileIn), mode)))
            {
                /*int sSize = BasicIO.GetFileSize(fileIn);
                int tSize = BasicIO.GetFileSize(fileOut);
                float ratio = ((sSize - tSize) / (float)sSize) * 100;
                */
                //return string.Format("Compressed Successfully! Ratio: {0}%", ratio.ToString().Substring(0, ratio.ToString().LastIndexOf(".") + 3));
                //return "OK!!";
                return true;
            }
            else
                //return "Operation Interruppted!";
                //return "FAILED!!";
                return false;
            }

        public static bool Decompress(string fileIn, string fileOut, string mode)
        {
            if (BasicIO.WriteStreamToFile(fileOut, Decompress(BasicIO.ReadStreamFromFile(fileIn), mode)))
                //return "UnCompressed Successfully!";
                return true;
            else
                //return "Operation Interruppted!";
                return false;
        }
    }
}
