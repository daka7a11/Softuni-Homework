using System;
using System.Linq;

namespace CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int n = arr.Length;
            while (true)
            {
                if (n > 1)
                {
                    int[] currArr= new int[arr.Length-1];
                    for (int i = 0; i < currArr.Length; i++)
                    {
                        currArr[i] = arr[i] + arr[i + 1];
                    }
                    n--;
                    arr = currArr;
                }
                else
                {
                    break;
                }

            }
            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
