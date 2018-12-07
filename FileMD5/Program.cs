using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileMD5
{
    class Program
    {
        static void Main(string[] args)
        {
           
            GetMD5HashFromFile(@"D:\下载\刑碧旗日记（重口请慎入） (1).doc");
            GetMD5HashFromFile(@"D:\下载\刑碧旗日记（重口请慎入） (2).doc");
            GetMD5HashFromFile(@"D:\下载\刑碧旗日记（重口请慎入）.doc");
        }

        private static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                Console.WriteLine(sb.ToString());
                return sb.ToString();
                
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }
    }
}
