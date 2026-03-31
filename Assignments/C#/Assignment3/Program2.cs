using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Student
    {
        int rollno, semester;
        string name, branch;
        char Class;
        int[] marks = new int[5];

        internal Student(string name,int rollno,char Class,string branch,int semester)
        {
            this.rollno = rollno;
            this.semester = semester;
            this.name = name;
            this.branch = branch;
            this.Class = Class;
        }

        public void GetMarks()
        {
            Console.WriteLine("\nEnter 5 marks: ");
            for (int i = 0; i < marks.Length; i++)
            {
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void DisplayResult()
        {
            int sum = 0;
            bool res=true;
        
            foreach (int  i in marks)
            {
                sum += i;
                if (i < 35)
                {
                    res= false;
                }

            }
            int avg = sum / 5;
            Console.WriteLine("\nAverage Mark: " + avg);

            Console.Write("Result: ");
            if (!res)
            {
                Console.WriteLine("Failed");
            }
            else if(!res || avg < 50)
            {
                Console.WriteLine("Failed");
            }
            else
            {
                Console.WriteLine("Passed");
            }

        }

        public void DisplayData()
        {
            Console.WriteLine("Name: "+name);
            Console.WriteLine("RollNo: "+rollno);
            Console.WriteLine("Branch: " + branch);
            Console.WriteLine("Class: " + Class);
            Console.WriteLine("Semester: "+semester);
        }
    }
}
