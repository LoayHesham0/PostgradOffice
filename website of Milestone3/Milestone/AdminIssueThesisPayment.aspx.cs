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
    public partial class AdminIssueThesisPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ThesisSerialNo.Text) ||
               String.IsNullOrEmpty(amount.Text) ||
               String.IsNullOrEmpty(noOfInstallments.Text) ||
               String.IsNullOrEmpty(fundPercentage.Text))
            {
                Response.Write("<script>alert('you must fill all boxes');</script>");
            }
            else
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int ThesisSerialNumber = Int16.Parse(ThesisSerialNo.Text);
                int Amount = Int16.Parse(amount.Text);
                int NumberOfInstallments = Int16.Parse(noOfInstallments.Text);
                float FundPercentage = float.Parse(fundPercentage.Text);

                SqlCommand adminIssueThesisPay = new SqlCommand("AdminIssueThesisPayment", conn);
                adminIssueThesisPay.CommandType = CommandType.StoredProcedure;

                adminIssueThesisPay.Parameters.Add(new SqlParameter("@ThesisSerialNo", ThesisSerialNumber));
                adminIssueThesisPay.Parameters.Add(new SqlParameter("@amount", Amount));
                adminIssueThesisPay.Parameters.Add(new SqlParameter("@noOfInstallments", NumberOfInstallments));
                adminIssueThesisPay.Parameters.Add(new SqlParameter("@fundPercentage", FundPercentage));

                conn.Open();
                adminIssueThesisPay.ExecuteNonQuery();
                conn.Close();

                Response.Write("<script>alert('Succesful Issue');</script>");


            }
        }
    }
}