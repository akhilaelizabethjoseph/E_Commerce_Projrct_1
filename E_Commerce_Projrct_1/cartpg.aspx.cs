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
    public partial class cartpg : System.Web.UI.Page
    {
        Cls1 ob = new Cls1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str = "select * from carttab";
                DataSet ds = ob.fn_adapter(str);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string s = "delete from carttab where cartid=" + getid + "";
            int i1 = ob.fn_exequery(s);

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
            int pid1 = Convert.ToInt32(Session["pid"]);
            string stre = "select productprice from producttab where productid=" + pid1 + "";
            string sp = ob.fn_scalar(stre);
            decimal price = Convert.ToDecimal(sp);
            TextBox txtqua = (TextBox)GridView1.Rows[i].Cells[2].Controls[0];
            decimal q = Convert.ToDecimal(txtqua.Text);
            decimal d = price * q;

            string ssre = "update carttab set quantity='" + txtqua.Text + "',totalprice=" + d + " where cartid=" + getid + "";
            int i3 = ob.fn_exequery(ssre);
            GridView1.EditIndex = -1;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string maxstr = "select max(cartid) from carttab";
            string cid = ob.fn_scalar(maxstr);
            int i1 = Convert.ToInt32(cid);
            for (int k = 1; k <= i1; k++)
            {
                string sse = "select * from carttab where cartid=" + k + "";
                SqlDataReader dr = ob.fn_reader(sse);
                int ccartid = 0;
                int userid = 0;
                int productid = 0;
                string quantity = "";

                decimal totalprice = 0;
                while (dr.Read())
                {
                    ccartid = Convert.ToInt32(dr["cartid"].ToString());
                    userid = Convert.ToInt32(dr["userid"].ToString());
                    productid = Convert.ToInt32(dr["productid"].ToString());
                    quantity = dr["quantity"].ToString();
                    totalprice = Convert.ToDecimal(dr["totalprice"].ToString());

                }
                Session["cartid"] = ccartid;
                Session["userid"] = userid;
                Session["productid"] = productid;
                Session["totalprice"] = totalprice;
                Session["quantity"] = quantity;



                string inseorde = "insert into ordertab values(" + Session["cartid"] + "," + Session["productid"] + "," + Session["userid"] + ",'" + Session["quantity"] + "'," + Session["totalprice"] + ",'active')";
                ob.fn_exequery(inseorde);
                string delcart = "delete from carttab where cartid=" + k + "";
                ob.fn_exequery(delcart);




            }
            string stotal = "select sum(totalprice) from ordertab";
            string stt = ob.fn_scalar(stotal);
            decimal grant = Convert.ToDecimal(stt);
            
            string date = DateTime.Now.ToString();

            
            string billinsert = "insert into billtab values('"+date+"'," + Session["userid"] + "," + grant + ",'billlevel')";
            int a1 = ob.fn_exequery(billinsert);
            Response.Redirect("billviewpg.aspx");
            



            }
    }
    }

