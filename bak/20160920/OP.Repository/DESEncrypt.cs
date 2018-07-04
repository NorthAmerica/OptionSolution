using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;

namespace OP.Repository
{
    /// <summary>
    /// DESEncrypt加密解密算法。 
    /// </summary>
    public sealed class DESEncrypt
    {
        private DESEncrypt()
        {
            // 
            // TODO: 在此处添加构造函数逻辑 
            // 
        }

        private static string key = "kwiner";

        /**//// <summary> 
            /// 对称加密解密的密钥 
            /// </summary> 
        public static string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }

        /// <summary> 
        /// DES加密 
        /// </summary> 
        /// <param name="encryptString"></param> 
        /// <returns></returns> 
        public static string DesEncrypt(string encryptString)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            List<byte> lb = new List<byte>();
            if (keyBytes.Length < 8)
            {
                int countnum = 0;
                foreach (var item in keyBytes)
                {
                    lb.Add(item);
                    countnum++;
                }
                while (true)
                {
                    if (countnum >= 8)
                    {
                        break;
                    }
                    lb.Add(0);
                    countnum++;
                }
                keyBytes = lb.ToArray();
            }
            else if (keyBytes.Length > 8)
            {
                keyBytes = keyBytes.Take(8).ToArray();
            }
            byte[] keyIV = keyBytes;
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Mode = CipherMode.CBC;
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, provider.CreateEncryptor(keyBytes, keyIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            //string returnstring = Encoding.UTF8.GetString(mStream.ToArray());
            return Convert.ToBase64String(mStream.ToArray());
        }

        /// <summary> 
        /// DES解密 
        /// </summary> 
        /// <param name="decryptString"></param> 
        /// <returns></returns> 
        public static string DesDecrypt(string decryptString)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            List<byte> lb = new List<byte>();
            if (keyBytes.Length < 8)
            {
                int countnum = 0;
                foreach (var item in keyBytes)
                {
                    lb.Add(item);
                    countnum++;
                }
                while (true)
                {
                    if (countnum >= 8)
                    {
                        break;
                    }
                    lb.Add(0);
                    countnum++;
                }
                keyBytes = lb.ToArray();
            }
            else if (keyBytes.Length > 8)
            {
                keyBytes = keyBytes.Take(8).ToArray();
            }
            byte[] keyIV = keyBytes;
            byte[] inputByteArray = Convert.FromBase64String(decryptString);
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Mode = CipherMode.CBC;
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, provider.CreateDecryptor(keyBytes, keyIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(mStream.ToArray());
        }
    }
}
