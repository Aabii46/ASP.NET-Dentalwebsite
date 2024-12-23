using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dentalwebsite
{
    public partial class fetch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        static string DentalConnection = ConfigurationManager.ConnectionStrings["DentalConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(DentalConnection);
        protected void btn_Register_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("sp_Fetchusers", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);

            gvd_FetchData.DataSource = ds.Tables[0];
            gvd_FetchData.DataBind();

            con.Close();
        }
    }
}