using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge2
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public void GetData()
        {
            Console.Write("Enter Product ID: ");
            ProductId = int.Parse(Console.ReadLine());

            Console.Write("Enter Product Name: ");
            ProductName = Console.ReadLine();

            Console.Write("Enter Price: ");
            Price = double.Parse(Console.ReadLine());
        }

        public void Display()
        {
            Console.WriteLine(ProductId + "  " + ProductName + "  " + Price);
        }
    }

}
