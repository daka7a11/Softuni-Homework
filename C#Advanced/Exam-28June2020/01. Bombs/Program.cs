using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(input.Reverse());
            input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(input.Reverse());
            int daturaBombs = 0;
            int cherryBombs = 0;
            int smokeDecoyBombs = 0;
            while (stack.Count != 0)
            {
                if (queue.Count == 0)
                {
                    break;
                }
                if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDecoyBombs >= 3)
                {
                    break;
                }
                int bombEffect = stack.Peek();
                int bombCasing = queue.Peek();
                if (bombEffect+bombCasing==40)
                {
                    daturaBombs++;
                    stack.Pop();
                    queue.Dequeue();
                }
                else if (bombEffect + bombCasing == 60)
                {
                    cherryBombs++;
                    stack.Pop();
                    queue.Dequeue();
                }
                else if (bombEffect + bombCasing == 120)
                {
                    smokeDecoyBombs++;
                    stack.Pop();
                    queue.Dequeue();
                }
                else
                {
                    List<int> support = new List<int>();
                    support.Add(queue.Dequeue() - 5);
                    while(queue.Count!=0)
                    {
                        support.Add(queue.Dequeue());
                    }
                    queue = new Queue<int>(support);
                }
            }
            if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDecoyBombs >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (stack.Count==0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.Write("Bomb Effects: ");
                while (stack.Count!=1)
                {
                    Console.Write($"{stack.Pop()}, ");
                }
                Console.WriteLine(stack.Pop());
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.Write("Bomb Casings: ");
                while (queue.Count != 1)
                {
                    Console.Write($"{queue.Dequeue()}, ");
                }
                Console.WriteLine(queue.Dequeue());
            }
            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {daturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombs}");
        }
    }
}
