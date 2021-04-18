using System;

namespace _3._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string text = Console.ReadLine();
            while (text.ToLower().Contains(wordToRemove.ToLower()))
            {
                text = text.ToLower().Remove(text.IndexOf(wordToRemove.ToLower()),wordToRemove.Length);
            }
            Console.WriteLine(text);
        }
    }
}
