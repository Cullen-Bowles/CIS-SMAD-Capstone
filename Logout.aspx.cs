namespace WebApplication4
{
    using System;
    using System.Web.UI;

    public partial class Logout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}