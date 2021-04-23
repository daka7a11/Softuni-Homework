using System;

namespace _8.__Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            foreach (var word in input)
            {
                string numberAsString = "";
                for (int i = 1; i < word.Length-1; i++)
                {
                    numberAsString += word[i];
                }
                double num = int.Parse(numberAsString);
                char firstLetter = word[0];
                if (Char.IsUpper(firstLetter))
                {
                    sum += num / ((int)firstLetter - 64);
                }
                else
                {
                    sum += num * ((int)firstLetter - 96);
                }
                char secondLetter = word[word.Length-1];
                if (Char.IsUpper(secondLetter))
                {
                    sum -= (int)secondLetter - 64;
                }
                else
                {
                    sum += (int)secondLetter - 96;
                }
            }
            Console.WriteLine($"{sum :F2}");
        }
    }
}
