using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace TEAMFIRST
{
    public class common
    {

        #region 防止XSS注入 获取request
        /// <summary>
        /// 防止XSS注入 获取request
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string request(string str)
        {
            string returnstr = string.Empty;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request[str]))
                returnstr = XSSInject.XSSInject.FilterXSS(System.Web.HttpContext.Current.Request[str].Trim());

            return returnstr;
        }

        public static string requestForm(string str)
        {
            string returnstr = string.Empty;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form[str]))
                returnstr = XSSInject.XSSInject.FilterXSS(System.Web.HttpContext.Current.Request.Form[str].Trim());

            return returnstr;
        }

        public static string requestQueryString(string str)
        {
            string returnstr = string.Empty;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString[str]))
                returnstr = XSSInject.XSSInject.FilterXSS(System.Web.HttpContext.Current.Request.QueryString[str].Trim());

            return returnstr;
        }

        public static string requestCookies(string str)
        {
            string returnstr = string.Empty;
            if (System.Web.HttpContext.Current.Request.Cookies[str] != null)
                returnstr = XSSInject.XSSInject.FilterXSS(System.Web.HttpContext.Current.Request.Cookies[str].Value.Trim());

            return returnstr;
        }
        #endregion

        #region 过滤SQL注入;
        /// <summary>
        /// 过滤SQL注入;
        /// </summary>
        /// <param name="str">传入string进行SQL过滤</param>
        public static string Sqlstr(string str)
        {
            str = str.Trim();
            if (str == "" || str == string.Empty || str == null)
                return "";

            str = str.Replace(';', '；');
            str = str.Replace('(', '（');
            str = str.Replace(')', '）');

            return str;
        }
        #endregion

        #region  字符串过滤方法
        // 在 petshop 的字符过滤基础上修改
        public static string TextBoxText(string TextBoxString)
        {


            StringBuilder retVal = new StringBuilder();

            // check incoming parameters for null or blank string
            if ((TextBoxString != null) && (TextBoxString != String.Empty))
            {
                TextBoxString = TextBoxString.Trim();

                //chop the string incase the client-side max length
                //fields are bypassed to prevent buffer over-runs
                //if (TextBoxString.Length > maxLength)
                //    TextBoxString = TextBoxString.Substring(0, maxLength);

                //convert some harmful symbols incase the regular
                //expression validators are changed
                for (int i = 0; i < TextBoxString.Length; i++)
                {
                    switch (TextBoxString[i])
                    {
                        case '"':
                            retVal.Append("&quot;");
                            break;
                        case '<':
                            retVal.Append("&lt;");
                            break;
                        case '>':
                            retVal.Append("&gt;");
                            break;
                        case ' ':
                            retVal.Append("&nbsp");
                            break;
                        case '\n':
                            retVal.Append("<br>");
                            break;
                        default:
                            retVal.Append(TextBoxString[i]);
                            break;
                    }
                }

                // Replace single quotes with white space
                retVal.Replace("'", " ");
            }

            return retVal.ToString();

        }
        #endregion

        #region 执行正则提取出值
        //执行正则提取出值#region 执行正则提取出值
        /**/
        /**********************************
         * 函数名称:GetRegValue
         * 功能说明:执行正则提取出值
         * 参    数:HtmlCode:html源代码
         * 调用示例:
         *          string GetValue=GetRegValue(Reg,HtmlCode)
         *          Response.Write(GetValue);
         * ********************************/
        /**/
        /// <summary>
        /// 执行正则提取出值
        /// </summary>
        /// <param name="Reg">正则表达式</param>
        /// <param name="HtmlCode">HtmlCode源代码</param>
        /// <returns></returns>
        public static string GetRegValue(string RegexString, string RemoteStr)
        {
            string MatchVale = "";
            //string MatchVale = "0";  //为预防正则匹配为空值,导致insert into失败而修改
            Regex r = new Regex(RegexString);
            Match m = r.Match(RemoteStr);
            if (m.Success)
            {
                MatchVale = m.Value;
            }
            return MatchVale.Replace("\r", "").Replace("\n", "");
        }
        #endregion

    }
}