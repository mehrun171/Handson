using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Reservation_System
{
    public static class AdminMenu
    {
        public static void ShowAdminMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("======== RRS Admin Menu ========");
                Console.WriteLine();
                Console.WriteLine("1. Add Train");
                Console.WriteLine("2. Delete Train");
                Console.WriteLine("3. Reactivate Train");
                Console.WriteLine("4. View All Bookings");
                Console.WriteLine("5. View All Cancellations");
                Console.WriteLine("6. Logout");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AdminServices.AddTrain();
                        break;
                    case "2":
                        AdminServices.DeleteTrain();
                        break;
                    case "3":
                        AdminServices.ReactivateTrain();
                        break;
                    case "4":
                        ReportManager.ViewBookings();
                        break;
                    case "5":
                        ReportManager.ViewCancellations();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }

}