using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======Program1======");
            try
            {
                BankAccount account = new BankAccount(1000);

                account.Deposit(500);
                account.Withdraw(200);
                account.Withdraw(2000); 

                Console.WriteLine("Current Balance: " + account.GetBalance());
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception: " + ex.Message);
            }
            Console.WriteLine();




            Console.WriteLine("======Program2======");
            Scholarship obj = new Scholarship();

            try
            {
                Console.Write("Enter Marks: ");
                int marks = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Fees: ");
                double fees = Convert.ToDouble(Console.ReadLine());

                double scholarshipAmount = obj.Merit(marks, fees);

                Console.WriteLine("Scholarship Amount: " + scholarshipAmount);
            }
            catch (InvalidMarksException ex)
            {
                Console.WriteLine("Custom Exception: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter valid input.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.WriteLine();



            Console.WriteLine("======Program3======");
            BookShelf shelf = new BookShelf();
            shelf[0] = new Books("Thirukkural", "Thiruvalluvar");
            shelf[1] = new Books("Wings of Fire", "A.P.J Abdul Kalam");
            shelf[2] = new Books("Harry Potter", "J.K Rowling");
            shelf[3] = new Books("Cinderella", "Charles Perrault");
            shelf[4] = new Books("My Master", "Swami Vivekananda");

            Console.WriteLine("Books in Shelf:");
            shelf.DisplayAll();

        }
    }
}
