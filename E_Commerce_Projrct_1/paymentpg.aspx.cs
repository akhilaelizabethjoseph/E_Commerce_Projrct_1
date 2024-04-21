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
    public partial class paymentpg : System.Web.UI.Page
    {
        Cls1 ob = new Cls1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(Session["userid"]);
            Service_balance1.ServiceClient obj = new Service_balance1.ServiceClient();
            string bal = obj.balancecheck(userid, TextBox1.Text);
            int b = Convert.ToInt32(bal);
            //Label1.Text = bal;
            string selgrant = "select granttotal from billtab where userid=" + userid + "";
            string total = ob.fn_scalar(selgrant).ToString();
            Session["total"] = total;
            int t = Convert.ToInt32(Session["total"]);
            if (t>b)
            {
                Label2.Text = "insufficient balance";
            }
            else if (b > t)
            {
                int b1 = b - t;
                string ba = b1.ToString();
                string balupdate = "update accounttab set accountbalance='"+ba+"' where userid=" + userid + " ";
                int i7 = ob.fn_exequery(balupdate);

            }





        }
    }
}