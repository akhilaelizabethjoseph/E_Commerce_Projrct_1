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
    public partial class productpg : System.Web.UI.Page
    {
        Cls1 ob = new Cls1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s = "select categoryid,categoryname from categorytab";
                DataSet ds = ob.fn_adapter(s);
                DropDownList1.DataSource = ds;

                DropDownList1.DataTextField = "categoryname";
                DropDownList1.DataValueField = "categoryid";
                DropDownList1.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/akhila/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string str = "insert into producttab values(" + DropDownList1.SelectedItem.Value + ",'" + TextBox2.Text + "','" + p + "'," + TextBox3.Text + ",'" + TextBox4.Text + "','" + TextBox5.Text + "','" +TextBox6.Text + "')";
            int i = ob.fn_exequery(str);
            if (i == 1)
            {
                Label8.Text = "Product Added";
            }
        }
    }
}