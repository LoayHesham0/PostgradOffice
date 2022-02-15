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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (String.IsNullOrEmpty(id.Text.ToString()) || String.IsNullOrEmpty(password.Text))
            {
                Response.Write("<script>alert('you must fill all boxes');</script>");
            }
            else
            {
                int username = Int16.Parse(id.Text);
                string pass = password.Text;


                SqlCommand loginproc = new SqlCommand("userlogin", conn);
                loginproc.CommandType = CommandType.StoredProcedure;

                loginproc.Parameters.Add(new SqlParameter("@id", username));
                loginproc.Parameters.Add(new SqlParameter("@password", pass));
                SqlParameter success = loginproc.Parameters.Add("@Success", SqlDbType.Int);


                success.Direction = ParameterDirection.Output;

                SqlCommand typeproc = new SqlCommand("tabletype", conn);
                typeproc.CommandType = CommandType.StoredProcedure;

                typeproc.Parameters.Add(new SqlParameter("@id", username));
                SqlParameter type = typeproc.Parameters.Add("@type", SqlDbType.VarChar, 50);
                type.Direction = ParameterDirection.Output;

                conn.Open();
                loginproc.ExecuteNonQuery();
                typeproc.ExecuteNonQuery();
                conn.Close();


                if (success.Value.ToString() == "1")
                {
                    Session["UserId"] = username;
                    if (type.Value.ToString() == "gucianstudent".ToString())
                    {
                        Server.Transfer("RouterPage.aspx");
                        Response.Write("Hello");
                        Response.Redirect("RouterPage.aspx");
                    }
                    else if (type.Value.ToString() == "nongucianstudent".ToString())
                    {
                        Server.Transfer("RouterPage.aspx");
                        Response.Write("Hello");
                        Response.Redirect("RouterPage.aspx");
                    }
                    else if (type.Value.ToString() == "examiner".ToString())
                    {
                        Response.Redirect("Examiner.aspx");
                    }
                    else if (type.Value.ToString() == "supervisor".ToString())
                    {
                        Response.Redirect("supervisor.aspx");
                    }
                    else if (type.Value.ToString() == "admin".ToString())
                    {
                        Response.Redirect("admin.aspx");
                    }
                }
                else
                {
                   Response.Write("<script>alert('you must register first');</script>");
                    
                }
            }
        }
        protected void register(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}
