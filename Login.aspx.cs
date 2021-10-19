using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["InvalidUsage"] != null)
            {
                LoginFailure.Text = Session["InvalidUsage"].ToString();
            }
            if (!Page.IsPostBack)
            {
                LoginFailure.ForeColor = Color.Red;
                if (Session["LoggedOut"] != null)
                {
                    LoginFailure.Text = Session["LoggedOut"].ToString();
                }
                if (Request.QueryString.Get("loggedout") == "true")
                {
                    LoginFailure.ForeColor = Color.Green;
                    LoginFailure.Text = "User Successfully Logged Out!";

                }
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            SqlCommand loginCommand = new SqlCommand();
            loginCommand.Connection = con2;
            loginCommand.CommandType = System.Data.CommandType.StoredProcedure;
            loginCommand.CommandText = "sp_UserLogin";
            loginCommand.Parameters.AddWithValue("@Username", txtusername.Text);

            con2.Open();
            SqlDataReader loginResults = loginCommand.ExecuteReader();
            if (loginResults.Read())
            {

                Session["UserID"] = loginResults.GetValue(0);//stores the users ID and username to be used to identify current user on other pages
                var passHash = loginResults.GetValue(1).ToString();
                Session["Username"] = txtusername.Text;
                Session["InvalidUsage"] = null;
                if (PasswordHash.ValidatePassword(txtpassword.Text, passHash))
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    LoginFailure.Text = "Incorrect Username or Password";
                }
            }
            else
            {
                LoginFailure.Text = "Incorrect Username or Password";
            }
        }
    }
}