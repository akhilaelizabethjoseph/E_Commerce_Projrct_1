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
    public partial class adminreg : System.Web.UI.Page
    {
        Cls1 ob = new Cls1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(userid) from logintab";
            string userid = ob.fn_scalar(sel);
            int user_id = 0;
            if (userid == "")
            {
                user_id = 1;
            }
            else
            {
                int newuserid = Convert.ToInt32(userid);
                user_id = newuserid + 1;
            }
            string ins = "insert into adminregtab values(" + user_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text + ")";
            int i = ob.fn_exequery(ins);
            if (i != 0)
            {
                string inslog = "insert into logintab values(" + user_id + ",'" + TextBox4.Text + "','" + TextBox5.Text + "','admin','active')";
                int j = ob.fn_exequery(inslog);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("categorypg.aspx");
        }

        protected void category_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("categorypg.aspx");
        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("productpg.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("categoryeditpg.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("producteditpg.aspx");
        }
    }
}