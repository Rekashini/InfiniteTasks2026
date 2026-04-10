using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
   
    class Program2
    {
        static void Main()
        {
            string[] words = { "mum", "amsterdam", "bloom" };

            var result = words
                .Where(w => w.StartsWith("a", StringComparison.OrdinalIgnoreCase)
                         && w.EndsWith("m", StringComparison.OrdinalIgnoreCase));

            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }
    }
}
