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
    public partial class examiner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void examinerRegister_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(first_name.Text) ||
                String.IsNullOrEmpty(last_name.Text) ||
                String.IsNullOrEmpty(fieldOfWork.Text) ||
                String.IsNullOrEmpty(isNational.Text) ||
                String.IsNullOrEmpty(email.Text) ||
                String.IsNullOrEmpty(password.Text))
            {
                Response.Write("<script>alert('you must fill all boxes');</script>");
            }
            else
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                string firstname = first_name.Text;
                string lastname = last_name.Text;
                string field_of_work = fieldOfWork.Text;
                string is_National = isNational.Text.ToString();
                string electronicmail = email.Text;
                string pass = password.Text;

                SqlCommand examinerproc = new SqlCommand("ExaminerRegister", conn);
                examinerproc.CommandType = CommandType.StoredProcedure;

                examinerproc.Parameters.Add(new SqlParameter("@first_name", firstname));
                examinerproc.Parameters.Add(new SqlParameter("@last_name", lastname));
                examinerproc.Parameters.Add(new SqlParameter("@fieldOfWork", field_of_work));
                examinerproc.Parameters.Add(new SqlParameter("@isNational", is_National));
                examinerproc.Parameters.Add(new SqlParameter("@email", electronicmail));
                examinerproc.Parameters.Add(new SqlParameter("@password", pass));

                conn.Open();
                examinerproc.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("login.aspx");
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}