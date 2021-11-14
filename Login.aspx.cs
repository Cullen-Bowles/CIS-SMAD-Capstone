namespace WebApplication4
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.Configuration;
    using System.Web.UI;

    public partial class WebForm1 : Page
    {
        private readonly SqlConnection con2 =
            new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["InvalidUsage"] != null) LoginFailure.Text = Session["InvalidUsage"].ToString();
            if (!Page.IsPostBack)
            {
                LoginFailure.ForeColor = Color.Red;
                if (Session["LoggedOut"] != null) LoginFailure.Text = Session["LoggedOut"].ToString();
                if (Request.QueryString.Get("loggedout") == "true")
                {
                    LoginFailure.ForeColor = Color.Green;
                    LoginFailure.Text = "User Successfully Logged Out!";
                }

                Session["MessageCount"] = 0;
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            var loginCommand = new SqlCommand();
            loginCommand.Connection = con2;
            loginCommand.CommandType = CommandType.StoredProcedure;
            loginCommand.CommandText = "sp_UserLogin";
            loginCommand.Parameters.AddWithValue("@Username", txtusername.Text);

            var validLogin = false;

            con2.Open();
            var loginResults = loginCommand.ExecuteReader();
            if (loginResults.Read())
            {
                Session["UserID"] =
                    loginResults
                        .GetValue(0); //stores the users ID and username to be used to identify current user on other pages
                var passHash = loginResults.GetValue(1).ToString();
                Session["Username"] = txtusername.Text;
                Session["InvalidUsage"] = null;
                if (PasswordHash.ValidatePassword(txtpassword.Text, passHash))
                {
                    validLogin = true;
                    //Response.Redirect("Home.aspx");
                }
                else
                {
                    Session.Clear();
                    LoginFailure.Text = "Incorrect Username or Password";
                }
            }
            else
            {
                Session.Clear();
                LoginFailure.Text = "Incorrect Username or Password";
            }

            con2.Close();

            if (validLogin)
            {
                // now get message count
                var sqlQuery =
                    "SELECT COUNT(ID) as MessageCount FROM Messenger WHERE ToUserID = @UserID AND IsRead = 0";
                var comm = new SqlCommand(sqlQuery, con2);
                comm.Parameters.AddWithValue("@UserID", Session["UserID"]);
                con2.Open();
                var srd = comm.ExecuteReader();
                if (srd.Read()) Session["MessageCount"] = srd.GetValue(0).ToString();
                con2.Close();

                Response.Redirect("Home.aspx");
            }
        }
    }
}