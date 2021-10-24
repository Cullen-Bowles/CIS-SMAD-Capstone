using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;


namespace WebApplication4
{
    public partial class ManageUser : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
        SqlConnection con2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
        public static int userID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)//forces the page back to the sign in page if the user is not signed in
            {
                Session["InvalidUsage"] = "Guests cannot access this page, Please sign in";
                Response.Redirect("CreateUser-Login.aspx");
            }
            else if (!IsPostBack)
            {

                txtusername.ReadOnly = false;
                txtoldpassword.ReadOnly = false;
                txtnewpassword.ReadOnly = false;
                txtconpassword.ReadOnly = false;
                txtemail.ReadOnly = false;
                txtfirstname.ReadOnly = false;
                txtlastname.ReadOnly = false;
                txtorganization.ReadOnly = false;
                txtreason.ReadOnly = false;

                con2.Open();
                String sqlQueryRecentUser = "SELECT UserID FROM dbo.Person WHERE Username=@Username";
                SqlCommand com1 = new SqlCommand(sqlQueryRecentUser, con2);
                com1.Parameters.AddWithValue("@Username", Session["Username"]);
                SqlDataReader srd = com1.ExecuteReader();
                var hasReadValue = srd.Read();
                var hasUser = false;
                if (hasReadValue)//checks if database is empty, if it is not, it aquires the UserID for future use, if not, then it tells the user that no user exists

                {
                    userID = Int32.Parse(srd.GetValue(0).ToString());
                }

                //else

                //{
                //    NoUser.Text = "No Users currently exist. Please create a User account before attempting to edit a user";
                //    hasUser = true;
                //}
                srd.Close();
                if (!hasUser)//if their is a user, uses the aquired ID to place the correct info into text boxes                    
                {
                    String sqlQuery = "SELECT Username, Email, FirstName, LastName, Organization, Reason FROM Person WHERE UserID = @UserID";
                    SqlCommand comm = new SqlCommand(sqlQuery, con2);
                    SqlParameter param = new SqlParameter("@UserID", Session["UserID"]);
                    comm.Parameters.Add(param);
                    srd = comm.ExecuteReader();
                    while (srd.Read())
                    {

                        txtusername.Text = srd.GetValue(0).ToString();//gets value from the corresponding column in the query                            
                        txtoldpassword.Text = "";
                        txtnewpassword.Text = "";
                        txtconpassword.Text = "";
                        txtemail.Text = srd.GetValue(1).ToString();
                        txtfirstname.Text = srd.GetValue(2).ToString();
                        txtlastname.Text = srd.GetValue(3).ToString();
                        txtorganization.Text = srd.GetValue(4).ToString();
                        txtreason.Text = srd.GetValue(5).ToString();
                    }
                    srd.Close();
                }
                con2.Close();

            }
        }
        protected void btnconfirm_Click(object sender, EventArgs e)
        {
            con2.Open();
            String sqlQueryRecentUser = "SELECT UserID FROM dbo.Person WHERE Username=@Username";
            SqlCommand com1 = new SqlCommand(sqlQueryRecentUser, con2);
            com1.Parameters.AddWithValue("@Username", Session["Username"]);
            SqlDataReader srd = com1.ExecuteReader();
            var hasReadValue = srd.Read();
            var hasUser = true;
            if (!hasReadValue)//same funtion as further up, makes sure there is a user in the database
            {
                //ID = Int32.Parse(srd.GetValue(0).ToString());
                //NoUser.Text = "This User does not exist. Make sure you CONFIRM the user before attempting to edit";
                hasUser = false;
            }

            srd.Close();//confirms the update of the user and their password
            if (hasUser && txtnewpassword.Text.Equals(txtconpassword.Text) && (txtnewpassword.Text != null || txtconpassword.Text != null) && (!txtnewpassword.Text.Equals("") || !txtconpassword.Text.Equals("")))
            {
                String sqlQuery = "UPDATE dbo.Person SET Username=@Username, Email=@Email" +
                    "FirstName=@FirstName, LastName=@LastName, Organization=@Organization, Reason=@Reason WHERE Username=@signedIn";
                SqlCommand comm = new SqlCommand(sqlQuery, con2);
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@Username", txtusername.Text);
                param[1] = new SqlParameter("@Email", txtemail.Text);              
                param[2] = new SqlParameter("@FirstName", txtfirstname.Text);
                param[3] = new SqlParameter("@LastName", txtlastname.Text);
                param[4] = new SqlParameter("@Organization", txtorganization.Text);
                param[5] = new SqlParameter("@Reason", txtreason.Text);
                param[6] = new SqlParameter("@signedIn", Session["Username"]);
                comm.Parameters.Add(param[0]);
                comm.Parameters.Add(param[1]);              
                comm.Parameters.Add(param[2]);
                comm.Parameters.Add(param[3]);               
                comm.Parameters.Add(param[4]);
                comm.Parameters.Add(param[5]);
                comm.Parameters.Add(param[6]);
                comm.ExecuteNonQuery();
                SqlCommand passUpdate = new SqlCommand();
                passUpdate.Connection = con2;
                passUpdate.CommandType = System.Data.CommandType.StoredProcedure;
                passUpdate.CommandText = "sp_updateLogin";
                passUpdate.Parameters.AddWithValue("@Username", txtusername.Text);
                passUpdate.Parameters.AddWithValue("@PasswordHash", PasswordHash.HashPassword(txtnewpassword.Text));
                con2.Close();

            }
            //updates the data of the users without changing the password
            else if (hasUser && ((txtoldpassword.Text == null || txtoldpassword.Text.Equals("")) && (txtnewpassword.Text == null || txtnewpassword.Text.Equals("")) && (txtconpassword.Text == null || txtconpassword.Text.Equals(""))))//changes newest entry into database if a user is in database
                                                                                                                                                                                                                                        //&& ((txtnewpassword.Text.Equals("") && txtconfirmpass.Text.Equals("")) || (txtnewpassword.Text == null && txtconfirmpass.Text == null))
            {
                String sqlQuery = "UPDATE dbo.Person SET Username=@Username, Email=@Email" +
                    "FirstName=@FirstName, LastName=@LastName, Organization=@Organization, Reason=@Reason WHERE Username=@signedIn";
                SqlCommand comm = new SqlCommand(sqlQuery, con2);
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@Username", txtusername.Text);
                param[1] = new SqlParameter("@Email", txtemail.Text);
                param[2] = new SqlParameter("@FirstName", txtfirstname.Text);
                param[3] = new SqlParameter("@LastName", txtlastname.Text);
                param[4] = new SqlParameter("@Organization", txtorganization.Text);
                param[5] = new SqlParameter("@Reason", txtreason.Text);
                param[6] = new SqlParameter("@signedIn", Session["Username"]);
                comm.Parameters.Add(param[0]);
                comm.Parameters.Add(param[1]);
                comm.Parameters.Add(param[2]);
                comm.Parameters.Add(param[3]);
                comm.Parameters.Add(param[4]);
                comm.Parameters.Add(param[5]);
                comm.Parameters.Add(param[6]);
                comm.ExecuteNonQuery();
                con2.Close();
                UserUpdated.Text = "User Has been updated.";
                Session["Username"] = txtusername.Text;
            }
            //catches if someone tries to update the users password and messes up the new password confirmation
            else if (hasUser && !txtnewpassword.Text.Equals(txtconpassword.Text))
            {
                noMatch.Text = "Passwords do not match";
            }
        }
    }
}