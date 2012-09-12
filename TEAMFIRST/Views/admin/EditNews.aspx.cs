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
    public partial class EditNews : System.Web.UI.Page
    {
        protected string msgId = string.Empty;
        protected string msgTitle = string.Empty;
        protected string msgContent = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLiteParameter[] param = null;
            string sql = "select msgid,msgtitle,strftime('%Y-%m-%d', addtime) adddate,msgcontent from newsmsg where msgid="
                + common.requestQueryString("msgid") + " order by addtime desc";
            DataSet ds = TEAMFIRST.Controls.SQLiteHelper.Query(sql, param);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                msgId = ds.Tables[0].Rows[i]["msgid"].ToString();
                msgTitle = ds.Tables[0].Rows[i]["msgtitle"].ToString();
                msgContent = ds.Tables[0].Rows[i]["msgcontent"].ToString().Replace("&quot;", "\"")
                    .Replace("&lt;", "<").Replace("&gt;", ">").Replace("&nbsp", " ");
                break;
            }


        }
    }
}