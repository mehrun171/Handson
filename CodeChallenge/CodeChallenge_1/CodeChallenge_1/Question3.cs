using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge_1
{
    /*3. Write a C# Sharp program to check the largest number among three given integers.
 
Sample Input:
1,2,3
1,3,2
1,1,1
1,2,2
Expected Output:
3
3
1
2*/
    class Question3
    {
        public static void Main()
        {
            Console.WriteLine("Biggest Number among three numbers");
            Console.WriteLine("Enter 3 numbers with ,");
            string input = Convert.ToString(Console.ReadLine());
            string[] input2 = input.Split(',');
            int max = 0;
            foreach(string i in input2){
                if (Convert.ToInt32(i) > max)
                {
                    max = Convert.ToInt32(i);
                }
            }
            Console.WriteLine($"MAX element:{max}");
            Console.ReadLine();
        }
    }
}
