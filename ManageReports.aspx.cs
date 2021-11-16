namespace WebApplication4
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Web.Configuration;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Models;

    public partial class ManageReports : Page
    {
        private readonly HttpClient hClient = new HttpClient();

        private SqlConnection con =
            new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null) //forces the page back to the sign in page if the user is not signed in
            {
                Session["InvalidUsage"] = "Guests cannot access this page, Please sign in";
                Response.Redirect("Login.aspx");
            }
            else if (!Page.IsPostBack)
            {
                var URL = "http://saworker.storyanalyzer.org/saresults.php?uid=" + Session["email"] +
                          "&request=listsaextracts";

                // Issue a GET request and get the results from the server.
                var response = hClient.GetStringAsync(new Uri(URL)).Result;

                // Parse the results into a JSONDocument. This formats the returned data into a traditional
                // JSON structure that can be traversed (walked).
                var jsondata = JsonDocument.Parse(response);

                // Clear out the list (just housekeeping)
                ddlSAList.Items.Clear();

                // for each root element in the JSON array, extract it,
                //  get the properties of each (like columns from a SELECT query)
                //  and display in the DDL.
                foreach (var item in jsondata.RootElement.EnumerateArray())
                {
                    var text = item.GetProperty("userid").GetString()
                               + " " + item.GetProperty("extractrequestdate").GetString();

                    var value = "uid=" + item.GetProperty("userid").GetString()
                                       + "&extractrequesttime=" + item.GetProperty("extractrequestdate").GetString();

                    ddlSAList.Items.Add(new ListItem(text, value));
                }
            }
        }

        protected void
            btnMakeRequest_Click(object sender,
                EventArgs e) // Rest get to show users what the 3rd party app will return when full connection is established
        {
            // Use the selected command from Dr. Mitri's SA REST API
            // to retrieve results from the SA Server.

            var URL = "http://saworker.storyanalyzer.org/saresults.php?"
                      + ddlSAList.SelectedValue
                      + "&request=gettitle";
            var URL2 = "http://saworker.storyanalyzer.org/saresults.php?"
                       + ddlSAList.SelectedValue
                       + "&request=getsource";
            var URL3 = "http://saworker.storyanalyzer.org/saresults.php?"
                       + ddlSAList.SelectedValue
                       + "&request=getsentencedetails";
            var URL4 = "http://saworker.storyanalyzer.org/saresults.php?"
                       + ddlSAList.SelectedValue
                       + "&request=getpeople";


            // Issue the GET command to the SA Server and get the response.
            var response = hClient.GetStringAsync(new Uri(URL)).Result;
            var response2 = hClient.GetStringAsync(new Uri(URL2)).Result;
            var response3 = hClient.GetStringAsync(new Uri(URL3)).Result;
            var response4 = hClient.GetStringAsync(new Uri(URL4)).Result;
            // The response could be plain text for some API commands
            //  or it could be HTML (to show a visualization)
            txtstorytitle.Text = response;
            txtstorysource.Text = response2;
            if (ddlRequest.SelectedValue.Equals("setsentencedetails"))
            {
                var sentenceReponse = GetSentenceExtract();
                txtstorytext.Text = "";
                txtstorytext.Text = sentenceReponse;
                txtstorytitle.ReadOnly = true;
                txtstorysource.ReadOnly = true;
                txtstorytext.ReadOnly = false;

                // parse to Object
                var extracts = Root.FromJson(sentenceReponse);
                FillSentenceDropdown(extracts);

                // TODO: take the object, put the sentences into a dropdown with sentenceNbr/sentence
                //      then on select, fill second dropdown with tokens  #/token
                //      text box for new value
                //      submit build the setsentence request command
            }
            else if (ddlRequest.SelectedValue.Equals("settokensdetail"))
            {
                txtstorytext.Text = "";
                txtstorytext.Text = response4;
                txtstorytitle.ReadOnly = true;
                txtstorysource.ReadOnly = true;
                txtstorytext.ReadOnly = false;
            }
            else if (ddlRequest.SelectedValue.Equals("settitle"))
            {
                txtstorytitle.ReadOnly = false;
                txtstorysource.ReadOnly = true;
                txtstorytext.ReadOnly = true;
            }
            else if (ddlRequest.SelectedValue.Equals("setsource"))
            {
                txtstorytitle.ReadOnly = true;
                txtstorysource.ReadOnly = false;
                txtstorytext.ReadOnly = true;
            }
        }

        private void FillSentenceDropdown(Root[] extracts)
        {
            ddlSentences.Items.Clear();
            // add placeholder
            if (extracts.Any())
                ddlSentences.Items.Add(new ListItem("Choose sentence...", ""));
            else
                ddlSentences.Items.Add(new ListItem("No Sentences found...", ""));

            foreach (var item in extracts)
            {
                var text = item.Sentence;

                var value = item.SentenceNbr.ToString();

                ddlSentences.Items.Add(new ListItem(text, value));
            }
        }

        protected void btnPUTedit_Click(object sender, EventArgs e)
        {
            var putData = new Dictionary<string, string>();
            putData.Add("uid", Session["email"].ToString());
            putData.Add("extractrequesttime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //putData.Add("request", ddlRequest.SelectedValue);
            if (ddlRequest.SelectedValue.Equals("settitle"))
            {
                putData.Add("request", ddlRequest.SelectedValue);
                putData.Add("title", txtstorytitle.Text);
            }

            else if (ddlRequest.SelectedValue.Equals("setsource"))
            {
                putData.Add("request", ddlRequest.SelectedValue);
                putData.Add("source", txtstorysource.Text);
            }
            else if (ddlRequest.SelectedValue.Equals("setsentencedetails"))
            {
                // TODO: come up with a way to UI friendly let user set word to change with sentence # and word # 
                // build the command
                var command = new StringBuilder();
                command.Append("setsentencedetails-");
                command.Append(ddlSentences.SelectedItem.Value);
                command.Append("-token-");
                command.Append(ddlTokens.SelectedItem.Value);
                command.Append("-");
                command.Append(tokenEdit.Text);

                // send command
                putData.Add("request", command.ToString());

                tokenEdit.Text = string.Empty;
            }

            var content = new FormUrlEncodedContent(putData);
            lblPostResponseMessage.Text = content.ToString();
            var response = hClient.PutAsync("http://saworker.storyanalyzer.org/saresults.php", content);

            var responseString = response.Result.StatusCode;
            lblPostResponseMessage.Text =
                "Request has been sent. Check view reports in a few minutes to view the report.";
        }

        protected void ddlSentences_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var sentenceNumber = ddlSentences.SelectedItem.Value;
            var sentences = GetSentenceExtract();

            ddlTokens.Items.Clear();


            var extracts = Root.FromJson(sentences);
            var sentence = extracts.Where(x => x.SentenceNbr.ToString() == sentenceNumber).Select(x => x.Sentence)
                .FirstOrDefault();
            if (sentence != null)
                txtSentence.Text = sentence;

            var tokens = extracts.Where(x => x.SentenceNbr.ToString() == sentenceNumber).Select(x => x.Tokens)
                .FirstOrDefault();
            if (tokens != null)
            {
                // add placeholder
                ddlTokens.Items.Add(new ListItem("Choose token...", ""));

                for (var i = 0; i < tokens.Length; i++)
                {
                    var text = tokens[i];

                    var value = i.ToString();

                    ddlTokens.Items.Add(new ListItem(text, value));
                }
            }
            else
            {
                ddlTokens.Items.Add(new ListItem("No Tokens found...", ""));
            }
        }

        protected string GetSentenceExtract()
        {
            var URL3 = "http://saworker.storyanalyzer.org/saresults.php?"
                       + ddlSAList.SelectedValue
                       + "&request=getsentencedetails";

            var response3 = hClient.GetStringAsync(new Uri(URL3)).Result;


            return response3;
        }
    }
}