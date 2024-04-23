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
    public partial class viewfeedbackpg : System.Web.UI.Page
    {
        Cls1 ob = new Cls1();
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = "select * from feedbacktab where status='pending'";
            DataSet ds = ob.fn_adapter(str);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtreply = (TextBox)GridView1.Rows[i].Cells[3].Controls[0];
            TextBox txtstats = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];
            string strup = "update feedbacktab set reply='" + txtreply.Text + "',status='" + txtstats.Text + "'where feedbackid=" + getid + "";
            int io = ob.fn_exequery(strup);
            GridView1.EditIndex = -1;
        }
    }
}