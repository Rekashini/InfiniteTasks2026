using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeChallenge3
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==============Program2===============");
            string filePath = "sample.txt";

            Console.Write("Enter text to append: ");
            string text = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(text);
            }

            if (File.Exists(filePath))
                Console.WriteLine("Text appended successfully!");
            else
                Console.WriteLine("File created and text written!");
        }
    }
}
