using System;
using System.Web.Security;

namespace Assignment2_2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Something new
            FormsAuthentication.SignOut();
        }
    }
}