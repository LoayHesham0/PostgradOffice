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
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void studentRegister_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(first_name.Text) ||
                String.IsNullOrEmpty(last_name.Text) ||
                String.IsNullOrEmpty(faculty.Text) ||
                String.IsNullOrEmpty(address.Text) ||
                String.IsNullOrEmpty(gucian.Text.ToString()) ||
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
            string faculty_type = faculty.Text;
            string specific_address = address.Text;
            string Gucian = gucian.Text.ToString();
            string electronicmail = email.Text;
            string pass = password.Text;

            SqlCommand Studentproc = new SqlCommand("StudentRegister", conn);
            Studentproc.CommandType = CommandType.StoredProcedure;

            Studentproc.Parameters.Add(new SqlParameter("@first_name", firstname));
            Studentproc.Parameters.Add(new SqlParameter("@last_name", lastname));
            Studentproc.Parameters.Add(new SqlParameter("@faculty", faculty_type));
            Studentproc.Parameters.Add(new SqlParameter("@address", specific_address));
            Studentproc.Parameters.Add(new SqlParameter("@Gucian", Gucian));
            Studentproc.Parameters.Add(new SqlParameter("@email", electronicmail));
            Studentproc.Parameters.Add(new SqlParameter("@password", pass));

            conn.Open();
            Studentproc.ExecuteNonQuery();
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