using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=======Program1: Remove character=======");
            Program1.RemoveChar("python", 1);
            Program1.RemoveChar("python", 0);
            Program1.RemoveChar("python", 4);
            Console.WriteLine();


            Console.WriteLine("===Program2: Exchange 1st and last Character===");
            Program2.SwapChar("abcd");
            Program2.SwapChar("a");
            Program2.SwapChar("xy");
            Console.WriteLine();


            Console.WriteLine("=======Program3: Sort the elements=======");
            Program3.SortElements();



        }
    }
}
