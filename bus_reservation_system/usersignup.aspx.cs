using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bus_reservation_system
{
    public partial class usersignup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string uname = name.Text;
            string uemail = email.Text;
            string upass = password.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString =WebConfigurationManager.ConnectionStrings["conString"].ConnectionString;

            try
            {
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into [User] (name,email,password) values (@Name,@Email,@Password)", con);
                    cmd.Parameters.AddWithValue("@Name", uname);
                    cmd.Parameters.AddWithValue("@Email", uemail);
                    cmd.Parameters.AddWithValue("@Password", upass);
                    int a = cmd.ExecuteNonQuery();
                    Response.Redirect("/userlogin.aspx");

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}