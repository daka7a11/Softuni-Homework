using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nsx = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(numbers);
            for (int i = 0; i < nsx[1]; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(nsx[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count>0)
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
