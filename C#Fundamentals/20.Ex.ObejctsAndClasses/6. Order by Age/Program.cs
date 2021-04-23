using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Order_by_Age
{
    public class Person
    {
        public Person(string name,string id,int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<Person> persons = new List<Person>();
            while (input[0].ToLower() != "end")
            {
                Person currPerson = new Person(input[0],input[1],int.Parse(input[2]));
                persons.Add(currPerson);
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            persons = persons.OrderBy(x => x.Age).ToList();
            foreach (Person x in persons)
            {
                Console.WriteLine($"{x.Name} with ID: {x.Id} is {x.Age} years old.");
            }
        }
    }
}
