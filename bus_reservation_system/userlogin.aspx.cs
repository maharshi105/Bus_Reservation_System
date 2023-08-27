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
    public partial class userlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Email = email.Text;
            string Password = password.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["conString"].ConnectionString;

            try
            {
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from [User] where email=@email and password=@password", con);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@password", Password);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read()) {
                        Session["id"] = reader["UserId"].ToString();
                        Session["email"] = Email;
                        Session["isAdmin"] = reader["isAdmin"];
                        Response.Redirect("/homepage.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}