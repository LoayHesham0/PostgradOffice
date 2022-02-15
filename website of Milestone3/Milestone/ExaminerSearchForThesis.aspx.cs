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
    public partial class ExaminerSearchForThesis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examiner.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String keyWord = keywordBox.Text;

            SqlCommand ExaminerSearchForThesis = new SqlCommand("ExaminerSearchForThesis", conn);
            ExaminerSearchForThesis.CommandType = CommandType.StoredProcedure;
            ExaminerSearchForThesis.Parameters.Add(new SqlParameter("@keyword", keyWord));


            //ExaminerSearchForThesis.ExecuteNonQuery();
            conn.Open();
            SqlDataReader rdr = ExaminerSearchForThesis.ExecuteReader(CommandBehavior.CloseConnection);



            String separator = "<br />";

            Label resultString = new Label();
            resultString.Text = "Result : " + separator + separator;
            form1.Controls.Add(resultString);

            while (rdr.Read())
            {
                if (!rdr.IsDBNull(rdr.GetOrdinal("serialNumber")))
                {
                    int serialNumber = rdr.GetInt32(rdr.GetOrdinal("serialNumber"));
                    Label serialNumberLabel = new Label();
                    serialNumberLabel.Text = "Serial Number : " + serialNumber.ToString() + "    ";
                    form1.Controls.Add(serialNumberLabel);
                }
                else
                {
                    Label serialNumberLabel = new Label();
                    serialNumberLabel.Text = "Serial Number : Null     ";
                    form1.Controls.Add(serialNumberLabel);
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("title")))
                {
                    String thesisTitle = rdr.GetString(rdr.GetOrdinal("title"));
                    Label thesisTitleLabel = new Label();
                    thesisTitleLabel.Text = "Title : " + thesisTitle + "    ";
                    form1.Controls.Add(thesisTitleLabel);
                }
                else
                {
                    Label thesisTitleLabel = new Label();
                    thesisTitleLabel.Text = "Title : Null     ";
                    form1.Controls.Add(thesisTitleLabel);
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("field")))
                {
                    String field = rdr.GetString(rdr.GetOrdinal("field"));
                    Label fieldLabel = new Label();
                    fieldLabel.Text = "Field : " + field + "    ";
                    form1.Controls.Add(fieldLabel);
                }
                else
                {
                    Label fieldLabel = new Label();
                    fieldLabel.Text = "Field : Null     ";
                    form1.Controls.Add(fieldLabel);
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("type")))
                {
                    String type = rdr.GetString(rdr.GetOrdinal("type"));
                    Label typeLabel = new Label();
                    typeLabel.Text = "Type : " + type + "    ";
                    form1.Controls.Add(typeLabel);
                }
                else
                {
                    Label typeLabel = new Label();
                    typeLabel.Text = "Type : Null     ";
                    form1.Controls.Add(typeLabel);
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("startDate")))
                {
                    DateTime startDate = rdr.GetDateTime(rdr.GetOrdinal("startDate"));
                    Label startDateLabel = new Label();
                    startDateLabel.Text = "Start Date : " + startDate + "    ";
                    form1.Controls.Add(startDateLabel);
                }
                else
                {
                    Label startDateLabel = new Label();
                    startDateLabel.Text = "Start Date : Null     ";
                    form1.Controls.Add(startDateLabel);
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("endDate")))
                {
                    DateTime endDate = rdr.GetDateTime(rdr.GetOrdinal("endDate"));
                    Label endDateLabel = new Label();
                    endDateLabel.Text = "End Date : " + endDate + "    ";
                    form1.Controls.Add(endDateLabel);
                }
                else
                {
                    Label endDateLabel = new Label();
                    endDateLabel.Text = "End Date : Null     ";
                    form1.Controls.Add(endDateLabel);
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("defenseDate")))
                {
                    DateTime defenseDate = rdr.GetDateTime(rdr.GetOrdinal("defenseDate"));
                    Label defenseDateLabel = new Label();
                    defenseDateLabel.Text = "Defense Date : " + defenseDate + "    ";
                    form1.Controls.Add(defenseDateLabel);
                }
                else
                {
                    Label defenseDateLabel = new Label();
                    defenseDateLabel.Text = "Defense Date : Null     ";
                    form1.Controls.Add(defenseDateLabel);
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("years")))
                {
                    int years = rdr.GetInt32(rdr.GetOrdinal("years"));
                    Label yearsLabel = new Label();
                    yearsLabel.Text = "Years : " + years + "    ";
                    form1.Controls.Add(yearsLabel);
                }
                else
                {
                    Label yearsLabel = new Label();
                    yearsLabel.Text = "Years : Null     ";
                    form1.Controls.Add(yearsLabel);
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("grade")))
                {
                    decimal grade = rdr.GetDecimal(rdr.GetOrdinal("grade"));
                    Label gradeLabel = new Label();
                    gradeLabel.Text = "Grade : " + grade + "    ";
                    form1.Controls.Add(gradeLabel);
                }
                else
                {
                    Label gradeLabel = new Label();
                    gradeLabel.Text = "Grade : Null     ";
                    form1.Controls.Add(gradeLabel);
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("payment_id")))
                {
                    int paymentId = rdr.GetInt32(rdr.GetOrdinal("payment_id"));
                    Label paymentIdLabel = new Label();
                    paymentIdLabel.Text = "Payment Id : " + paymentId + "    ";
                    form1.Controls.Add(paymentIdLabel);
                }
                else
                {
                    Label paymentIdLabel = new Label();
                    paymentIdLabel.Text = "Payment Id : Null     ";
                    form1.Controls.Add(paymentIdLabel);
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("noExtension")))
                {
                    int noExtension = rdr.GetInt32(rdr.GetOrdinal("noExtension"));
                    Label noExtensionLabel = new Label();
                    noExtensionLabel.Text = "Number Of Extension: " + noExtension + separator;
                    form1.Controls.Add(noExtensionLabel);
                }
                else
                {
                    Label noExtensionLabel = new Label();
                    noExtensionLabel.Text = "Number Of Extension: Null     " + separator;
                    form1.Controls.Add(noExtensionLabel);
                }
            }
            conn.Close();
        }
    }
}