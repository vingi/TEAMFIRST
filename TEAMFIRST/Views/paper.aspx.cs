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
        protected string pPage = string.Empty;
        protected string nPage = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            int prePage = 5;//每頁記錄數
            int curPage = 1;//當前頁數
            int jumpRec = 0;//跳過多少記錄
            int total = 0;
            if (!string.IsNullOrEmpty(common.requestQueryString("curPage")))
            {
                curPage = Int16.Parse(common.requestQueryString("curPage"));
            }
            jumpRec = (curPage - 1) * prePage;
            total = Int16.Parse(TEAMFIRST.Controls.SQLiteHelper.GetSingle("select count(*) from newspaper where state=1").ToString());
            SQLiteParameter[] param = null;
            string sql = "select newsid,newstitle,strftime('%Y-%m-%d', addtime) adddate from newspaper where state=1"
                + " order by newsid desc limit " + prePage + " Offset " + jumpRec;
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

            if (curPage - 1 > 0)
            {
                pPage = "<a href=\"/Views/paper.aspx?naviPage=navi5&curPage=" + (curPage - 1) + "\"><img width=\"15\" height=\"59\" src=\"/Assets/Images/pre_page.png\" alt=\"\" /></a>";
            }
            if ((curPage * prePage) < total)
            {
                nPage = "<a href=\"/Views/paper.aspx?naviPage=navi5&curPage=" + (curPage + 1) + "\"><img width=\"15\" height=\"59\" src=\"/Assets/Images/next_page.png\" alt=\"\" /></a>";
            }
        }
    }
}