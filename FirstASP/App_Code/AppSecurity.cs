using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

public class AppSecurity
{
    #region Constructors
    public AppSecurity()
    {
    }
    #endregion

    #region Fields
    private int _userID;
    private string _userEmail;
    private string _userRole;
    private string _userName;
    private string _loginError;
    #endregion

    #region Properties

    public string UserName
    {
        get { return _userName; }
        set { _userName = value; }
    }

    public string LoginError
    {
        get { return _loginError; }
        set { _loginError = value; }
    }

    public int UserID
    {
        get { return _userID; }
        set { _userID = value; }
    }

    public string UserEmail
    {
        get { return _userEmail; }
        set { _userEmail = value; }
    }

    public string UserRole
    {
        get { return _userRole; }
        set { _userRole = value; }
    }
    #endregion

    #region Methods/Functions

    public static AppSecurity doLogIn(string userName, string password){

        DataTable dt = new DataTable();
        
        //Connection string to SQL database
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_cs"].ConnectionString);
        
        //Call for stored procedure
        SqlCommand cmd = new SqlCommand("spUserLogin", con);
        cmd.CommandType = CommandType.StoredProcedure;

        //Add Parameters to Stored Procedure
        cmd.Parameters.AddWithValue("@UserName", userName);
        cmd.Parameters.AddWithValue("@UserPassword", password);

        try
        {
            //open connection to db to fill dataset
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            //process errors here
            ex.ToString();
        }
        finally
        {
            //close connection to db
            con.Close();
        }

        if (dt.Rows.Count > 0)
        { 
            //if data connection is successfull create object
            AppSecurity sec = new AppSecurity();
            sec.UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
            sec.UserEmail = dt.Rows[0]["UserEmail"].ToString();
            sec.UserRole = dt.Rows[0]["UserRole"].ToString();
            sec.UserName = dt.Rows[0]["UserName"].ToString();
            
            return sec;
        }
        else
        {
            //if data connection failed return error message
            AppSecurity sec = new AppSecurity();
            sec.LoginError = "Login Failed! Please Re-Enter Password";

            return sec;
        }
     }

    public DataTable GetUser(int id)
    {
        //Embedded SQL connection object - ConfigurationManager namespace allows for runtime 
        //access to web.config setting, specifically connection strings and key values
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_cs"].ConnectionString);
        //connection object
        SqlCommand cmd = new SqlCommand("spGetUserByID", con);
        //Create datatable to hold result set
        DataTable dt = new DataTable();
        // Mark the Command as  text type
        //command type is an enumeration: Stored procedure, text(embedded SQL) or table direct
        cmd.CommandType = CommandType.StoredProcedure;
        // Add Parameters to Stored Procedure
        SqlParameter parmUserID = new SqlParameter("@UserID", SqlDbType.Int);
        parmUserID.Value = id;
        cmd.Parameters.Add(parmUserID);
        // Open the database connection and execute the command
        try
        {
            //opens connection to database
            con.Open();
            //data adapter object is trasport link between data source & data destination
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //fill method
            da.Fill(dt);
        }
        catch (Exception exc)
        {
            exc.ToString();
        }
        finally
        {
            //close connections
            con.Close();
        }

        //Returns the datatable
        return dt;
    }

    public void UpdateUser(int id, string username, string pword, string fname, string lname, string email, string phone, string role, Boolean active)
    {
        //connection object - ConfigurationManager namespace allows for runtime 
        //access to web.config setting, specifically connection strings and key values
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_cs"].ConnectionString);
        SqlCommand cmd = new SqlCommand("spUpdateUser", con);

        //mark the Command as a Stored Procedure
        cmd.CommandType = CommandType.StoredProcedure;

        //add Parameters to Stored Procedures
        SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);
        parameterUserID.Value = id;
        cmd.Parameters.Add(parameterUserID);

        SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.VarChar, 30);
        parameterUserName.Value = username;
        cmd.Parameters.Add(parameterUserName);

        SqlParameter parameterUserPword = new SqlParameter("@UserPassword", SqlDbType.VarChar, 30);
        parameterUserPword.Value = pword;
        cmd.Parameters.Add(parameterUserPword);

        SqlParameter parameterUserFname = new SqlParameter("@UserFname", SqlDbType.VarChar, 30);
        parameterUserFname.Value = fname;
        cmd.Parameters.Add(parameterUserFname);

        SqlParameter parameterUserLname = new SqlParameter("@UserLname", SqlDbType.VarChar, 30);
        parameterUserLname.Value = lname;
        cmd.Parameters.Add(parameterUserLname);

        SqlParameter parameterUserEmail = new SqlParameter("@UserEmail", SqlDbType.VarChar, 255);
        parameterUserEmail.Value = email;
        cmd.Parameters.Add(parameterUserEmail);

        SqlParameter parameterUserPhone = new SqlParameter("@UserPhone", SqlDbType.VarChar, 50);
        parameterUserPhone.Value = phone;
        cmd.Parameters.Add(parameterUserPhone);

        SqlParameter parameterUserRole = new SqlParameter("@UserRole", SqlDbType.VarChar, 50);
        parameterUserRole.Value = role;
        cmd.Parameters.Add(parameterUserRole);

        SqlParameter parameterUserIsActive = new SqlParameter("@UserIsActive", SqlDbType.Bit);
        parameterUserIsActive.Value = active;
        cmd.Parameters.Add(parameterUserIsActive);

        // Open the database connection and execute the command
        try
        {
            con.Open();
            //This is not a query so just issue the command to execute the stored procedure
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc)
        {
            //if error,notify user
            exc.ToString();
        }
        finally
        {
            con.Close();
        }
    }

    public void InsertUser(string username, string pword, string fname, string lname, string email, string phone, string role, Boolean active)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_cs"].ConnectionString);
        SqlCommand cmd = new SqlCommand("spInsertUser", con);

        //mark the Command as a Stored Procedure
        cmd.CommandType = CommandType.StoredProcedure;

        //add Parameters to Stored Procedures
        SqlParameter parameterUserName = new SqlParameter("@UserName", SqlDbType.VarChar, 30);
        parameterUserName.Value = username;
        cmd.Parameters.Add(parameterUserName);

        SqlParameter parameterUserPword = new SqlParameter("@UserPassword", SqlDbType.VarChar, 30);
        parameterUserPword.Value = pword;
        cmd.Parameters.Add(parameterUserPword);

        SqlParameter parameterUserFname = new SqlParameter("@UserFname", SqlDbType.VarChar, 30);
        parameterUserFname.Value = fname;
        cmd.Parameters.Add(parameterUserFname);

        SqlParameter parameterUserLname = new SqlParameter("@UserLname", SqlDbType.VarChar, 30);
        parameterUserLname.Value = lname;
        cmd.Parameters.Add(parameterUserLname);

        SqlParameter parameterUserEmail = new SqlParameter("@UserEmail", SqlDbType.VarChar, 255);
        parameterUserEmail.Value = email;
        cmd.Parameters.Add(parameterUserEmail);

        SqlParameter parameterUserPhone = new SqlParameter("@UserPhone", SqlDbType.VarChar, 50);
        parameterUserPhone.Value = phone;
        cmd.Parameters.Add(parameterUserPhone);

        SqlParameter parameterUserRole = new SqlParameter("@UserRole", SqlDbType.VarChar, 50);
        parameterUserRole.Value = role;
        cmd.Parameters.Add(parameterUserRole);

        SqlParameter parameterUserIsActive = new SqlParameter("@UserIsActive", SqlDbType.Bit);
        parameterUserIsActive.Value = active;
        cmd.Parameters.Add(parameterUserIsActive);

        // Open the database connection and execute the command
        try
        {
            con.Open();
            //This is not a query so just issue the command to execute the stored procedure
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc)
        {
            exc.ToString();
        }
        finally
        {
            //if error,notify user
            con.Close();
        }
    }
    #endregion
}