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
    public partial class singleproductpg : System.Web.UI.Page
    {
        Cls1 ob = new Cls1();
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = "select productimage,productname,productdescription,productprice from producttab where productid='" + Session["pid"] + "'";
            SqlDataReader dr = ob.fn_reader(str);
            while (dr.Read())
            {
                Image1.ImageUrl = dr["productimage"].ToString();
                Label1.Text = dr["productname"].ToString();
                Label2.Text = dr["productdescription"].ToString();
                Label3.Text = dr["productprice"].ToString();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel21 = "select max(cartid) from carttab";
            string userid = ob.fn_scalar(sel21);
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
            Label4.Text = TextBox1.Text;
            int pid = Convert.ToInt32(Session["pid"]);
            int uid1 = Convert.ToInt32(Session["uid"]);
            string str = "select productprice from producttab where productid=" + pid + "";
            string st = ob.fn_scalar(str);
            int pr = Convert.ToInt32(st);

            int q = Convert.ToInt32(TextBox1.Text);
            int d = pr * q;
            
            decimal d1 = Convert.ToDecimal(d);
            string s = "available";
            string ins = "insert into carttab values("+user_id+"," + pid+ ","+uid1+",'" + TextBox1.Text + "'," + d + ",'" + s + "')";
            ob.fn_exequery(ins);
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userhomepg.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("cartpg.aspx");
        }
    }
}