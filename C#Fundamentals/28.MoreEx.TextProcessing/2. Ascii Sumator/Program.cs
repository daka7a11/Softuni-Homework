using System;

namespace _2._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            int one = char.Parse(Console.ReadLine());
            int two = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int currCharValue = input[i];
                if (currCharValue> one && currCharValue < two)
                {
                    sum += currCharValue;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
