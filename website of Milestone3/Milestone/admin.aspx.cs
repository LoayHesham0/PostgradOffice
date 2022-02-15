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
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void listsupname_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminListSup.aspx");

        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void Listthesesandcount_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminViewAllThesesAndAdminviewOnGoingTheses.aspx");
        }

        protected void issuethesispayment_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminIssueThesisPayment.aspx");
        }

        protected void AdminIssueInstallPayment_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminIssueInstallPayment.aspx");
        }

        protected void AdminUpdateExtension_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminUpdateExtension.aspx");
        }

        protected void AddPhoneNumber_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAddPhoneNumber.aspx");
        }
    }
}