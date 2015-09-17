using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Assignment2_2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButtonClick(object sender, EventArgs e)
        {
            String password = pwd.Value;
            String userName = usr.Value;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CineplexConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("ReadPassword", conn) {CommandType = CommandType.StoredProcedure};
            cmd.Parameters.AddWithValue("@QueriedUsername", userName);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            String pwdInDb = (String)reader["Password"];
            conn.Close();

            if (pwdInDb.Equals(password))
            {
                message.Text = "Login very successful.";
                System.Diagnostics.Debug.WriteLine("Success");
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                message.Text = "Login failed. Check Username and Password.";
                System.Diagnostics.Debug.WriteLine("Failure");
            }
        }
    }
}