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
    public partial class EditPaper : System.Web.UI.Page
    {
        protected string newsId = string.Empty;
        protected string newsTitle = string.Empty;
        protected string newsContent = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLiteParameter[] param = null;
            string sql = "select newsid,newstitle,strftime('%Y-%m-%d', addtime) adddate,newscontent from newspaper where newsid="
                + common.requestQueryString("newsid") + " order by addtime desc";
            DataSet ds = TEAMFIRST.Controls.SQLiteHelper.Query(sql, param);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                newsId = ds.Tables[0].Rows[i]["newsid"].ToString();
                newsTitle = ds.Tables[0].Rows[i]["newstitle"].ToString();
                newsContent = ds.Tables[0].Rows[i]["newscontent"].ToString().Replace("&quot;", "\"")
                    .Replace("&lt;", "<").Replace("&gt;", ">").Replace("&nbsp", " ");
                break;
            }

        }
    }
}