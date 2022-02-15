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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String ConnStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection conn = new SqlConnection(ConnStr);
            

            SqlCommand AddProgressReport = new SqlCommand("AddProgressReport", conn);
            AddProgressReport.CommandType = System.Data.CommandType.StoredProcedure;
            AddProgressReport.Parameters.Add(new SqlParameter("thesisSerialNo", Serial.Text));
            AddProgressReport.Parameters.Add(new SqlParameter("progressReportDate", Date.Text));

            conn.Open ();
            AddProgressReport.ExecuteNonQuery();
            conn.Close();
            Response.Write("Progress Report Successfully added");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String ConnStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection conn = new SqlConnection(ConnStr);


            SqlCommand FillProgressReport = new SqlCommand("FillProgressReport", conn);
            FillProgressReport.CommandType = System.Data.CommandType.StoredProcedure;
            FillProgressReport.Parameters.Add(new SqlParameter("thesisSerialNo", Serialtoo.Text));
            FillProgressReport.Parameters.Add(new SqlParameter("progressReportNo", PRNO.Text));
            FillProgressReport.Parameters.Add(new SqlParameter("state", State.Text));
            FillProgressReport.Parameters.Add(new SqlParameter("description", Desc.Text));



            conn.Open();
            FillProgressReport.ExecuteNonQuery();
            conn.Close();
            Response.Write("Progress Report Updated Successfully");
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("RouterPage.aspx");
        }
    }
}