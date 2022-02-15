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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String ConnStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();

            SqlConnection conn = new SqlConnection(ConnStr);



            int idnum = Int32.Parse(Session["UserId"].ToString());

            SqlCommand ViewCoursesGrades = new SqlCommand("ViewCoursesGrades", conn);
            ViewCoursesGrades.CommandType = CommandType.StoredProcedure;
            ViewCoursesGrades.Parameters.Add(new SqlParameter("@studentId", idnum));


            conn.Open();


            SqlDataReader rdr = ViewCoursesGrades.ExecuteReader(CommandBehavior.CloseConnection);
            String separator = "<br />";

            Label resultString = new Label();
            resultString.Text = "Courses & Grades : " + separator + separator;
            form1.Controls.Add(resultString);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(rdr.GetOrdinal("Course Code")))
                {
                    String CourseCode = rdr.GetString(rdr.GetOrdinal("Course Code"));
                    Label CourseCodelabel = new Label();
                    CourseCodelabel.Text = "Course Code : " + CourseCode + " | ";
                    form1.Controls.Add(CourseCodelabel);
                }
                else
                {
                    Label CourseCodelabel = new Label();
                    CourseCodelabel.Text = "Course Code : NULL     " + " | ";
                    form1.Controls.Add(CourseCodelabel);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("Grade")))
                {
                    Decimal Grade = rdr.GetDecimal(rdr.GetOrdinal("Grade"));
                    Label Gradelabel = new Label();
                    Gradelabel.Text = "Grade : " + Grade + " | ";
                    form1.Controls.Add(Gradelabel);
                }
                else
                {
                    Label Gradelabel = new Label();
                    Gradelabel.Text = "Grade : NULL     " + " | ";
                    form1.Controls.Add(Gradelabel);

                }


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RouterPage.aspx");
        }
    }
}