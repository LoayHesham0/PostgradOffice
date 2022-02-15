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
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            String ConnStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection conn = new SqlConnection(ConnStr);


            SqlCommand addPublication = new SqlCommand("addPublication", conn);
            addPublication.CommandType = System.Data.CommandType.StoredProcedure;
            addPublication.Parameters.Add(new SqlParameter("title", Title.Text));
            addPublication.Parameters.Add(new SqlParameter("pubDate", PubDate.Text));
            addPublication.Parameters.Add(new SqlParameter("host", Host.Text));
            addPublication.Parameters.Add(new SqlParameter("place", Place.Text));
            addPublication.Parameters.Add(new SqlParameter("accepted", Accepted.Text));

            conn.Open();
            addPublication.ExecuteNonQuery();
            conn.Close();
            Response.Write("Publication Added Successfully");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            String ConnStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection conn = new SqlConnection(ConnStr);


            SqlCommand linkPubThesis = new SqlCommand("LinkPubThesis", conn);
            linkPubThesis.CommandType = System.Data.CommandType.StoredProcedure;
            linkPubThesis.Parameters.Add(new SqlParameter("PubID", Pubid.Text));
            linkPubThesis.Parameters.Add(new SqlParameter("thesisSerialNo", Tno.Text));
          

            conn.Open();
            linkPubThesis.ExecuteNonQuery();
            conn.Close();
            Response.Write("Publication Linked Successfully");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("RouterPage.aspx");
        }
    }
}