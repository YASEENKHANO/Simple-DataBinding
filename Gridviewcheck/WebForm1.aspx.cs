using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Gridviewcheck
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {//Check if the page is being loaded for the first time
            if(!IsPostBack)
            {//Call the method to bind data to the GridView
                BindGrid();
            }

        }

        //Method to bind the data to gridview
        private void BindGrid()
        {

            //Define the SQL Query to select data from the Products table
            string query = "Select Id, Name, Price From Products";

            //Get the connection sting from the Web.config file
            string connstring = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

            //Using statement ensures the connection is closed and disposed propeerly
           using( SqlConnection conn= new SqlConnection(connstring))
            {
                //Create a sQlCommand object  to execute the query
                SqlCommand cmd = new SqlCommand(query, conn);

                //Open the SQL connection
                conn.Open();

                //Create a SQlDataAdapter to fill a DataTable with the result of thequery
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                //Create a Datatable to hold the data
                DataTable dt = new DataTable();

                //Fill the DataTable with data from the database
                sda.Fill(dt);

                //Set the data source of thee GridView to the DataTable
                GridView1.DataSource = dt;

                //Bind the data to the Gridview
                GridView1.DataBind();

            }


        }
    }
}