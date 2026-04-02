using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Program3
    {
        public static void SortElements()
        {
            Stack<int> stack = new Stack<int>();

            Console.WriteLine("Enter number of elements: ");
            int n=int.Parse(Console.ReadLine());

            Console.WriteLine("Enter elements: ");
            for(int i = 0; i < n; i++)
            {
                int value=int.Parse(Console.ReadLine());
                stack.Push(value);
            }

            List<int> list = new List<int>(stack);
            list.Sort();
            list.Reverse();
            stack.Clear();
            foreach (int item in list)
            {
                stack.Push(item);
            }

            Console.WriteLine("Stack elements in descending order:");
            foreach (int item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
