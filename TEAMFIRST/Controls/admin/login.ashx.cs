using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAMFIRST.Controls.admin
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //lengue  wlc_2012_
            context.Response.ContentType = "text/plain";
            TEAMFIRST.Controls.admin.loginAction action = new TEAMFIRST.Controls.admin.loginAction();

            if (action.Login(context))
            {
                context.Response.Write("1");
            }
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