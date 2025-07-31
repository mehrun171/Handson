using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge_2
{
/*    3. Write a C# program to implement a method that takes an integer as input and throws 
 *    an exception if the number is negative. Handle the exception in the calling code.
*/    
    public class NegativeNumException : Exception
    {
        public NegativeNumException() {
            Console.WriteLine("Entered Number is NEGATIVE NUMBER");
            }
    }
    class Question3
    {
        public static void Check(int num)
        {
            if (num < 0)
            {
                throw new NegativeNumException();
            }
            else
            {
                Console.WriteLine($"Entered Number is :{num}");
            }
        }
        public static void Main()
        {
            Console.WriteLine("Enter a Number");
            int number = Convert.ToInt32(Console.ReadLine());
            try
            {
                Check(number);
            }
            catch(NegativeNumException e)
            {
                Console.WriteLine("Exception Occurred :" + e.Message);
            }
            Console.ReadLine();
        }
    }
}
