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
    public partial class Evaluate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
        protected void EvaluateButton(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                int supervisorID = Int16.Parse(TextBox1.Text);
                int thesisSerialNo = Int16.Parse(TextBox2.Text);
                int progressReportNo = Int16.Parse(TextBox3.Text);
                int evaluation = Int16.Parse(TextBox4.Text);


                SqlCommand EvaluateProgressReport = new SqlCommand("EvaluateProgressReport", conn);
                EvaluateProgressReport.CommandType = CommandType.StoredProcedure;
                EvaluateProgressReport.Parameters.Add(new SqlParameter("@supervisorID", supervisorID));
                EvaluateProgressReport.Parameters.Add(new SqlParameter("@thesisSerialNo", thesisSerialNo));
                EvaluateProgressReport.Parameters.Add(new SqlParameter("@progressReportNo", progressReportNo));
                EvaluateProgressReport.Parameters.Add(new SqlParameter("@evaluation", evaluation));


                conn.Open();

                EvaluateProgressReport.ExecuteNonQuery();

                conn.Close();

            }
            catch
            {

                MsgBox("! Error occurred. !" + " Re-try with a different numbers.", this.Page, this);
            }
            finally
            {


            }



        }

        protected void BackButton(object sender, EventArgs e)
        {
            Response.Redirect("supervisor.aspx");
        }
    }
}