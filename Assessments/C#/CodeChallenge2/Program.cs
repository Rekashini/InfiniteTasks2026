using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========Program1========");
            Undergraduate ug = new Undergraduate("Rika", 123, 75.5);
            Console.WriteLine("Undergraduate Student");
            Console.WriteLine("Name: " + ug.name);
            Console.WriteLine("ID: " + ug.studentId);
            Console.WriteLine("Grade: " + ug.grade);
            Console.WriteLine("Passed: " + ug.IsPassed(ug.grade));
            Console.WriteLine();

            Graduate grad = new Graduate("Vishnu Priya", 201, 78.0);
            Console.WriteLine("Graduate Student");
            Console.WriteLine("Name: " + grad.name);
            Console.WriteLine("ID: " + grad.studentId);
            Console.WriteLine("Grade: " + grad.grade);
            Console.WriteLine("Passed: " + grad.IsPassed(grad.grade));
            Console.WriteLine();




            Console.WriteLine("========Program2========");
            Product[] prod = new Product[10];

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("\nEnter details for Product " + (i + 1));
                prod[i] = new Product();
                prod[i].GetData();
            }

            for (int i = 0; i < prod.Length - 1; i++)
            {
                for (int j = i + 1; j < prod.Length; j++)
                {
                    if (prod[i].Price > prod[j].Price)
                    {
                        Product temp = prod[i];
                        prod[i] = prod[j];
                        prod[j] = temp;
                    }
                }
            }

            Console.WriteLine("\nSorted Products by Price:");
            foreach (Product p in prod)
            {
                p.Display();
            }
            Console.WriteLine();




            Console.WriteLine("========Program3========");
            try
            {
                Console.Write("Enter an integer: ");
                int number = int.Parse(Console.ReadLine());
                Program3.CheckNumber(number);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            Console.WriteLine();




            Console.WriteLine("========Program4========");
            Console.Write("Enter first number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.Write("Enter choice 1(+),2(-),3(*): ");
            int choice = int.Parse(Console.ReadLine());

            CalculatorOperations obj = new CalculatorOperations();
            Calculator calc = null;

            switch (choice)
            {
                case 1:
                    calc = obj.Add;
                    Console.WriteLine("Addition Result: " + calc(num1, num2));
                    break;

                case 2:
                    calc = obj.Subtract;
                    Console.WriteLine("Subtraction Result: " + calc(num1, num2));
                    break;

                case 3:
                    calc = obj.Multiply;
                    Console.WriteLine("Multiplication Result: " + calc(num1, num2));
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;


            }
        }
    }
}
