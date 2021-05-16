using System;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Func<string, bool> func = GetAsciiSum(n);
            foreach (var item in names)
            {
                if (func(item))
                {
                    Console.WriteLine(item);
                    return;
                }
            }
        }
        static Func<string, bool> GetAsciiSum(int n)
        {
            return p => p.Select(x => (int)x).Sum() >= n;
        }
    }
}
