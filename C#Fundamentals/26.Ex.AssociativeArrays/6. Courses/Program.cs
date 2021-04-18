using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string[] input = Console.ReadLine().Split(" : ");
            while (input[0].ToLower()!="end")
            {
                if (!courses.ContainsKey(input[0]))
                {
                    courses.Add(input[0], new List<string> {input[1]});
                }
                else
                {
                    courses[input[0]].Add(input[1]);
                }
                input = Console.ReadLine().Split(" : ");
            }
            foreach (var x in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{x.Key}: {x.Value.Count}");
                foreach (var z in x.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {z}");
                }
            }
        }
    }
}
