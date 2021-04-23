using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> removedElements = new List<int>();
            while (nums.Count > 0)
            {
                int indexToRemove = int.Parse(Console.ReadLine());
                bool shouldIsRemoved = true;
                for (int i = 0; i < nums.Count; i++)
                {
                    if (i == indexToRemove)
                    {
                        if (!shouldIsRemoved)
                        {
                            nums[i] += nums[indexToRemove];
                        }
                        continue;
                    }
                    if (indexToRemove < 0)
                    {
                        removedElements.Add(nums[0]);
                        nums.Insert(0, nums[nums.Count - 1]);
                        nums.RemoveAt(0+1);
                        indexToRemove = 0;
                        shouldIsRemoved = false;
                    }
                    if (indexToRemove > nums.Count - 1)
                    {
                        removedElements.Add(nums[nums.Count - 1]);
                        nums.Add(nums[0]);
                        nums.RemoveAt(nums.Count - 2);
                        indexToRemove = nums.Count - 1;
                        shouldIsRemoved = false;
                    }
                    if (nums[i] <= nums[indexToRemove])
                    {
                        nums[i] += nums[indexToRemove];
                    }
                    else
                    {
                        nums[i] -= nums[indexToRemove];
                    }
                }
                if (shouldIsRemoved)
                {
                    removedElements.Add(nums[indexToRemove]);
                    nums.Remove(nums[indexToRemove]);
                }
            }
            Console.WriteLine(removedElements.Sum());
        }
    }
}
