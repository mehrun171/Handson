using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    /*
 * 
2.)

Write a query that returns words starting with letter 'a' and ending with letter 'm'.


Expected input and output
"mum", "amsterdam", "bloom" → "amsterdam"
 */
    class Question2
    {
        static void Main()
        {
            List<string> strings = new List<string>();
            Console.WriteLine("Enter number of strings");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter String {0}: ", i + 1);
                string s = Console.ReadLine();
                strings.Add(s);
            }
            var result = strings.Where(word => word.StartsWith("a") && word.EndsWith("m"));
            Console.WriteLine("Output: ");
            foreach (var res in result)
                Console.WriteLine(res);
            Console.Read();
        }
    }
}
