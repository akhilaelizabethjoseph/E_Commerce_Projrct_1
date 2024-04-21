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
    public partial class userhomepg : System.Web.UI.Page
    {
        Cls1 ob = new Cls1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s = "select categoryid,categoryimage,categoryname,categorydescription from categorytab";
                DataSet ds = ob.fn_adapter(s);
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }

       

        protected void ImageButton1_Command1(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Session["cid"] = id;
            Response.Redirect("userproductviewpg.aspx");

            
        }
    }
}