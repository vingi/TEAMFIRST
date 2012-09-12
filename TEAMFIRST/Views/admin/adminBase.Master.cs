using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TEAMFIRST.Views.admin
{
    public partial class adminBase : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //验证用户权限
            if (Request.Cookies["username"] != null && !string.IsNullOrEmpty(Request.Cookies["username"].Value))
            {
                string loginName = Request.Cookies["username"].Value;
                loginName = Encrypt.DESDecrypt(loginName).Replace(System.Configuration.ConfigurationManager.AppSettings["AccountKey"], "");
                string sql = "select * from adminuser where username='" + loginName + "' and state=1";
                if (TEAMFIRST.Controls.SQLiteHelper.Exists(sql))
                {
                    //通过验证
                }
                else
                {
                    Response.Redirect("/Views/admin/login.aspx");
                }
            }
            else
            {
                Response.Redirect("/Views/admin/login.aspx");
            }
        }
    }
}