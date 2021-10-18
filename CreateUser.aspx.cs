using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

namespace WebApplication4
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection con2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncreateuser_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text.Equals(txtconpassword.Text))
            {

                con2.Open();

                //Session["Username"] = UserText.Text;
                String querys = "SELECT Username FROM Person";
                SqlCommand com1 = new SqlCommand(querys, con2);
                SqlDataReader srd = com1.ExecuteReader();
                var hasReadValue = srd.Read();
                var hasUser = false;
                if (hasReadValue)//checks though database for an existing user
                {
                    do
                    {
                        if (srd.GetValue(0).ToString().Equals(txtusername.Text))//blocks entry if user exists
                        {
                            ExistingUser.Text = "User already exists, Please enter another UserName";
                            hasUser = true;
                            break;
                        }

                    }
                    while (srd.Read());
                }
                srd.Close();
                if (!hasUser)//inserts new user into database
                {
                    String sqlQuery = "INSERT INTO dbo.Person (Username, Email, FirstName, LastName, Organization, Reason) VALUES (@Username, @Email, @FirstName, @LastName, @Organization, @Reason)";
                    SqlCommand comm = new SqlCommand(sqlQuery, con2);
                    SqlParameter[] paramCreate = new SqlParameter[6];
                    paramCreate[0] = new SqlParameter("@Username", txtusername.Text);
                    paramCreate[1] = new SqlParameter("@Email", txtemail.Text);
                    paramCreate[2] = new SqlParameter("@FirstName", txtfirstname.Text);
                    paramCreate[3] = new SqlParameter("@LastName", txtlastname.Text);
                    paramCreate[4] = new SqlParameter("@Organization", txtorganization.Text);
                    paramCreate[5] = new SqlParameter("@Reason", txtreason.Text);
                    comm.Parameters.Add(paramCreate[0]);
                    comm.Parameters.Add(paramCreate[1]);
                    comm.Parameters.Add(paramCreate[2]);
                    comm.Parameters.Add(paramCreate[3]);
                    comm.Parameters.Add(paramCreate[4]);
                    comm.Parameters.Add(paramCreate[5]);
                    comm.ExecuteNonQuery();
                    String sqlUserandID = "SELECT UserID, Username FROM Person WHERE UserID IN (SELECT max(UserID) FROM Person)";
                    SqlCommand sqlComm = new SqlCommand(sqlUserandID, con2);
                    SqlDataReader src = sqlComm.ExecuteReader();
                    if (src.Read())
                    {
                        Session["UserID"] = Int32.Parse(src.GetValue(0).ToString());
                        Session["Username"] = src.GetValue(1).ToString();
                    }
                    src.Close();
                    string passQuery = "INSERT INTO Pass (UserID, Username, PasswordHash) VALUES (@UserID, @Username, @Password)";
                    SqlCommand com3 = new SqlCommand(passQuery, con2);
                    SqlParameter[] paramPass = new SqlParameter[3];
                    paramPass[0] = new SqlParameter("@UserID", ((int)Session["UserID"]));
                    paramPass[1] = new SqlParameter("@Username", txtusername.Text);
                    paramPass[2] = new SqlParameter("@Password", PasswordHash.HashPassword(txtpassword.Text));
                    com3.Parameters.Add(paramPass[0]);
                    com3.Parameters.Add(paramPass[1]);
                    com3.Parameters.Add(paramPass[2]);
                    com3.ExecuteNonQuery();
                    con2.Close();
                    Session["Login"] = true;
                    Session["CreateUser"] = false;
                    Response.Redirect("CreateUser-Login.aspx");
                }
            }
        }
        protected void btnclear_Click(object sender, EventArgs e)
        {

        }
    }
}