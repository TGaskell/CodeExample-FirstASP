using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public class Users
{
    #region Constructors
    public Users()
	{
	}
    #endregion

    #region Fields

    private int _userid;
        private string _fname;
        private string _lname;
        private string _add1;
        private string _add2;
        private string _city;
        private string _state;
        private string _username;
        private string _password;
        private string _email;
        private string _phone;
        private string _role;
        private bool _active;

    #endregion

    #region Properties

        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public string Fname
        {
            get { return _fname; }
            set { _fname = value; }
        }
        public string Lname
        {
            get { return _lname; }
            set { _lname = value; }
        }
        public string Add1
        {
            get { return _add1; }
            set { _add1 = value; }
        }
        public string Add2
        {
            get { return _add2; }
            set { _add2 = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

    #endregion

    #region Methods/Functions

    public static Users Fetch(int userid) 
    {
            Users u = new Users();
            //connection object - ConfigurationManager namespace allows for runtime 
            //access to web.config setting, specifically connection strings and key values
            SqlConnection cn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["SE256_cs"].ConnectionString);
            //command object is for direct interface with database
            SqlCommand cmd = new SqlCommand("spGetUserByID", cn);
            //create datatable to hold result set
            DataTable dt = new DataTable();
            //mark the Command as a Stored Procedure
            //command type is an enumeration: Stored procedure, text(embedded SQL) or table direct
            cmd.CommandType = CommandType.StoredProcedure;

            //add Parameters to Stored Procedure
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userid;

            //open the database connection and execute the command
            try
            {
                //opens connection to database
                cn.Open();
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
                cn.Close();
            }
            //return the dataset
            if (dt.Rows.Count > 0)
            {
                u.UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
                u.Fname = dt.Rows[0]["UserFname"].ToString();
                u.Lname = dt.Rows[0]["UserLname"].ToString();
                u.Add1 = dt.Rows[0]["UserAdd1"].ToString();
                u.Add2 = dt.Rows[0]["UserAdd2"].ToString();
                u.City = dt.Rows[0]["UserCity"].ToString();
                u.State = dt.Rows[0]["StateID"].ToString();
                u.UserName = dt.Rows[0]["UserName"].ToString();
                u.Password = dt.Rows[0]["UserPassword"].ToString();
                u.Email = dt.Rows[0]["UserEmail"].ToString();
                u.Phone = dt.Rows[0]["UserPhone"].ToString();
                u.Role = dt.Rows[0]["UserRole"].ToString();
                u.Active = Convert.ToBoolean(dt.Rows[0]["UserIsActive"].ToString());
            }
            return u;
        }

    public static DataTable Fetch()
    {
        DataTable dt = new DataTable();
        return dt;
    }

    public static bool Save(Users u)
    {
        bool b = false;

        //connection object - ConfigurationManager namespace allows for runtime 
        //access to web.config setting, specifically connection strings and key values
        SqlConnection cn = new
        SqlConnection(ConfigurationManager.ConnectionStrings["SE256_cs"].ConnectionString);
        //command object is for direct interface with database
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        if (u.UserID > 0)
        {
            cmd.CommandText = "spUpdateUser";
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = u.UserID;
        }
        else
        {
            cmd.CommandText = "spInsertUser";
        }
        //create datatable to hold result set
        DataTable dt = new DataTable();
        //mark the Command as a Stored Procedure
        //command type is an enumeration: Stored procedure, text(embedded SQL) or table direct
        cmd.CommandType = CommandType.StoredProcedure;

        //add Parameters to Stored Procedure
        cmd.Parameters.Add("@UserFname", SqlDbType.Int).Value = u.Fname;
        cmd.Parameters.Add("@UserLname", SqlDbType.VarChar).Value = u.Lname;
        cmd.Parameters.Add("@UserAdd1", SqlDbType.VarChar).Value = u.Add1;
        cmd.Parameters.Add("@UserAdd2", SqlDbType.VarChar).Value = u.Add2;
        cmd.Parameters.Add("@UserCity", SqlDbType.VarChar).Value = u.City;
        cmd.Parameters.Add("@StateID", SqlDbType.VarChar).Value = u.State;
        cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = u.UserName;
        cmd.Parameters.Add("@UserPassword", SqlDbType.VarChar).Value = u.Password;
        cmd.Parameters.Add("@UserEmail", SqlDbType.VarChar).Value = u.Email;
        cmd.Parameters.Add("@UserPhone", SqlDbType.VarChar).Value = u.Phone;
        cmd.Parameters.Add("@UserRole", SqlDbType.VarChar).Value = u.Role;
        cmd.Parameters.Add("@UserIsActive", SqlDbType.VarChar).Value = u.Active;

        //open the database connection and execute the command
        try
        {
            //opens connection to database
            cn.Open();
            //execute 
            cmd.ExecuteNonQuery();
            b = true;
        }
        catch (Exception exc)
        {
            exc.ToString();
            b = false;
        }
        finally
        {
            //close connections
            cn.Close();
        }
        //return the dataset
        return b;
    }

    public static bool Delete(int userid)
    {
        bool b = false;
        return b;
    }
    #endregion
}