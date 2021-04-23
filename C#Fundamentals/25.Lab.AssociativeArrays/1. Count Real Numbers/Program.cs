using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();
            foreach (double x in numbers)
            {
                if (counts.ContainsKey(x))
                {
                    counts[x]++;
                }
                else
                {
                    counts.Add(x, 1);
                }
            }
            foreach (var x in counts)
            {
                Console.WriteLine($"{x.Key} -> {x.Value}");
            }
        }
    }
}
