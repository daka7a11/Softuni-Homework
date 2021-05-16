using System;
using System.Collections.Generic;

namespace _5._Filter_by_Age
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] persons = new Person[n];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);
                persons[i] = new Person { Name = name, Age = age };
            }
            string condition = Console.ReadLine();
            int ageToFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func<Person, bool> funcCondition = GetCondition(condition, ageToFilter);
            Action<Person> print = Printer(format);

            foreach (var person in persons)
            {
                if (funcCondition(person))
                {
                    print(person);
                }
            }

        }
        static Action<Person> Printer(string format)
            {
            switch (format)
            {
                case "name":
                    return p => Console.WriteLine(p.Name);
                case "age":
                    return p => Console.WriteLine(p.Age);
                case "name age":
                    return p => Console.WriteLine($"{p.Name} - {p.Age}");
                default: return null;
            }
        }
        static Func<Person , bool> GetCondition(string condition,int age)
        {
            switch (condition)
            {
                case "younger": return p => p.Age < age;
                case "older": return p => p.Age >= age;
                default: return null;
            }
        }
    }
}
