using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (input[0].ToLower() != "end")
            {
                string name = input[0];
                int age = int.Parse(input[1]);
                string town = input[2];
                persons.Add(new Person() { Name = name, Age = age, Town = town });
                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            int n = int.Parse(Console.ReadLine());
            int matches = GetMatches(persons, n);
            if (matches > 1)
            {
                Console.WriteLine($"{matches} {persons.Count - matches} {persons.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
        static int GetMatches(List<Person> persons, int position)
        {
            int matches = 0;
            Person person = persons[position - 1];
            foreach (var item in persons)
            {
                if (person.CompareTo(item)==0)
                {
                    matches++;
                }
            }
            return matches;
        }
    }
}
