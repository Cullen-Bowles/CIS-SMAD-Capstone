using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class ManageReports : System.Web.UI.Page
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

            }
        }
        protected void ddlusersstories_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            string getReport = "SELECT AnalysisTitle, AnalysisDate, AnalysisSource, AnalysisReport FROM AnalysisRecord WHERE AnalysisNumber=" + ddlusersreports.SelectedValue;
            SqlCommand comm = new SqlCommand(getReport, con);
            SqlDataReader src = comm.ExecuteReader();
            if (src.Read())
            {
                txtstorytext.Text = src.GetValue(0).ToString();
                txtsubmissiondate.Text = src.GetValue(1).ToString();
                txtstorysource.Text = src.GetValue(2).ToString();
                txtstorytext.Text = src.GetValue(3).ToString();
            }
            con.Close();
        }
        protected void btndeletereport_Click(object sender, EventArgs e)
        {
            con.Open();
            string sqlString = "DELETE FROM AnalysisRecord WHERE AnalysisNumber=@AnalysisNumber";
            SqlCommand comm = new SqlCommand(sqlString, con);
            comm.Parameters.AddWithValue("@AnalysisNumber", ddlusersreports.SelectedValue);
            comm.ExecuteNonQuery();
            con.Close();
            con.Open();//repopulates the list without the deleted analysis
            String sqlQuery = "SELECT AnalysisNumber, AnalysisTitle FROM AnalysisRecord WHERE UserID=@UserID";
            SqlCommand com1 = new SqlCommand(sqlQuery, con);
            SqlParameter param = new SqlParameter("@UserID", Session["UserId"]);
            com1.Parameters.Add(param);
            SqlDataReader srd = comm.ExecuteReader();
            ddlusersreports.DataSource = srd;
            ddlusersreports.DataTextField = "AnalysisTitle";
            ddlusersreports.DataValueField = "AnalysisNumber";
            ddlusersreports.DataBind();
            con.Close();
            ddlusersreports.Items.Insert(0, new ListItem("Select a report", ""));
            ddlusersreports.Items[0].Selected = true;
            ddlusersreports.Items[0].Attributes["disabled"] = "disabled";
            con.Close();
            txtstorytile.Text = "";
            txtsubmissiondate.Text = "";
            txtstorysource.Text = "";
            txtstorytext.Text = "";
        }
    }
}