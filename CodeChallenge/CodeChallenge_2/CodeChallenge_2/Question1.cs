using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge_2
{
   /* 1. Create an Abstract class Student with Name, StudentId, Grade as members and also an abstract method Boolean Ispassed(grade) 
    * which takes grade as an input and checks whether student passed the course or not.

Create 2 Sub classes Undergraduate and Graduate that inherits all members of the student and overrides Ispassed(grade) method

For the UnderGrad class, if the grade is above 70.0, then isPassed returns true, otherwise it returns false. For the Grad class, 
   if the grade is above 80.0, then isPassed returns true, otherwise returns false.
 
Test the above by creating appropriate objects*/

    abstract class Student
    {
       public string StudentName { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }
        public Student(string studentname,int studentid,double grade)
        {
            StudentName = studentname;
            StudentId = studentid;
            Grade = grade;
        }
        public abstract bool IsPassed(double grade);
    }
    class UnderGraduate : Student {
          public UnderGraduate(string studentname, int studentid, double grade) : base (studentname, studentid, grade) { }
        public override bool IsPassed(double grade)
        {
            if (grade > 70.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Graduate : Student {
     public Graduate(string studentname, int studentid, double grade) : base(studentname, studentid, grade) { }
        public override bool IsPassed(double grade)
        {
            if (grade > 80.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Question1
    {
        static void Main(string[] args)
        {
            UnderGraduate undergraduate = new UnderGraduate("Tom", 121, 80.0);
            Graduate graduate = new Graduate("Lilly", 145, 65.0);
            Console.WriteLine($"Undergraduate = {undergraduate.StudentName} , {undergraduate.StudentId} Pass Result: {undergraduate.IsPassed(undergraduate.Grade)}");
            Console.WriteLine($"Graduate = {graduate.StudentName} ,{undergraduate.StudentId}  Pass Result: {graduate.IsPassed(graduate.Grade)}");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Enter student name,student id, student grade");
            string name = Console.ReadLine();
            int id = Convert.ToInt32(Console.ReadLine());
            double grade = Convert.ToDouble(Console.ReadLine());
            UnderGraduate ug = new UnderGraduate(name, id, grade);
            Graduate g = new Graduate(name, id, grade);
            Console.WriteLine("---------------------O/P of above student in both cases-------------------");
            Console.WriteLine($"Undergraduate = {ug.StudentName}, {ug.StudentId}, Pass Result: {ug.IsPassed(ug.Grade)}");
            Console.WriteLine($"Graduate = {g.StudentName} ,{g.StudentId}, Pass Result: {g.IsPassed(g.Grade)}");
            Console.ReadLine();
        }

    }
}
