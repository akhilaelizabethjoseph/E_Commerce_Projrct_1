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
    public partial class logindesign1 : System.Web.UI.Page
    {
        Cls1 ob = new Cls1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(userid) from logintab where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
            string cid = ob.fn_scalar(str);
            if (cid == "1")
            {
                string sel = "select userid from logintab where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                string userid = ob.fn_scalar(sel);
                Session["uid"] = userid;
                string str2 = "select logtype from logintab where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                string logtype = ob.fn_scalar(str2);
                if (logtype == "admin")
                {
                    Response.Redirect("adminreg.aspx");
                }
                else if (logtype == "user")
                {
                    Response.Redirect("userhomepg.aspx");
                }



            }
            else
            {
                Label1.Text = "invalid  username and password";
            }

        }
    }
}