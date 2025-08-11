using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static Railway_Reservation_System.DBConnection;

namespace Railway_Reservation_System
{
    public class ReservationManager
    {
        public void BookTicket(int custID)
        {
            Console.Write("Enter Source: ");
            string source = Console.ReadLine().ToLower();

            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine().ToLower();

            Console.Write("Enter Travel Class (Sleeper / 2AC / 3AC): ");
            string travelClass = Console.ReadLine().ToLower();

            Console.Write("Enter Travel Date in format (DD-MM-YYYY): ");
            string travelDateInput = Console.ReadLine();

            if (!DateTime.TryParseExact(travelDateInput, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime travelDate))
            {
                Console.WriteLine("Invalid date format");
                return;
            }

            if (travelDate < DateTime.Today)
            {
                Console.WriteLine("Travel date cannot be in the past.");
                return;
            }

            using (SqlConnection con = GetConnection())
            {
                con.Open();

                if (!IsValidCustomer(con, custID))
                {
                    Console.WriteLine("Invalid Customer ID");
                    return;
                }

                try
                {
                    string previewQuery = @"
                    SELECT t.TrainNo, t.TrainName, tc.Class, tc.Availability
                    FROM Trains t
                    JOIN TrainClasses tc ON t.TrainNo = tc.TrainNo
                    WHERE LOWER(t.Source) = @source AND LOWER(t.Destination) = @destination";

                    using (SqlCommand previewCmd = new SqlCommand(previewQuery, con))
                    {
                        previewCmd.Parameters.AddWithValue("@source", source);
                        previewCmd.Parameters.AddWithValue("@destination", destination);

                        using (SqlDataReader previewReader = previewCmd.ExecuteReader())
                        {
                            Console.WriteLine("Available Trains for Your Route:");
                            bool found = false;
                            while (previewReader.Read())
                            {
                                found = true;
                                Console.WriteLine($"Train No: {previewReader["TrainNo"]}, Name: {previewReader["TrainName"]}, Class: {previewReader["Class"]}, Seats: {previewReader["Availability"]}");
                            }

                            if (!found)
                            {
                                Console.WriteLine("No trains available for this route.");
                                return;
                            }
                        }
                    }

                    string trainQuery = @"
                    SELECT t.TrainNo, tc.Availability
                    FROM Trains t
                    JOIN TrainClasses tc ON t.TrainNo = tc.TrainNo
                    WHERE LOWER(t.Source) = @source AND LOWER(t.Destination) = @destination AND LOWER(tc.Class) = @class";

                    using (SqlCommand trainCmd = new SqlCommand(trainQuery, con))
                    {
                        trainCmd.Parameters.AddWithValue("@source", source);
                        trainCmd.Parameters.AddWithValue("@destination", destination);
                        trainCmd.Parameters.AddWithValue("@class", travelClass);

                        using (SqlDataReader dr = trainCmd.ExecuteReader())
                        {
                            if (!dr.Read())
                            {
                                Console.WriteLine("No train found for the given route and class.");
                                return;
                            }

                            int trainNo = Convert.ToInt32(dr["TrainNo"]);
                            int seatsAvailable = Convert.ToInt32(dr["Availability"]);

                            if (seatsAvailable <= 0)
                            {
                                Console.WriteLine("No seats available in the selected class.");
                                return;
                            }

                            dr.Close();

                            string berth = GenerateBerth();
                            decimal fare = CalculateFare(con, trainNo, travelClass);

                            string insertQuery = @"
                            INSERT INTO Reservations (CustId, TrainNo, Class, TravelDate, BookingDate, BerthAllotment, TotalCost, IsDeleted)
                            VALUES (@custId, @trainNo, @class, @travelDate, @bookingDate, @berth, @totalCost, 0)";

                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                            {
                                insertCmd.Parameters.AddWithValue("@custId", custID);
                                insertCmd.Parameters.AddWithValue("@trainNo", trainNo);
                                insertCmd.Parameters.AddWithValue("@class", travelClass);
                                insertCmd.Parameters.AddWithValue("@travelDate", travelDate);
                                insertCmd.Parameters.AddWithValue("@bookingDate", DateTime.Today);
                                insertCmd.Parameters.AddWithValue("@berth", berth);
                                insertCmd.Parameters.AddWithValue("@totalCost", fare);

                                int rows = insertCmd.ExecuteNonQuery();
                                object result = insertCmd.ExecuteScalar();
                                int BookingId = Convert.ToInt32(result);

                                if (rows > 0)
                                {
                                    string updateSeats = @"
                                    UPDATE TrainClasses
                                    SET Availability = Availability - 1
                                    WHERE TrainNo = @trainNo AND LOWER(Class) = @class";

                                    using (SqlCommand updateCmd = new SqlCommand(updateSeats, con))
                                    {
                                        updateCmd.Parameters.AddWithValue("@trainNo", trainNo);
                                        updateCmd.Parameters.AddWithValue("@class", travelClass);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                    

                                    Console.WriteLine("Ticket booked successfully!");
                                    Console.WriteLine($"Train No: {trainNo}, Berth: {berth}, Fare: {fare}");
                                }
                                else
                                {
                                    Console.WriteLine("Booking failed.");
                                }
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Booking failed due to invalid input or database error.");
                    Console.WriteLine($"Details: {e.Message}");
                }
            }
        }

        private bool IsValidCustomer(SqlConnection con, int custId)
        {
            string query = "SELECT COUNT(*) FROM Customers WHERE CustId = @custId AND IsDeleted = 0";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@custId", custId);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public string GenerateBerth()
        {
            Random rnd = new Random();
            return "Berth->" + rnd.Next(1, 150);
        }

        private decimal CalculateFare(SqlConnection con, int trainNo, string travelClass)
        {
            string Query = @"
            SELECT CostPerSeat
            FROM TrainClasses
            WHERE TrainNo = @trainNo AND LOWER(Class) = @class";

            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                cmd.Parameters.AddWithValue("@trainNo", trainNo);
                cmd.Parameters.AddWithValue("@class", travelClass.ToLower());

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToDecimal(result);
                }
                else
                {
                    throw new Exception("Fare not available");
                }
            }
        }
    }
}
