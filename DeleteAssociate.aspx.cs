using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;
using System.IO;

namespace WebApplication4
{
    public partial class DeleteAssociate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CS = WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {

                    //fills drop down list with story titles
                    SqlCommand cmd = new SqlCommand("SELECT SharedUsername FROM AnalysisCommons WHERE UserID = '" + Session["UserID"].ToString() + "'", con);
                    con.Open();

                    DropDownList1.DataSource = cmd.ExecuteReader();
                    DropDownList1.DataTextField = "SharedUsername";
                    DropDownList1.DataValueField = "SharedUsername";
                    DropDownList1.DataBind();

                    con.Close();
                }
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["StoryAnalyzer"].ConnectionString);
            sqlConnect.Open();


            //removing friend from database which will get rid of it in the gridview
            String delete = "DELETE from AnalysisCommons WHERE UserID = @UserID AND SharedUsername = @SharedUsername";
            SqlCommand query = new SqlCommand(delete, sqlConnect);
            query.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            query.Parameters.AddWithValue("@SharedUsername", DropDownList1.SelectedValue.ToString());
            query.ExecuteNonQuery();

            lblRemove.Text = "Successfully removed colleague";
            lblRemove.ForeColor = System.Drawing.Color.Green;

        }
    }
}