using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge7
{
    internal class Program
    {
        public static SqlConnection conn = null;
        public static SqlCommand cmd = null;
        public static SqlDataReader dataReader = null;

        static void Main(string[] args)
        {
            InsertEmployee();
            DisplayEmployees();
            Console.Read();
        }

        static SqlConnection getConnection()
        {
            conn = new SqlConnection(
                "Data Source=ICS-LT-DPCQLB4\\SQLEXPRESS;" +
                "Initial Catalog=Employeemanagement;" +
                "Integrated Security=true");

            conn.Open();

            return conn;
        }

        //insert using stored procedure

        static void InsertEmployee()
        {
            try
            {
                conn = getConnection();

                Console.WriteLine("Enter Employee Name :");
                string ename = Console.ReadLine();

                Console.WriteLine("Enter Employee Salary :");
                decimal esal = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Enter Employee Type (F/P) :");
                string etype = Console.ReadLine();

                cmd = new SqlCommand("Insert_EmployeeDetails", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpName", ename);
                cmd.Parameters.AddWithValue("@Empsal", esal);
                cmd.Parameters.AddWithValue("@Emptype", etype);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine("Employee Inserted Successfully...");
                }
                else
                {
                    Console.WriteLine("Could not insert record...");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //display all employees

        static void DisplayEmployees()
        {
            try
            {
                conn = getConnection();

                cmd = new SqlCommand("select * from Employee_Details", conn);

                dataReader = cmd.ExecuteReader();

                Console.WriteLine("----------------------------");
                Console.WriteLine("Employee Details");
                Console.WriteLine("-------------------------");

                while (dataReader.Read())
                {
                    Console.WriteLine(
                        dataReader["Empno"] + " " +
                        dataReader["EmpName"] + " " +
                        dataReader["Empsal"] + " " +
                        dataReader["Emptype"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
