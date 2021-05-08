using System;
using System.Collections.Generic;

namespace _2._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            string[] setsLengths = Console.ReadLine().Split();
            int firstSetLength = int.Parse(setsLengths[0]);
            int secondSetLength = int.Parse(setsLengths[1]);
            for (int i = 0; i < firstSetLength; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstSet.Add(num);
            }
            for (int i = 0; i < secondSetLength; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondSet.Add(num);
            }
            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
