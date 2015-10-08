using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CineplexAdministration
{
    public partial class Movies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.MovieNavActive = true;
        }

        protected void AddPerson_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMovie.aspx");
        }
    }
}