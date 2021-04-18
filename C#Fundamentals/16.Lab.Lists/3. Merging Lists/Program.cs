using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
            List<int> secondNums = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
            List<int> result = new List<int>(Math.Max(nums.Count,secondNums.Count));
            for (int i = 0; i < Math.Min(nums.Count,secondNums.Count); i++)
            {
                result.Add(nums[i]);
                result.Add(secondNums[i]);
            }
            if (nums.Count>secondNums.Count)
            {
                for (int i = secondNums.Count; i < nums.Count; i++)
                {
                    result.Add(nums[i]);
                }
            }
            else if(secondNums.Count>nums.Count)
            {
                for (int i = nums.Count; i < secondNums.Count; i++)
                {
                    result.Add(secondNums[i]);
                }
            }
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
