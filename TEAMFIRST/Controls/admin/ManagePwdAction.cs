using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace TEAMFIRST.Controls.admin
{
    public class ManagePwdAction
    {
        public bool Modify(HttpContext context)
        {
            bool istrue = false;
            if (VerifyRequest(context.Request))
            {
                string userName = context.Request.Cookies["username"].Value;
                userName = Encrypt.DESDecrypt(userName).Replace(System.Configuration.ConfigurationManager.AppSettings["AccountKey"], "");
                string sql = "select * from adminUser where UserName='" + userName + "' and state=1";

                if (SQLiteHelper.Exists(sql))
                {
                    sql = "update adminUser set UserPwd='" + Encrypt.MD5Encrypt(common.requestForm("AgainPwd"))+"' where state=1 and UserName='" + userName + "'";
                    SQLiteHelper.ExecuteSql(sql);
                    istrue = true;
                }
            }

            return istrue;
        }

        //验证返回数据的正确性
        private bool VerifyRequest(HttpRequest request)
        {
            bool istrue = true;

            //验证数据是否异常
            if (string.IsNullOrEmpty(common.requestForm("OldPwd")) || string.IsNullOrEmpty(common.requestForm("AgainPwd")))
            {
                istrue = false;
            }

            return istrue;
        }
    }
}