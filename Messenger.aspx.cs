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
    public partial class Messanger : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString);
        SqlConnection con2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)//forces the page back to the sign in page if the user is not signed in
            {
                Session["InvalidUsage"] = "Guests cannot access this page, Please sign in";
                Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                con.Open();
                String sqlQuery = "SELECT UserID, SharedUserID, SharedUsername FROM AnalysisCommons WHERE UserID = @UserID";
                SqlCommand comm = new SqlCommand(sqlQuery, con);
                comm.Parameters.AddWithValue("@UserID", Session["UserID"]);
                SqlDataReader srd = comm.ExecuteReader();
                ddlsharedusers.DataSource = srd;
                ddlsharedusers.DataTextField = "SharedUsername";
                ddlsharedusers.DataValueField = "SharedUserID";
                ddlsharedusers.DataBind();
                con.Close();
                ddlsharedusers.Items.Insert(0, new ListItem("Select an Associate", "0"));//placeholder for when page is first loaded
                ddlsharedusers.Items[0].Selected = true;
                ddlsharedusers.Items[0].Attributes["disabled"] = "disabled";

                con2.Open();
                String getMessages = "SELECT Body, CreatedByUsername, IsRead FROM Messenger WHERE ToUserID = @UserID AND IsRead = " + 0;
                SqlCommand com1 = new SqlCommand(getMessages, con2);
                com1.Parameters.AddWithValue("@UserID", Session["UserID"]);
                SqlDataReader sdr = com1.ExecuteReader();
                while (sdr.Read())
                {
                    txtmessages.Text = sdr.GetValue(1).ToString() + ": " + sdr.GetValue(0).ToString() + "\n";
                }
                sdr.Close();
                String isRead = "UPDATE Messenger SET IsRead = " + 1 + ", DateRead = '" + DateTime.Today.ToString("u") + "' WHERE ToUserID = @UserID";
                SqlCommand com2 = new SqlCommand(isRead, con2);
                com2.Parameters.AddWithValue("@UserID", Session["UserID"]);
                com2.ExecuteNonQuery();
                con2.Close();
            }
        }

        protected void ddlsharedusers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SharedUserID"] = ddlsharedusers.SelectedValue;
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(ddlsharedusers.SelectedValue) != 0)
            {
                con2.Open();
                String sqlMessage = "INSERT INTO Messenger (Body, Created, CreatedBy, ToUserID, IsRead, CreatedByUsername) VALUES (@Body, @Created, @CreatedBy, @ToUserID, @IsRead, @CreatedByUsername)";
                SqlCommand comm = new SqlCommand(sqlMessage, con2);
                int notRead = 0;
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Body", txtmessage.Text);
                param[1] = new SqlParameter("@Created", DateTime.Today.ToString("u"));
                param[2] = new SqlParameter("@CreatedBy", Session["UserID"]);
                param[3] = new SqlParameter("@ToUserID", Session["SharedUserID"]);
                param[4] = new SqlParameter("@IsRead", notRead);
                param[5] = new SqlParameter("@CreatedByUsername", Session["Username"]);
                comm.Parameters.Add(param[0]);
                comm.Parameters.Add(param[1]);
                comm.Parameters.Add(param[2]);
                comm.Parameters.Add(param[3]);
                comm.Parameters.Add(param[4]);
                comm.Parameters.Add(param[5]);
                comm.ExecuteNonQuery();
                con2.Close();
            }
            else
            {

            }

        }
    }
}