using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TEAMFIRST.Views.admin
{
    public partial class ManagePwd : System.Web.UI.Page
    {
        protected string userName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            userName = Request.Cookies["username"].Value;
            userName = Encrypt.DESDecrypt(userName).Replace(System.Configuration.ConfigurationManager.AppSettings["AccountKey"], "");
        }
    }
}