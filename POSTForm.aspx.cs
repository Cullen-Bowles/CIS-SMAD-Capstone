using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace InClassWebApp
{
    public partial class POSTForm : System.Web.UI.Page
    {

        HttpClient hClient = new HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String URL = "http://saworker.storyanalyzer.org/saresults.php?uid=ezelljd@jmu.edu&request=listsaextracts";

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
            postData.Add("uid","ezelljd@jmu.edu"); // User who owns this analysis
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
            lblPostResponseMessage.Text += responseString.ToString() + " " + response.Result.ToString();


        }
    }
}