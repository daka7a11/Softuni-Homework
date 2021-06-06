using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(input.Reverse());
            input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(input.Reverse());

            List<int> claimedItems = new List<int>();

            while (stack.Count!=0)
            {
                if (queue.Count==0)
                {
                    break;
                }
                int firstNum = stack.Peek();
                int secondNum = queue.Peek();
                if ((firstNum+secondNum)%2==0)
                {
                    claimedItems.Add(firstNum + secondNum);
                    stack.Pop();
                    queue.Dequeue();
                }
                else
                {
                    List<int> support = new List<int>();
                    while (stack.Count!=0)
                    {
                        support.Add(stack.Pop());
                    }
                    support.Add(queue.Dequeue());
                    stack = new Stack<int>(support.ToArray().Reverse());
                }
            }
            if (stack.Count==0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            int sum = claimedItems.Sum();
            if (sum>=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
        }
    }
}
