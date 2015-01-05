using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        ((LinkButton)Master.FindControl("lbtnLogin")).Visible = false;
        base.OnPreRender(e);
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    protected void lbtnLogin_Click(object sender, EventArgs e)
    {
       // Attempt to Validate User Credentials 
        {
            //Create and instantiate the class object
            AppSecurity sec = new AppSecurity();
           
            if (!string.IsNullOrEmpty(txtUserName.Text) & !string.IsNullOrEmpty(txtPassword.Text))
            {
                //Send string value to class function and return string for form output
                sec = AppSecurity.doLogIn(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            }
            else
            {
                //if login failed display error message
                lblMessage.Text = sec.LoginError.ToString();
                return;
            }

            //Check for at least one record returned from the class function
            if (sec.UserID > 0)
            {

                // Use .NET built in security system to set the UserID 
                //within a client-side Cookie
                FormsAuthenticationTicket ticket 
                    = new FormsAuthenticationTicket(sec.UserID.ToString(), false,480);

                //For security reasons we may hash the cookies
                string encrytpedTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrytpedTicket);
                Response.Cookies.Add(cookie);

                //set the username to a client side cookie for future reference
                HttpCookie MyCookie = new HttpCookie("FullName");
                DateTime now = DateTime.Now;
                MyCookie.Value = sec.UserID.ToString() + " " + sec.UserName.ToString();
                MyCookie.Expires = now.AddDays(1);
                Response.Cookies.Add(MyCookie);
                //set the userrole to a session variable for future reference
                Session["Role"] = sec.UserRole.ToString();
                Session["cart"] = null;
                //If it all works Redirect browser back to home page
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                //or else display the failed login message
                lblMessage.Text = sec.LoginError.ToString();
            }
        }
    }
}