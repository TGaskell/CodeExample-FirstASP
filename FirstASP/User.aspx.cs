using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class User : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //check to make sure user is authenticated otherwise send to Login
        if (!Request.IsAuthenticated)
        {
            Response.Redirect("~/Login.aspx");
        }
        //user the request namespace to determine a query string value
        //default to -1 so to load blank form in case of missing query string value
        int intID = -1;
        if ((Request.QueryString["id"] != null))
        {
            //- request.QueryString gets items from the query string
            //- convert the query string to the proper data type
            intID = Int32.Parse(Request.QueryString["id"]);
        }
        //- for example if id <> -1 fill customer record or if id = -1, prepare form for add record functionality
        if (!IsPostBack)
        {
            //bind form data objects procedure call, made on first visit to page
            BindData(intID);
        }
    }

    private void BindData(int intID)
    {
        //render page according to query string variable if in edit mode
        if (intID > 0)
        {
            lbtnAddUpdate.Text = "Update";
            //create a datatable to hold the data
            DataTable dt = default(DataTable);

            //create and instantiate a new class object
            AppSecurity myAdmin = new AppSecurity();
            //call class function to retrieve current data and store in datatable
            dt = myAdmin.GetUser(intID);
            //use data to populate form controls(text boxes,dropdownlists)
            if (dt.Rows.Count > 0)
            {
                txtFirstName.Text = dt.Rows[0]["UserFname"].ToString();
                txtLastName.Text = dt.Rows[0]["UserLname"].ToString();
                txtAddress1.Text = dt.Rows[0]["UserAdd1"].ToString();
                txtAddress2.Text = dt.Rows[0]["UserAdd2"].ToString();
                txtCity.Text = dt.Rows[0]["UserCity"].ToString();
                ddlState.SelectedValue = dt.Rows[0]["StateID"].ToString();
                txtZip.Text = dt.Rows[0]["UserZip"].ToString();
                txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                txtPassword.Text = dt.Rows[0]["UserPassword"].ToString();
                txtEmail.Text = dt.Rows[0]["UserEmail"].ToString();
                txtPhone.Text = dt.Rows[0]["UserPhone"].ToString();
                txtUserRole.Text = dt.Rows[0]["UserRole"].ToString();
                rblIsActive.SelectedValue = dt.Rows[0]["UserIsActive"].ToString();
            }
            else
            {
                lbtnAddUpdate.Text = "Add";
            }
        }
        else
        {
            //if in add mode no need to get data, just show blank form and change
            //button text to appropriate function
            lbtnAddUpdate.Text = "Add";
        }
    }


    protected void lbtnAddUpdate_Click(object sender, EventArgs e)
    {
        //user the request namespace to determine a query string value
        //default to -1 so to load blank form in case of missing query string value
        int intID = -1;
        if ((Request.QueryString["id"] != null))
        {
            //- request.QueryString gets items from the query string
            //- convert the query string to the proper data type
            intID = Int32.Parse(Request.QueryString["id"]);
        }
        //handle add or update function
        //if in edit mode
        if (intID > 0)
        {
            try
            {
                //create and instantiate a new class object
                //this allows the code to a access class function and procedure calls
                //New is used to instantiate an object in the Visual Basic Language
                AppSecurity myAdmin = new AppSecurity();
                //actual update method being invoked
                myAdmin.UpdateUser(intID, txtUserName.Text.Trim(), txtPassword.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtUserRole.Text.Trim(), Convert.ToBoolean(rblIsActive.SelectedValue));
            }
            catch (Exception exc)
            {
                exc.ToString();
            }
            finally
            {
                //if error, notify user
                //clean up and return to page
                Response.Redirect("~/User.aspx?id=" + intID.ToString());
            }
        }
        else
        {
            //if in add mode
            //try statement for exception catching
            try
            {
                //create and instantiate a new class object
                //this allows the code to a access class function and procedure calls
                //New is used to instantiate an object in the Visual Basic Language
                AppSecurity myAdmin = new AppSecurity();
                //actual insert method being invoked
                myAdmin.InsertUser(txtUserName.Text.Trim(), txtPassword.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtUserRole.Text.Trim(), Convert.ToBoolean(rblIsActive.SelectedValue));
            }
            catch (Exception exc)
            {
                exc.ToString();
            }
            finally
            {
                //if error,notify user
                //clean up and return to page
                Response.Redirect("~/Users.aspx");
            }
        }
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        //cancel button redirects to initial state
        Response.Redirect("~/Users.aspx");
    }

    protected void ddlState_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlState.Items.Insert(0,"Choose State");
        }
    }
}

