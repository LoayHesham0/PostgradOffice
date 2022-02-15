using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone
{
    public partial class supervisor1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EvaluateButton(object sender, EventArgs e)
        {
            Response.Redirect("Evaluate.aspx");
        }

        protected void ListMyButton(object sender, EventArgs e)
        {
            Response.Redirect("ListMy.aspx");
        }

        protected void ViewPubsButton(object sender, EventArgs e)
        {
            Response.Redirect("ViewPubs.aspx");
        }

        protected void AddButton(object sender, EventArgs e)
        {
            Response.Redirect("AddADefenseOrExaminer.aspx");
        }

        protected void CancelButton(object sender, EventArgs e)
        {
            Response.Redirect("CancelThesis.aspx");
        }

        protected void BackButton(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void AddPhoneNumber_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorAddPhoneNumber.aspx");
        }
    }
}