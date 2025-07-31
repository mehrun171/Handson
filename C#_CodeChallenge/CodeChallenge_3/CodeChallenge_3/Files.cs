using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeChallenge_3
{
    //3. Write a program in C# Sharp to append some text to an existing file.
    //If file is not available, then create one in the same workspace.
    //Hint: (Use the appropriate mode of operation.Use stream writer class)
    class Files
    {
        static void WriteStream()
        {
            FileStream fs = new FileStream("C:\\mehr\\Infinite_Hands_on\\CodeChallenge\\CodeChallenge_3\\CodeChallenge_3\\Test2.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Console.Write("Enter string to append in the file:  ");
            string str = Console.ReadLine();
            sw.WriteLine(str);

        }
        static void ReadStream()
        {
            FileStream fs = new FileStream("C:\\mehr\\Infinite_Hands_on\\CodeChallenge\\CodeChallenge_3\\CodeChallenge_3\\Test.txt", FileMode.Append, FileAccess.Write);
            StreamReader sr = new StreamReader(fs);
            string str = sr.ReadLine();
            Console.WriteLine("Text existing in the file: ");
            while (str != null)
            {
                Console.WriteLine(str);
                str = sr.ReadLine();
            }
            
        }
        public static void Main()
        {
            WriteStream();
            Console.WriteLine("************Text Appended************");
            ReadStream();
            Console.WriteLine("Done!!!");
            Console.Read();
        }
    }
}