using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=========Program1=========");
            BookShelf shelf = new BookShelf();
            shelf[0] = new Books("Thirukkural", "Thiruvalluvar");
            shelf[1] = new Books("Wings of Fire", "A.P.J Abdul Kalam");
            shelf[2] = new Books("Harry Potter", "J.K Rowling");
            shelf[3] = new Books("Cinderella", "Charles Perrault");
            shelf[4] = new Books("My Master", "Swami Vivekananda");

            Console.WriteLine("Books in Shelf:");
            shelf.DisplayAll();
            Console.WriteLine();






            Console.WriteLine("=========Program2=========");
            string filePath = "sample.txt";

            string[] linesToWrite =
            {
                "Hello",

                "Welcome to C#",

                "This is a sample program.",

                "Program is completed"
            };

            File.WriteAllLines(filePath, linesToWrite);
            Console.WriteLine("Data written to the file successfully.\n");

            string[] linesRead = File.ReadAllLines(filePath);
            Console.WriteLine("Contents of the file:");

            foreach (string i in linesRead)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();






            Console.WriteLine("=========Program3=========");
            Console.WriteLine("Enter file path:");
            string path = Console.ReadLine();

            int count = 0;
            foreach (string line in File.ReadLines(path))
            {
                count++;
            }
            Console.WriteLine("Number of lines: " + count);

        }
    }
}
