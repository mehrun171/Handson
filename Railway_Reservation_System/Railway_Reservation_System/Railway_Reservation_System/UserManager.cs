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

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"
                INSERT INTO Customers (CustName, Phone, MailId)
                VALUES (@name, @phone, @mail)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@mail", email);

                con.Open();
                cmd.ExecuteNonQuery();
                object result = cmd.ExecuteScalar();
                int custId = Convert.ToInt32(result);
                Console.WriteLine($"Customer registered successfully with CustID ->{custId}");
            }
        }
    }
}
