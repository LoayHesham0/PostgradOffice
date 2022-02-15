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
    public partial class WebForm2 : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            String ConnStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
           
            SqlConnection conn = new SqlConnection(ConnStr);


            
            int idnum = Int32.Parse(Session["UserId"].ToString());

            SqlCommand ViewMyProfile = new SqlCommand("viewMyProfile", conn);
            ViewMyProfile.CommandType = CommandType.StoredProcedure;
            ViewMyProfile.Parameters.Add(new SqlParameter("@studentId", idnum));


            conn.Open();

            

            SqlDataReader rdrtoo = ViewMyProfile.ExecuteReader(CommandBehavior.CloseConnection);
            String separator = "<br />";

            DataTable dt = new DataTable();
            dt.Load(rdrtoo);
            Boolean UnderGradIDexists = dt.Columns.Contains("undergradID");
            conn.Close();
            
            conn.Open();
            SqlDataReader rdr = ViewMyProfile.ExecuteReader(CommandBehavior.CloseConnection);
            Label resultString = new Label();
            resultString.Text = "Personal Info : " + separator + separator;
            form1.Controls.Add(resultString);
           
            while (rdr.Read())
            {

                String firstname = rdr.GetString(rdr.GetOrdinal("firstName"));
                Label firstnameLabel = new Label();
                firstnameLabel.Text = "first name : " + firstname + separator;
                form1.Controls.Add(firstnameLabel);


                if (!rdr.IsDBNull(rdr.GetOrdinal("lastName")))
                {
                    String lastname = rdr.GetString(rdr.GetOrdinal("lastName"));
                    Label lastnamelabel = new Label();
                    lastnamelabel.Text = "Last name : " + lastname + separator;
                    form1.Controls.Add(lastnamelabel);
                }
                else
                {
                    Label lastnamelabel = new Label();
                    lastnamelabel.Text = "last name : Null     " + separator;
                    form1.Controls.Add(lastnamelabel);
                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("type")))
                {
                    String type = rdr.GetString(rdr.GetOrdinal("type"));
                    Label typelabel = new Label();
                    typelabel.Text = "type : " + type + separator;
                    form1.Controls.Add(typelabel);
                }
                else
                {
                    Label typelabel = new Label();
                    typelabel.Text = "type : Null     " + separator;
                    form1.Controls.Add(typelabel);

                }
                if (!rdr.IsDBNull(rdr.GetOrdinal("faculty")))
                {
                    String faculty = rdr.GetString(rdr.GetOrdinal("faculty"));
                    Label facultylabel = new Label();
                    facultylabel.Text = "faculty : " + faculty + separator;
                    form1.Controls.Add(facultylabel);
                }
                else
                {
                    Label facultylabel = new Label();
                    facultylabel.Text = "faculty : Null     " + separator;
                    form1.Controls.Add(facultylabel);

                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("address")))
                {
                    String address = rdr.GetString(rdr.GetOrdinal("address"));
                    Label addresslabel = new Label();
                    addresslabel.Text = "address : " + address + separator;
                    form1.Controls.Add(addresslabel);
                }
                else
                {
                    Label addresslabel = new Label();
                    addresslabel.Text = "address : Null     " + separator;
                    form1.Controls.Add(addresslabel);

                }

                if (!rdr.IsDBNull(rdr.GetOrdinal("gpa")))
                {
                    Decimal gpa = rdr.GetDecimal(rdr.GetOrdinal("gpa"));
                    Label addresslabel = new Label();
                    addresslabel.Text = "gpa : " + gpa + separator;
                    form1.Controls.Add(addresslabel);
                }
                else
                {
                    Label addresslabel = new Label();
                    addresslabel.Text = "gpa : Null     " + separator;
                    form1.Controls.Add(addresslabel);

                }
                
                if (UnderGradIDexists)
                {
                    Int32 undergradID = Convert.ToInt32(rdr.GetOrdinal("undergradID"));
                    Label undergradIDlabel = new Label();
                    undergradIDlabel.Text = "undergradID : " + undergradID + separator;
                    form1.Controls.Add(undergradIDlabel);
                }


                string email = rdr.GetString(rdr.GetOrdinal("email"));
                Label emailLabel = new Label();
                emailLabel.Text = "email : " + email + separator;
                form1.Controls.Add(emailLabel);


            }



        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RouterPage.aspx");
        }
    }
}