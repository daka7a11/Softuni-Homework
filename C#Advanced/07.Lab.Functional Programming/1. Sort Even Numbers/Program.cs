﻿using System;
using System.Linq;

namespace _1._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToArray();
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
