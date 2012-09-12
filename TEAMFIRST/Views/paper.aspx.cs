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
    public partial class paper : System.Web.UI.Page
    {
        protected string content = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLiteParameter[] param = null;
            string sql = "select newsid,newstitle,strftime('%Y-%m-%d', addtime) adddate from newspaper where state=1 order by addtime desc";
            DataSet ds = TEAMFIRST.Controls.SQLiteHelper.Query(sql, param);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sb.AppendFormat("<div class=\"row\"><div class=\"n_date\">{0}</div><div class=\"n_split\"></div>",
                    ds.Tables[0].Rows[i]["adddate"].ToString());
                sb.AppendFormat("<div class=\"n_title\"><a href=\"/Views/paper_detail.aspx?naviPage=navi5&newsId={0}\">{1}</a></div></div>",
                    ds.Tables[0].Rows[i]["newsid"].ToString(), ds.Tables[0].Rows[i]["newstitle"].ToString());
            }
            content = sb.ToString();
        }
    }
}