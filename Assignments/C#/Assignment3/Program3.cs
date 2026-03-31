using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class SaleDetails
    {
        int Salesno, Productno, Qty;
        double Price,TotalAmount;
        DateTime dateofsale;

        internal SaleDetails(int Salesno,int Productno,int Qty,double Price,DateTime dateofsale)
        {
            this.Salesno = Salesno;
            this.Productno = Productno;
            this.Qty = Qty;
            this.Price = Price;
            this.dateofsale = dateofsale;

        }
        public void sales()
        {
            TotalAmount=Qty*Price;
            Console.WriteLine("Total Amount: " + TotalAmount);
        }

        public static void Showdata(SaleDetails s)
        {
            Console.WriteLine("Sales Number: " + s.Salesno);
            Console.WriteLine("Product Number: " +s.Productno);
            Console.WriteLine("Quantity: " + s.Qty);
            Console.WriteLine("Price: " + s.Price);
            Console.WriteLine("Date Of Sale: " +s.dateofsale);
        }


    }
}
