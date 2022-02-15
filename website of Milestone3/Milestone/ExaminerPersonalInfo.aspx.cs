using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone
{
    public partial class ExaminerPersonalInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examiner.aspx");
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int id = (int)Session["UserId"];
            String name = nameBox.Text;
            String fieldOfWork = fieldOfWorkBox.Text;

            SqlCommand UpdateExaminerProfile = new SqlCommand("UpdateExaminerProfile", conn);
            UpdateExaminerProfile.CommandType = CommandType.StoredProcedure;
            UpdateExaminerProfile.Parameters.Add(new SqlParameter("@ExaminerID", id));
            UpdateExaminerProfile.Parameters.Add(new SqlParameter("@name", name));
            UpdateExaminerProfile.Parameters.Add(new SqlParameter("@fieldOfWork", fieldOfWork));

            conn.Open();
            UpdateExaminerProfile.ExecuteNonQuery();
            conn.Close();
        }
    }
}