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
    public partial class billviewpg : System.Web.UI.Page
    {
        Cls1 ob = new Cls1();
        protected void Page_Load(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(Session["userid"]);
            string sel = "select billid,billdate,userid,granttotal from billtab where userid=" + Session["userid"] + "";
            SqlDataReader dr = ob.fn_reader(sel);
            while (dr.Read())
            {
                TextBox1.Text = dr["billid"].ToString();
                TextBox2.Text = dr["billdate"].ToString();
                TextBox3.Text = dr["userid"].ToString();
                TextBox4.Text = dr["granttotal"].ToString();
            }
            
            
            
        }
    }
}