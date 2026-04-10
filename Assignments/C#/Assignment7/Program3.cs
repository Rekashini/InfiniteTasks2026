using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public decimal EmpSalary { get; set; }
    }

    class Program3
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>
        {
            new Employee { EmpId = 1, EmpName = "Arun",   EmpCity = "Bangalore", EmpSalary = 50000 },
            new Employee { EmpId = 2, EmpName = "Meena",  EmpCity = "Chennai",   EmpSalary = 42000 },
            new Employee { EmpId = 3, EmpName = "Karthik",EmpCity = "Bangalore", EmpSalary = 60000 },
            new Employee { EmpId = 4, EmpName = "Priya",  EmpCity = "Hyderabad", EmpSalary = 48000 },
            new Employee { EmpId = 5, EmpName = "Suresh", EmpCity = "Bangalore", EmpSalary = 40000 }
        };

            Console.WriteLine("All Employees:");
            DisplayEmployees(employees);

            Console.WriteLine("\nEmployees with Salary > 45000:");
            var highSalary = employees.Where(e => e.EmpSalary > 45000);
            DisplayEmployees(highSalary);

            Console.WriteLine("\nEmployees from Bangalore:");
            var bangaloreEmployees = employees.Where(e => e.EmpCity == "Bangalore");
            DisplayEmployees(bangaloreEmployees);

            Console.WriteLine("\nEmployees Sorted by Name (Ascending):");
            var sortedByName = employees.OrderBy(e => e.EmpName);
            DisplayEmployees(sortedByName);
        }

        static void DisplayEmployees(IEnumerable<Employee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
            }
        }
    }
}
