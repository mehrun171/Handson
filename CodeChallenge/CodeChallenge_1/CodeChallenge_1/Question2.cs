using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge_1
{
    /*2. Write a C# Sharp program to exchange the first and last characters in a given string and return the new string.
 
Sample Input:
"abcd"
"a"
"xy"
Expected Output:
 
dbca
a
yx*/

    class Question2
    {
            static string Run(string str)
            {
                char[] chars = str.ToCharArray();
                char temp = chars[0];
                chars[0] = chars[chars.Length - 1];
                chars[chars.Length - 1] = temp;

                return new string(chars);
            }
        

        public static void Main()
        {
            string[] test = { "abcd", "a", "xy" };

            foreach (string str in test)
            {
                Console.WriteLine(Run(str));
            }

            Console.ReadLine();
        }
    }
}


