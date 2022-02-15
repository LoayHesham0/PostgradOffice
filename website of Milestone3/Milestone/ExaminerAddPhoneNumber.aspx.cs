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
    public partial class ExaminerAddPhoneNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int IDnumber = Int16.Parse(id.Text);
            string Phone_Number = phone_number.Text;

            SqlCommand ExaminerAddPhoneNumber = new SqlCommand("Addmobile", conn);
            ExaminerAddPhoneNumber.CommandType = CommandType.StoredProcedure;

            ExaminerAddPhoneNumber.Parameters.Add(new SqlParameter("@id", IDnumber));
            ExaminerAddPhoneNumber.Parameters.Add(new SqlParameter("@mobile_number", Phone_Number));

            conn.Open();
            ExaminerAddPhoneNumber.ExecuteNonQuery();
            conn.Close();
        }
        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examiner.aspx");
        }

        
    }
}