using System;
using System.Collections.Generic;

namespace _5._Students_2._0
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> listOfStudents = new List<Student>();
            string[] input = Console.ReadLine().Split();
            while (input[0].ToLower() != "end")
            {
                Student currStudent = new Student();
                bool isStudentExisting = false;
                int indexOfExistingStudent = -1;
                for (int i = 0; i < listOfStudents.Count; i++)
                {
                    if (listOfStudents[i].FirstName == input[0] && listOfStudents[i].LastName == input[1])
                    {
                        isStudentExisting = true;
                        indexOfExistingStudent = i;
                    }
                }
                if (isStudentExisting)
                {
                    listOfStudents[indexOfExistingStudent].FirstName= input[0];
                    listOfStudents[indexOfExistingStudent].LastName = input[1];
                    listOfStudents[indexOfExistingStudent].Age = int.Parse(input[2]);
                    listOfStudents[indexOfExistingStudent].HomeTown = input[3];
                }
                else
                {
                currStudent.FirstName = input[0];
                currStudent.LastName = input[1];
                currStudent.Age = int.Parse(input[2]);
                currStudent.HomeTown = input[3];
                listOfStudents.Add(currStudent);
                }
                input = Console.ReadLine().Split();
            }
            string printByTown = Console.ReadLine();
            foreach (var item in listOfStudents)
            {
                if (item.HomeTown == printByTown)
                {
                    Console.WriteLine($"{item.FirstName} { item.LastName} is { item.Age } years old.");
                }
            }
        }
    }
}
