using System;
using System.Linq;

namespace EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] arr2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int index = 0;
            int sum = 0;
            bool isEqual = true;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i]==arr2[i])
                {
                    sum += arr1[i];
                }
                else
                {
                    index=i;
                    isEqual = false;
                    break;
                }
            }
            if (isEqual)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
            }
        }
    }
}
