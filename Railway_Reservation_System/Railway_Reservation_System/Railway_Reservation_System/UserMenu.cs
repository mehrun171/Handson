using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Reservation_System
{
    public static class UserMenu
    {
        public static void Show()
        {
            var userManager = new UserManager();
            var trainManager = new TrainManager();
            var reservationManager = new ReservationManager();
            var cancellationManager = new CancellationManager();
            var reportManager = new ReportManager();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("========== Railway Reservation System ==========");
                Console.WriteLine();
                Console.WriteLine("1. Register New Customer"); //working
                Console.WriteLine("2. Book Ticket");//working
                Console.WriteLine("3. Cancel Ticket");//working
                Console.WriteLine("4. View Available Trains");//working
                Console.WriteLine("5. View Bookings");//working
                Console.WriteLine("6. View Cancellations");//working
                Console.WriteLine("7. Print Ticket");//working
                Console.WriteLine("8. Exit");
                //add nunit aslo//
                Console.Write("Enter your choice: ");
                Console.WriteLine();
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1: userManager.RegisterUser();
                        break;
                    case 2:
                        Console.Write("Enter your registered Customer ID: ");
                        int custId = int.Parse(Console.ReadLine());
                        reservationManager.BookTicket(custId);
                        break;
                    case 3: cancellationManager.CancelTicket(); 
                        break;
                    case 4: trainManager.ViewAvailableTrains(); 
                        break;
                    case 5: reportManager.ViewBookings(); 
                        break;
                    case 6: reportManager.ViewCancellations(); 
                        break;
                    case 7: reportManager.PrintTicket(); 
                        break;
                    case 8: Console.WriteLine("Exit The Menu..."); 
                        return;
                    default: Console.WriteLine("Invalid choice...Choose again."); 
                        break;
                }
            }
        }
    }

}
