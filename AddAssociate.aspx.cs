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
        String connectionString = "Data source=Localhost;Initial Catalog=Lab3; Trusted_Connection=Yes; MultipleActiveResultSets=true;";

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString);
        SqlConnection con2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CS = WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {

                    //fills drop down list with story titles
                    SqlCommand cmd = new SqlCommand("SELECT SharedUsername FROM AnalysisCommons WHERE UserID = '" + Session["UserID"] + "'", con);
                    con.Open();

                    ddlCommonsAssociates.DataSource = cmd.ExecuteReader();
                    ddlCommonsAssociates.DataTextField = "SharedUsername";
                    ddlCommonsAssociates.DataValueField = "SharedUsername";
                    ddlCommonsAssociates.DataBind();
                    con.Close();
                }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            String value = "";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
            sqlConnect.Open();

            //checking to see if there is another account with the same email
            String check = "SELECT UserID, Username FROM Person WHERE Email = @Email";
            SqlCommand queryCheck = new SqlCommand(check, sqlConnect);
            queryCheck.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtsearch.Text.ToString()));
            //int val = Convert.ToInt32(queryCheck.ExecuteScalar());

            //if (val == 1)
            //{
            //    String quer = "SELECT UserID FROM Person WHERE Email = @Email";
            //    SqlCommand ch = new SqlCommand(quer, sqlConnect);
            //    ch.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtsearch.Text.ToString()));
            //    using (SqlDataReader dr = ch.ExecuteReader())
            //    {
            //        while (dr.Read())
            //        {
            //            value = dr[0].ToString();
            //        }
            //    }
            SqlDataReader src = queryCheck.ExecuteReader();
            while (src.Read())
            {
                Session["ShareUserId"] = src.GetInt32(0);
                Session["SharedUsername"] = src.GetValue(1).ToString();
            }
            src.Close();
                String query = ("INSERT into AnalysisCommons (UserID, SharedUserID, SharedUsername) VALUES (@UserID, @SharedUserID, @SharedUsername)");
                SqlCommand cmd = new SqlCommand(query, sqlConnect);
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@UserID", Session["UserID"]);
                param[1] = new SqlParameter("@SharedUserID", Session["SharedUserID"]);
                param[2] = new SqlParameter("@SharedUsername", Session["SharedUsername"]);
                cmd.Parameters.Add(param[0]);
                cmd.Parameters.Add(param[1]);
                cmd.Parameters.Add(param[2]);
                cmd.ExecuteNonQuery();

                lblstatus.Text = "Successfully added Colleague!";
                lblstatus.ForeColor = System.Drawing.Color.Green;

                ddlCommonsAssociates.DataBind();

                //lblstatus.Text = "You are already collegues with this person";
                //lblstatus.ForeColor = System.Drawing.Color.Red;
            
        }
    }
}