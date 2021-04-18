using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split()
                .ToList();
            Random rnd = new Random();
            for (int i = 0; i < words.Count; i++)
            {
                int randomNum = rnd.Next(0, words.Count);
                string elementI = words[i];
                words[i] = words[randomNum];
                words[randomNum] = elementI;
            }
            Console.WriteLine(string.Join('\n',words));
        }
    }
}
