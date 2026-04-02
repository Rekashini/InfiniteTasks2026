using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge1
{
    internal class Employee
    {
        static List<Employee> employees = new List<Employee>();
        public int Id { get; set; }
        public string Name { get;set;}
        public string Department { get; set; }
        public double Salary { get; set; }

        public static void AddEmployee()
        {
            Employee emp = new Employee();

            Console.Write("Enter ID: ");
            emp.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name: ");
            emp.Name = Console.ReadLine();
            Console.Write("Enter Department: ");
            emp.Department = Console.ReadLine();
            Console.Write("Enter Salary: ");
            emp.Salary = Convert.ToDouble(Console.ReadLine());
            employees.Add(emp);
            Console.Write("Employee added successfully");
        }

        public static void ViewEmployee()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
            }

            Console.WriteLine("\n--- Employee List ---");
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Dept: {emp.Department}, Salary: {emp.Salary}");
            }
        }
        public static void SearchEmployee()
        {
            Console.Write("Enter ID to search: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool found = false;

            foreach (Employee e in employees)
            {
                if (e.Id == id)
                {
                    Console.WriteLine("Found: " + e.Name);
                    found = true;
                    break;
                }
            }

            if (!found)
                Console.WriteLine("Employee not found.");
        }
        public static void UpdateEmployee()
        {
            Console.Write("Enter ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Employee e in employees)
            {
                if (e.Id == id)
                {
                    Console.Write("New Name: ");
                    e.Name = Console.ReadLine();

                    Console.Write("New Department: ");
                    e.Department = Console.ReadLine();

                    Console.Write("New Salary: ");
                    e.Salary = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Employee updated!");
                    return;
                }
            }

            Console.WriteLine("Employee not found.");
        }

        public static void DeleteEmployee()
        {
            Console.Write("Enter ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    employees.RemoveAt(i);
                    Console.WriteLine("Employee deleted!");
                    return;
                }
            }

            Console.WriteLine("Employee not found.");
        }

    }

}
