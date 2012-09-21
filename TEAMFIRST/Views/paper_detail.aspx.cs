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
        protected string img1 = string.Empty;
        protected string img2 = string.Empty;
        protected string img3 = string.Empty;
        protected string prePage = string.Empty;
        protected string nextPage = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLiteParameter[] param = null;
            string sql = "";
            if (string.IsNullOrEmpty(common.requestQueryString("view")))
            {
                sql = "select newsid,newstitle,strftime('%Y-%m-%d', addtime) adddate,newscontent,newsimg from newspaper where state=1 and newsid="
                    + common.requestQueryString("newsid");
            }
            else
            {
                sql = "select newsid,newstitle,strftime('%Y-%m-%d', addtime) adddate,newscontent,newsimg from newspaper where newsid="
                    + common.requestQueryString("newsid");
            }

            DataSet ds = TEAMFIRST.Controls.SQLiteHelper.Query(sql, param);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                title = ds.Tables[0].Rows[i]["newstitle"].ToString();
                adddate = ds.Tables[0].Rows[i]["adddate"].ToString().Replace("-",".");
                content = ds.Tables[0].Rows[i]["newscontent"].ToString().Replace("&quot;","\"")
                    .Replace("&lt;","<").Replace("&gt;",">").Replace("&nbsp;"," ");
                string newsimg = ds.Tables[0].Rows[i]["newsimg"].ToString();
                string[] imgs = newsimg.Split(',');
                for (int j = 0; j < imgs.Length; j++)
                {
                    if (j == 1)
                    {
                        img1 = "<img src=\"" + imgs[j] + "\" width=\"152\" height=\"102\"  alt=\"\" border=\"0\">";
                    }
                    else if (j == 2)
                    {
                        img2 = "<img src=\"" + imgs[j] + "\" width=\"152\" height=\"102\"  alt=\"\" border=\"0\">";
                    }
                    else if (j == 3)
                    {
                        img3 = "<img src=\"" + imgs[j] + "\" width=\"152\" height=\"102\"  alt=\"\" border=\"0\">";
                    }
                }
            }

            sql = "select newsid from newspaper where newsid<"
                + common.requestQueryString("newsid")+" and state=1 order by newsid desc limit 1";
            ds = TEAMFIRST.Controls.SQLiteHelper.Query(sql, param);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                prePage = "<a href=\"/Views/paper_detail.aspx?naviPage=navi5&newsId=" + ds.Tables[0].Rows[i]["newsid"].ToString() 
                    + "\"><img width=\"15\" height=\"59\" src=\"/Assets/Images/pre_page.png\" alt=\"\" /></a>";
            }
            sql = "select newsid from newspaper where newsid>"
                + common.requestQueryString("newsid") + " and state=1 order by newsid limit 1";
            ds = TEAMFIRST.Controls.SQLiteHelper.Query(sql, param);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                nextPage = "<a href=\"/Views/paper_detail.aspx?naviPage=navi5&newsId=" + ds.Tables[0].Rows[i]["newsid"].ToString()
                    + "\"><img width=\"15\" height=\"59\" src=\"/Assets/Images/next_page.png\" alt=\"\" /></a>";
            }
        }
    }
}