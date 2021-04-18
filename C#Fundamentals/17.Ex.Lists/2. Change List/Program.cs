using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string[] input = Console.ReadLine().Split();
            while (input[0].ToLower()!="end")
            {
                if (input[0].ToLower()=="delete")
                {
                    while (numbers.Contains(int.Parse(input[1])))
                    {
                        numbers.Remove(int.Parse(input[1]));
                    }
                }
                else if (input[0].ToLower()=="insert")
                {
                    numbers.Insert(int.Parse(input[2]), int.Parse(input[1]));
                }
                input = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
