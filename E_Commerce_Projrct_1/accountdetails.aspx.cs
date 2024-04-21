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
    public partial class accountdetails : System.Web.UI.Page
    {
        Cls1 ob = new Cls1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(Session["uid"]);
            string inseracc = "insert into accounttab values('" + TextBox1.Text + "'," + userid + ",'" + TextBox2.Text + "')";
            int i4 = ob.fn_exequery(inseracc);
            if (i4 == 1)
            {
                Label1.Text = "inserted";
            }
        }
    }
}