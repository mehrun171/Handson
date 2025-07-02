using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    /*2. Create a class called Scholarship which has a function Public void Merit() 
     * that takes marks and fees as an input.
If the given mark is >= 70 and <=80, then calculate scholarship amount as 20% of the fees
If the given mark is > 80 and <=90, then calculate scholarship amount as 30% of the fees
If the given mark is >90, then calculate scholarship amount as 50% of the fees.
In all the cases return the Scholarship amount, else throw an user exception*/


    public class UserException : Exception
    {
        public UserException() 
        {
            Console.WriteLine("NO Scholarship");
        }
    }


    class Scholarship
    {
        public double Merit(int marks,double fee)
        {
            double scholarshipAmount;
            if(marks>=70 && marks <= 80)
            {
                scholarshipAmount = fee * 0.20;
            }
            else if (marks >80 && marks <= 90)
            {
                scholarshipAmount = fee * 0.30;
            }
            else if(marks>90)
            {
                scholarshipAmount = fee * 0.50;
            }
            else

            {
                throw new UserException();
            }
            return scholarshipAmount;
        }
    }
    class Question2
    {
        public static void Main(string[] args)

        {
            Scholarship s = new Scholarship();
            try
            {
                Console.WriteLine("Enter the fee amount");
                double fee = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the marks");
                int marks = int.Parse(Console.ReadLine());
                double amount = s.Merit(marks, fee);
                Console.WriteLine("Scholarship Amount:" + amount);
            }
            catch (UserException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Console.ReadLine();
        }

    }
}
