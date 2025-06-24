using System;

namespace Assignment2Proj
{
    class ArrayQues2
    {
        public static void AQ2()
        {
            int n = 10;
            int[] array = new int[n];
            Console.WriteLine("Enter 10 elements into the array");
            for (int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Elements of array:" + string.Join(", ", array));

            int sum = 0, min = array[0], max = array[0];
            double avg = 0;
            foreach (int i in array)
            {
                sum += i;
                if (i < min) min = i;
                if (i > max) max = i;
            }
            avg = sum / n;

            for(int i = 0; i < n-1; i++)
            {
                for(int j = i+1; j < n; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            Console.WriteLine($"Total:{sum}");
            Console.WriteLine($"Average:{avg}");
            Console.WriteLine($"Minimum element of array:{min}");
            Console.WriteLine($"Maximum element of array:{max}");
            Console.WriteLine("Ascending Order:"+string.Join(", ",array));
            Console.Write("Descending Order:");
            for(int i = n - 1; i >= 0; i--)
            {
                Console.Write(array[i]+", ");
            }
            Console.WriteLine();
            Console.ReadLine();

        }
    }
}
