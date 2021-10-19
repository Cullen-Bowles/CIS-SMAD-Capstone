using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class StoryUpload : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

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
            var hasStory = false;
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

                }
                while (srd.Read());
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
                param[4] = new SqlParameter("@UserID", Session["UserID"]);
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
        protected void btnUploadFile_Click(object sender, EventArgs e)//allows the user to upload a text file
        {

            if (fileUploadText.HasFile)//checks if a file has been uploaded
            {
                String fpath = Request.PhysicalApplicationPath + "textfiles\\" + fileUploadText.FileName;
                fileUploadText.SaveAs(fpath);

                if (File.Exists(fpath))//checks if there is a file along the path
                {
                    //Read all the content in one string
                    //and display the string
                    string str = File.ReadAllText(fpath);
                    StoryTextEntry.Text = str;
                    File.Delete(fpath);
                }
            }
            else
            {
                StoryTextEntry.Text = "Something went wrong!";
            }
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