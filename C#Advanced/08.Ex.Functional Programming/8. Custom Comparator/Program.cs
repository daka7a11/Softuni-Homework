using System;
using System.Linq;

namespace _8._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Array.Sort(nums,(x,y) => 
            {
                int sorter = 0;
                if (x % 2 == 0 && y % 2 != 0)
                {
                    sorter = -1;
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    sorter = 1;
                }
                else
                {
                    sorter = x - y;
                    sorter = x.CompareTo(y);
                }
                return sorter;
            });
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
