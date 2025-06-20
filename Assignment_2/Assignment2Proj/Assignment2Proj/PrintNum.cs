using System;


namespace Assignment2Proj
{
    class PrintNum
    {
        public static void Num()
        {
            Console.WriteLine("Enter a Number");
            string s= Console.ReadLine();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("{0} {0} {0} {0}", s);
                Console.WriteLine("{0}{0}{0}{0}", s);
            }
            Console.ReadLine();

        }
    }
}
