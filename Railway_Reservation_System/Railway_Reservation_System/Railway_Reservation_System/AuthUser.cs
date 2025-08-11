using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Reservation_System
{
    public static class AuthUser

    {
        public static string Authenticate(string username, string password, string role)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                con.Open();
                string query = "";

                if (role == "Admin")
                    query = "SELECT 'Admin' FROM Admins WHERE Username=@username AND Password=@password";
                else if (role == "User")
                    query = "SELECT 'User' FROM Customers WHERE Username=@username AND Password=@password";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                var result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }


    }
}
