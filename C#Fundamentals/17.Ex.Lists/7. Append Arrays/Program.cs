using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split("|")
                .ToList();
            input.Reverse();
            List<string> result = new List<string>();
            for (int i = 0; i < input.Count; i++)
            {
                List<string> currArr = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                for (int j = 0; j < currArr.Count; j++)
                {
                    result.Add(currArr[j]);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
