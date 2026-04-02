using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Program2
    {
        public static void SwapChar(string str)
        {
            int n = str.Length;
            char[] res = new char[n];
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    res[i] = str[n - 1];
                }
                else if (i == n - 1)
                {
                    res[i] = str[0];
                }
                else
                {
                    res[i] = str[i];
                }
            }

            string result = new string(res);
            Console.WriteLine(result);
        }
    }
}
