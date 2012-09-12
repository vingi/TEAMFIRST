using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAMFIRST.Controls.admin
{
    /// <summary>
    /// ManagePwd 的摘要说明
    /// </summary>
    public class ManagePwd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            TEAMFIRST.Controls.admin.ManagePwdAction action = new TEAMFIRST.Controls.admin.ManagePwdAction();
            if (action.Modify(context))
                context.Response.Write("1");
            else
                context.Response.Write("0");

            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}