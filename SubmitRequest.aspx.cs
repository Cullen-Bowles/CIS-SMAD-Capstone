using System;
using System.Collections.Generic;
using System.Data;
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
using System.Threading.Tasks;

namespace WebApplication4
{  
    public partial class SubmitRequest : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)//forces the page back to the sign in page if the user is not signed in
            {
                Session["InvalidUsage"] = "Guests cannot access this page, Please sign in";
                Response.Redirect("Login.aspx");
            }
            else if (!Page.IsPostBack)
            {
                con.Open();
                String sqlQuery = "SELECT TextID, StoryTitle FROM Story WHERE UserID = @UserID";
                SqlCommand comm = new SqlCommand(sqlQuery, con);
                comm.Parameters.AddWithValue("@UserID", Session["UserId"]);
                SqlDataReader srd = comm.ExecuteReader();
                ddlusersstories.DataSource = srd;
                ddlusersstories.DataTextField = "StoryTitle";
                ddlusersstories.DataValueField = "TextID";
                ddlusersstories.DataBind();
                con.Close();
                ddlusersstories.Items.Insert(0, new ListItem("Select a Story", "0"));//placeholder for when page is first loaded
                ddlusersstories.Items[0].Selected = true;
                ddlusersstories.Items[0].Attributes["disabled"] = "disabled";
                
            }
        }

        protected void ddlusersstories_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (!ddlusersstories.SelectedValue.Equals("0"))
            {
                con.Open();
                SqlCommand comm = new SqlCommand("SELECT TextID, StoryTitle, StorySource, StoryText FROM Story WHERE UserID=" + ddlusersstories.SelectedValue, con);
                SqlDataReader srd = comm.ExecuteReader();
                while (srd.Read())
                {
                    Session["TextID"] = srd.GetValue(0);
                    txtstorytext.Text = srd.GetValue(1).ToString();
                    //var storyDateTime = DateTime.Parse(srd.GetValue(1).ToString());// guarantees that the date being sent to text box is in validation format                   
                    txtstorysource.Text = srd.GetValue(2).ToString();

                    txtstorytext.Text = srd.GetValue(3).ToString();
                }
                srd.Close();
                con.Close();
                

            }
        }

        

        protected void btnSubmitRequest_Click1(object sender, EventArgs e)
        {
            con.Open();
            string requestInsert = "INSERT INTO AnalysisRecord (UserID, TextID, AnalysisTitle, AnalysisDate, AnalysisSource, AnalysisRecord, AnalysisReason) VALUES (@UserID, @TextID, @AnalysisTitle, @AnalysisDate, @AnalysisSource, @AnlysisReport, @AnalysisReason)";
            SqlCommand comm = new SqlCommand(requestInsert, con);
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@UserID", (int)Session["UserID"]);
            param[1] = new SqlParameter("@TextID", (int)Session["TextID"]);
            param[2] = new SqlParameter("@AnalysisTitle", txtstorytile.Text);
            param[3] = new SqlParameter("@AnalysisDate", txtsubmissiondate.Text);
            param[4] = new SqlParameter("@AnalysisSource", txtstorysource.Text);
            param[5] = new SqlParameter("@AnalysisRecord", "This is a placehold, functionality to be added soon");
            param[6] = new SqlParameter("@AnalysisReason", "Placeholder for database");
            comm.Parameters.Add(param[0]);
            comm.Parameters.Add(param[1]);
            comm.Parameters.Add(param[2]);
            comm.Parameters.Add(param[3]);
            comm.Parameters.Add(param[4]);
            comm.Parameters.Add(param[5]);
            comm.Parameters.Add(param[6]);
            comm.ExecuteNonQuery();
            con.Close();
        }
    }
}