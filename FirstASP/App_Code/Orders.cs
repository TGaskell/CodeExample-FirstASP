using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class Orders
{
    #region Constructors
    public Orders()
	{
    }
    #endregion

    #region Fields

    private int _id;
        private int _userid;
        private int _status;
        private DateTime _orderdate;
        private string _add1;
        private string _add2;
        private string _city;
        private int _stateid;
        private string _zip;
        private DateTime _orderlastupdate;

    #endregion

    #region Properties

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public DateTime Orderdate
        {
            get { return _orderdate; }
            set { _orderdate = value; }
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
        public int Stateid
        {
            get { return _stateid; }
            set { _stateid = value; }
        }
        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
        public DateTime Orderlastupdate
        {
            get { return _orderlastupdate; }
            set { _orderlastupdate = value; }
        }

    #endregion

    #region Methods/Functions

        public static Orders Fetch(int id)
        {
            Orders o = new Orders();
            //connection object - ConfigurationManager namespace allows for runtime 
            //access to web.config setting, specifically connection strings and key values
            SqlConnection cn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["SE256_cs"].ConnectionString);
            //command object is for direct interface with database
            SqlCommand cmd = new SqlCommand("spGetOrderByID", cn);
            //create datatable to hold result set
            DataTable dt = new DataTable();
            //mark the Command as a Stored Procedure
            //command type is an enumeration: Stored procedure, text(embedded SQL) or table direct
            cmd.CommandType = CommandType.StoredProcedure;

            //add Parameters to Stored Procedure
            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = id;

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
                o.ID = Convert.ToInt32(dt.Rows[0]["OrderID"].ToString());
                o.Userid = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
                o.Status = Convert.ToInt32(dt.Rows[0]["StatusID"].ToString());
                o.Orderdate = Convert.ToDateTime(dt.Rows[0]["OrderDate"].ToString());
                o.Add1 = dt.Rows[0]["OrderAdd1"].ToString();
                o.Add2 = dt.Rows[0]["OrderAdd2"].ToString();
                o.City = dt.Rows[0]["OrderCity"].ToString();
                o.Stateid = Convert.ToInt32(dt.Rows[0]["StateID"].ToString());
                o.Zip = dt.Rows[0]["OrderZip"].ToString();
                o.Orderlastupdate = Convert.ToDateTime(dt.Rows[0]["OrderLastUpdate"].ToString());
            }
            return o;
        }

        public static DataTable Fetch()
        {
            DataTable dt = new DataTable();
            return dt;
        }

        public static bool Save(Orders o)
        {
            bool b = false;

            //connection object - ConfigurationManager namespace allows for runtime 
            //access to web.config setting, specifically connection strings and key values
            SqlConnection cn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["SE256_cs"].ConnectionString);
            //command object is for direct interface with database
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            if (o.ID > 0)
            {
                cmd.CommandText = "spUpdateOrder";
                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = o.ID;
            }
            else
            {
                cmd.CommandText = "spInsertOrder";
            }
            //create datatable to hold result set
            DataTable dt = new DataTable();
            //mark the Command as a Stored Procedure
            //command type is an enumeration: Stored procedure, text(embedded SQL) or table direct
            cmd.CommandType = CommandType.StoredProcedure;

            //add Parameters to Stored Procedure
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = o.Userid;
            cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = o.Status;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = o.Orderdate;
            cmd.Parameters.Add("@OrderAdd1", SqlDbType.VarChar).Value = o.Add1;
            cmd.Parameters.Add("@OrderAdd2", SqlDbType.VarChar).Value = o.Add2;
            cmd.Parameters.Add("@OrderCity", SqlDbType.VarChar).Value = o.City;
            cmd.Parameters.Add("@StateID", SqlDbType.Int).Value = o.Stateid;
            cmd.Parameters.Add("@OrderZip", SqlDbType.VarChar).Value = o.Zip;

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