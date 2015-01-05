using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Cats c = new Cats();
                c = Cats.Fetch(Convert.ToInt32(Request.QueryString["id"].ToString()));
                txtName.Text = c.Name;
                txtDesc.Text = c.Desc;
                chkIsActive.Checked = c.Active;
            }
        }
    }

    protected void lbtnAddUpdate_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtDesc.Text))
        {
            Cats c = new Cats();
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                c.ID = Convert.ToInt32(Request.QueryString["id"].ToString());
            }
            else
            {
                c.ID = 0;
            }
            c.Name = txtName.Text;
            c.Desc = txtDesc.Text;
            c.Active = Convert.ToBoolean(chkIsActive.Checked.ToString());

            if (Cats.Save(c))
            {
                Response.Redirect("~/Categories.aspx");
            }
            else
            {
                lblError.Text = "Error saving record.";
            }

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //cancel button redirects to initial state
        Response.Redirect("~/Categories.aspx");
    }
}