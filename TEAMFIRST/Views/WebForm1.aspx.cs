using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TEAMFIRST.Controls;

namespace TEAMFIRST.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet dt = SQLiteHelper.Query("Select * from Users ");
            Response.Write(dt.Tables[0].Rows[1][1].ToString());
            //SQLiteHelper.ExecuteSql("insert into users values ('123456')");
        }
    }
}