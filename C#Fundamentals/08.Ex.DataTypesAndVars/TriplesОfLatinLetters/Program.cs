using System;

namespace TriplesОfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    for (int k = 0; k < num; k++)
                    {
                        char first = (char)('a' + i);
                        char third = (char)('a' + k);
                        char second = (char)('a' + j);
                        Console.WriteLine($"{first}{second}{third}");
                    }
                }
            }
        }
    }
}
