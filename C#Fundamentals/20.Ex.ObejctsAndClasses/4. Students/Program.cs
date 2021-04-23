using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Students
{
    public class Student
    {
        public Student(string fName,string sName, double grade)
        {
            this.FirstName = fName;
            this.SecondName = sName;
            this.Grade = grade;
        }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }


    }
    class Program
    {
        static void Main(string[] args)
        {
            int numStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>(numStudents);
            for (int i = 0; i < numStudents; i++)
            {
                string[] input = Console.ReadLine().Split();
                Student currStudent = new Student(input[0], input[1],double.Parse(input[2]));
                students.Add(currStudent);
            }
            students = students.OrderBy(x => x.Grade).Reverse().ToList();
            foreach (Student x in students)
            {
                Console.WriteLine($"{x.FirstName} {x.SecondName}: {x.Grade:F2}");
            }
        }
    }
}
