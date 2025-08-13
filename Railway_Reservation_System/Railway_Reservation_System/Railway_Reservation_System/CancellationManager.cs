using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static Railway_Reservation_System.DBConnection;

namespace Railway_Reservation_System
{
    public class BookingInfo
    {
        public int BookingId { get; set; }
        public int TrainNo { get; set; }
        public string Class { get; set; }
        public DateTime TravelDate { get; set; }
        public double Cost { get; set; }
    }

    public class CancellationManager
    {
        public void CancelTicket()
        {
            Console.Write("Enter Customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int custId))
            {
                Console.WriteLine("Invalid Customer ID");
                return;
            }

            using (SqlConnection con = GetConnection())
            {
                con.Open();

                List<BookingInfo> bookings = new List<BookingInfo>();

                string custBookings = @"
                SELECT BookingId, TrainNo, Class, TravelDate, TotalCost
                FROM Reservations
                WHERE CustId = @custId AND IsDeleted = 0";

                using (SqlCommand cmd = new SqlCommand(custBookings, con))
                {
                    cmd.Parameters.AddWithValue("@custId", custId);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Active Bookings:");
                        while (dr.Read())
                        {
                            BookingInfo booking = new BookingInfo
                            {
                                BookingId = (int)dr["BookingId"],
                                TrainNo = (int)dr["TrainNo"],
                                Class = dr["Class"].ToString(),
                                TravelDate = (DateTime)dr["TravelDate"],
                                Cost = Convert.ToDouble(dr["TotalCost"])
                            };

                            bookings.Add(booking);
                            Console.WriteLine($"Booking ID: {booking.BookingId}, Train No: {booking.TrainNo}, Class: {booking.Class}, Date: {booking.TravelDate:dd-MM-yyyy}, Fare: {booking.Cost}");
                        }

                        if (bookings.Count == 0)
                        {
                            Console.WriteLine("No active bookings found for this customer.");
                            return;
                        }
                    }
                }

                Console.WriteLine("Enter Booking ID to cancel: ");
                if (!int.TryParse(Console.ReadLine(), out int bookingIdToCancel))
                {
                    Console.WriteLine("Invalid Booking ID.");
                    return;
                }

                BookingInfo selectedBooking = bookings.FirstOrDefault(b => b.BookingId == bookingIdToCancel);
                if (selectedBooking == null)
                {
                    Console.WriteLine("Booking ID not found in your active bookings.");
                    return;
                }

                Console.WriteLine("Are you sure you want to cancel this ticket? (yes/no): ");
                string confirmation = Console.ReadLine().ToLower();
                if (confirmation != "yes")
                {
                    Console.WriteLine("Cancellation Cancelled");
                    return;
                }

                SqlTransaction tr = con.BeginTransaction();

                try
                {
                    double refund = selectedBooking.Cost * 0.5;

                    SqlCommand insertCancel = new SqlCommand(@"
                    INSERT INTO Cancellations (BookingId, RefundAmount)
                    VALUES (@bookingId, @refund)", con, tr);
                    insertCancel.Parameters.AddWithValue("@bookingId", selectedBooking.BookingId);
                    insertCancel.Parameters.AddWithValue("@refund", refund);
                    insertCancel.ExecuteNonQuery();

                    SqlCommand updateBooking = new SqlCommand("UPDATE Reservations SET IsDeleted = 1 WHERE BookingId = @bookingId", con, tr);
                    updateBooking.Parameters.AddWithValue("@bookingId", selectedBooking.BookingId);
                    updateBooking.ExecuteNonQuery();

                    SqlCommand updateSeats = new SqlCommand(@"
                    UPDATE TrainClasses SET Availability = Availability + 1 
                    WHERE TrainNo = @trainNo AND Class = @class", con, tr);
                    updateSeats.Parameters.AddWithValue("@trainNo", selectedBooking.TrainNo);
                    updateSeats.Parameters.AddWithValue("@class", selectedBooking.Class);
                    updateSeats.ExecuteNonQuery();

                    tr.Commit();
                    Console.WriteLine($"Ticket cancelled successfully. 50% Refund-Initiated: {refund}");
                }
                catch (Exception e)
                {
                    tr.Rollback();
                    Console.WriteLine("Cancellation failed: " + e.Message);
                }
            }
        }
    }
}
