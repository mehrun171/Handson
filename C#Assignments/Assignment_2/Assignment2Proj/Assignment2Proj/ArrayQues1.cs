using System;


namespace Assignment2Proj
{
    class ArrayQues1
    {
        public static void AQ1()
        {
            Console.WriteLine("Enter the number of elements:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            if (n <= 0)
            {
                Console.WriteLine("error");
                return;
            }
            Console.WriteLine("Enter elements in the array");
            for(int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Elements of array:" + string.Join(", ", array));
            int sum = 0;
            int min = array[0];
            int max = array[0];
            double avg = 0;
            for (int i= 0;i < n;i++)
            {
                sum += array[i];
                if (array[i] < min) min = array[i];
                if (array[i] > max) max = array[i];
            }
            avg = sum / n;
            Console.WriteLine($"Average of array elements:{avg}");
            Console.WriteLine($"Minimum element of array:{min}");
            Console.WriteLine($"Maximum element of array:{max}");
            Console.ReadLine();

        }
    }
}
