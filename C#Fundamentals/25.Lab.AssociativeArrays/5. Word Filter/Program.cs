using System;
using System.Linq;

namespace _5._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Where(x => x.Length % 2 == 0).ToArray();
            Console.WriteLine(string.Join("\n",input));
        }
    }
}
