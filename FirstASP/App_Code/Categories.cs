using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public class Cats
{
    #region Constructors
    public Cats()
	{
	}
    #endregion

    #region Fields
        private int _id;
        private string _name;
        private string _desc;
        private bool _active;
    #endregion

   #region Properties   
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }
   #endregion

   #region Methods/Function

    public static Cats Fetch(int id) 		          
    {
        Cats c=new Cats();
        //connection object - ConfigurationManager namespace allows for runtime 
        //access to web.config setting, specifically connection strings and key values
        SqlConnection cn = new 
        SqlConnection(ConfigurationManager.ConnectionStrings["SE256_cs"].ConnectionString);
        //command object is for direct interface with database
        SqlCommand cmd = new SqlCommand("spGetCategoryByID", cn);
        //create datatable to hold result set
        DataTable dt = new DataTable();
        //mark the Command as a Stored Procedure
        //command type is an enumeration: Stored procedure, text(embedded SQL) or table direct
        cmd.CommandType = CommandType.StoredProcedure;

        //add Parameters to Stored Procedure
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

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
            c.ID = Convert.ToInt32(dt.Rows[0]["CategoryID"].ToString());
            c.Name = dt.Rows[0]["CategoryName"].ToString();
            c.Desc = dt.Rows[0]["CategoryDesc"].ToString();
            c.Active = Convert.ToBoolean(dt.Rows[0]["CategoryIsActive"].ToString());
        }
        return c;
    }

    public static DataTable Fetch()
    {
        DataTable dt=new DataTable();

        return dt;
    }

    public static bool Save(Cats c)
    {
        bool b=false;

        //connection object - ConfigurationManager namespace allows for runtime 
        //access to web.config setting, specifically connection strings and key values
        SqlConnection cn = new
        SqlConnection(ConfigurationManager.ConnectionStrings["SE256_cs"].ConnectionString);
        
        //command object is for direct interface with database
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        if (c.ID > 0)
        {
            cmd.CommandText = "spUpdateCategory";
            cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = c.ID;
        }
        else
        {
            cmd.CommandText = "spInsertCategory";
        }
       
        //create datatable to hold result set
        DataTable dt = new DataTable();
        //mark the Command as a Stored Procedure
        //command type is an enumeration: Stored procedure, text(embedded SQL) or table direct
        cmd.CommandType = CommandType.StoredProcedure;

        //add Parameters to Stored Procedure
        cmd.Parameters.Add("@CategoryName", SqlDbType.VarChar).Value = c.Name;
        cmd.Parameters.Add("@CategoryDesc", SqlDbType.VarChar).Value = c.Desc;
        cmd.Parameters.Add("@CategoryIsActive", SqlDbType.Bit).Value = c.Active;

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

    public static bool Delete(int id)
    {
        bool b = false;
        return b;
    }
    #endregion
}