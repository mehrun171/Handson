using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge_1
{
    /*1. Write a C# Sharp program to remove the character at a given position in the string. 
     * The given position will be in the range 0..(string length -1) inclusive.
 
Sample Input:
"Python", 1
"Python", 0
"Python", 4
Expected Output:
Pthon
ython
Pythn
*/
    class Question1
    {
        public static void Run(string str,int pos)
        {
            string ans = "";
            for(int i = 0; i < str.Length; i++)
            {
                if (i != pos)
                {
                    ans += str[i];
                }
                
            }
            Console.WriteLine($"{ans}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string");
            string str= Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter the position");
            int pos = Convert.ToInt32(Console.ReadLine());
            Run(str, pos);
            Console.ReadLine();
        }
    }
}
