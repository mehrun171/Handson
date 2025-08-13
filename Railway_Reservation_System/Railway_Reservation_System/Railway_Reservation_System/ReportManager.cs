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
        public static void ViewBookings()
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
        public static void ViewMyBookings(int custId)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"
        SELECT r.BookingId, c.CustName, r.TrainNo, r.Class, r.TravelDate, r.TotalCost
        FROM Reservations r
        JOIN Customers c ON r.CustId = c.CustId
        WHERE r.IsDeleted = 0 AND r.CustId = @custId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@custId", custId);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                bool hasbookings = false;
                Console.WriteLine($"Bookings for Customer ID: {custId}");
                while (dr.Read())
                {
                    hasbookings = true;
                    Console.WriteLine($"Booking ID: {dr["BookingId"]}, Customer: {dr["CustName"]}, " +
                                      $"Train No: {dr["TrainNo"]}, Class: {dr["Class"]}, " +
                                      $"Date: {Convert.ToDateTime(dr["TravelDate"]).ToShortDateString()}, " +
                                      $"Cost: {dr["TotalCost"]}");
                }
                if (!hasbookings)
                {
                    Console.WriteLine("No Bookings found for this customer.");
                }
            }
        }

        public static void ViewCancellations()
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

        public static void ViewMyCancellations(int custId)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"
        SELECT 
            c.CancelId,
            c.BookingId,
            c.RefundAmount,
            c.CancellationDate,
            r.TravelDate,
            r.Class,
            t.TrainName,
            t.Source,
            t.Destination,
            cu.CustName
        FROM Cancellations c
        JOIN Reservations r ON c.BookingId = r.BookingId
        JOIN Trains t ON r.TrainNo = t.TrainNo
        JOIN Customers cu ON r.CustId = cu.CustId
        WHERE r.CustId = @custId AND r.IsDeleted = 1";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@custId", custId);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                bool hasCancellations = false;
                Console.WriteLine($"Cancelled Bookings for Customer ID: {custId}");
                while (dr.Read())
                {
                    hasCancellations = true;
                    Console.WriteLine($"Cancel ID: {dr["CancelId"]}, Booking ID: {dr["BookingId"]}, " +
                                      $"Customer: {dr["CustName"]}, Train: {dr["TrainName"]}, " +
                                      $"Route: {dr["Source"]} to {dr["Destination"]}, Class: {dr["Class"]}, " +
                                      $"Travel Date: {Convert.ToDateTime(dr["TravelDate"]).ToShortDateString()}, " +
                                      $"Refund: {dr["RefundAmount"]}, " +
                                      $"Cancelled On: {Convert.ToDateTime(dr["CancellationDate"]).ToShortDateString()}");
                }
                if (!hasCancellations)
                {
                    Console.WriteLine("No cancellations found for this customer.");
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
                        Console.WriteLine();
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
                        Console.WriteLine();

                    }
                }
                else
                {
                    Console.WriteLine("No tickets found for this customer");
                }
            }
        }

    }
}

