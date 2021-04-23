using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _6._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string>(songs);
            while (queue.Count>0)
            {
                string input = Console.ReadLine();
                if (input.ToLower()=="play")
                {
                    queue.Dequeue();
                }
                else if (input.Substring(0,3).ToLower() == "add")
                {
                    string song = input.Substring(4);
                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }
                }
                else if (input.ToLower() == "show")
                {
                    Console.WriteLine(string.Join(", ",queue));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
