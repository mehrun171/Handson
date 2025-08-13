using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Reservation_System
{
    public class User
    {
        public string Username;
        public string Password;

        public bool Login(string username, string password)
        {
            return Username == username && Password == password;
        }

        public virtual string GetRole()
        {
            return "User";
        }
    }

    public class Admin : User
    {
        public override string GetRole()
        {
            return "Admin";
        }
    }
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
        public static int GetCustomerId(string username)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "SELECT CustId FROM Customers WHERE Username = @username AND IsDeleted = 0";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);

                con.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    throw new Exception("Customer not found or account is inactive.");
                }
            }
        }



    }
}
