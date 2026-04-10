using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class Program1
    {
        static void Main()
        {
            int[] numbers = { 7, 2, 30 };

            var result = numbers
                .Where(n => n * n > 20)
                .Select(n => $"{n} - {n * n}");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
