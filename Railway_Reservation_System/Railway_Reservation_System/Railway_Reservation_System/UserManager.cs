using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Railway_Reservation_System.DBConnection;

namespace Railway_Reservation_System
{
    public class UserManager
    {
        public void RegisterUser()
        {
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Email ID: ");
            string email = Console.ReadLine();

            Console.Write("Enter UserName: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"
                INSERT INTO Customers (CustName, Phone, MailId,Username,Password)
                VALUES (@name, @phone, @email,@username,@password)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Customer registered successfully");
            }
        }
    }
}
