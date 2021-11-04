using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;
using System.IO;


namespace WebApplication4
{
    public partial class AddAssociate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
            sqlConnect.Open();

            //checking to see if there is another account with the same email
            String check = "SELECT COUNT(1) FROM Person WHERE Username = @Username";
            SqlCommand queryCheck = new SqlCommand(check, sqlConnect);
            queryCheck.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtSearch.Text.ToString()));
            int val = Convert.ToInt32(queryCheck.ExecuteScalar());

            if (val == 1)
            {
                String query = "SELECT UserID, Username FROM Person WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, sqlConnect);
                cmd.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtSearch.Text.ToString()));

                //using labels with more information about the serach to inform users that that is the colleague they want to add
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lblusername.Text = dr["Username"].ToString();
                    }
                }

                lblAdd.Text = "Colleague found!";
                lblAdd.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                lblStatus.Text = "Colleague does not exist";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            sqlConnect.Close();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
            sqlConnect.Open();

            //checking to see if there is another account with the same email
            String check = "SELECT COUNT(1) FROM Person WHERE Username = @Username";
            SqlCommand queryCheck = new SqlCommand(check, sqlConnect);
            queryCheck.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtSearch.Text.ToString()));
            int val = Convert.ToInt32(queryCheck.ExecuteScalar());


            if (val == 1)
            {
                String query1 = "SELECT UserID, Username FROM Person WHERE Username = @Username";
                SqlCommand cmd1 = new SqlCommand(query1, sqlConnect);
                cmd1.Parameters.AddWithValue("@Username", HttpUtility.HtmlEncode(txtSearch.Text.ToString()));

                using (SqlDataReader dr = cmd1.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lblusername.Text = dr["Username"].ToString();
                        Session["SharedUserID"] = dr.GetValue(0);
                    }
                }

                SqlConnection sqlConnect1 = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString);
                sqlConnect1.Open();

                String ch = "SELECT COUNT(1) FROM AnalysisCommons WHERE UserID = @UserID AND SharedUsername = @SharedUsername";
                SqlCommand queryCh = new SqlCommand(ch, sqlConnect1);
                queryCh.Parameters.AddWithValue("@SharedUsername", HttpUtility.HtmlEncode(txtSearch.Text.ToString()));
                queryCh.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                int val3 = Convert.ToInt32(queryCh.ExecuteScalar());


                if (val3 != 1)
                {
                    
                    String query = ("INSERT into AnalysisCommons (UserID, SharedUserID, SharedUsername) VALUES (@UserID, @SharedUserID, @SharedUsername)");
                    SqlCommand cmd = new SqlCommand(query, sqlConnect1);

                    cmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                    cmd.Parameters.AddWithValue("@SharedUserID", Session["SharedUserID"]);
                    cmd.Parameters.AddWithValue("@SharedUsername", lblusername.Text.ToString());
                    cmd.ExecuteNonQuery();

                    lblAdd.Text = "Successfully added Colleague!";
                    lblAdd.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    lblAdd.Text = "You are already collegues with this person";
                    lblAdd.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblStatus.Text = "Colleague does not exist";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            sqlConnect.Close();
        }
    }
}
