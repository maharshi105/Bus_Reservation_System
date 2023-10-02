using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bus_reservation_system
{
    public partial class book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("/userlogin.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    bookdate.Text = DateTime.Now.Date.ToString();
                }
                UpdateData();
            }
        }

        protected void UpdateData()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["conString"].ConnectionString;

            
                using (con)
                {
                    seatDropDown.Items.Clear();
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("select * from [Buses] where Id=@busId", con);
                    cmd1.Parameters.AddWithValue("@busId", Request.QueryString["Id"].ToString());
                    SqlDataReader rdr = cmd1.ExecuteReader();
                    List<ListItem> seats = new List<ListItem>();
                    while (rdr.Read())
                    {
                        int seatcnt = (int)rdr["seats"];
                        for (int i = 1; i <= seatcnt; i++)
                        {
                            ListItem li = new ListItem();
                            li.Text = i.ToString();
                            li.Value = i.ToString();
                            seatDropDown.Items.Add(li);
                        }
                    }
                    rdr.Close();

                    SqlCommand cmd = new SqlCommand("select * from Reservation where busId=@busId and date=@date", con);
                    cmd.Parameters.AddWithValue("@busId", Request.QueryString["Id"].ToString());
                    cmd.Parameters.AddWithValue("@date", bookdate.Text);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int seat = (int)reader["seatNo"];
                        ListItem li = new ListItem();
                        li.Text = seat.ToString();
                        li.Value = seat.ToString();
                        seatDropDown.Items.Remove(li);
                    }
                    
                }
            
        }


        protected void bookdate_TextChanged(object sender, EventArgs e)
        {
            DateTime selectedDate;
            if (DateTime.TryParse(bookdate.Text, out selectedDate))
            {
                // Check if the selected date is in the past
                if (selectedDate < DateTime.Today)
                {
                    // Display an error message to the user
                    errorLabel.Text = "Please select a future date.";
                    errorLabel.Style["color"] = "red";
                    seatDropDown.Items.Clear(); // Clear the dropdown list
                }
                else
                {
                    errorLabel.Visible = false;
                    // If the selected date is in the future, update the available seats
                    UpdateData();
                }
            }
            else
            {
                // Handle invalid date format
                errorLabel.Text = "Invalid date format. Please enter a valid date.";
                seatDropDown.Items.Clear(); // Clear the dropdown list
                seatDropDown.Items.Clear(); // Clear the dropdown list
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(seatDropDown.Text) || string.IsNullOrEmpty(bookdate.Text))
            {
                errorLabel.Text = "Please enter a valid input.";
                errorLabel.Style["color"] = "red";

                return;

            }
            else
            {
                int seat = int.Parse(seatDropDown.Text);
                DateTime date = DateTime.Parse(bookdate.Text);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = WebConfigurationManager.ConnectionStrings["conString"].ConnectionString;

                try
                {
                    using (con)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into [Reservation] (busId,userId,date,seatNo) values (@busId,@userId,@Date,@seatNo)", con);
                        cmd.Parameters.AddWithValue("@busId", Request.QueryString["Id"].ToString());
                        cmd.Parameters.AddWithValue("@userId", Session["id"]);
                        cmd.Parameters.AddWithValue("@Date", date);
                        cmd.Parameters.AddWithValue("@seatNo", seat);
                        int a = cmd.ExecuteNonQuery();

                        Response.Redirect("/dashboard.aspx");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        } 
    }
}