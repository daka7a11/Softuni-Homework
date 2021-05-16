using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> people = new List<string>();
            List<string> filters = new List<string>();
            foreach (var name in input)
            {
                people.Add(name);
            }
            input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            while (input[0].ToLower() != "print")
            {
                string command = input[0].ToLower();
                string criteria = input[1].ToLower();
                string filter = input[2];
                if (command == "add filter")
                {
                    filters.Add(criteria + ";" + filter);
                }
                else if (command == "remove filter")
                {
                    filters.Remove(criteria + ";" + filter);
                }

                input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var item in filters)
            {
                string[] splitedCommand = item.Split(";");
                string itemCriteria = splitedCommand[0];
                string itemFilter = splitedCommand[1];
                if (itemCriteria == "starts with")
                {
                    people = people.Where(x => !x.StartsWith(itemFilter)).ToList();
                }
                else if (itemCriteria == "ends with")
                {
                    people = people.Where(x => !x.EndsWith(itemFilter)).ToList();
                }
                else if (itemCriteria == "length")
                {
                    int length = int.Parse(itemFilter);
                   people= people.Where(x => x.Length != length).ToList();
                }
                else if (itemCriteria == "contains")
                {
                    people = people.Where(x => !x.Contains(itemFilter)).ToList();
                }
            }
            Console.WriteLine(string.Join(" ", people));
        }
    }
}
