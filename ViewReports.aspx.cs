using System;
using System.Collections.Generic;
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

namespace WebApplication4
{
    public partial class ViewReports : System.Web.UI.Page
    {
        HttpClient hClient = new HttpClient();
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                con.Open();
                String sqlQuery = "SELECT AnalysisNumber, AnalysisTitle FROM AnalysisRecord WHERE UserID = @UserID";
                SqlCommand comm = new SqlCommand(sqlQuery, con);
                comm.Parameters.AddWithValue("@UserID", Session["UserId"]);
                SqlDataReader srd = comm.ExecuteReader();
                ddlusersreports.DataSource = srd;
                ddlusersreports.DataTextField = "StoryTitle";
                ddlusersreports.DataValueField = "TextID";
                ddlusersreports.DataBind();
                con.Close();
                ddlusersreports.Items.Insert(0, new ListItem("Select a Report", "0"));//placeholder for when page is first loaded
                ddlusersreports.Items[0].Selected = true;
                ddlusersreports.Items[0].Attributes["disabled"] = "disabled";
                // Format the URL. We will use the SA API command "listsaextracts" to see all extracts
                //  under this particular user.
                String URL = "http://saworker.storyanalyzer.org/saresults.php?uid=bowlescx@dukes.jmu.edu&request=listsaextracts";

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

        protected void ddlusersstories_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string getReport = "SELECT AnalysisTitle, AnalysisDate, AnalysisSource, AnalysisReport FROM AnalysisRecord WHERE AnalysisNumber="+ddlusersreports.SelectedValue;
            SqlCommand comm = new SqlCommand(getReport, con);
            SqlDataReader src = comm.ExecuteReader();
            if(src.Read())
            {
                txtstorytext.Text = src.GetValue(0).ToString();
                txtsubmissiondate.Text = src.GetValue(1).ToString();
                txtstorysource.Text = src.GetValue(2).ToString();
                txtstorytext.Text = src.GetValue(3).ToString();
            }
            con.Close();
        }

        
    }
}