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
        protected string newshidden = string.Empty;
        protected string newsImg = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLiteParameter[] param = null;
            string sql = "select newsid,newstitle,strftime('%Y-%m-%d', addtime) adddate,newscontent,newsimg from newspaper where newsid="
                + common.requestQueryString("newsid") + " order by addtime limit 1";
            DataSet ds = TEAMFIRST.Controls.SQLiteHelper.Query(sql, param);
            string temp_imgstr = string.Empty;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                newsId = ds.Tables[0].Rows[i]["newsid"].ToString();
                newsTitle = ds.Tables[0].Rows[i]["newstitle"].ToString();
                newsContent = ds.Tables[0].Rows[i]["newscontent"].ToString().Replace("&amp;", "&").Replace("&quot;", "\"")
                    .Replace("&lt;", "<").Replace("&gt;", ">").Replace("&nbsp;", " ");
                newshidden = ds.Tables[0].Rows[i]["newsimg"].ToString();
            }
            string[] imgs = newshidden.Split(',');
            for (int i = 0; i < imgs.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                if (imgs[i].Length > 3)
                {
                    //<div id="SWFUpload_0_1" class="uploadifyQueueItem">
                        //<div class="cancel" onclick="jQuery('#uploadify').uploadifyCancel('SWFUpload_0_1')">
                        //<img src="/Assets/uploadify/close.png" border="0">								
                        //</div>                                
                        //<div class="uploadifyImageShow"><img src="http://uimg.twhouses.com.tw/uploads/2012/9/15/37534235256387thumb.jpg" alt="" class="ImageShow"></div>
                        //<span class="fileName"> </span>															
                    //</div>
                    sb.Append("<div id=\"SWFUpload_0_" + (i+1).ToString() + "\" class=\"uploadifyQueueItem\">");
                    sb.Append("<div class=\"cancel\" onclick=\"jQuery('#uploadify').uploadifyCancel('SWFUpload_0_" + (i + 1).ToString() + "')\"><img src=\"/Assets/uploadify/close.png\" border=\"0\"></div>");
                    sb.Append("<div class=\"uploadifyImageShow\"><img src=\"" + imgs[i] + "\" width=\"152\" height=\"102\"  alt=\"\" class=\"ImageShow\"></div>");
                    sb.Append("<span class=\"fileName\"> </span>");
                    sb.Append("</div>");
                    newsImg += sb.ToString();
                }
            }

        }
    }
}