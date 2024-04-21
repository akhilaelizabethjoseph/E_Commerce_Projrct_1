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
    public partial class producteditpg : System.Web.UI.Page
    {
        Cls1 ob = new Cls1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str = "select productid,productname,productprice,productstock,productstatus from producttab";
                DataSet ds = ob.fn_adapter(str);
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
            TextBox txtproprice = (TextBox)GridView1.Rows[i].Cells[3].Controls[0];
            TextBox txtstk = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];
            TextBox txtsts = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            string str = "update producttab set productprice=" + txtproprice.Text + ",productstock='" + txtstk.Text + "',productstatus='"+txtsts.Text+"'where productid=" + getid + "";
            int i1 = ob.fn_exequery(str);
            



        }
    }
}