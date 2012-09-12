using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAMFIRST.Controls.admin
{
    /// <summary>
    /// AddNews 的摘要说明
    /// </summary>
    public class AddNews : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            TEAMFIRST.Controls.admin.AddNewsAction action = new TEAMFIRST.Controls.admin.AddNewsAction();
            string op = common.requestForm("op");
            if ("deal".Equals(op))
            {
                if (action.Deal(context))
                {
                    context.Response.Write("1");
                }
                else
                    context.Response.Write("0");
            }
            else if ("edit".Equals(op))
            {
                if (action.Edit(context))
                {
                    context.Response.Write("1");
                }
                else
                    context.Response.Write("0");
            }
            else
            {
                if (action.Add(context))
                {
                    context.Response.Write("1");
                }
                else
                    context.Response.Write("0");
            }

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