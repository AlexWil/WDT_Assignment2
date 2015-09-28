using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment2_2
{
    public partial class Movies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.MoviesNavigation.Attributes["class"] = "active";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void AddMovieButton_Click(object sender, EventArgs e)
        {
            var title = GridView1.FooterRow.FindControl("TitelTextBox") as TextBox;
            var shortDescription = GridView1.FooterRow.FindControl("ShortDescriptionTextBox") as TextBox;
            var longDescription = GridView1.FooterRow.FindControl("LongDescriptionTextBox") as TextBox;
            var imageUrl = GridView1.FooterRow.FindControl("ImageUrlTextBox") as TextBox;
            var price = GridView1.FooterRow.FindControl("PriceTextBox") as TextBox;
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CineplexConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("InsertMovie", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Title", title.Text);
            cmd.Parameters.AddWithValue("@ShortDescription", shortDescription.Text);
            cmd.Parameters.AddWithValue("@LongDescription", longDescription.Text);
            cmd.Parameters.AddWithValue("@ImageUrl", imageUrl.Text);
            cmd.Parameters.AddWithValue("@Price", price.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            GridView1.DataBind();
        }
    }
}