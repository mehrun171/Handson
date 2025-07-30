using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CodeChallenge_6
{
    class DataAccess
    {
        static SqlConnection con = null;
        static SqlCommand cmd = null;

        public SqlConnection getConnection()
        {
            string connect = "Data Source=ICS-LT-4FFZC64\\SQLEXPRESS;Initial Catalog=CodeChallengeDB;" +
                             "User ID=sa;Password=Mehrunshamshi@77;";
            con = new SqlConnection(connect);
            con.Open();
            return con;
        }

        public int InsertEmployeeData(string name, string gender, double salary)
        {
            int empId = 0;
            try
            {
                con = getConnection();
                cmd = new SqlCommand("InsertEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Salary", salary);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    empId = reader.GetInt32(0);
                }
                reader.Close(); 
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return empId;
        }

        
    }
    class Employee
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }

        DataAccess da = new DataAccess();

        public int InsertEmployee()
        {
            Console.WriteLine("Enter Name of the Employee:");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Gender of the Employee:");
            Gender = Console.ReadLine();
            Console.WriteLine("Enter Salary of the Employee:");
            Salary = Convert.ToDouble(Console.ReadLine());

            return da.InsertEmployeeData(Name, Gender, Salary);
        }
    }

    class InsertProc
    {
            public static void Main()
            {
                Employee emp = new Employee();
                int empId = emp.InsertEmployee();
                if (empId > 0)
                {
                    Console.WriteLine($"Employee added successfully with EmpId: {empId}");
                }
                else
                {
                    Console.WriteLine("Failed to add employee.");
                }
            Console.ReadLine();
            }
        }
}
