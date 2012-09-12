using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TEAMFIRST.Controls.admin
{
    public class loginAction
    {
        public bool Login(HttpContext context)
        {
            bool istrue = false;
            if (VerifyRequest(context.Request))
            {

                istrue = Login(common.requestForm("username"), common.requestForm("userpwd"));
            }

            return istrue;
        }

        public bool Login(string LoginName, string Password)
        {
            bool istrue = false;

            string sql = "select * from adminuser where username='"+LoginName+"' and userpwd='"+Encrypt.MD5Encrypt(Password)+"' and state=1";
            if (SQLiteHelper.Exists(sql))
            {
                istrue = true;
                setcookie();
                sql = "update adminuser set lastlogintime=datetime(CURRENT_TIMESTAMP,'localtime') where username='" + LoginName + "' and userpwd='" + Encrypt.MD5Encrypt(Password) + "' and state=1";
                SQLiteHelper.ExecuteSql(sql);
            }

            return istrue;
        }



        //验证返回数据的正确性
        private bool VerifyRequest(HttpRequest request)
        {
            bool istrue = true;

            //验证数据是否异常
            if (string.IsNullOrEmpty(common.requestForm("username")) ||
                string.IsNullOrEmpty(common.requestForm("userpwd")))
            {
                istrue = false;
            }

            return istrue;
        }

        public void setcookie()
        {
            string _domain = ConfigurationManager.AppSettings["WebDomain"];
            HttpCookieCollection cookiecollect = new HttpCookieCollection();
            HttpCookie ck_LoginName = null;

            if (string.IsNullOrEmpty(common.requestForm("username")))
            {

            }
            else
            {
                ck_LoginName = new HttpCookie("username", Encrypt.DESEncrypt(common.requestForm("username") + System.Configuration.ConfigurationManager.AppSettings["AccountKey"]));
            }

            cookiecollect.Add(ck_LoginName);

            for (int i = 0; i < cookiecollect.Count; i++)
            {
                //cookiecollect[i].Domain = _domain;
                System.Web.HttpContext.Current.Response.Cookies.Add(cookiecollect[i]);
            }
        }
    }
}