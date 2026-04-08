using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge2
{
    abstract class Student
    {
        public string name;
        public int studentId;
        public double grade;
        public Student(string name, int studentId, double grade)
        {
            this.name = name;
            this.studentId = studentId;
            this.grade = grade;
        }
        public abstract bool IsPassed(double grade);
    }
    class Undergraduate : Student
    {
        public Undergraduate(string name, int studentId, double grade)
            : base(name, studentId, grade)
        {
        }
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }
    class Graduate : Student
    {
        public Graduate(string name, int studentId, double grade)
            : base(name, studentId, grade)
        {

        }
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }
}
