using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    /*    2. Write a program in C# Sharp to create a file and write an array of strings to the file.
    */
    class Question2
    {
        static void Main()
        {
            List<string> stringlines = new List<string>();
            Console.Write("Enter number of strings: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter string {0}", i + 1);
                string s = Console.ReadLine();
                stringlines.Add(s);
            }
            FileStream fs = new FileStream("C:\\mehr\\Infinite_Hands_on\\C#Assignments\\Assignment_6\\Assignment_6\\Question_2_Text.txt",
                FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);

            foreach (var str in stringlines)
            {
                writer.WriteLine(str);
            }
            writer.Close();

            Console.WriteLine("File created and data written successfully.");
            Console.ReadLine();
        }
    }
}
