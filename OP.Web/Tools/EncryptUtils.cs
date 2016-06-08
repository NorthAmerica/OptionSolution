﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Security.Cryptography;
using System.IO;

namespace OP.Web.Tools
{
    public sealed class EncryptUtils
    {
        #region Base64加密解密
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <returns></returns>
        public static string Base64Encrypt(string input)
        {
            return Base64Encrypt(input, new UTF8Encoding());
        }

        /// <summary>
                /// Base64加密
                /// </summary>
                /// <param name="input">需要加密的字符串</param>
                /// <param name="encode">字符编码</param>
                /// <returns></returns>
        public static string Base64Encrypt(string input, Encoding encode)
        {
            return Convert.ToBase64String(encode.GetBytes(input));
        }

        /// <summary>
                /// Base64解密
                /// </summary>
                /// <param name="input">需要解密的字符串</param>
                /// <returns></returns>
        public static string Base64Decrypt(string input)
        {
            return Base64Decrypt(input, new UTF8Encoding());
        }

        /// <summary>
                /// Base64解密
                /// </summary>
                /// <param name="input">需要解密的字符串</param>
                /// <param name="encode">字符的编码</param>
                /// <returns></returns>
        public static string Base64Decrypt(string input, Encoding encode)
        {
            return encode.GetString(Convert.FromBase64String(input));
        }
        #endregion
    }
}
