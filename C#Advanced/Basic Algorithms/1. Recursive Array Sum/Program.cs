using System;
using System.Linq;

namespace _1._Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(ArraySum(arr,0));
        }
        static int ArraySum(int[] arr, int startIndex)
        {
            if (startIndex==arr.Length-1)
            {
                return arr[startIndex];
            }

            return arr[startIndex] + ArraySum(arr, startIndex + 1);
        }
    }
}
