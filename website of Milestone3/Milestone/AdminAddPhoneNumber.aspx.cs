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
    public partial class AdminAddPhoneNumber : System.Web.UI.Page
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
            if (String.IsNullOrEmpty(id.Text) ||
                String.IsNullOrEmpty(phone_number.Text) )
            {
                Response.Write("<script>alert('you must fill all boxes');</script>");
            }
            else
            {

                string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int IDnumber = Int16.Parse(id.Text);
                string Phone_Number = phone_number.Text;

                SqlCommand AdminAddPhoneNumber = new SqlCommand("addMobile", conn);
                AdminAddPhoneNumber.CommandType = CommandType.StoredProcedure;

                AdminAddPhoneNumber.Parameters.Add(new SqlParameter("@id", IDnumber));
                AdminAddPhoneNumber.Parameters.Add(new SqlParameter("@mobile_number", Phone_Number));

                conn.Open();
                AdminAddPhoneNumber.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('successful add');</script>");
            }
        }
    }
}