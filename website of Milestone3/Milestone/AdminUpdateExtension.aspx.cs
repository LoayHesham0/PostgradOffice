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
    public partial class AdminUpdateExtension : System.Web.UI.Page
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
            if (String.IsNullOrEmpty(ThesisSerialNo.Text))
            {
                Response.Write("<script>alert('you must fill all boxes');</script>");
            }
            else
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int ThesisSerialNumber = Int16.Parse(ThesisSerialNo.Text);

                SqlCommand adminupdateExtension = new SqlCommand("AdminUpdateExtension", conn);
                adminupdateExtension.CommandType = CommandType.StoredProcedure;

                adminupdateExtension.Parameters.Add(new SqlParameter("@ThesisSerialNo", ThesisSerialNumber));

                conn.Open();
                adminupdateExtension.ExecuteNonQuery();
                conn.Close();

                Response.Write("<script>alert('Succesful update');</script>");
            }
        }
    }
}