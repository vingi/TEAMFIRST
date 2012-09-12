using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAMFIRST.Controls.admin
{
    /// <summary>
    /// UploadPic 的摘要说明
    /// </summary>
    public class UploadPic : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpRequest rq = HttpContext.Current.Request;
            foreach (var item in rq.Form)
            {
                string tt = item.ToString();
                string aa = string.Empty;
            }


            //HttpFileCollection files = HttpContext.Current.Request.Files;
            //int tt = files.Count;

            string filepath = common.requestForm("filedata");
            context.Response.Write("Hello World");
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