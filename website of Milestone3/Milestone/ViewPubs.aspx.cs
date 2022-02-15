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
    public partial class ViewPubs : System.Web.UI.Page
    {
        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void ViewButton(object sender, EventArgs e)
        {
            
                string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                string StudentID = StudentIDBox.Text;
                SqlCommand ViewAStudentPublications = new SqlCommand("ViewAStudentPublications", conn);
                ViewAStudentPublications.CommandType = CommandType.StoredProcedure;
                ViewAStudentPublications.Parameters.Add(new SqlParameter("@StudentID", StudentID));
                conn.Open();
                SqlDataReader rdr = ViewAStudentPublications.ExecuteReader(CommandBehavior.CloseConnection);




            if (rdr.HasRows)
            {

                String separator = "<br />";

                Label resultString = new Label();
                resultString.Text = "Result : " + separator + separator;
                form1.Controls.Add(resultString);
                while (rdr.Read())
                {
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
                    if (!rdr.IsDBNull(rdr.GetOrdinal("title")))
                    {
                        String Title = rdr.GetString(rdr.GetOrdinal("title"));
                        Label TitleLabel = new Label();
                         TitleLabel.Text = "Title : " + Title + "    ";
                        form1.Controls.Add(TitleLabel);
                    }
                    else
                    {
                        Label TitleLabel = new Label();
                        TitleLabel.Text = "Title : Null     ";
                        form1.Controls.Add(TitleLabel);
                    }
                    if (!rdr.IsDBNull(rdr.GetOrdinal("place")))
                    {
                        String place = rdr.GetString(rdr.GetOrdinal("place"));
                        Label placeLabel = new Label();
                        placeLabel.Text = "place : " + place + "    ";
                        form1.Controls.Add(placeLabel);
                    }
                    else
                    {
                        Label placeLabel = new Label();
                        placeLabel.Text = "place : Null     ";
                        form1.Controls.Add(placeLabel);
                    }
                    if (!rdr.IsDBNull(rdr.GetOrdinal("accepted")))
                    {
                        bool accepted = rdr.GetBoolean(rdr.GetOrdinal("accepted"));
                        Label acceptedLabel = new Label();
                        acceptedLabel.Text = "accepted : " + accepted + "    ";
                        form1.Controls.Add(acceptedLabel);
                    }
                    else
                    {
                        Label acceptedLabel = new Label();
                        acceptedLabel.Text = "accepted : Null     ";
                        form1.Controls.Add(acceptedLabel);
                    }
                    if (!rdr.IsDBNull(rdr.GetOrdinal("host")))
                    {
                        String host = rdr.GetString(rdr.GetOrdinal("host"));
                        Label hostLabel = new Label();
                        hostLabel.Text = "host : " + host + "    " + separator;
                        form1.Controls.Add(hostLabel);
                    }
                    else
                    {
                        Label hostLabel = new Label();
                        hostLabel.Text = "host : Null     " + separator;
                        form1.Controls.Add(hostLabel);
                    }
                }
            }
            else
            {
                MsgBox("! Error occurred. !" +" Student not found or has no publications", this.Page, this);
            }
            conn.Close();

        

        }


        protected void BackButton(object sender, EventArgs e)
        {
            Response.Redirect("supervisor.aspx");
        }
    }
}