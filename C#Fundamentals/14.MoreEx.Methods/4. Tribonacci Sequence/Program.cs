using System;
using System.Linq;

namespace _4._Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintNumTribonacciSequence(n);
        }
        static void PrintNumTribonacciSequence(int n)
        {
            string numbers = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                if (i==1)
                {
                    numbers+= "1 ";
                }
                else if (i==2)
                {
                    numbers += "1 ";
                }
                else if (i==3)
                {
                    numbers += "2 ";

                }
                else if (i>3)
                {
                    int[] arr = numbers.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    numbers += arr[i-2]+arr[i-3]+arr[i-4]+" ";
                }
            }
            Console.WriteLine(numbers);
        }
    }
}
