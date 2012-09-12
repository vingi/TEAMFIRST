using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TEAMFIRST.Controls.admin
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpFileCollection files = Request.Files;
            int ii = files.Count;
            Response.Write("http://uimg.twhouses.com.tw/uploads/2012/8/4/452217248449147thumb.JPG");

        }
    }
}