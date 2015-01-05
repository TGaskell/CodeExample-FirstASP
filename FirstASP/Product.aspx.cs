using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Prods p = new Prods();
                p = Prods.Fetch(Convert.ToInt32(Request.QueryString["id"].ToString()));
                txtName.Text = p.Name;
                txtDescription.Text = p.Desc;
                txtSKU.Text = p.SKU;
                ddlCategory.SelectedValue = p.Categoryid;
                chkIsActive.Checked = p.Active;
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    protected void ddlCategory_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlCategory.Items.Insert(0, "Choose Category");
        }
    }
        protected void ddlCategory_OnSelectedIndexChange(object sender, EventArgs e)
    {

    }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtDescription.Text))
            {
                Prods p = new Prods();
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    p.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
                }
                else
                {
                    p.ID = 0;
                }
                    p.Name = txtName.Text;
                    p.Desc = txtDescription.Text;
                    p.SKU = txtSKU.Text;
                    p.Categoryid = ddlCategory.SelectedValue;
                    p.Active = Convert.ToBoolean(chkIsActive.Checked.ToString());

                if (Prods.Save(p))
                {
                    Response.Redirect("~/Products.aspx");
                }
                else
                {
                    lblError.Text = "Error saving record.";
                }

            }
        }
        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            //check to make sure session is valid
            if (Session["cart"] != null)
            {
                //populate array with query string
                ArrayList alcart = (ArrayList)Session["cart"];
                bool found = false;
                foreach (string id in alcart)
                {
                    if (id == Request.QueryString["id"])
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    alcart.Add(Request.QueryString["id"]);
                }
                Session["cart"] = alcart;

            }
            else
            {
                ArrayList alcart = new ArrayList();
                alcart.Add(Request.QueryString["id"]);
                Session["cart"] = alcart;
            }
            
        }
}