using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone
{
    public partial class Examiner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExaminerPersonalInfo.aspx");
        }

        protected void listButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExaminerListThesis.aspx");
        }

        protected void commentButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExaminerAddComment.aspx");
        }
        
        protected void gradeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExaminerAddGrade.aspx");
        }

        protected void searchForThesisButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ExaminerSearchForThesis.aspx");
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void AddPhoneNumber_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExaminerAddPhoneNumber.aspx");
        }
    }
}