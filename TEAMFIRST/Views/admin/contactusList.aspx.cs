using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.Data;
using System.Text;

namespace TEAMFIRST.Views.admin
{
    public partial class contactusList : System.Web.UI.Page
    {
        protected string content = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLiteParameter[] param = null;
            string sql = "select * from contactus order by addtime desc";
            DataSet ds = TEAMFIRST.Controls.SQLiteHelper.Query(sql, param);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++) {
                string rw =ds.Tables[0].Rows[i]["username"].ToString();
                sb.Append("<tr style=\"height:22px;\" onmouseover=\"changecolor(this)\" onmouseout=\"returncolor(this)\">");
                sb.AppendFormat("<td class=\"border_lbr\">{0}</td><td class=\"border_br\">{1}</td>", 
                    ds.Tables[0].Rows[i]["username"].ToString(), ds.Tables[0].Rows[i]["mobile"].ToString());
                sb.AppendFormat("<td class=\"border_br\">{0}</td><td class=\"border_br\">{1}</td>",
                    ds.Tables[0].Rows[i]["email"].ToString(), ds.Tables[0].Rows[i]["addtime"].ToString());
                sb.AppendFormat("<td class=\"border_br\" style=\"text-align:center;\"><a href=\"#\" onclick=\"javascript:showContent('row{0}');\">查看</a></td>",i.ToString());
                sb.Append("</tr>");
                sb.AppendFormat("<tr style=\"height:22px;display:none;\" id=\"row{0}\">", i.ToString());
                sb.AppendFormat("<td class=\"border_lbr\" colspan=\"5\">{0}</td>",
                    ds.Tables[0].Rows[i]["msgcontent"].ToString());
                sb.Append("</tr>");
            }
            content = sb.ToString();
        }
    }
}