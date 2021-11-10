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
        HttpClient hClient = new HttpClient();
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString);
        SqlConnection con2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)//forces the page back to the sign in page if the user is not signed in
            {
                Session["InvalidUsage"] = "Guests cannot access this page, Please sign in";
                Response.Redirect("Login.aspx");
            }
            else if (!Page.IsPostBack)
            {
                con2.Open();
                String email = "SELECT Email FROM Person WHERE UserID = @UserID";
                SqlCommand com1 = new SqlCommand(email, con2);
                com1.Parameters.AddWithValue("@UserID", Session["UserID"]);
                SqlDataReader src = com1.ExecuteReader();
                if (src.Read())
                {
                    txtEmail.Text = src.GetValue(0).ToString();
                }
                con2.Close();
                con.Open();
                String sqlQuery = "SELECT TextID, StoryTitle FROM Story WHERE UserID = @UserID";
                SqlCommand comm = new SqlCommand(sqlQuery, con);
                comm.Parameters.AddWithValue("@UserID", Session["UserId"]);
                SqlDataReader srd = comm.ExecuteReader();
                if (srd.HasRows)
                {
                    ddlusersstories.DataSource = srd;
                    ddlusersstories.DataTextField = "StoryTitle";
                    ddlusersstories.DataValueField = "TextID";
                    ddlusersstories.DataBind();
                }
                con.Close();
                ddlusersstories.Items.Insert(0, new ListItem("Select a Story", "0"));//placeholder for when page is first loaded
                ddlusersstories.Items[0].Selected = true;
                ddlusersstories.Items[0].Attributes["disabled"] = "disabled";

                String URL = "http://saworker.storyanalyzer.org/saresults.php?uid="+txtEmail.Text+"&request=listsaextracts";

                var response = hClient.GetStringAsync(new Uri(URL)).Result;

                var jsondata = JsonDocument.Parse(response);

                ddlExtracts.Items.Clear();

                // for each root element in the JSON array, extract it,
                //  get the properties of each (like columns from a SELECT query)
                //  and display in the DDL.
                foreach (var item in jsondata.RootElement.EnumerateArray())
                {
                    var text = item.GetProperty("userid").GetString()
                        + " " + item.GetProperty("extractrequestdate").GetString();

                    var value = "uid=" + item.GetProperty("userid").GetString()
                        + "&extractrequesttime=" + item.GetProperty("extractrequestdate").GetString();

                    ddlExtracts.Items.Add(new ListItem(text, value));

                }

            }
        }

        protected void ddlusersstories_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT TextID, StoryTitle, StorySource, StoryText FROM Story WHERE TextID=" + ddlusersstories.SelectedValue, con);
            SqlDataReader srd = comm.ExecuteReader();
            if (srd.Read())
            {
                //Session["TextID"] = srd.GetValue(0);
                //txtstorytile.Text = srd.GetValue(1).ToString();
                ////var storyDateTime = DateTime.Parse(srd.GetValue(1).ToString());// guarantees that the date being sent to text box is in validation format                   
                //txtstorysource.Text = srd.GetValue(2).ToString();
                //txtstorytext.Text = srd.GetValue(3).ToString();
                txtTitle.Text = srd.GetValue(1).ToString();
                txtURL.Text = srd.GetValue(2).ToString();
                txtStory.Text = srd.GetValue(3).ToString();
            }
            srd.Close();
            con.Close();



        }

        

        //protected void btnSubmitRequest_Click1(object sender, EventArgs e)
        //{
        //    con.Open();
        //    string requestInsert = "INSERT INTO AnalysisRecord (UserID, TextID, AnalysisTitle, AnalysisDate, AnalysisSource, AnalysisRecord, AnalysisReason) VALUES (@UserID, @TextID, @AnalysisTitle, @AnalysisDate, @AnalysisSource, @AnlysisReport, @AnalysisReason)";
        //    SqlCommand comm = new SqlCommand(requestInsert, con);
        //    SqlParameter[] param = new SqlParameter[7];
        //    param[0] = new SqlParameter("@UserID", (int)Session["UserID"]);
        //    param[1] = new SqlParameter("@TextID", (int)Session["TextID"]);
        //    param[2] = new SqlParameter("@AnalysisTitle", txtstorytile.Text);
        //    param[3] = new SqlParameter("@AnalysisDate", txtsubmissiondate.Text);
        //    param[4] = new SqlParameter("@AnalysisSource", txtstorysource.Text);
        //    param[5] = new SqlParameter("@AnalysisRecord", "This is a placehold, functionality to be added soon");
        //    param[6] = new SqlParameter("@AnalysisReason", "Placeholder for database");
        //    comm.Parameters.Add(param[0]);
        //    comm.Parameters.Add(param[1]);
        //    comm.Parameters.Add(param[2]);
        //    comm.Parameters.Add(param[3]);
        //    comm.Parameters.Add(param[4]);
        //    comm.Parameters.Add(param[5]);
        //    comm.Parameters.Add(param[6]);
        //    comm.ExecuteNonQuery();
        //    con.Close();
        //}
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            // Using our hClient HTTPClient instance object data field from above

            /*
             * Remember that when sending a new story to SA that the analysis may take
             * a few minutes! It will not show up immediately. For the editing of 
             * analyses, I would advise editing an existing analysis extract.
             *
             **/

            /*
             * The saextract POST request requires the following key and value pairs
             * as its data (the content of the command). The first three are required with
             * ALL Story Analyzer POST requests.
             *
             * uid - the email address of the analysis user
             * extractrequesttime - the time of a particular analysis "y-m-d h:m:s" format
             * request - this is the specific command: here its 'saextract' as we are requesting a new extract.
             * 
             * 'saextract' requires the following additional pieces of data:
             * title - The title of the new story to be analyzed.
             * source - the URL or alternative source of the story.
             * narrative - This is the body/text of the story.
            */

            // Create a Dictionary object that will store the data of the POST 
            //  request.
            var postData = new Dictionary<String, String>();

            // These three 
            postData.Add("uid", txtEmail.Text); // User who owns this analysis
            postData.Add("extractrequesttime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // Current Time and Date
            // Great website tutorial for DateTime Formatting: https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1
            postData.Add("request", ddlCommands.SelectedItem.ToString()); // The command we want to execute with POST - Should be "saextract"
            // SelectedItem should be the one selected in the DDL on the form - "saextract"

            // Extra parameters needed for the "saextract" command
            // Other POST commands for SA may require extra parameters like this
            //  so check each one carefully!
            postData.Add("title", txtTitle.Text); // Title of the new story
            postData.Add("source", txtURL.Text); // URL/Source Description of the new story
            postData.Add("narrative", txtStory.Text); // Body of the new story.
            // Might be a good idea to strip out any errant characters here: apostrophes, colons, etc.

            var content = new FormUrlEncodedContent(postData);

            lblPostResponseMessage.Text = content.ToString();

            var response = hClient.PostAsync("http://saworker.storyanalyzer.org/saresults.php", content);



            // These lines are optional, just printing to the form the results of the POST request.
            // A status code of OK and/or 200 are good! You should research the HTTP POST response codes
            // so that you can use logic to print the appropriate result to the user.
            var responseString = response.Result.StatusCode;
            //lblPostResponseMessage.Text += responseString.ToString() + " " + response.Result.ToString();
            lblPostResponseMessage.Text = "Request has been sent. Check view reports in a few minutes to view the report.";


        }
    }
}