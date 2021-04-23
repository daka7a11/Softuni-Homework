using System;
using System.Collections;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> queue = new Queue<string>();
            int passedCount = 0;
            while (command.ToLower()!="end")
            {
                if (command.ToLower()=="green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Count==0)
                        {
                            break;
                        }
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        passedCount++;
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{passedCount} cars passed the crossroads.");
        }
    }
}
