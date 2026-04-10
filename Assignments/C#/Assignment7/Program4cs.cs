using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelConcessionLib;


namespace Assignment7
{
    class Program4
    {
        const decimal TotalFare = 500;

        static void Main()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            ConcessionCalculator calculator = new ConcessionCalculator();
            string result = calculator.CalculateConcession(age, TotalFare);

            Console.WriteLine($"\nPassenger Name: {name}");
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

}
