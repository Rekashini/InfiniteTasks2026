using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Program3
    {
        public static void PerformOperations()
        {
           
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine(num1 + " + " + num2 + " = " + (num1 + num2));
            Console.WriteLine(num1 + " - " + num2 + " = " + (num1 - num2));
            Console.WriteLine(num1 + " * " + num2 + " = " + (num1 * num2));

            if (num2 != 0)
            {
                Console.WriteLine(num1 + " / " + num2 + " = " + (num1 / num2));
            }
            else
            {
                Console.WriteLine("Denominator is Zero");
            }
        }
    }
}
