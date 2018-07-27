using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NTCore.Utility
{
    public static class EncryptHelper
    {
        #region DES

        public const string DESKey = "6495CD95288E49EA9FBBA2BFA5A889AA";

        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string DESEncrypt(string text, string sKey = DESKey)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(sKey))
            {
                return string.Empty;
            }

            sKey = sKey.PadRight(8, ' ');
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.Default.GetBytes(text);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey.Substring(0, 8));
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey.Substring(0, 8));
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                return ret.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string DESDecrypt(string text, string sKey = DESKey)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(sKey))
            {
                return string.Empty;
            }

            sKey = sKey.PadRight(8, ' ');
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                var len = text.Length / 2;
                byte[] inputByteArray = new byte[len];
                int x, i;
                for (x = 0; x < len; x++)
                {
                    i = Convert.ToInt32(text.Substring(x * 2, 2), 16);
                    inputByteArray[x] = (byte)i;
                }
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey.Substring(0, 8));
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey.Substring(0, 8));
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Encoding.Default.GetString(ms.ToArray());
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        #endregion

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(i.ToString("x2"));
            }
            return builder.ToString();
        }




    }
}
