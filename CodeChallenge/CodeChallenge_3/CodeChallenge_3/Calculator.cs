using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge_3
{
/*    4. Write a console program that uses delegate object as an argument to call Calculator Functionalities like 
 *    1. Addition, 2. Subtraction and 3. Multiplication by taking 2 integers and returning the output to the user. 
 *    You should display all the return values accordingly.
*/    class Calculator
    
        {
            public delegate void CalculatorDelegate(int x, int y);

                public static void Add(int a, int b)
                {
                    Console.WriteLine($"Addition: {a + b}");
                }

                public static void Subtract(int a, int b)
                {
                    Console.WriteLine($"Subtraction: {a - b}");
                }

                public static void Multiply(int a, int b)
                {
                    Console.WriteLine($"Multiplication: {a * b}");
                }

                public static void Main(string[] args)
                {
                    Console.Write("Enter integer x: ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter integer y: ");
                    int y = Convert.ToInt32(Console.ReadLine());


                    CalculatorDelegate cal = Add;
                    cal += Subtract;
                    cal += Multiply;
                    cal(x, y); 
                    Console.ReadLine();

                }
          }
 }