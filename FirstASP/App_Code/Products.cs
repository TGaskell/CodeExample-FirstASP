using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class Prods
{
    #region Constructors
    public Prods()
	{
	}
    #endregion

    #region Fields

    private int _id;
        private string _categoryid;
        private string _name;
        private string _desc;
        private string _sku;
        private decimal _cost;
        private bool _active;

    #endregion

    #region Properties

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Categoryid
        {
            get { return _categoryid; }
            set { _categoryid = value; }
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
        public string SKU
        {
            get { return _sku; }
            set { _sku = value; }
        }
        public decimal Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

    #endregion

    #region Methods/Functions

        public static Prods Fetch(int id)
        {
            Prods p = new Prods();
            //connection object - ConfigurationManager namespace allows for runtime 
            //access to web.config setting, specifically connection strings and key values
            SqlConnection cn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["SE256_cs"].ConnectionString);
            //command object is for direct interface with database
            SqlCommand cmd = new SqlCommand("spGetProductByID", cn);
            //create datatable to hold result set
            DataTable dt = new DataTable();
            //mark the Command as a Stored Procedure
            //command type is an enumeration: Stored procedure, text(embedded SQL) or table direct
            cmd.CommandType = CommandType.StoredProcedure;

            //add Parameters to Stored Procedure
            cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = id;

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
                p.ID = Convert.ToInt32(dt.Rows[0]["ProductID"].ToString());
                p.Categoryid = dt.Rows[0]["CategoryID"].ToString();
                p.Name = dt.Rows[0]["ProductName"].ToString();
                p.Desc = dt.Rows[0]["ProductDesc"].ToString();
                p.SKU = dt.Rows[0]["ProductSKU"].ToString();
                p.Cost = Convert.ToDecimal(dt.Rows[0]["ProductCost"].ToString());
                p.Active = Convert.ToBoolean(dt.Rows[0]["ProductIsActive"].ToString());
            }
            return p;
        }

        public static DataTable Fetch()
        {
            DataTable dt = new DataTable();
            return dt;
        }

        public static bool Save(Prods p)
        {
            bool b=false;

        //connection object - ConfigurationManager namespace allows for runtime 
        //access to web.config setting, specifically connection strings and key values
        SqlConnection cn = new
        SqlConnection(ConfigurationManager.ConnectionStrings["SE256_cs"].ConnectionString);
        //command object is for direct interface with database
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        if (p.ID > 0)
        {
            cmd.CommandText = "spUpdateProduct";
            cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = p.ID;
        }
        else
        {
            cmd.CommandText = "spInsertProduct";
        }
       
        //create datatable to hold result set
        DataTable dt = new DataTable();
        //mark the Command as a Stored Procedure
        //command type is an enumeration: Stored procedure, text(embedded SQL) or table direct
        cmd.CommandType = CommandType.StoredProcedure;

        //add Parameters to Stored Procedure
        cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = p.Categoryid; 
        cmd.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = p.Name;
        cmd.Parameters.Add("@ProductDesc", SqlDbType.VarChar).Value = p.Desc;
        cmd.Parameters.Add("@ProductSKU", SqlDbType.VarChar).Value = p.SKU;
        cmd.Parameters.Add("@ProductCost", SqlDbType.Decimal).Value = p.Cost;
        cmd.Parameters.Add("@ProductIsActive", SqlDbType.Bit).Value = p.Active;

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