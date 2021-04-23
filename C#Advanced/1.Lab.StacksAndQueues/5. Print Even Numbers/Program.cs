using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(numbers);
            while (queue.Count>1)
            {
                int number = queue.Dequeue();
                if (number %2 == 0)
                {
                    Console.Write(number+", ");
                }
            }
            int lastNumber = queue.Dequeue();
            if (lastNumber%2==0)
            {
                Console.WriteLine(lastNumber);
            }
        }
    }
}
