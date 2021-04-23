using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                bool isBiggest = true;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] <= arr[j])
                    {
                        isBiggest = false;
                        break;
                    }
                }
                if (isBiggest)
                {
                    Console.Write(arr[i]+" ");
                }
            }
        }
    }
}
