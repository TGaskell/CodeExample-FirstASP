﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Categories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //check to make sure user is logged in, if not send to login page
        if (Request.IsAuthenticated == false)
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void lbtnAddUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Category.aspx?id=-1");
    }
}