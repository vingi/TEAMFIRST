﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace TEAMFIRST
{
    public class Encrypt
    {
        /// <summary>
        /// 当前程序加密所使用的密钥

        /// </summary>
        public static readonly string sKey = "vingiDES";

        #region 加密方法
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="pToEncrypt">需要加密字符串</param>
        /// <param name="sKey">密钥</param>
        /// <returns>加密后的字符串</returns>
        public static string DESEncrypt(string pToEncrypt)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                //把字符串放到byte数组中


                //原来使用的UTF8编码，我改成Unicode编码了，不行
                byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);

                //建立加密对象的密钥和偏移量


                //使得输入密码必须输入英文文本
                des.Key = Encoding.UTF8.GetBytes(sKey);
                des.IV = Encoding.UTF8.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                ret.ToString();
                return ret.ToString();
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("写入配置信息失败，详细信息：" + ex.Message.Replace("\r\n", "").Replace("'", ""));
            }

            return "";
        }
        #endregion

        #region 解密方法
        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="pToDecrypt">需要解密的字符串</param>
        /// <param name="sKey">密匙</param>
        /// <returns>解密后的字符串</returns>
        public static string DESDecrypt(string pToDecrypt)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                //建立加密对象的密钥和偏移量，此值重要，不能修改
                des.Key = Encoding.UTF8.GetBytes(sKey);
                des.IV = Encoding.UTF8.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象
                StringBuilder ret = new StringBuilder();
                return System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write("读取配置信息失败，详细信息：" + ex.Message.Replace("\r\n", "").Replace("'", ""));
            }
            return "";
        }
        #endregion


        #region MD5编码方法
        /// <summary>
        /// MD5编码方法
        /// </summary>
        /// <param name="pToDecrypt">需要编码的字符串</param>
        /// <returns>编码后的字符串</returns>
        public static string MD5Encrypt(string pToEncrypt)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pToEncrypt, "MD5");
        }
        #endregion

        #region SHA1编码方法
        /// <summary>
        /// MD5编码方法
        /// </summary>
        /// <param name="pToDecrypt">需要编码的字符串</param>
        /// <returns>编码后的字符串</returns>
        public static string SHA1Encrypt(string pToEncrypt)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pToEncrypt, "SHA1");
        }
        #endregion

    }

}
