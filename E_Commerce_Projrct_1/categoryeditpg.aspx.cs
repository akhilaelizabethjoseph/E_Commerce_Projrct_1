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
    public partial class categoryeditpg : System.Web.UI.Page
    {
        Cls1 ob = new Cls1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s = "select categoryid,categoryname,categoryimage,categorydescription,categorystatus from categorytab";
                DataSet ds = ob.fn_adapter(s);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
               
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
            TextBox txtcatde = (TextBox)GridView1.Rows[i].Cells[3].Controls[0];
            //TextBox txtst = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];

            string str = "update categorytab set categorydescription='" + txtcatde.Text + "'where categoryid=" + getid + "";
            int i2 = ob.fn_exequery(str);
            GridView1.EditIndex = -1;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(GridView1.EditIndex==e.Row.RowIndex && e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)e.Row.Cells[4].FindControl("DropDownList1");
            }
        }
    }
}