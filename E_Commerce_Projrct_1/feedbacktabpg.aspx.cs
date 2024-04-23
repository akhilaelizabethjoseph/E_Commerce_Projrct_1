using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace E_Commerce_Projrct_1
{
    public partial class feedbacktabpg : System.Web.UI.Page
    {
        Cls1 ob = new Cls1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(Session["uid"]);
            string str = "insert into feedbacktab values(" + userid + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','pending')";
            int i5 = ob.fn_exequery(str);
        }
    }
}