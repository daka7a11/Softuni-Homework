using System;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Action<int[]> print = x => Console.Write(string.Join(" ",x));
            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        nums = nums.Select(x => x + 1).ToArray();
                        break;
                    case "multiply":
                        nums = nums.Select(x => x * 2).ToArray();
                        break;
                    case "subtract":
                        nums = nums.Select(x => x - 1).ToArray();
                        break;
                    case "print":
                        print(nums);
                        Console.WriteLine();
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
