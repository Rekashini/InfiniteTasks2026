using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*************Program1*************");
            AccountDetails obj = new AccountDetails(101, "Arun", "Savings", 1000);

            Console.WriteLine("\n**** Account Details ****");
            obj.showdata();
            Console.WriteLine();

            Console.Write("Enter amount: ");
            float amount = Convert.ToSingle(Console.ReadLine());

            Console.Write("Enter Transaction Type : ");
            char Transaction_Type = Convert.ToChar(Console.ReadLine());

            obj.UpdateBalance(Transaction_Type, amount);

            Console.WriteLine("\n*** Updated Account Details ***");
            obj.showdata();
            Console.WriteLine();




            Console.WriteLine("*************Program2*************");

            Student data=new Student("Rika",123,'A',"ECE",5);
            Console.WriteLine("\n**** Student Details ****");
            data.DisplayData();
            data.GetMarks();
            data.DisplayResult();
            Console.WriteLine();




            Console.WriteLine("*************Program3*************");
            SaleDetails obj2 = new SaleDetails(11,2345,2,765.9,DateTime.Now);
            Console.WriteLine("\n** Sales Details **");
            SaleDetails.Showdata(obj2);
            obj2.sales();


        }
    }

    
}