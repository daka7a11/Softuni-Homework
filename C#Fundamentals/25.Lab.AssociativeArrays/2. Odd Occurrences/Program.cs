using System;
using System.Collections.Generic;

namespace _2._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().ToLower().Split();
            Dictionary<string, int> words = new Dictionary<string, int>();
            foreach (var x in input)
            {
                if (words.ContainsKey(x))
                {
                    words[x]++;
                }
                else
                {
                    words.Add(x,1);
                }
            }
            foreach (var x in words)
            {
                if (x.Value%2!=0)
                {
                    Console.Write(x.Key+" ");
                }
            }
        }
    }
}
