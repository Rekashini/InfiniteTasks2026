using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Program3
    {
        public static void PrintArray()
        {
            Console.WriteLine("*******************Array Program1*****************");
            int[] arr = { 1, 2, 3, 4, 5 };
            Console.WriteLine("The Elements of array are: ");
            foreach (int i in arr) Console.WriteLine(i);
            int sum = 0;
            int min = arr[0];
            int max = arr[0];
            
            foreach (int i in arr)
            {
                sum=sum+i;

                if (i < min)
                {
                    min = i;
                }
                if (i > max)
                {
                    max = i;
                }

            }
            Console.WriteLine("Average: " +(sum / arr.Length));
            Console.WriteLine("Minimum value: " +min);
            Console.WriteLine("Maximum value: " +max);

        }
    }
}
