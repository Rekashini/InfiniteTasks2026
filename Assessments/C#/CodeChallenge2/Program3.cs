using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge2
{
    internal class Program3
    {
        public static void CheckNumber(int num)
        {
            if (num < 0)
            {
                throw new Exception("Number cannot be negative!");
            }
            else
            {
                Console.WriteLine("Number is valid: " + num);
            }
        }
    }
}
