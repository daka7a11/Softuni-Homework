using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> people = new List<string>();
            foreach (var name in input)
            {
                people.Add(name);
            }
            input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (input[0].ToLower() != "party!")
            {
                string command = input[0].ToLower();
                string criteria = input[1].ToLower();
                GetChangedList(people, command, criteria, input[2]);

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.Write(string.Join(", ",people));
                Console.WriteLine(" are going to the party!");
            }
        }
        static List<string> GetChangedList(List<string> people, string command, string criteria, string inputFilter)
        {
            List<string> supportingList = new List<string>();
            if (criteria == "startswith")
            {
                string filter = inputFilter;
                supportingList = people.Where(p => p.StartsWith(filter)).ToList();
            }
            else if (criteria == "endswith")
            {
                string filter = inputFilter;
                supportingList = people.Where(p => p.EndsWith(filter)).ToList();
            }
            else if (criteria == "length")
            {
                int length = int.Parse(inputFilter);
                supportingList = people.Where(p => p.Length == length).ToList();
            }
            if (command == "double")
            {
                foreach (var item in supportingList)
                {
                    people.Add(item);
                }
            }
            else if (command == "remove")
            {
                foreach (var item in supportingList)
                {
                    people.Remove(item);
                }
            }
            return people;
        }
    }
}
