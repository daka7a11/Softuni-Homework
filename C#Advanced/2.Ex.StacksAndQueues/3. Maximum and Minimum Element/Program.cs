﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (nums[0]==1)
                {
                    stack.Push(nums[1]);
                }
                else if (nums[0]==2)
                {
                    stack.Pop();
                }
                else if (nums[0] == 3)
                {
                    if (stack.Count!=0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (nums[0] == 4)
                {
                    if (stack.Count != 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
