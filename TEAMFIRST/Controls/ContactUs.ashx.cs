using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAMFIRST.Controls
{
    /// <summary>
    /// ContactUs 的摘要说明
    /// </summary>
    public class ContactUs : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            TEAMFIRST.Controls.ContactUsAction action = new TEAMFIRST.Controls.ContactUsAction();

            if (action.Add(context))
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