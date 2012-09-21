using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.Data;
using System.Text;

namespace TEAMFIRST.Views
{
    public partial class news : System.Web.UI.Page
    {
        protected string content = string.Empty;
        protected string leftUrl = string.Empty;
        protected string rightUrl = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLiteParameter[] param = null;
            string sql = "";
            int msgid = Int16.Parse(common.requestQueryString("msgid"));
            if (string.IsNullOrEmpty(common.requestQueryString("view")))
            {
                sql = "select msgcontent from NewsMsg where state=1 and msgid=" + msgid;
            }
            else
            {
                sql = "select msgcontent from NewsMsg where msgid=" + msgid;
            }

            DataSet ds = TEAMFIRST.Controls.SQLiteHelper.Query(sql, param);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                content = ds.Tables[0].Rows[i]["msgcontent"].ToString().Replace("&amp;", "&").Replace("&quot;", "\"")
                    .Replace("&lt;", "<").Replace("&gt;", ">").Replace("&nbsp;", " ");
            }

            sql = "select msgid from newsmsg where state=1 order by msgid desc limit 2";
            ds = TEAMFIRST.Controls.SQLiteHelper.Query(sql, param);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int id = Int16.Parse(ds.Tables[0].Rows[i]["msgid"].ToString());
                if (i == 0)
                {
                    if (id == msgid)
                        leftUrl = "<a href=\"/Views/news.aspx?naviPage=navi1&msgid=" + id
                            + "\" ><img src=\"/Assets/Images/icon1.png\" width=\"8\" height=\"7\"  alt=\"\" border=\"0\"></a>";
                    else
                        leftUrl = "<a href=\"/Views/news.aspx?naviPage=navi1&msgid=" + id 
                            + "\" ><img src=\"/Assets/Images/icon2.png\" width=\"8\" height=\"7\"  alt=\"\" border=\"0\"></a>";
                }
                else
                {
                    if (id == msgid)
                        rightUrl = "<a href=\"/Views/news.aspx?naviPage=navi1&msgid=" + id
                            + "\" ><img src=\"/Assets/Images/icon1.png\" width=\"8\" height=\"7\"  alt=\"\" border=\"0\"></a>";
                    else
                        rightUrl = "<a href=\"/Views/news.aspx?naviPage=navi1&msgid=" + id
                            + "\" ><img src=\"/Assets/Images/icon2.png\" width=\"8\" height=\"7\"  alt=\"\" border=\"0\"></a>";
                }
            }
        }
    }
}