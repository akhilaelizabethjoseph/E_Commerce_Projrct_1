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
    public partial class categorypg : System.Web.UI.Page
    {
        Cls1 ob = new Cls1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/akhila/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string str = "insert into categorytab values('" + TextBox1.Text + "','" + p + "','" + TextBox2.Text + "','" +DropDownList1.SelectedItem.Text+ "')";
            int i = ob.fn_exequery(str);
            if (i == 1)
            {
                Label5.Text = "category added";
            }
        }
    }
}