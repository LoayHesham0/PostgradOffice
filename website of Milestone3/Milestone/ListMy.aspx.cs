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
    public partial class ListMy : System.Web.UI.Page
    {
        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                int supervisorID = (int)Session["UserId"];

                SqlCommand ViewSupStudentsYears = new SqlCommand("ViewSupStudentsYears", conn);
                ViewSupStudentsYears.CommandType = CommandType.StoredProcedure;
                ViewSupStudentsYears.Parameters.Add(new SqlParameter("@supervisorID", supervisorID));

                conn.Open();
                ViewSupStudentsYears.ExecuteNonQuery();
                SqlDataReader rdr = ViewSupStudentsYears.ExecuteReader(CommandBehavior.CloseConnection);

                String separator = "<br />";

                Label resultString = new Label();
                resultString.Text = "Result : " + separator + separator;
                form1.Controls.Add(resultString);

                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(rdr.GetOrdinal("firstName")))
                    {
                        String firstName = rdr.GetString(rdr.GetOrdinal("firstName"));
                        Label firstNameLabel = new Label();
                        firstNameLabel.Text = "firstName : " + firstName.ToString() + "    ";
                        form1.Controls.Add(firstNameLabel);
                    }
                    else
                    {
                        Label firstNameLabel = new Label();
                        firstNameLabel.Text = "firstName : Null     ";
                        form1.Controls.Add(firstNameLabel);
                    }
                    if (!rdr.IsDBNull(rdr.GetOrdinal("lastName")))
                    {
                        String lastName = rdr.GetString(rdr.GetOrdinal("lastName"));
                        Label lastNameLabel = new Label();
                        lastNameLabel.Text = "lastName : " + lastName.ToString() + "    ";
                        form1.Controls.Add(lastNameLabel);
                    }
                    else
                    {
                        Label lastNameLabel = new Label();
                        lastNameLabel.Text = "lastName : Null     ";
                        form1.Controls.Add(lastNameLabel);
                    }
                    if (!rdr.IsDBNull(rdr.GetOrdinal("years")))
                    {
                        int years = rdr.GetInt32(rdr.GetOrdinal("years"));
                        Label yearsLabel = new Label();
                        yearsLabel.Text = "Years : " + years + "    " + separator;
                        form1.Controls.Add(yearsLabel);
                    }
                    else
                    {
                        Label yearsLabel = new Label();
                        yearsLabel.Text = "Years : Null     " + separator;
                        form1.Controls.Add(yearsLabel);
                    }

                }
                conn.Close();


            }
            catch
            {

                MsgBox("You have no students", this.Page, this);
            }
            finally
            {


            }




        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("supervisor.aspx");
        }

    }
}