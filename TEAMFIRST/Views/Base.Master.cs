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
    public partial class Base : System.Web.UI.MasterPage
    {
        protected string msgid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLiteParameter[] param = null;
            string sql = "select msgid from newsmsg where state=1 order by msgid desc limit 1";
            DataSet ds = TEAMFIRST.Controls.SQLiteHelper.Query(sql, param);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                msgid = ds.Tables[0].Rows[i]["msgid"].ToString();
            }
        }
    }
}