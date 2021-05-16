using System;
using System.Linq;

namespace _3._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int[], int> minNumber = GetSmallesNumber(nums);
            Console.WriteLine(minNumber(nums));
        }
        static Func<int[],int> GetSmallesNumber (int[] arr)
        {
            return n => arr.Min();
        }
    }
}
