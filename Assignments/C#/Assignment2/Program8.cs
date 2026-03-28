using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Program8
    {
        public static void StringCompare()
        {
            Console.WriteLine("\n***********************String Program3**********************");
            string str1,str2;
            Console.WriteLine("Enter first word: ");
            str1 = Console.ReadLine();
            Console.WriteLine("Enter second word: ");
            str2 = Console.ReadLine();
            if (str1.Equals(str2))
                Console.WriteLine("Words are same");
            else
                Console.WriteLine("Words are not same");

        }
    }
}
