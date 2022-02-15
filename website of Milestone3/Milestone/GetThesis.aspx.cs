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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String ConnStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();

            SqlConnection conn = new SqlConnection(ConnStr);



            int idnum = Int32.Parse(Session["UserId"].ToString());

            SqlCommand GetThesis = new SqlCommand("GetThesis", conn);
            GetThesis.CommandType = CommandType.StoredProcedure;
            GetThesis.Parameters.Add(new SqlParameter("@studentID", idnum));


            conn.Open();


            SqlDataReader rdr = GetThesis.ExecuteReader(CommandBehavior.CloseConnection);
            String separator = "<br />";

            Label resultString = new Label();
            resultString.Text = "Thesis : " + separator + separator;
            form1.Controls.Add(resultString);
            while (rdr.Read())
            {

                if (!rdr.IsDBNull(rdr.GetOrdinal("serialNumber")))
                {
                    Int32 title = rdr.GetInt32(rdr.GetOrdinal("serialNumber"));
                    Label serialNumberLabel = new Label();
                    serialNumberLabel.Text = "Serial Number : " + title + " | ";
                    form1.Controls.Add(serialNumberLabel);
                }
                else
                {
                    Label serialNumberLabel = new Label();
                    serialNumberLabel.Text = " Serial Number : NULL  " + " | ";
                    form1.Controls.Add(serialNumberLabel);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("title")))
                {
                    String title = rdr.GetString(rdr.GetOrdinal("title"));
                    Label titlelabel = new Label();
                    titlelabel.Text = "Thesis Title : " + title + " | ";
                    form1.Controls.Add(titlelabel);
                }
                else
                {
                    Label titlelabel = new Label();
                    titlelabel.Text = "Thesis Title : NULL  " + " | ";
                    form1.Controls.Add(titlelabel);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("type")))
                {
                    String type = rdr.GetString(rdr.GetOrdinal("type"));
                    Label typelabel = new Label();
                    typelabel.Text = "Thesis Type : " + type + " | ";
                    form1.Controls.Add(typelabel);
                }
                else
                {
                    Label typelabel = new Label();
                    typelabel.Text = "Thesis Type : NULL     " + " | ";
                    form1.Controls.Add(typelabel);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("field")))
                {
                    String field = rdr.GetString(rdr.GetOrdinal("field"));
                    Label fieldlabel = new Label();
                    fieldlabel.Text = "Field of Thesis : " + field + " | ";
                    form1.Controls.Add(fieldlabel);
                }
                else
                {
                    Label fieldlabel = new Label();
                    fieldlabel.Text = "Field of Thesis : NULL " + " | ";
                    form1.Controls.Add(fieldlabel); 
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("startDate")))
                {
                    DateTime startDate = rdr.GetDateTime(rdr.GetOrdinal("startDate"));
                    Label startDatelabel = new Label();
                    startDatelabel.Text = "Start Date : " + startDate + " | ";
                    form1.Controls.Add(startDatelabel);
                }
                else
                {
                    Label startDatelabel = new Label();
                    startDatelabel.Text = "Start Date : NULL     " + " | ";
                    form1.Controls.Add(startDatelabel);

                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("endDate")))
                {
                    DateTime endDate = rdr.GetDateTime(rdr.GetOrdinal("endDate"));
                    Label endDateLabel = new Label();
                    endDateLabel.Text = "End Date : " + endDate + " | ";
                    form1.Controls.Add(endDateLabel);
                }
                else
                {
                    Label endDateLabel = new Label();
                    endDateLabel.Text = "End Date : NULL     " + " | ";
                    form1.Controls.Add(endDateLabel);

                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("defenseDate")))
                {
                    DateTime defenseDate = rdr.GetDateTime(rdr.GetOrdinal("defenseDate"));
                    Label defenseDatelabel = new Label();
                    defenseDatelabel.Text = "Defense Date : " + defenseDate + " | ";
                    form1.Controls.Add(defenseDatelabel);
                }
                else
                {
                    Label defenseDatelabel = new Label();
                    defenseDatelabel.Text = "Defense Data : NULL     " + " | ";
                    form1.Controls.Add(defenseDatelabel);

                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("years")))
                {
                    Int32 years = Convert.ToInt32(rdr.GetOrdinal("years"));
                    Label yearslabel = new Label();
                    yearslabel.Text = "Number of Years : " + years + " | ";
                    form1.Controls.Add(yearslabel);
                }
                else
                {
                    Label yearslabel = new Label();
                    yearslabel.Text = "Number of Years : NULL     " + " | ";
                    form1.Controls.Add(yearslabel);

                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("grade")))
                {
                    Int32 grade = Convert.ToInt32(rdr.GetOrdinal("grade"));
                    Label gradelabel = new Label();
                    gradelabel.Text = "Grade : " + grade + " | ";
                    form1.Controls.Add(gradelabel);
                }
                else
                {
                    Label gradelabel = new Label();
                    gradelabel.Text = "Grade : NULL     " + " | ";
                    form1.Controls.Add(gradelabel);
                }


            }



        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RouterPage.aspx");
        }
    }
    }
