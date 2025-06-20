using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2Proj
{
    class ArrayQues3
    {
        public static void AQ3()
        {
            Console.WriteLine("Enter the number of elements:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            int[] copyarray = new int[n];
            Console.WriteLine("Enter elements in the array");
            for (int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Elements of original array:" + string.Join(", ", array));
            for(int i=0;i<n;i++)
            {
                copyarray[i] = array[i];
            }

            Console.WriteLine("Elements of copied array:" + string.Join(", ", copyarray));
            Console.ReadLine();

        }
    }
}
