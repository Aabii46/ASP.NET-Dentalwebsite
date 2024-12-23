using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Dentalwebsite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        static string DentalConnection = ConfigurationManager.ConnectionStrings["DentalConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(DentalConnection);
        protected void btn_Register_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("sp_login1", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@username", SqlDbType.VarChar);
            cmd.Parameters.Add(p1).Value = txt_UName.Text;

            SqlParameter p2 = new SqlParameter("@pwd", SqlDbType.VarChar);
            cmd.Parameters.Add(p2).Value = txt_Pwd.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            int a = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());
            if (a > 0)
            {
                Response.Redirect("fetch.aspx");

            }
            else
            {
                Response.Write("Invalid Username");
            }
            con.Close();

        }
    }
}