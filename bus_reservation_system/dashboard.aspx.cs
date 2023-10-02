using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.Configuration;

namespace bus_reservation_system
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("/userlogin.aspx");
            }

            if (!IsPostBack)
            {
                BindGridView();
            }
        }
        protected void userReservations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteReservation")
            {
                int reservationIdToDelete = Convert.ToInt32(e.CommandArgument);

                // Call a method to delete the reservation with the specified reservationId
                DeleteReservation(reservationIdToDelete);

                // Rebind the GridView to refresh the data
                BindGridView();
            }
        }

        private void BindGridView()
        {
            string userIdFromSession = Session["Id"].ToString();

            if (!string.IsNullOrEmpty(userIdFromSession))
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = WebConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                // Create a SQL connection and command (make sure to replace the connection string with your actual connection string)
                using (connection)
                {
                    connection.Open();

                    // Define your SQL query with a parameter for userId
                    string sqlQuery = @"
                    SELECT r.Id AS ReservationId, r.date, r.seatNo,
                           b.busno, b.src, b.dest, b.amount
                    FROM Reservation r
                    INNER JOIN Buses b ON r.busId = b.Id
                    WHERE r.userId = @UserId";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Add the userId parameter to the SQL command
                        command.Parameters.AddWithValue("@UserId", userIdFromSession);

                        // Create a DataTable to hold the retrieved data
                        DataTable dt = new DataTable();

                        // Use a SqlDataAdapter to fill the DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }

                        // Bind the DataTable to the GridView
                        userReservations.DataSource = dt;
                        userReservations.DataBind();
                    }
                }
            }
        }

        protected void DeleteReservation(int reservationId)
        {
            // Implement your logic to delete the reservation with the given reservationId
            // Use the reservationId parameter to identify and delete the specific reservation
            // You'll need a SQL DELETE statement or an ORM operation to perform the deletion
            // Replace this with your actual database deletion logic
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Reservation WHERE Id = @ReservationId";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@ReservationId", reservationId);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}