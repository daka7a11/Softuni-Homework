using System;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToArray();
            int n = int.Parse(Console.ReadLine());
            Func<int, bool> func = CheckDevisible(n);
            foreach (var number in nums)
            {
                if (func(number))
                {
                    Console.Write(number+" ");
                }
            }
        }
        static Func<int, bool> CheckDevisible(int n)
        {
            return x => x % n != 0;
        }
    }
}
