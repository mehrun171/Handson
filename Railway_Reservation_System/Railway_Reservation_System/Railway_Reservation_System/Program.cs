using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Reservation_System
{
    /*class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("*************************************");
            Console.WriteLine("Welcome to Railway Reservation System");
            Console.WriteLine("*************************************");
            Console.WriteLine();

            Console.Write("Enter role (Admin/User): ");
            string role = Console.ReadLine();

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();


            string menu_role=AuthUser.Authenticate(username, password,role);

            if (menu_role == "Admin")
            {
                AdminMenu.ShowAdminMenu();
            }
            else if (menu_role == "User")
            {
                UserMenu.Show();
            }
            else
            {
                Console.WriteLine("Invalid credentials. Exiting...");
            }
        }
    }


}

