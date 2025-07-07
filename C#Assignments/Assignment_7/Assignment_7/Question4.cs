using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    /*
 * 4.    Create a class library with a function CalculateConcession()  that takes age as an input and calculates concession for travel as below:
If age <= 5 then “Little Champs - Free Ticket” should be displayed
If age > 60 then calculate 30% concession on the totalfare(Which is a constant Eg:500/-) and Display “ Senior Citizen” + Calculated Fare
Else “Print Ticket Booked” + Fare. 
Create a Console application with a Class called Program which has TotalFare as Constant, Name, Age.  Accept Name, Age from the user and call the CalculateConcession() function to test the Classlibrary functionality
 */
    class Question4
    {
        static void Main()
        {
            Console.Write("Enter your name: ");
            string Name = Console.ReadLine();
            Console.Write("Enter your age: ");
            int Age = int.Parse(Console.ReadLine());
            Console.Write("Enter the total fare: ");
            double TotalFare = double.Parse(Console.ReadLine());

            Assignement7_Question4.TravelConcession travelConcession = new Assignement7_Question4.TravelConcession();
            string result = travelConcession.CalculateConcession(Age, TotalFare);
            Console.WriteLine($"Hello {Name}, {result}");
            Console.Read();
        }
    }
}