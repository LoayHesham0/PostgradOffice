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
    public partial class AdminListSup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  
            String connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand supproc = new SqlCommand("AdminListSup", conn);
            supproc.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = supproc.ExecuteReader(CommandBehavior.CloseConnection);

            String separator = "<br />";

            Label resultString = new Label();
            resultString.Text = "Result : " + separator + separator;
            form1.Controls.Add(resultString);

            

            while (rdr.Read())
            {
                Label space = new Label();
                space.Text = separator;
                if (!rdr.IsDBNull(rdr.GetOrdinal("id")))
                {
                    int id = rdr.GetInt32(rdr.GetOrdinal("id"));
                    Label idLabel = new Label();
                    idLabel.Text = "id : " + id.ToString() + "    ";
                    form1.Controls.Add(idLabel);
                    

                }
                else
                {
                    Label idLabel = new Label();
                    idLabel.Text = "id : Null     ";
                    form1.Controls.Add(idLabel);
                    

                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("email")))
                {

                    string email = rdr.GetString(rdr.GetOrdinal("email"));
                    Label emailLabel = new Label();
                    emailLabel.Text = "email : " + email.ToString() + "    ";
                    form1.Controls.Add(emailLabel);
                    
                }
                else
                {
                    Label emailLabel = new Label();
                    emailLabel.Text = "email : Null     ";
                    form1.Controls.Add(emailLabel);                   
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("password")))
                {

                    string password = rdr.GetString(rdr.GetOrdinal("email"));
                    Label  passwordLabel = new Label();
                    passwordLabel.Text = "password : " + password.ToString() + "    ";
                    form1.Controls.Add(passwordLabel);
                    
                }
                else
                {
                    Label passwordLabel = new Label();
                    passwordLabel.Text = "password : Null     ";
                    form1.Controls.Add(passwordLabel);                   
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("name")))
                {

                    string name = rdr.GetString(rdr.GetOrdinal("name"));
                    Label nameLabel = new Label();
                    nameLabel.Text = "name : " + name.ToString() + "    ";
                    form1.Controls.Add(nameLabel);
                    
                }
                else
                {
                    Label nameLabel = new Label();
                    nameLabel.Text = "name : Null     ";
                    form1.Controls.Add(nameLabel);                   
                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("faculty")))
                {

                    string faculty = rdr.GetString(rdr.GetOrdinal("faculty"));
                    Label facultyLabel = new Label();
                    facultyLabel.Text = "faculty : " + faculty.ToString() + "    ";
                    form1.Controls.Add(facultyLabel);
                    form1.Controls.Add(space);
                }
                else
                {
                    Label facultyLabel = new Label();
                    facultyLabel.Text = "faculty : Null     ";
                    form1.Controls.Add(facultyLabel);                                                 
                }
                
            }
            conn.Close();
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }
    }
}