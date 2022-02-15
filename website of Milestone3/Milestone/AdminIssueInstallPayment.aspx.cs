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
    public partial class AdminIssueInstallPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(paymentID.Text) ||
               String.IsNullOrEmpty(InstallStartDate.Text))
            {
                Response.Write("<script>alert('you must fill all boxes');</script>");
            }
            else
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int PaymentID = Int16.Parse(paymentID.Text);
                DateTime Install_Start_Date = DateTime.Parse(InstallStartDate.Text);

                SqlCommand adminIssueThesisPay = new SqlCommand("AdminIssueInstallPayment", conn);
                adminIssueThesisPay.CommandType = CommandType.StoredProcedure;

                adminIssueThesisPay.Parameters.Add(new SqlParameter("@paymentID ", PaymentID));
                adminIssueThesisPay.Parameters.Add(new SqlParameter("@InstallStartDate", Install_Start_Date));
                conn.Open();
                adminIssueThesisPay.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('Succesful Issue');</script>");
            }
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }
    }
}