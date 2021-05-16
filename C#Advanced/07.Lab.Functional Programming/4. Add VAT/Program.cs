using System;
using System.Linq;

namespace _4._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                .Split(", ")
                .Select(x => double.Parse(x))
                .Select(x => x * 1.20)
                .ToArray();
            foreach (var number in nums)
            {
                Console.WriteLine($"{number:F2}");
            }
        }
    }
}
