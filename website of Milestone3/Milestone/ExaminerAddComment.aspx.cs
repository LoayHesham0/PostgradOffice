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
    public partial class ExaminerAddComment : System.Web.UI.Page

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

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examiner.aspx");
        }

        protected void addButton_Click(object sender, EventArgs e)
        {


            try
            {

                string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int thesisSerialNumber = Int16.Parse(thesisSerialNumberBox.Text);
                DateTime defenseDate = DateTime.Parse(defenseDateBox.Text);
                String commentValue = commentBox.Text;

                SqlCommand AddCommentsGrade = new SqlCommand("AddCommentsGrade", conn);
                AddCommentsGrade.CommandType = CommandType.StoredProcedure;
                AddCommentsGrade.Parameters.Add(new SqlParameter("@ThesisSerialNo", thesisSerialNumber));
                AddCommentsGrade.Parameters.Add(new SqlParameter("@DefenseDate", defenseDate));
                AddCommentsGrade.Parameters.Add(new SqlParameter("@comments", commentValue));
                SqlParameter success = AddCommentsGrade.Parameters.Add("@Success", SqlDbType.Int);
                success.Direction = ParameterDirection.Output;

                conn.Open();
                AddCommentsGrade.ExecuteNonQuery();
                conn.Close();


                if (success.Value.ToString() == "1")
                {
                    Response.Write("<script>alert('invalid thesis !!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Success!!');</script>");
                }




            }
            catch
            {

                MsgBox("invalid thesis !!", this.Page, this);
            }
            finally
            {

               }
            
        }
    }
}