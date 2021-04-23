using System;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string firstSymbol = arr[0];
                string[] temp = new string[arr.Length];
                for (int j = 1; j < arr.Length; j++)
                {
                    temp[j - 1] = arr[j];
                }
                temp[temp.Length - 1] = firstSymbol;
                arr = temp;
            }
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
