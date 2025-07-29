using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Assignment
{
    /* Use the Below class with Data that you already have and write the queries
 -------------------------------------------------------------------------

 1. Create a console application and add class named Employee with following field.
 Employee Class
 EmployeeID (Integer)
 FirstName (String)
 LastName (String)
 Title (String)
 DOB (Date)
 DOJ (Date)
 City (String)

 2. Create a Generic List Collection empList and populate it with the following records.
 EmployeeID FirstName    LastName Title       DOB DOJ         City
 1001        Malcolm Daruwalla   Manager     16/11/1984     8/6/2011     Mumbai
 1002         Asdin Dhalla     AsstManager     20/08/1984     7/7/2012     Mumbai
 1003         Madhavi Oza         Consultant  14/11/1987     12/4/2015     Pune
 1004         Saba Shaikh       SE         3/6/1990     2/2/2016     Pune
 1005         Nazia Shaikh      SE      8/3/1991     2/2/2016     Mumbai
 1006         Amit Pathak      Consultant  7/11/1989     8/8/2014     Chennai
 1007         Vijay Natrajan    Consultant  2/12/1989     1/6/2015     Mumbai
 1008         Rahul Dubey       Associate    11/11/1993     6/11/2014     Chennai
 1009         Suresh Mistry       Associate  12/8/1992     3/12/2014     Chennai
 1010         Sumit Shah        Manager     12/4/1991     2/1/2016     Pune
*/

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
        public void Display()
        {
            Console.WriteLine($"ID: {EmployeeID}, FirstName: {FirstName}, LastName: {LastName}, Title: {Title}, DOB: {DOB}, DOJ: {DOJ}, City: {City}");
        }
    }

    class Program
    {
        static void Main()
        {
            List<Employee> empList = new List<Employee> { 
            new Employee{ EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("16/11/1984"), DOJ = DateTime.Parse("8/6/2011"), City = "Mumbai" },
            new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("20/08/1984"), DOJ = DateTime.Parse("7/7/2012"), City = "Mumbai" },
            new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("14/11/1987"), DOJ = DateTime.Parse("12/4/2015"), City = "Pune" },
            new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("3/6/1990"), DOJ = DateTime.Parse("2/2/2016"), City = "Pune" },
            new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("8/3/1991"), DOJ = DateTime.Parse("2/2/2016"), City = "Mumbai" },
            new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.Parse("7/11/1989"), DOJ = DateTime.Parse("8/8/2014"), City = "Chennai" },
            new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = DateTime.Parse("2/12/1989"), DOJ = DateTime.Parse("1/6/2015"), City = "Mumbai" },
            new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = DateTime.Parse("11/11/1993"), DOJ = DateTime.Parse("6/11/2014"), City = "Chennai" },
            new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = DateTime.Parse("12/8/1992"), DOJ = DateTime.Parse("3/12/2014"), City = "Chennai" },
            new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = DateTime.Parse("12/4/1991"), DOJ = DateTime.Parse("2/1/2016"), City = "Pune" }
        };

            // 1. Display joined before 1/1/2015

            Console.WriteLine("1. Employees who have joined before 1/1/2015:");
            foreach (var emp in empList.Where(e => e.DOJ < new DateTime(2015, 1, 1)))
                emp.Display();
            Console.WriteLine();

            // 2. Display a list of all the employee whose date of birth is after 1/1/1990

            Console.WriteLine("2. Employees born after 1/1/1990:");
            foreach (var emp in empList.Where(e => e.DOB > new DateTime(1990, 1, 1)))
                emp.Display();
            Console.WriteLine();

            // 3. Display a list of all the employee whose designation is Consultant and Associate

            Console.WriteLine("3. Employees who are Consultant or Associate:");
            foreach (var emp in empList.Where(e => e.Title == "Consultant" || e.Title == "Associate"))
                emp.Display();
            Console.WriteLine();

            // 4. Display total number of employees

            Console.WriteLine($"4. Total number of employees: {empList.Count}");
            Console.WriteLine();

            // 5. Display total number of employees belonging to “Chennai”

            Console.WriteLine($"5. Total number of employees in Chennai: {empList.Count(e => e.City == "Chennai")}");
            Console.WriteLine();

            // 6. Display highest employee id from the list

            Console.WriteLine($"6. Max Employee ID: {empList.Max(e => e.EmployeeID)}");
            Console.WriteLine();

            // 7. Display total number of employee who have joined after 1/1/2015

            Console.WriteLine($"7. Employees who joined after 1/1/2015: {empList.Count(e => e.DOJ > new DateTime(2015, 1, 1))}");
            Console.WriteLine();

            // 8. Display total number of employee whose designation is not “Associate”

            Console.WriteLine($"8. Employees whose designation is not Associate: {empList.Count(e => e.Title != "Associate")}");
            Console.WriteLine();

            // 9. Display total number of employee based on City

            var totalCity = empList
                .GroupBy(emp => emp.City)
                .Select(g => new { city = g.Key, Count = g.Count() });

            Console.WriteLine("9. Total number of employees based on City:");
            foreach (var x in totalCity)
            {
                Console.WriteLine($"The city is {x.city} and the count is {x.Count}");
            }
            Console.WriteLine();

            // 10. Display total number of employee based on city and title

            var TotalEmp = empList
                .GroupBy(emp => new { emp.City, emp.Title })
                .Select(g => new { city = g.Key.City, title = g.Key.Title, Count = g.Count() });

            Console.WriteLine("10. Total number of employees based on City and Title:");
            foreach (var x in TotalEmp)
            {
                Console.WriteLine($"The city is {x.city}, the title is {x.title}, the count is {x.Count}");
            }
            Console.WriteLine();

            // 11. Display total number of employee who is youngest in the list

            var Youngest = empList.Max(emp => emp.DOB);
            var Youngemp = empList.FindAll(emp => emp.DOB == Youngest);

            Console.WriteLine("11.The Youngest Employee is:");
            foreach (var emp in Youngemp)
            {
                emp.Display();
            }


            Console.Read();
        }
    }
}
