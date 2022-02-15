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

    public partial class AddADefenseOrExaminer : System.Web.UI.Page
    {
        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BackButton(object sender, EventArgs e)
        {
            Response.Redirect("supervisor.aspx");
        }

        protected void GucianButton(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                string ThesisSNGucian = TextBox1.Text;
                DateTime DefenseDateGucian = DateTime.Parse(TextBox2.Text);
                string DefenseLocationGucian = TextBox3.Text;

                SqlCommand AddDefenseGucian = new SqlCommand("AddDefenseGucian", conn);
                AddDefenseGucian.CommandType = CommandType.StoredProcedure;
                AddDefenseGucian.Parameters.Add(new SqlParameter("@ThesisSerialNo", ThesisSNGucian));
                AddDefenseGucian.Parameters.Add(new SqlParameter("@DefenseDate", DefenseDateGucian));
                AddDefenseGucian.Parameters.Add(new SqlParameter("@DefenseLocation", DefenseLocationGucian));

                conn.Open();
                AddDefenseGucian.ExecuteNonQuery();
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

        protected void NonGucianButton(object sender, EventArgs e)
        {
            try
            {

                string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                string ThesisSNNonGucian = TextBox4.Text;
                DateTime DefenseDateNonGucian = DateTime.Parse(TextBox5.Text);
                string DefenseLocationNonGucian = TextBox6.Text;

                SqlCommand AddDefenseNonGucian = new SqlCommand("AddDefenseNonGucian", conn);
                AddDefenseNonGucian.CommandType = CommandType.StoredProcedure;
                AddDefenseNonGucian.Parameters.Add(new SqlParameter("@ThesisSerialNo", ThesisSNNonGucian));
                AddDefenseNonGucian.Parameters.Add(new SqlParameter("@DefenseDate", DefenseDateNonGucian));
                AddDefenseNonGucian.Parameters.Add(new SqlParameter("@DefenseLocation", DefenseLocationNonGucian));

                conn.Open();
                AddDefenseNonGucian.ExecuteNonQuery();
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

        protected void ExaminerButton(object sender, EventArgs e)
        {

            try
            {

                string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                string ThesisSN = TextBox7.Text;
                DateTime DefenseDate = DateTime.Parse(TextBox8.Text);
                string ExaminerName = TextBox9.Text;
                int National = Int16.Parse(TextBox10.Text);
                string FieldOfWork = TextBox11.Text;

                SqlCommand AddExaminer = new SqlCommand("AddExaminer", conn);
                AddExaminer.CommandType = CommandType.StoredProcedure;
                AddExaminer.Parameters.Add(new SqlParameter("@thesisserialNo", ThesisSN));
                AddExaminer.Parameters.Add(new SqlParameter("@DefenseDate", DefenseDate));
                AddExaminer.Parameters.Add(new SqlParameter("@ExaminerName", ExaminerName));
                AddExaminer.Parameters.Add(new SqlParameter("@National", National));
                AddExaminer.Parameters.Add(new SqlParameter("@Fieldofwork", FieldOfWork));

                conn.Open();
                AddExaminer.ExecuteNonQuery();
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

    }
}