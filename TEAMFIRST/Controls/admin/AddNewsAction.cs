using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAMFIRST.Controls.admin
{
    public class AddNewsAction
    {
        public bool Add(HttpContext context)
        {
            bool istrue = false;
            if (VerifyRequest(context.Request))
            {
                string sql = "insert into newsmsg (msgtitle,msgcontent,state,addtime) values"
                    + " ('" + common.requestForm("MsgTitle") + "','" + common.requestForm("elm1") + "',1,datetime(CURRENT_TIMESTAMP,'localtime'))";
                SQLiteHelper.ExecuteSql(sql);

                istrue = true;
            }

            return istrue;
        }

        public bool Deal(HttpContext context)
        {
            bool istrue = false;
            int state = Convert.ToInt16(common.requestForm("state"));
            int newState = (state + 1) % 2;
            string sql = "update newsmsg set state=" + newState + " where msgid=" + common.requestForm("msgid");
            int count = SQLiteHelper.ExecuteSql(sql);

            if (count > 0)
                istrue = true;

            return istrue;
        }

        public bool Edit(HttpContext context)
        {
            bool istrue = false;
            string sql = "update newsmsg set msgtitle='" + common.requestForm("MsgTitle") + "',msgcontent='"
                + common.requestForm("elm1") + "' where msgid=" + common.requestForm("msgid");
            int count = SQLiteHelper.ExecuteSql(sql);

            if (count > 0)
                istrue = true;

            return istrue;
        }

        //验证返回数据的正确性
        private bool VerifyRequest(HttpRequest request)
        {
            bool istrue = true;

            //验证数据是否异常
            if (string.IsNullOrEmpty(common.requestForm("MsgTitle")) || string.IsNullOrEmpty(common.requestForm("elm1")))
            {
                istrue = false;
            }

            return istrue;
        }
    }
}