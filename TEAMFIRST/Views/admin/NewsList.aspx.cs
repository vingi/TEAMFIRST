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
    public partial class NewsList : System.Web.UI.Page
    {
        protected string content = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLiteParameter[] param = null;
            string sql = "select msgid,msgtitle,strftime('%Y-%m-%d %H:%M:%S', addtime) adddate,state from newsmsg order by addtime desc";
            DataSet ds = TEAMFIRST.Controls.SQLiteHelper.Query(sql, param);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int state = Convert.ToInt16(ds.Tables[0].Rows[i]["state"].ToString());
                String stateStr = "正常";
                if (state == 0)
                {
                    stateStr = "已删除";
                }
                sb.Append("<tr style=\"height:22px;\" onmouseover=\"changecolor(this)\" onmouseout=\"returncolor(this)\">");
                sb.AppendFormat("<td class=\"border_lbr\">{0}</td><td class=\"border_br\">{1}</td>",
                    ds.Tables[0].Rows[i]["msgtitle"].ToString(), ds.Tables[0].Rows[i]["adddate"].ToString());
                sb.AppendFormat("<td class=\"border_br\">{0}</td><td class=\"border_br\"><a href=\"#\" onclick=\"javascript:dealNews({1},{2});\">變更狀態</a>｜",
                    stateStr, ds.Tables[0].Rows[i]["msgid"].ToString(), state);
                sb.AppendFormat("<a href=\"/Views/admin/EditNews.aspx?msgId={0}\">編輯</a>｜",
                    ds.Tables[0].Rows[i]["msgid"].ToString());
                sb.AppendFormat("<a href=\"/Views/news.aspx?naviPage=navi1&msgId={0}\" target=\"_blank\">瀏覽</a></td>",
                    ds.Tables[0].Rows[i]["msgid"].ToString());
                sb.Append("</tr>");

            }
            content = sb.ToString();
        }
    }
}