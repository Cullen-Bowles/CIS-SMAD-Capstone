namespace WebApplication4
{
    using System;
    using System.Data.SqlClient;
    using System.Web.Configuration;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Messanger : Page
    {
        private readonly SqlConnection con =
            new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString);

        private readonly SqlConnection con2 =
            new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null) //forces the page back to the sign in page if the user is not signed in
            {
                Session["InvalidUsage"] = "Guests cannot access this page, Please sign in";
                Response.Redirect("Login.aspx");
            }

            if (!Page.IsPostBack)
            {
                con.Open();
                var sqlQuery =
                    "SELECT UserID, SharedUserID, SharedUsername FROM AnalysisCommons WHERE UserID = @UserID";
                var comm = new SqlCommand(sqlQuery, con);
                comm.Parameters.AddWithValue("@UserID", Session["UserID"]);
                var srd = comm.ExecuteReader();
                ddlsharedusers.DataSource = srd;
                ddlsharedusers.DataTextField = "SharedUsername";
                ddlsharedusers.DataValueField = "SharedUserID";
                ddlsharedusers.DataBind();
                con.Close();
                ddlsharedusers.Items.Insert(0,
                    new ListItem("Select an Associate", "0")); //placeholder for when page is first loaded
                ddlsharedusers.Items[0].Selected = true;
                ddlsharedusers.Items[0].Attributes["disabled"] = "disabled";

                con2.Open();
                var getMessages =
                    "SELECT Id, Body, CreatedByUsername, IsRead, Created FROM Messenger WHERE ToUserID = @UserID AND IsRead = 0"; // + 0;
                var com1 = new SqlCommand(getMessages, con2);
                com1.Parameters.AddWithValue("@UserID", Session["UserID"]);
                var sdrMessages = com1.ExecuteReader();

                dsMessages.DataSource = sdrMessages;
                dsMessages.DataBind();

                //while (sdr.Read()) txtmessages.Text = sdr.GetValue(1) + ": " + sdr.GetValue(0) + "\n";
                //sdr.Close();

                // update call  ??
                ////String isRead = "UPDATE Messenger SET IsRead = " + 1 + ", DateRead = '" + DateTime.Today.ToString("u") + "' WHERE ToUserID = @UserID";
                //var isRead = "UPDATE Messenger SET IsRead = " + 1 + ", DateRead = '" + DateTime.Now +
                //             "' WHERE ToUserID = @UserID";
                //var com2 = new SqlCommand(isRead, con2);
                //com2.Parameters.AddWithValue("@UserID", Session["UserID"]);
                //com2.ExecuteNonQuery();
                //con2.Close();
            }
        }

        protected void ddlsharedusers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SharedUserID"] = ddlsharedusers.SelectedValue;
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            if (int.Parse(ddlsharedusers.SelectedValue) != 0)
            {
                con2.Open();
                var sqlMessage =
                    "INSERT INTO Messenger (Body, Created, CreatedBy, ToUserID, IsRead, CreatedByUsername) VALUES (@Body, @Created, @CreatedBy, @ToUserID, @IsRead, @CreatedByUsername)";
                var comm = new SqlCommand(sqlMessage, con2);
                var notRead = 0;
                var param = new SqlParameter[6];
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
        }

        protected void btnRead_OnClick(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var id = btn.CommandArgument;

            // use same button for command with CommandName then a switch call
            switch (btn.CommandName)
            {
                case "MarkOneRead":
                    MarkMessageRead(btn.CommandArgument);
                    break;
                case "MarkAllRead":
                    MarkAllMessagesRead(btn.CommandArgument);
                    break;
            }

            Response.Redirect("Messenger.aspx");
        }

        private void MarkAllMessagesRead(string commandArgument)
        {
            var isRead = "UPDATE Messenger SET IsRead = " + 1 + ", DateRead = '" + DateTime.Now +
                         "' WHERE ToUserID = @ID AND IsRead = 0";
            var com2 = new SqlCommand(isRead, con2);
            con2.Open();
            com2.Parameters.AddWithValue("@ID", Session["UserId"]);
            com2.ExecuteNonQuery();
            con2.Close();

            UpdateCount();
        }

        private void MarkMessageRead(string commandArgument)
        {
            //String isRead = "UPDATE Messenger SET IsRead = " + 1 + ", DateRead = '" + DateTime.Today.ToString("u") + "' WHERE ID = @ID";
            var isRead = "UPDATE Messenger SET IsRead = " + 1 + ", DateRead = '" + DateTime.Now +
                         "' WHERE ID = @ID";
            var com2 = new SqlCommand(isRead, con2);
            con2.Open();
            com2.Parameters.AddWithValue("@ID", commandArgument);
            com2.ExecuteNonQuery();
            con2.Close();

            UpdateCount();
        }

        private void UpdateCount()
        {
            var sqlQuery =
                "SELECT COUNT(ID) as MessageCount FROM Messenger WHERE ToUserID = @UserID AND IsRead = 0";
            var comm = new SqlCommand(sqlQuery, con2);
            comm.Parameters.AddWithValue("@UserID", Session["UserID"]);
            con2.Open();
            var srd = comm.ExecuteReader();
            if (srd.Read()) Session["MessageCount"] = srd.GetValue(0).ToString();
            con2.Close();
        }
    }
}