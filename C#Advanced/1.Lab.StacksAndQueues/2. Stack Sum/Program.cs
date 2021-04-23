using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(numbers);
            string[] input = Console.ReadLine().Split().Select(x => x.ToLower()).ToArray();
            while (input[0]!="end")
            {
                if (input[0]=="add")
                {
                    stack.Push(int.Parse(input[1]));
                    stack.Push(int.Parse(input[2]));
                }
                else if (input[0]=="remove")
                {
                    if (!(int.Parse(input[1])>stack.Count))
                    {
                        for (int i = 0; i < int.Parse(input[1]); i++)
                        {
                            stack.Pop();
                        }
                    }
                }


                input = Console.ReadLine().Split();
            }
            int sum = 0;
            while (stack.Count>0)
            {
                sum += stack.Pop();
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
