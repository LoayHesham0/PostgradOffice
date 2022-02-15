using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void supervisor_Click(object sender, EventArgs e)
        {
            Response.Redirect("supervisorreg.aspx");
        }

        protected void examiner_Click(object sender, EventArgs e)
        {

            Response.Redirect("examinerreg.aspx");
        }

        protected void student_Click(object sender, EventArgs e)
        {

            Response.Redirect("studentreg.aspx");
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}