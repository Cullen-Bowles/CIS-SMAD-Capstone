namespace WebApplication4
{
    using System;
    using System.Data.SqlClient;
    using System.Net.Http;
    using System.Text.Json;
    using System.Web.Configuration;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class ViewReports : Page
    {
        private readonly SqlConnection con2 =
            new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

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
                //con2.Open();
                //var email = "SELECT Email FROM Person WHERE UserID = @UserID";
                //var com1 = new SqlCommand(email, con2);
                //com1.Parameters.AddWithValue("@UserID", Session["UserID"]);
                //var src = com1.ExecuteReader();
                //if (src.Read()) txtEmail.Text = src.GetValue(0).ToString();
                //con2.Close();
                //con.Open();
                //String sqlQuery = "SELECT AnalysisNumber, AnalysisTitle FROM AnalysisRecord WHERE UserID = @UserID";
                //SqlCommand comm = new SqlCommand(sqlQuery, con);
                //comm.Parameters.AddWithValue("@UserID", Session["UserId"]);
                //SqlDataReader srd = comm.ExecuteReader();
                //if (srd.HasRows)
                //{
                //    ddlusersreports.DataSource = srd;
                //    ddlusersreports.DataTextField = "StoryTitle";
                //    ddlusersreports.DataValueField = "TextID";
                //    ddlusersreports.DataBind();
                //}
                //con.Close();
                //ddlusersreports.Items.Insert(0, new ListItem("Select a Report", "0"));//placeholder for when page is first loaded
                //ddlusersreports.Items[0].Selected = true;
                //ddlusersreports.Items[0].Attributes["disabled"] = "disabled";

                // Format the URL. We will use the SA API command "listsaextracts" to see all extracts
                //  under this particular user.
                var URL = "http://saworker.storyanalyzer.org/saresults.php?uid=" + txtEmail.Text +
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

        //protected void ddlusersstories_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    con.Open();
        //    string getReport = "SELECT AnalysisTitle, AnalysisDate, AnalysisSource, AnalysisReport FROM AnalysisRecord WHERE AnalysisNumber="+ddlusersreports.SelectedValue;
        //    SqlCommand comm = new SqlCommand(getReport, con);
        //    SqlDataReader src = comm.ExecuteReader();
        //    if(src.Read())
        //    {
        //        txtstorytext.Text = src.GetValue(0).ToString();
        //        txtsubmissiondate.Text = src.GetValue(1).ToString();
        //        txtstorysource.Text = src.GetValue(2).ToString();
        //        txtstorytext.Text = src.GetValue(3).ToString();
        //    }
        //    con.Close();
        //}

        protected void
            btnMakeRequest_Click(object sender,
                EventArgs e) // Rest get to show users what the 3rd party app will return when full connection is established
        {
            // Use the selected command from Dr. Mitri's SA REST API
            // to retrieve results from the SA Server.

            var URL = "http://saworker.storyanalyzer.org/saresults.php?"
                      + ddlSAList.SelectedValue
                      + "&request="
                      + ddlRequest.SelectedValue;

            // Issue the GET command to the SA Server and get the response.
            var response = hClient.GetStringAsync(new Uri(URL)).Result;


            // The response could be plain text for some API commands
            //  or it could be HTML (to show a visualization)
            if (ddlRequest.SelectedIndex >= 0 && ddlRequest.SelectedIndex <= 3)
                // The result is plain text: A URL for the source for example or story title.
                txtDisplay.Text = response;
            else if (ddlRequest.SelectedValue.Equals("showbootstrapdashboard"))
                // Here the user has selected to show the bootstrap dashboard.
                // We will open the URL for the dashboard in a new tab.
                Page.ClientScript.RegisterStartupScript(GetType(), "OpenWindow",
                    "window.open('" + URL + "','_newtab');", true);
            //Response.Redirect(URL);
            else
                // The results are HRML for a visualization. I'll replace the contents
                // of a DIV on the ASP.net form with the results
                // This will dynamically update the HTML page.
                displayViz.InnerHtml = response;
        }
    }
}