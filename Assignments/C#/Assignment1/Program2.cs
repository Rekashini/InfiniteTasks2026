using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Program2
    {
        public static void Positive_or_Negative()
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine( (num > 0) ? $"{num} is a positive number" : (num < 0) ? $"{num} is a negative number" : "The number is zero");
        }
    }
}
