using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SqlClient;
using static Railway_Reservation_System.DBConnection;

namespace Railway_Reservation_System
{
    public class TrainManager
    {
        public void ViewAvailableTrains()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"
                SELECT t.TrainNo, t.TrainName, t.Source, t.Destination, 
                       tc.Class, tc.Availability, tc.CostPerSeat
                FROM Trains t
                JOIN TrainClasses tc ON t.TrainNo = tc.TrainNo
                WHERE t.IsActive = 1 AND tc.Availability > 0";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("Available Trains:");
                while (dr.Read())
                {
                    Console.WriteLine($"Train No: {dr["TrainNo"]}, TrainName: {dr["TrainName"]}, " +
                                      $"From: {dr["Source"]}, To: {dr["Destination"]}, " +
                                      $"Class: {dr["Class"]}, Available Seats: {dr["Availability"]}, " +
                                      $"Fare: {dr["CostPerSeat"]}");
                }
            }
        }
    }

}
