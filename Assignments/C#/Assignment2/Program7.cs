using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Program7
    {
        public static void StringReverse()
        {

            Console.WriteLine("\n***********************String Program2**********************");
            string str;
            Console.WriteLine("Enter a word: ");
            str = Console.ReadLine();
            Console.WriteLine("The String is: " + str);
            Console.Write("The Reversed String is: ");
            for (int i = str.Length - 1; i >= 0; i--)
            {
                Console.Write(str[i]);
            }
        }
    }
}
