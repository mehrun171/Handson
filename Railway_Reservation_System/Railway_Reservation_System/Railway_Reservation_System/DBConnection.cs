using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Railway_Reservation_System
{
    public static class DBConnection
    {
        static readonly string connectionString = "Data Source=ICS-LT-4FFZC64\\SQLEXPRESS;Initial Catalog=RailwayReservationSystem;" +
                "User ID=sa;Password=Mehrunshamshi@77;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
