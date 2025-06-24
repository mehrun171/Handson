using System;

namespace FirstProj_Dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckEqualOrNot();
            Console.WriteLine("");
            CheckPosOrNeg();
            Console.WriteLine("");
            Operations();
            Console.WriteLine("");
            Table();
            Console.WriteLine("");
            Console.WriteLine("****Sum of Two Unsimilar Numbers****");
            Console.Write("Enter the first num: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second nnum: ");
            int b = Convert.ToInt32(Console.ReadLine());
            int ans = ReturnFun(a, b);
            Console.WriteLine("Result:"+ans);
            Console.ReadLine();
        }

        public static void CheckEqualOrNot()
        {
            Console.WriteLine("****Equal numbers or not****");
            Console.WriteLine("Enter num1 :");
            int num1;
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter num2 :");
            int num2;
            num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 == num2)
            {
                Console.WriteLine($"{num1} and {num2} are Equal");
            }
            else
            {
                Console.WriteLine($"{num1} and {num2} are Not Equal");

            }
        }

        public static void CheckPosOrNeg()
        {
            Console.WriteLine("****Check if given Number is Positive or Negative****");
            Console.WriteLine("Enter a number :");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num > 0)
            {
                Console.WriteLine($"{num} is a Positive Number");
            }
            else
            {
                Console.WriteLine($"{num} is a Negative Number");
            }
        }

        public static void Operations()
        {
            Console.WriteLine("****Performing Operations****");
            Console.WriteLine("Enter first number :");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number :");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Opearation to be performed :");
            char o = Convert.ToChar(Console.ReadLine());
            switch (o)
            {
                case '+':
                    Console.WriteLine($"{a} {o} {b} = {a + b}");
                    break;
                case '-':
                    Console.WriteLine($"{a} {o} {b} = {a - b}");
                    break;
                case '*':
                    Console.WriteLine($"{a} {o} {b} = {a * b}");
                    break;
                case '/':
                    Console.WriteLine($"{a} {o} {b} = {a / b}");
                    break;
                default:
                    Console.WriteLine("Invalid Operator");
                    break;
            }
        }

        public static void Table()
        {
            Console.WriteLine("****Multiplication Table****");
            Console.WriteLine("Enter the Number to print a table :");
            int t = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{t} * {i} = {t * i}");
            }
        }

        public static int ReturnFun(int a, int b)
        {
            if (a == b)
            {
                return 3 * (a + b);
            }
            return a + b;
        }


    }

    class Practice
    {

    }
}
