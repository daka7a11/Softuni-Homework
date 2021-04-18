using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            string[] input = Console.ReadLine().Split(" -> ",StringSplitOptions.RemoveEmptyEntries);
            while (input[0].ToLower()!="end")
            {
                if (!companies.ContainsKey(input[0]))
                {
                    companies.Add(input[0], new List<string> {input[1]});
                }
                else
                {
                    if (!companies[input[0]].Contains(input[1]))
                    {
                        companies[input[0]].Add(input[1]);
                    }
                }
                input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var x in companies.OrderBy(x => x.Key))
            {
                Console.WriteLine(x.Key);
                foreach (var z in x.Value)
                {
                    Console.WriteLine($"-- {z}");
                }
            }
        }
    }
}
