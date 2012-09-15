using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAMFIRST.Controls.admin
{
    public class AddPaperAction
    {
        public bool Add(HttpContext context)
        {
            bool istrue = false;
            if (VerifyRequest(context.Request))
            {
                string sql = "insert into newspaper (newstitle,newscontent,newsimg,state,addtime) values"
                    + " ('" + common.requestForm("NewsTitle") + "','" + common.requestForm("elm1") + "','" + common.requestForm("img") + "' ,1,datetime(CURRENT_TIMESTAMP,'localtime'))";
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
            string sql = "update newspaper set state=" + newState + " where newsid=" + common.requestForm("newsid");
            int count = SQLiteHelper.ExecuteSql(sql);

            if (count > 0)
                istrue = true;

            return istrue;
        }

        public bool Edit(HttpContext context)
        {
            bool istrue = false;
            string sql = "update newspaper set newstitle='" + common.requestForm("NewsTitle") + "',newscontent='"
                + common.requestForm("elm1") + "',newsimg = '" + common.requestForm("img") + "' where newsid=" + common.requestForm("newsid");
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
            if (string.IsNullOrEmpty(common.requestForm("NewsTitle")) || string.IsNullOrEmpty(common.requestForm("elm1")))
            {
                istrue = false;
            }

            return istrue;
        }
    }
}