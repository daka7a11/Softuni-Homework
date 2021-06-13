using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> hats = new Stack<int>(input);
            input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> scarfs = new Queue<int>(input);
            List<int> sets = new List<int>();
            while (hats.Count != 0)
            {
                if (scarfs.Count == 0)
                {
                    break;
                }
                int currHat = hats.Peek();
                int currScarf = scarfs.Peek();
                if (currHat > currScarf)
                {
                    sets.Add(hats.Pop() + scarfs.Dequeue());
                }
                else if (currHat < currScarf)
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
            }
            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ",sets));
        }
    }
}
