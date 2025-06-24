using System;


namespace Assignment2Proj
{
    class SwapNum
    {
        public static void Swap()
        {
            Console.WriteLine("Enter number 1");
            int num1=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number 2");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Before Swapping -> num1={num1} and num2={num2}");

            num1 = num1 ^ num2;
            num2 = num1 ^ num2;
            num1 = num1 ^ num2;

            Console.WriteLine($"After Swapping -> num1={num1} and num2={num2}");
            Console.ReadLine();

        }
    }
}
