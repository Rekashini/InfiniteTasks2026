using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Program5
    {
        public static void CopyArray()
        {
            Console.WriteLine("\n*******************Array Program3*****************");
            int[] arr = { 1, 2, 3, 4, 5 };
            int[] copy= new int[arr.Length];

            Console.Write("Copied Array: ");
            for (int i = 0; i < arr.Length; i++)
            {
                copy[i] = arr[i];
                Console.Write(" " + copy[i]);
            }
        }
    }
}
