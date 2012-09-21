using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAMFIRST.Controls.admin
{
    /// <summary>
    /// ClearFiles 的摘要说明
    /// </summary>
    public class ClearFiles : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string imgs = common.requestQueryString("imgs");
            string imgss = common.requestForm("imgs");
            context.Response.Write(1);
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