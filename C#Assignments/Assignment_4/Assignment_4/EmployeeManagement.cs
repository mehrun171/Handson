using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    /* Scenario: Employee Management System(Console-Based)

 -----------------------------------------------------

 You are tasked with developing a simple console-based Employee Management System using C# that allows users to manage a list of employees. Use a menu-driven approach to perform CRUD operations on a List<Employee>.

 Each Employee has the following properties:

 int Id


 string Name


 string Department


 double Salary

 Functional Requirements

 Design a menu that repeatedly prompts the user to choose one of the following actions:


 ===== Employee Management Menu =====

 1. Add New Employee

 2. View All Employees

 3. Search Employee by ID

 4. Update Employee Details

 5. Delete Employee

 6. Exit

 ====================================

 Enter your choice:

 Task:

 Write a C# program using:

 A class Employee with the above properties.

 A List<Employee> to hold all employee records.

 A menu-based loop to allow the user to perform the following:

 ✅ Expected Functionalities (CRUD)

 1.Prompt the user to enter details for a new employee and add it to the list.


 2.Display all employees

 3.Allow searching an employee by Id and display their details.

 4.Search for an employee by Id, and if found, allow the user to update name, department, or salary.

 5.Search for an employee by Id and remove the employee from the list.

 6.Cleanly exit the program.

 Use Exception handling Mechanism
  */
    class EmployeeManagement
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Department { set; get; }
        public double Salary { set; get; }
    }

    class Run
    {
        static List<EmployeeManagement> employeemanagement = new List<EmployeeManagement>();
        public static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("");
                Console.WriteLine("********** Employee Management Menu **********");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.WriteLine("");
                Console.WriteLine("Enter your choice : ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddEmployee();
                            break;
                        case 2:
                            ViewAllEmployees();
                            break;
                        case 3:
                            SearchByID();
                            break;
                        case 4:
                            UpdateDetails();
                            break;
                        case 5:
                            DelEmployee();
                            break;
                        case 6:
                            exit = true;
                            Console.WriteLine("Exiting the program");
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid INput");
                }
            }
        }
        static void AddEmployee()
        {
            Console.WriteLine("Enter Employee details in the order EmployeeID,Name,Department,Salary");
            int id = Convert.ToInt32(Console.ReadLine());
            string name = Convert.ToString(Console.ReadLine());
            string dept = Convert.ToString(Console.ReadLine());
            int salary = Convert.ToInt32(Console.ReadLine());
            employeemanagement.Add(new EmployeeManagement { Id = id, Name = name, Department = dept, Salary = salary });
        }

        public static void ViewAllEmployees()
        {
            if (employeemanagement.Count == 0)
            {
                Console.WriteLine("No employees to display.");
                return;
            }
            Console.WriteLine("***** Employee List *****");
            foreach (var emp in employeemanagement)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
            }
        }

        public static void SearchByID()
        {
            Console.Write("Enter Employee ID to search: ");

            int id = Convert.ToInt32(Console.ReadLine());
            var emp = employeemanagement.Find(e => e.Id == id);

            if (emp != null)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }

        }

        public static void UpdateDetails()
        {
            Console.Write("Enter Employee ID to update: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                var emp = employeemanagement.Find(e => e.Id == id);

                if (emp != null)
                {
                    Console.Write("Enter new Name (leave blank to keep current): ");
                    string name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name)) emp.Name = name;

                    Console.Write("Enter new Department (leave blank to keep current): ");
                    string department = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(department)) emp.Department = department;

                    Console.Write("Enter new Salary (leave blank to keep current): ");
                    string salaryInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(salaryInput))
                    {
                        if (double.TryParse(salaryInput, out double salary))
                        {
                            emp.Salary = salary;
                        }
                        else
                        {
                            Console.WriteLine("Invalid salary input. Salary not updated.");
                        }
                    }

                    Console.WriteLine("Employee details updated successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format.");
            }
        }

        public static void DelEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
           
                int id = int.Parse(Console.ReadLine());
                var emp = employeemanagement.Find(e => e.Id == id);

                if (emp != null)
                {
                    employeemanagement.Remove(emp);
                    Console.WriteLine("Employee deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            
        }
    }
}