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
    public partial class StoryEntry : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)//forces the page back to the sign in page if the user is not signed in
            {
                Session["InvalidUsage"] = "Guests cannot access this page, Please sign in";
                Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                StoryDateEntry.Text = DateTime.Today.ToString("u");
            }
            
        }
        protected void Confirm_Click(object sender, EventArgs e)
        {
            con.Open();
            //var newStory = new Story(StoryTitleEntry.Text, StoryDateEntry.Text, StorySourceEntry.Text, StoryTextEntry.Text);
            //Session["CurrentStory"] = newStory;
            String querys = "SELECT StoryTitle FROM Story";
            SqlCommand com1 = new SqlCommand(querys, con);
            SqlDataReader srd = com1.ExecuteReader();
            var hasReadValue = srd.Read();
            var hasStory = true;
            if (hasReadValue)//checks if there are stories in the database
            {
                do
                {
                    if (srd.GetValue(0).ToString().Equals(StoryTitleEntry.Text))//checks though story titles for a matching one
                    {
                        ExistingStory.Text = "A Story with that title already exists, Please enter a different Title";
                        hasStory = true;//if yes, tells the user and stop the program from being able to submit to db
                        break;
                    }
                    else
                    {
                        hasStory = false;
                    }

                }
                while (srd.Read());
            }
            else
            {
                hasStory = false;
            }
            srd.Close();
            if (!hasStory)//inserts the story into the database
            {

                String sqlQuery = "INSERT INTO dbo.Story (StoryTitle, StoryDate, StorySource, StoryText, UserID) VALUES (@StoryTitle, @StoryDate, @StorySource, @StoryText, @UserID)";
                SqlCommand comm = new SqlCommand(sqlQuery, con);
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@StoryTitle", StoryTitleEntry.Text);
                param[1] = new SqlParameter("@StoryDate", StoryDateEntry.Text);
                param[2] = new SqlParameter("@StorySource", StorySourceEntry.Text);
                param[3] = new SqlParameter("@StoryText", StoryTextEntry.Text);
                param[4] = new SqlParameter("@UserID", (int)Session["UserID"]);
                comm.Parameters.Add(param[0]);
                comm.Parameters.Add(param[1]);
                comm.Parameters.Add(param[2]);
                comm.Parameters.Add(param[3]);
                comm.Parameters.Add(param[4]);
                comm.ExecuteNonQuery();//creates a new entry with the provided data.
                submitted.Text = "Story has been submitted";
            }
            con.Close();

        }
        protected void Clear_Click(object sender, EventArgs e)//clears
        {
            StoryTitleEntry.Text = "";
            StoryDateEntry.Text = "";
            StorySourceEntry.Text = "";
            StoryTextEntry.Text = "";
        }
    }
}