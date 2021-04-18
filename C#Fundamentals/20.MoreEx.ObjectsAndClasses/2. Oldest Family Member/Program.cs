using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Oldest_Family_Member
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class Family
    {
        public Family()
        {
            this.listOfPersons = new List<Person>();
        }
        public List<Person> listOfPersons { get; set; }
        public void AddMember(Person person)
        {
            this.listOfPersons.Add(person);
        }
        public Person GetOldestMember(List<Person> list)
        {
            return list.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person currPerson = new Person();
                currPerson.Name = input[0];
                currPerson.Age = int.Parse(input[1]);
                family.AddMember(currPerson);
            }
            Person oldestPerson = family.GetOldestMember(family.listOfPersons);
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
