using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Reservation_System
{
    public class AdminServices
    {
        public static void AddTrain()
        {
            Console.Write("Enter Train Number: ");
            int trainNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();

            Console.Write("Enter Source Station: ");
            string source = Console.ReadLine();

            Console.Write("Enter Destination Station: ");
            string destination = Console.ReadLine();

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Trains (TrainNo, TrainName, Source, Destination) VALUES (@trainNo, @trainName, @source, @destination)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@trainNo", trainNo);
                cmd.Parameters.AddWithValue("@trainName", trainName);
                cmd.Parameters.AddWithValue("@source", source);
                cmd.Parameters.AddWithValue("@destination", destination);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Train added successfully.");
            }
        }

        public static void DeleteTrain()
        {
            Console.Write("Enter Train Number to deactivate: ");
            int trainNo = int.Parse(Console.ReadLine());

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Trains SET IsActive = 0 WHERE TrainNo = @trainNo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@trainNo", trainNo);
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Train deactivated successfully.");
                else
                    Console.WriteLine("Train not found or already inactive.");
            }
        }

        public static void ReactivateTrain()
        {
            Console.Write("Enter Train Number to Re-activate: ");
            int trainNo = int.Parse(Console.ReadLine());

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Trains SET IsActive = 1 WHERE TrainNo = @trainNo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@trainNo", trainNo);
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Train reactivated successfully.");
                else
                    Console.WriteLine("Train not found or already active.");
            }
        }

        public static void ViewAllBookings()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT R.BookingId, C.CustName, C.Phone, T.TrainName, T.Source, T.Destination, 
                   R.TravelDate, R.Class, R.BerthAllotment, R.TotalCost
            FROM Reservations R
            JOIN Customers C ON R.CustId = C.CustId
            JOIN Trains T ON R.TrainNo = T.TrainNo
            WHERE R.IsDeleted = 0";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("====== All Active Bookings ======");
                while (dr.Read())
                {
                    Console.WriteLine($"BookingID: {dr["BookingId"]}, Customer: {dr["CustName"]}, Phone: {dr["Phone"]}");
                    Console.WriteLine($"Train: {dr["TrainName"]} ({dr["Source"]} -> {dr["Destination"]}), Date: {dr["TravelDate"]}");
                    Console.WriteLine($"Class: {dr["Class"]}, Berth: {dr["BerthAllotment"]}, Cost: {dr["TotalCost"]}");
                }
            }
        }

    }
}
