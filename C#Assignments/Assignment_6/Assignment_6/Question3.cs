using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_6
{
    class Question3
    {
        static void Main()
        {
            try
            {
                FileStream fs = new FileStream("C:\\mehr\\Infinite_Hands_on\\C#Assignments\\Assignment_6\\Assignment_6\\SampleFile.txt",
                    FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                int linecount = 0;
                string str = sr.ReadLine();
                while (str != null)
                {
                    linecount++;
                    Console.WriteLine(str);
                    str = sr.ReadLine();
                }
                Console.WriteLine("Number of lines in file: {0}", linecount);
                sr.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occurred!!!" + e.Message);
            }
            Console.Read();
        }
    }
}