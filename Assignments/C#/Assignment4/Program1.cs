using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Program1
    {
        public static void RemoveChar(string str,int position)
        {
           
            if (position < 0 || position >= str.Length)
            {
                Console.WriteLine("Invalid Position");
                return;
            }

            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i != position)
                {
                    result += str[i];
                }
            }
            Console.WriteLine(result);

        }
    }
}
