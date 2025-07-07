using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    /*
 * 
3.	Create a list of employees with following property EmpId, EmpName, EmpCity, EmpSalary. Populate some data
Write a program for following requirement
a.	To display all employees data
b.	To display all employees data whose salary is greater than 45000
c.	To display all employees data who belong to Bangalore Region
d.	To display all employees data by their names is Ascending order
 */
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }

        public Employee(int empid, string empname, string empcity, double empsalary)
        {
            EmpId = empid;
            EmpName = empname;
            EmpCity = empcity;
            EmpSalary = empsalary;
        }
        class Question3
        {
            public static void Main()
            {
                List<Employee> employees = new List<Employee>();
                Console.Write("Enter number of employees: ");
                int n = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    Console.Write("Enter ID of employee-{0}: ", i + 1);
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Name of employee-{0}: ", i + 1);
                    string name = Console.ReadLine();
                    Console.Write("Enter City of employee-{0}: ", i + 1);
                    string city = Console.ReadLine();
                    Console.Write("Enter Salary of employee-{0}:", i + 1);
                    double salary = Convert.ToDouble(Console.ReadLine());
                    Employee e = new Employee(id, name, city, salary);
                    employees.Add(e);
                }

                Console.WriteLine("************************All Employee Details************************");
                foreach (var emp in employees)
                {
                    Console.WriteLine($"Id:{emp.EmpId}, Name:{emp.EmpName}, City:{emp.EmpCity}, Salary:{emp.EmpSalary}");
                }

                Console.WriteLine("************************Employees with salary greater than 45000************************");
                var SalAbove45k = employees.Where(emp => emp.EmpSalary > 45000);
                foreach (var emp in SalAbove45k)
                {
                    Console.WriteLine($"Id:{emp.EmpId}, Name:{emp.EmpName}, City:{emp.EmpCity}, Salary:{emp.EmpSalary}");
                }

                Console.WriteLine("************************Employees from Bangalore************************");
                var BangaloreEmployees = employees.Where(emp => emp.EmpCity == "Bangalore");
                foreach (var emp in BangaloreEmployees)
                {
                    Console.WriteLine($"Id:{emp.EmpId}, Name:{emp.EmpName}, City:{emp.EmpCity}, Salary:{emp.EmpSalary}");
                }

                Console.WriteLine("************************Employees sorted by name in ascending order************************");
                var SortedEmployees = employees.OrderBy(emp => emp.EmpName);
                foreach (var emp in SortedEmployees)
                {
                    Console.WriteLine($"Id:{emp.EmpId}, Name:{emp.EmpName}, City:{emp.EmpCity}, Salary:{emp.EmpSalary}");
                }

                Console.Read();
            }
        }
    }
}
