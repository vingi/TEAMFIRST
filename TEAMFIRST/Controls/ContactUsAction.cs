using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAMFIRST.Controls
{
    public class ContactUsAction
    {
        public bool Add(HttpContext context)
        {
            bool istrue = false;
            if (VerifyRequest(context.Request))
            {
                TEAMFIRST.Models.ContactUs model = new TEAMFIRST.Models.ContactUs();
                model.UserName = common.requestForm("UserName");
                model.Mobile = common.requestForm("Mobile");
                model.Email = common.requestForm("Email");
                model.MsgContent = common.requestForm("MsgContent");
                string sql = "insert into ContactUs (username,email,mobile,msgcontent,addtime) values"
                    + " ('" + model.UserName + "','" + model.Email + "','" + model.Mobile + "','" + model.MsgContent+"',datetime(CURRENT_TIMESTAMP,'localtime'))";
                SQLiteHelper.ExecuteSql(sql);

                istrue = true;
            }

            return istrue;
        }

        //验证返回数据的正确性
        private bool VerifyRequest(HttpRequest request)
        {
            bool istrue = true;

            //验证数据是否异常
            if (string.IsNullOrEmpty(common.requestForm("MsgContent")))
            {
                istrue = false;
            }

            return istrue;
        }
    }
}