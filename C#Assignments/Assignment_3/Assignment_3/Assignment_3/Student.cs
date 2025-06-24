using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    

    class Student
    {
        public static int rollno;
        public static string name;
        public static string Classs;
        public static int sem;
        public static string branch;
        int[] marks = new int[5];


        public Student(int RollNo, string Name, string Class, int semester, string Branch)
        {
            rollno = RollNo;
            name = Name;
            Classs = Class;
            sem = semester;
            branch = Branch;
        }
        public void GetMarks()
        {
            Console.WriteLine("Enter the 5 subject Marks");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine("Enter the Marks {0}", i + 1);
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void DisplayResult()
        {
            int total = 0;
            bool check=false;
            float avg;
        
            foreach (int i in marks)
            {
                if (i < 35)
                {
                    check = true;
                }
                total += i;
            }

            avg = total / 5;
            Console.WriteLine();

            Console.WriteLine($"Average of all the 5 subs is {avg}");
            Console.WriteLine("******Result:******");
            if (check == true)
            {
                Console.WriteLine("Failed");
            }
            else if (check == false && avg < 50)
            {
                Console.WriteLine("Failed");
            }
            else
            {
                Console.WriteLine("Passed");
            }
        }

        public void DisplayData()
        {
            Console.WriteLine("**********Student Details************");
            Console.WriteLine("Student Roll No:{0}", rollno);
            Console.WriteLine("Student Name:{0}", name);
            Console.WriteLine("Class:{0}", Classs);
            Console.WriteLine("Semester:{0}", sem);
            Console.WriteLine("Branch:{0}", branch);
            Console.WriteLine();
            Console.WriteLine("The 5 Subject Marks are:");
            foreach (int i in marks)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            DisplayResult();
        }
        public static void Main()
        {
            int roll;
            string stuname;
            string Class;
            int sem;
            string branch;
            Console.WriteLine("Enter Student Roll No: ");
            roll = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Name: ");
            stuname = Console.ReadLine();
            Console.WriteLine("Enter Student Class: ");
            Class = Console.ReadLine();
            Console.WriteLine("Enter Semester: ");
            sem = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Branch: ");
            branch = Console.ReadLine();
            Student student = new Student(roll, stuname, Class, sem, branch);
            student.GetMarks();
            student.DisplayData();
            Console.Read();

        }
    }
}
