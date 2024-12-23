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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        static string DentalConnection = ConfigurationManager.ConnectionStrings["DentalConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(DentalConnection);
        protected void btn_Register_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("sp_reguser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar);
            cmd.Parameters.Add(p1).Value = txt_Name.Text;

            SqlParameter p2 = new SqlParameter("@email", SqlDbType.VarChar);
            cmd.Parameters.Add(p2).Value = txt_Email.Text;

            SqlParameter p3 = new SqlParameter("@username", SqlDbType.VarChar);
            cmd.Parameters.Add(p3).Value = txt_UName.Text;

            SqlParameter p4 = new SqlParameter("@pwd", SqlDbType.VarChar);
            cmd.Parameters.Add(p4).Value = txt_Pwd.Text;


            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Write("User Failed!!!!");
            }
           
        }
    }
}