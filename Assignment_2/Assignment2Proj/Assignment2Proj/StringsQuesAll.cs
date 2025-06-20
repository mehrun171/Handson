using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Proj
{
    class StringsQuesAll
    {
        /*static void Main()
        {
            LengthOfWord();
            ReverseWord();
            CompareStrings();
        }*/
        public static void LengthOfWord()
        {
            Console.WriteLine("Enter a string");
            string str = Console.ReadLine();
            Console.WriteLine($"Length of the String is :{str.Length}");
            Console.ReadLine();

        }

        public static void ReverseWord()
        {
            Console.WriteLine("Enter a string to Reverse");
            string str = Console.ReadLine();
            string rev = "";
            for(int i = str.Length - 1; i >= 0; i--)
            {
                rev += str[i];
            }
            Console.WriteLine($"Reverse of the String is :{rev}");
            Console.ReadLine();

        }
        public static void CompareStrings()
        {
            Console.WriteLine("Enter first string");
            string str1 = Console.ReadLine();
            Console.WriteLine("Enter second string");
            string str2 = Console.ReadLine();
            if (str1 == str2)
            {
                Console.WriteLine("Both Strings are same => {0} == {1}",str1,str2);
            }
            else
            {
                Console.WriteLine("Both Strings are different => {0} != {1}", str1,str2);

            }
            Console.ReadLine();

        }

    }
}
