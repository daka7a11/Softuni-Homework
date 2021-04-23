using System;
using System.Linq;

namespace Zig_ZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arrOne = new int[n];
            int[] arrTwo = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] currArr = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();
                if (i % 2 == 0)
                {
                    arrOne[i] = currArr[0];
                    arrTwo[i] = currArr[1];
                }
                else
                {
                    arrOne[i] = currArr[1];
                    arrTwo[i] = currArr[0];
                }
            }
            Console.WriteLine(string.Join(" ",arrOne));
            Console.WriteLine(string.Join(" ", arrTwo));

        }
    }
}
