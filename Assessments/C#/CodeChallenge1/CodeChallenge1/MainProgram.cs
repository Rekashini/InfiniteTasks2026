using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1
{
    internal class MainProgram
    {

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("\n===== Employee Management Menu =====");
                Console.WriteLine("1.Add New Employee");
                Console.WriteLine("2.View All Employees");
                Console.WriteLine("3.Search Employee by ID");
                Console.WriteLine("4.Update Employee Details");
                Console.WriteLine("5.Delete Employee");
                Console.WriteLine("6.Exit");
                Console.WriteLine("=======================================");

                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Employee.AddEmployee();
                        break;
                    case 2:
                        Employee.ViewEmployee();
                        break;
                    case 3:
                        Employee.SearchEmployee();
                        break;
                    case 4:
                        Employee.UpdateEmployee();
                        break;
                    case 5:
                        Employee.DeleteEmployee();
                        break;
                    case 6:
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            } while (choice != 6);





            Console.WriteLine();
            Console.WriteLine("\n=====Challenge====2");
            Console.WriteLine();
            Employeees[] employees = new Employeees[2];

            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine($"Enter details for Employee {i + 1}:");

                Console.Write("Name of the employee: ");
                employees[i].Name = Console.ReadLine();

                Employeees.BirthDate dob = new Employeees.BirthDate();

                Console.Write("Input day of the birth: ");
                dob.Day = int.Parse(Console.ReadLine());

                Console.Write("Input month of the birth: ");
                dob.Month = int.Parse(Console.ReadLine());

                Console.Write("Input year of the birth: ");
                dob.Year = int.Parse(Console.ReadLine());

                employees[i].DOB = dob;
                Console.WriteLine();
            }

            Console.WriteLine("Employee Details:");
            Console.WriteLine("-----------------");

            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine($"Name: {employees[i].Name}");
                Console.WriteLine($"Date of Birth: {employees[i].DOB.Day:D2}/{employees[i].DOB.Month:D2}/{employees[i].DOB.Year:D2}");
                Console.WriteLine();
            }

        }

    }

}
