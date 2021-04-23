using System;
using System.Linq;

namespace PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                arr[i] = num;
            }
            Console.WriteLine(string.Join(' ', arr
                .Reverse()));
        }
    }
}
