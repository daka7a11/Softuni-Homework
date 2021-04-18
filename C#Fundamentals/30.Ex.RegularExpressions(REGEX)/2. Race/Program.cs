using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace _2._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternForName = @"[A-Za-z]+";
            string patternForNumbers = @"[0-9]";
            string[] peoples = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string input = Console.ReadLine();
            Dictionary<string, int> racers = new Dictionary<string, int>();
            while (input.ToLower() != "end of race")
            {
                var nameCol = Regex.Matches(input, patternForName);
                var numbersCol = Regex.Matches(input, patternForNumbers);
                string name = string.Empty;
                int number = 0;
                foreach (var item in nameCol)
                {
                    name += item;
                }
                foreach (var item in numbersCol)
                {
                    number += int.Parse(item.ToString());
                }
                if (peoples.Contains(name))
                {
                    if (racers.ContainsKey(name))
                    {
                        racers[name] += number;
                    }
                    else
                    {
                        racers.Add(name, number);
                    }
                }
                input = Console.ReadLine();
            }
            int i = 1;
            foreach (var x in racers.OrderByDescending(x => x.Value))
            {
                if (i > 3)
                {
                    break;
                }
                string text = i == 1 ? "st" : i == 2 ? "nd" : "rd";
                Console.WriteLine($"{i++}{text} place: {x.Key}");
            }
        }
    }
}
