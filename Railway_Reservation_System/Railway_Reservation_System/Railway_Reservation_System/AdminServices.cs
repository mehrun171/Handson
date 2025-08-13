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

            Console.Write("Enter Sleeper Class Seats: ");
            int sleeperSeats = int.Parse(Console.ReadLine());
            Console.Write("Enter Sleeper Class Cost per Seat: ");
            decimal sleeperCost = decimal.Parse(Console.ReadLine());

            Console.Write("Enter 2AC Class Seats: ");
            int ac2Seats = int.Parse(Console.ReadLine());
            Console.Write("Enter 2AC Class Cost per Seat: ");
            decimal ac2Cost = decimal.Parse(Console.ReadLine());

            Console.Write("Enter 3AC Class Seats: ");
            int ac3Seats = int.Parse(Console.ReadLine());
            Console.Write("Enter 3AC Class Cost per Seat: ");
            decimal ac3Cost = decimal.Parse(Console.ReadLine());

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                string trainQuery = "INSERT INTO Trains (TrainNo, TrainName, Source, Destination) VALUES (@trainNo, @trainName, @source, @destination)";
                SqlCommand trainCmd = new SqlCommand(trainQuery, conn);
                trainCmd.Parameters.AddWithValue("@trainNo", trainNo);
                trainCmd.Parameters.AddWithValue("@trainName", trainName);
                trainCmd.Parameters.AddWithValue("@source", source);
                trainCmd.Parameters.AddWithValue("@destination", destination);
                trainCmd.ExecuteNonQuery();

                string classQuery = "INSERT INTO TrainClasses (TrainNo, Class, Availability, MaxAvailability, CostPerSeat) VALUES (@trainNo, @class, @avail, @max, @cost)";
                SqlCommand sleeperCmd = new SqlCommand(classQuery, conn);
                sleeperCmd.Parameters.AddWithValue("@trainNo", trainNo);
                sleeperCmd.Parameters.AddWithValue("@class", "Sleeper");
                sleeperCmd.Parameters.AddWithValue("@avail", sleeperSeats);
                sleeperCmd.Parameters.AddWithValue("@max", sleeperSeats);
                sleeperCmd.Parameters.AddWithValue("@cost", sleeperCost);
                sleeperCmd.ExecuteNonQuery();

                SqlCommand ac2Cmd = new SqlCommand(classQuery, conn);
                ac2Cmd.Parameters.AddWithValue("@trainNo", trainNo);
                ac2Cmd.Parameters.AddWithValue("@class", "2AC");
                ac2Cmd.Parameters.AddWithValue("@avail", ac2Seats);
                ac2Cmd.Parameters.AddWithValue("@max", ac2Seats);
                ac2Cmd.Parameters.AddWithValue("@cost", ac2Cost);
                ac2Cmd.ExecuteNonQuery();

                SqlCommand ac3Cmd = new SqlCommand(classQuery, conn);
                ac3Cmd.Parameters.AddWithValue("@trainNo", trainNo);
                ac3Cmd.Parameters.AddWithValue("@class", "3AC");
                ac3Cmd.Parameters.AddWithValue("@avail", ac3Seats);
                ac3Cmd.Parameters.AddWithValue("@max", ac3Seats);
                ac3Cmd.Parameters.AddWithValue("@cost", ac3Cost);
                ac3Cmd.ExecuteNonQuery();

                Console.WriteLine("Train and class details added successfully.");
            }
        }


        public static void DeleteTrain()
        {
            Console.Write("Enter Train Number to deactivate: ");
            int trainNo = int.Parse(Console.ReadLine());

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                // Step 1: Check for bookings
                string bookingQuery = @"
            SELECT BookingId, CustId, TotalCost, BookingDate
            FROM Reservations
            WHERE TrainNo = @trainNo AND IsDeleted = 0";

                SqlCommand bookingCmd = new SqlCommand(bookingQuery, conn);
                bookingCmd.Parameters.AddWithValue("@trainNo", trainNo);

                SqlDataReader dr = bookingCmd.ExecuteReader();

                List<int> recentBookingIds = new List<int>();
                bool hasOldBookings = false;

                while (dr.Read())
                {
                    DateTime bookingDate = Convert.ToDateTime(dr["BookingDate"]);
                    int bookingId = Convert.ToInt32(dr["BookingId"]);
                    int custId = Convert.ToInt32(dr["CustId"]);
                    decimal refundAmount = Convert.ToDecimal(dr["TotalCost"]);

                    if ((DateTime.Now - bookingDate).TotalDays > 10)
                    {
                        hasOldBookings = true;
                        break;
                    }
                    else
                    {
                        recentBookingIds.Add(bookingId);
                    }
                }

                dr.Close();

                if (hasOldBookings)
                {
                    Console.WriteLine("Cannot deactivate train. Some bookings are older than 10 days.");
                    return;
                }

                // Step 2: Refund and cancel recent bookings
                foreach (int bookingId in recentBookingIds)
                {
                    string cancelQuery = @"
                INSERT INTO Cancellations (BookingId, RefundAmount, CancellationDate, TicketCancelled)
                SELECT BookingId, TotalCost, GETDATE(), 1
                FROM Reservations
                WHERE BookingId = @bookingId;

                UPDATE Reservations SET IsDeleted = 1 WHERE BookingId = @bookingId;";

                    SqlCommand cancelCmd = new SqlCommand(cancelQuery, conn);
                    cancelCmd.Parameters.AddWithValue("@bookingId", bookingId);
                    cancelCmd.ExecuteNonQuery();
                }

                // Step 3: Deactivate train
                string deactivateQuery = "UPDATE Trains SET IsActive = 0 WHERE TrainNo = @trainNo";
                SqlCommand deactivateCmd = new SqlCommand(deactivateQuery, conn);
                deactivateCmd.Parameters.AddWithValue("@trainNo", trainNo);
                int rows = deactivateCmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Train deactivated successfully. Refunds issued for recent bookings.");
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
