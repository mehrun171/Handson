using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static Railway_Reservation_System.DBConnection;


namespace Railway_Reservation_System
{
    public class ReportManager
    {
        public void ViewBookings()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"
                SELECT r.BookingId, c.CustName, r.TrainNo, r.Class, r.TravelDate, r.TotalCost
                FROM Reservations r
                JOIN Customers c ON r.CustId = c.CustId
                WHERE r.IsDeleted = 0";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("ALL Bookings:");
                while (dr.Read())
                {
                    Console.WriteLine($"Booking ID: {dr["BookingId"]}, Customer: {dr["CustName"]}, " +
                                      $"Train No: {dr["TrainNo"]}, Class: {dr["Class"]}, " +
                                      $"Date: {Convert.ToDateTime(dr["TravelDate"])}, " +
                                      $"Cost: {dr["TotalCost"]}");
                }
            }
        }

        public void ViewCancellations()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"
                SELECT CancelId, BookingId, RefundAmount, CancellationDate
                FROM Cancellations";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("Cancelled Bookings:");
                while (dr.Read())
                {
                    Console.WriteLine($"Cancel ID: {dr["CancelId"]}, Booking ID: {dr["BookingId"]}, " +
                                      $"Refund: {dr["RefundAmount"]}, " +
                                      $"Date: {Convert.ToDateTime(dr["CancellationDate"])}");
                }
            }
        }
        public void PrintTicket()
        {
            Console.Write("Enter Customer ID to print tickets: ");
            int custId = int.Parse(Console.ReadLine());

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"
        SELECT r.BookingId, c.CustName, c.Phone, c.MailId,
               t.TrainName, t.Source, t.Destination,
               r.Class, r.TravelDate, r.BerthAllotment, r.TotalCost, r.BookingDate
        FROM Reservations r
        JOIN Customers c ON r.CustId = c.CustId
        JOIN Trains t ON r.TrainNo = t.TrainNo
        WHERE r.CustId = @custId AND r.IsDeleted = 0";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@custId", custId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("======= TICKET DETAILS =======");
                        Console.WriteLine($"Booking ID     : {dr["BookingId"]}");
                        Console.WriteLine($"Customer Name  : {dr["CustName"]}");
                        Console.WriteLine($"Phone          : {dr["Phone"]}");
                        Console.WriteLine($"Email          : {dr["MailId"]}");
                        Console.WriteLine($"Train Name     : {dr["TrainName"]}");
                        Console.WriteLine($"From           : {dr["Source"]}");
                        Console.WriteLine($"To             : {dr["Destination"]}");
                        Console.WriteLine($"Class          : {dr["Class"]}");
                        Console.WriteLine($"Berth Allotment: {dr["BerthAllotment"]}");
                        Console.WriteLine($"Travel Date    : {Convert.ToDateTime(dr["TravelDate"])}");
                        Console.WriteLine($"Booking Date   : {Convert.ToDateTime(dr["BookingDate"])}");
                        Console.WriteLine($"Total Fare     : {dr["TotalCost"]}");
                        Console.WriteLine("===================================");
                    }
                }
                else
                {
                    Console.WriteLine("No tickets found for this customer.");
                }
            }
        }

    }
}

