using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int middleNum = (nums.Count / 2) + 1;
            double sum1 = 0;
            double sum2 = 0;
            for (int i = 0; i < middleNum - 1; i++)
            {
                if (nums[i] == 0)
                {
                    sum1 *= 0.8;
                }
                else
                {
                    sum1 += nums[i];
                }
            }
            for (int i = nums.Count - 1; i >= middleNum; i--)
            {
                if (nums[i] == 0)
                {
                    sum2 *= 0.8;
                }
                else
                {
                    sum2 += nums[i];
                }
            }
            if (sum1 < sum2)
            {
                Console.WriteLine($"The winner is left with total time: {sum1:F1}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {sum2:F1}");
            }
        }
    }
}
