using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CodeChallenge_6
{
    class DataAccesss
    {
        static SqlConnection con = null;
        static SqlCommand cmd = null;

        public SqlConnection getConnection()
        {
            string connect = "Data Source=ICS-LT-4FFZC64\\SQLEXPRESS;Initial Catalog=CodeChallengeDB;" +
                             "User ID=sa;Password=Mehrunshamshi@77;";
            con = new SqlConnection(connect);
            return con;
        }

        public double UpdateSalary(int empId)
        {
            double updatedSalary = 0;

            try
            {
                con = getConnection();
                cmd = new SqlCommand("UpdateEmployeeSalary", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", empId);
                cmd.Parameters.Add("@UpdatedSalary", SqlDbType.Decimal).Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();

                updatedSalary = Convert.ToDouble(cmd.Parameters["@UpdatedSalary"].Value);
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQL Error: " + e.Message);
            }
            finally
            {
                con.Close();
            }

            return updatedSalary;
        }

        public void DisplayEmployeeDetails(int empId)
        {
            try
            {
                con = getConnection();
                cmd = new SqlCommand("SELECT EmpId, Name, Gender, Salary FROM Employee_Details WHERE EmpId = @EmpId", con);
                cmd.Parameters.AddWithValue("@EmpId", empId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine("Employee Details After Update:");
                    Console.WriteLine($"EmpId: {reader["EmpId"]}");
                    Console.WriteLine($"Name: {reader["Name"]}");
                    Console.WriteLine($"Gender: {reader["Gender"]}");
                    Console.WriteLine($"Salary: {reader["Salary"]}");
                }
                else
                {
                    Console.WriteLine("No employee found with the given EmpId.");
                }

                reader.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQL Error: " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }

    class UpdateProc
    {
        static void Main()
        {
            DataAccesss da = new DataAccesss();

            Console.WriteLine("Enter EmpId to update salary:");
            int empId = Convert.ToInt32(Console.ReadLine());

            double newSalary = da.UpdateSalary(empId);
            if (newSalary > 0)
            {
                Console.WriteLine($"Salary updated successfully. New Salary: {newSalary}");
            }
            else
            {
                Console.WriteLine("Failed to update salary or employee not found.");
            }
            da.DisplayEmployeeDetails(empId);

            Console.ReadLine();
        }
    }
}
