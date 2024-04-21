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
    public partial class userreg : System.Web.UI.Page
    {
        Cls1 ob = new Cls1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s1 = "select districtid,districtname from districttab";
                DataSet ds = ob.fn_adapter(s1);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "districtname";
                DropDownList1.DataValueField = "districtid";
                DropDownList1.DataBind();
                string s2 = "select stateid,statename from statetab";
                DataSet ds1 = ob.fn_adapter(s2);
                DropDownList2.DataSource = ds1;
                DropDownList2.DataTextField = "statename";
                DropDownList2.DataValueField = "stateid";
                DropDownList2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(userid)from logintab";
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
            //Session["uid1"] = user_id;
            string ins = "insert into userregtab values(" + user_id + ",'" + TextBox1.Text + "'," + TextBox2.Text + ",'" + TextBox3.Text + "'," + TextBox4.Text + ",'" + TextBox5.Text + "','" + DropDownList1.SelectedItem.Text + "','" + DropDownList2.SelectedItem.Text + "'," + TextBox6.Text + ",'" + TextBox7.Text + "')";
            int i = ob.fn_exequery(ins);
            string inslog = "insert into logintab values(" + user_id + ",'" + TextBox8.Text + "','" + TextBox9.Text + "','user','active')";
            int j = ob.fn_exequery(inslog);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}