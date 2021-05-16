using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            List<int> result = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if (IsDivided(i,numbers))
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ",result));
        }
        static bool IsDivided(int num, int[] devides)
        {
            foreach (var x in devides)
            {
                if (!(num % x ==0))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
