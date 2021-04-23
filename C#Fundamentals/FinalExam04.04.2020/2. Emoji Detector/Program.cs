using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace _2._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(::|\*\*)[A-Z][a-z]{2,}\1";
            string text = Console.ReadLine();
            MatchCollection matches = Regex.Matches(text, pattern);
            int coolThreshold = 1;
            for (int i = 0; i < text.Length; i++)
            {
                char currChar = text[i];
                if (Char.IsDigit(currChar))
                {
                    coolThreshold *= int.Parse(currChar.ToString());
                }
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            foreach (Match x in matches)
            {
                int currSum = 0;
                string currWord = x.Value;
                for (int i = 2; i < currWord.Length-2; i++)
                {
                    currSum += (int)currWord[i];

                }
                if (currSum>coolThreshold)
                {
                    Console.WriteLine(x.Value);
                }

            }
        }
    }
}
