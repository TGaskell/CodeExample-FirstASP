using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ArrayList myCart = (ArrayList)Session["cart"];

            string str = string.Empty;
            foreach (string products in myCart)
            {
                str += products + ", ";
            }

            str = str.Substring(0, str.Length - 1);
            lblCartList.Text = str;
        }
        else
        {
            lblCartList.Text = string.Empty;
        }
    }
 }