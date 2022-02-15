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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String ConnStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();

            SqlConnection conn = new SqlConnection(ConnStr);
            
            int idnum = (int)Session["UserId"];

            SqlCommand GetName = new SqlCommand("GetName", conn);
            GetName.CommandType = CommandType.StoredProcedure;
            GetName.Parameters.Add(new SqlParameter("@studentID", idnum));

            conn.Open();
            SqlDataReader rdr = GetName.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr.Read())
            {


                
                String firstname = rdr.GetString(rdr.GetOrdinal("firstName"));
                Label Welcome = new Label();
                Welcome.Text = "Welcome " + firstname;
                form1.Controls.Add(Welcome);
            }
            


        }

        protected void View_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewMyProfile.aspx");
        }

        protected void List_Click(object sender, EventArgs e)
        {
            Response.Redirect("GetThesis.aspx");
        }

        protected void CoursesAndGrades_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCourses.aspx");
        }

        protected void PR_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddFillProg.aspx");
        }

        protected void addpub_Click(object sender, EventArgs e)
        {
            Response.Redirect("addlinkpub.aspx");
        }

    }


}