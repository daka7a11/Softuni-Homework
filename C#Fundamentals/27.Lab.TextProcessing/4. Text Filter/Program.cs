using System;
namespace _4._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();
            foreach (var bannedWord in bannedWords)
            {
                string replace = string.Empty;
                for (int i = 0; i < bannedWord.Length; i++)
                {
                    replace += "*";
                }
                text = text.Replace(bannedWord,replace);
            }
            Console.WriteLine(text);
        }
    }
}
