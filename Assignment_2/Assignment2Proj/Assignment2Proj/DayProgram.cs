using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Proj
{
    class DayProgram
    {
        enum DaysOfWeek
        {
            Monday =1,
            Tuesday=2,
            Wednesday=3,
            Thursday=4,
            Friday=5,
            Saturday=6,
            Sunday=7
        }
        public static void Run()
        {
            Console.WriteLine("Enter a number for which u want the Day of Week:");
            int number = Convert.ToInt32(Console.ReadLine());
            DaysOfWeek ans = (DaysOfWeek)number;
            Console.WriteLine($"The {number} day of the Week is : {ans}");
            Console.ReadLine();

        }
    }
}
