using System;
using System.Data;
using System.Data.SqlClient;

namespace CodeChallenge7
{
    internal class Program2
    {
        static void Main()
        {
            string connStr = "Data Source=ICS-LT-DPCQLB4\\SQLEXPRESS;Initial Catalog=Employeemanagement;Integrated Security=True";

            Console.Write("Enter Employee ID to update: ");
            int empId = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("updateemployeesal", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@empid", empId);

                SqlParameter outputParam = new SqlParameter("@updatedsalary", SqlDbType.Decimal);
                outputParam.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(outputParam);

                con.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("Updated Salary: " + cmd.Parameters["@updatedsalary"].Value);

                SqlCommand display = new SqlCommand(
                    "SELECT * FROM Employee_Details WHERE Empno = @empid", con);

                display.Parameters.AddWithValue("@empid", empId);

                SqlDataReader reader = display.ExecuteReader();

                Console.WriteLine("\nUpdated Employee Record:");
                while (reader.Read())
                {
                    Console.WriteLine(reader["Empno"] + " " +
                                      reader["EmpName"] + " " +
                                      reader["Empsal"] + " " +
                                      reader["Emptype"]);
                }

                reader.Close();
            }
        }
    }
}