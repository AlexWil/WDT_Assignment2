using System;

namespace Assignment2_2
{
    public partial class Events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.EventsNavigation.Attributes["class"] = "active";
        }
    }
}