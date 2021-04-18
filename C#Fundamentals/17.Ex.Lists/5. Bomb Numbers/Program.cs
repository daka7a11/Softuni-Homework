using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string[] input = Console.ReadLine().Split();
            int bomb = int.Parse(input[0]);
            int power = int.Parse(input[1]);
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bomb)
                {
                    int start = i - power;
                    int finish = i + power;
                    if (start<0)
                    {
                        start = 0;
                    }
                    if (finish>numbers.Count-1)
                    {
                        finish = numbers.Count - 1;
                    }
                    for (int j = start; j <= finish; j++)
                    {
                        numbers[j] = 0;
                    }
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
