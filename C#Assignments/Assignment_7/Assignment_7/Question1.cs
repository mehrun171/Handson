using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    /*
 * 1.) 
Write a query that returns list of numbers and their squares only if square is greater than 20 

Example input [7, 2, 30]  
Expected output
→ 7 - 49, 30 - 900

 */
    class Question1
    {
        static void Main(string[] args)
        {

            List<int> nums = new List<int>();
            Console.Write("Enter number of elements (n): ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Elements: ");
            for (int i = 0; i < n; i++)
            {
                int a = Convert.ToInt32(Console.ReadLine());
                nums.Add(a);
            }
            var res = nums.Where(x => x * x > 20).Select(x => $"{x} - {x * x}");

            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
            Console.Read();
        }
    }
}
