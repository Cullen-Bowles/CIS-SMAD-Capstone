using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class StoryEdit : System.Web.UI.Page
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
                FillDropDown();
                if (Session["Username"] == null)
                {
                    LoggedIn.Text = "User must be logged in to view and edit their own stories";
                }
                else
                {
                    LoggedIn.Text = "Click to view and edit your submitted texts";
                }

                con.Open();
                String sqlQueryStory = "SELECT TextID FROM dbo.Story ORDER BY TextID ASC";
                SqlCommand com1 = new SqlCommand(sqlQueryStory, con);
                SqlDataReader srd = com1.ExecuteReader();
                var hasReadValue = srd.Read();
                var hasStory = false;
                if (hasReadValue) //determines if there is anything in the data base, if yes, the boxes will be left blank
                {
                    hasStory = true;
                }
                srd.Close();
                if (hasStory)
                {
                    String sqlQuery = "SELECT StoryTitle, StoryDate, StorySource, StoryText FROM Story where TextID = " + 1;
                    SqlCommand comm = new SqlCommand(sqlQuery, con);
                    srd = comm.ExecuteReader();
                    while (srd.Read())
                    {
                        StoryTitleEntry.Text = srd.GetValue(0).ToString();
                        var storyDateTime = DateTime.Parse(srd.GetValue(1).ToString());
                        StoryDateEntry.Text = storyDateTime.ToShortDateString();
                        StorySourceEntry.Text = srd.GetValue(2).ToString();
                        StoryTextEntry.Text = srd.GetValue(3).ToString();
                    }
                    srd.Close();
                }
                con.Close();
            }
            

        }
        private void FillDropDown()//fills the dropdown list
        {
            ListItem placeholder = new ListItem();
            placeholder.Text = "Select a story";

            con.Open();
            String sqlQuery = "SELECT TextID, StoryTitle FROM Story WHERE UserID = @UserID";
            SqlCommand comm = new SqlCommand(sqlQuery, con);
            comm.Parameters.AddWithValue("@UserID", Session["UserID"]);
            SqlDataReader srd = comm.ExecuteReader();
            StoriesList.DataSource = srd;
            StoriesList.DataTextField = "StoryTitle";
            StoriesList.DataValueField = "TextID";
            StoriesList.DataBind();
            con.Close();
            StoriesList.Items.Insert(0, new ListItem("Select a Story", "0"));//placeholder for when page is first loaded
            StoriesList.Items[0].Selected = true;
            StoriesList.Items[0].Attributes["disabled"] = "disabled";
            StoryDateEntry.ReadOnly = true;
            StorySourceEntry.ReadOnly = true;
            StoryTextEntry.ReadOnly = true;
        }


        protected void Confirm_Click(object sender, EventArgs e)//confirms the update of the stories info to sql
        {
            con.Open();
            using (SqlCommand comm = new SqlCommand("UPDATE Story SET StoryTitle = @StoryTitle, StoryDate = @StoryDate, StorySource = @StorySource, StoryText = @StoryText WHERE TextID = " + StoriesList.SelectedValue, con))
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@StoryTitle", StoryTitleEntry.Text);//uses parameters to better control data being sent to sql
                param[1] = new SqlParameter("@StoryDate", StoryDateEntry.Text);
                param[2] = new SqlParameter("@StorySource", StorySourceEntry.Text);
                param[3] = new SqlParameter("@StoryText", StoryTextEntry.Text);
                comm.Parameters.Add(param[0]);
                comm.Parameters.Add(param[1]);
                comm.Parameters.Add(param[2]);
                comm.Parameters.Add(param[3]);
                comm.ExecuteNonQuery();
            }
            con.Close();
        }

        protected void StoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            String sqlQuery = "SELECT StoryTitle, StoryDate, StorySource, StoryText FROM Story where TextID = " + StoriesList.SelectedValue;
            SqlCommand comm = new SqlCommand(sqlQuery, con);
            SqlDataReader srd = comm.ExecuteReader();
            while (srd.Read())
            {
                StoryTitleEntry.Text = srd.GetValue(0).ToString();
                var storyDateTime = DateTime.Parse(srd.GetValue(1).ToString());
                StoryDateEntry.Text = storyDateTime.ToShortDateString();
                StorySourceEntry.Text = srd.GetValue(2).ToString();
                StoryTextEntry.Text = srd.GetValue(3).ToString();
            }
            srd.Close();
            con.Close();
        }
    }
}