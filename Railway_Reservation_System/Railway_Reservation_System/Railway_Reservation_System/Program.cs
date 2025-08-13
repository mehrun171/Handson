using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Reservation_System
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("*************************************");
                Console.WriteLine("Welcome to Railway Reservation System");
                Console.WriteLine("*************************************");
                Console.WriteLine();

                Console.Write("Enter role (Admin/User) or type 'exit' to quit: ");
                string role = Console.ReadLine();

                if (role.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting!! Goodbye!");
                    break;
                }

                Console.Write("Enter Username: ");
                string username = Console.ReadLine();

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                string menu_role = AuthUser.Authenticate(username, password, role);

                if (menu_role == "Admin")
                {
                    AdminMenu.ShowAdminMenu();
                    Console.WriteLine("Logged out.\n Press Enter to return to Main screen...");
                    Console.ReadLine();
                }
                else if (menu_role == "User")
                {
                    UserMenu.Show(username);
                    Console.WriteLine("Logged out.\n Press Enter to return to Main screen...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid credentials. Press Enter to try again...");
                    Console.ReadLine();
                }
            }
        }
    }

}
