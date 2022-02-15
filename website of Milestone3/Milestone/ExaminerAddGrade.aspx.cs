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


    public partial class ExaminerAddGrade : System.Web.UI.Page
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

                int thesisSerialNumber = Int32.Parse(thesisSerialNumberBox.Text);
                DateTime defenseDate = DateTime.Parse(defenseDateBox.Text);
                decimal grade = decimal.Parse(gradeBox.Text);

                SqlCommand AddDefenseGrade = new SqlCommand("AddDefenseGrade", conn);
                AddDefenseGrade.CommandType = CommandType.StoredProcedure;
                AddDefenseGrade.Parameters.Add(new SqlParameter("@ThesisSerialNo", thesisSerialNumber));
                AddDefenseGrade.Parameters.Add(new SqlParameter("@DefenseDate", defenseDate));
                AddDefenseGrade.Parameters.Add(new SqlParameter("@grade", grade));
                SqlParameter success = AddDefenseGrade.Parameters.Add("@Success", SqlDbType.Int);

                success.Direction = ParameterDirection.Output;

                conn.Open();
                AddDefenseGrade.ExecuteNonQuery();
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

                MsgBox("Invalid Values!!", this.Page, this);
            }
            finally
            {

                
            }


        }  
    }
}