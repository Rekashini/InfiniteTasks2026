using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Program4
    {
        public static void Marks()
        {
            Console.WriteLine("*******************Array Program2*****************");
            int[] arr = new int[10];
            int total = 0;
            Console.WriteLine("Enter Marks: ");
            for (int i = 0; i < arr.Length; i++)
            {

                arr[i] = Convert.ToInt32(Console.ReadLine());
                total = total + arr[i];

            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Total Marks: " + total);
            Console.WriteLine("Average: "+(total/10));
            Console.WriteLine("Maximum Marks: " + arr.Max());
            Console.WriteLine("Minimum Marks: " + arr.Min());

            Console.Write("Array in Ascending order:");
            foreach(int i in arr)
            {
                Console.Write(" "+i);
            }

            Console.Write("\nArray in Descending order:");
            for(int i = arr.Length-1; i>=0; i--)
            {
                Console.Write(" "+arr[i]);
            }
        }
    }
}
