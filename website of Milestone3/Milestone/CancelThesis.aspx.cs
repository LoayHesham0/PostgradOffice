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
    public partial class CancelThesis : System.Web.UI.Page
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



        protected void BackButton(object sender, EventArgs e)
        {
            Response.Redirect("supervisor.aspx");
        }

        protected void CancelButton(object sender, EventArgs e)
        {
            try
            {

                string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                int ThesisSerialNo = Int16.Parse(TextBox1.Text);



                SqlCommand CancelThesis = new SqlCommand("CancelThesis", conn);
                CancelThesis.CommandType = CommandType.StoredProcedure;
                CancelThesis.Parameters.Add(new SqlParameter("@ThesisSerialNo", ThesisSerialNo));
                SqlParameter success = CancelThesis.Parameters.Add("@Success", SqlDbType.Int);


                success.Direction = ParameterDirection.Output;


                conn.Open();
                CancelThesis.ExecuteNonQuery();
                conn.Close();

                if (success.Value.ToString() == "1")
                {
                    Response.Write("<script>alert('successful cancel');</script>");
                }
                else
                {
                    Response.Write("<script>alert('cannot be cancelled');</script>");
                }

            }
            catch
            {
                MsgBox("! Error occurred. !" + " please enter thesis seriel number with value 0", this.Page, this);
            }
            finally
            {

            }

        }
    }
}