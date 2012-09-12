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
    public partial class paper_detail : System.Web.UI.Page
    {
        protected string title = string.Empty;
        protected string adddate = string.Empty;
        protected string content = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLiteParameter[] param = null;
            string sql = "select newsid,newstitle,strftime('%Y-%m-%d', addtime) adddate,newscontent from newspaper where state=1 and newsid="
                + common.requestQueryString("newsid") + " order by addtime desc";
            DataSet ds = TEAMFIRST.Controls.SQLiteHelper.Query(sql, param);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                title = ds.Tables[0].Rows[i]["newstitle"].ToString();
                adddate = ds.Tables[0].Rows[i]["adddate"].ToString().Replace("-",".");
                content = ds.Tables[0].Rows[i]["newscontent"].ToString().Replace("&quot;","\"")
                    .Replace("&lt;","<").Replace("&gt;",">").Replace("&nbsp"," ");
                break;
            }

        }
    }
}