using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    internal class Scholarship
    {
        public double Merit(int marks, double fees)
        {
            if (marks >= 70 && marks <= 80)
            {
                return fees * 0.20;
            }
            else if (marks > 80 && marks <= 90)
            {
                return fees * 0.30;
            }
            else if (marks > 90)
            {
                return fees * 0.50;
            }
            else
            {
                throw new InvalidMarksException();
            }
        }
    }
    public class InvalidMarksException : Exception
    {
        public InvalidMarksException()
            : base("Marks are not eligible for scholarship.") { }

        public InvalidMarksException(string message)
            : base(message) { }
    }
}
