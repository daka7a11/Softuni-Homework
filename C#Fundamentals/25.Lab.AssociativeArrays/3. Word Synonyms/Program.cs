using System;
using System.Collections.Generic;

namespace _3._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (synonyms.ContainsKey(word))
                {
                    synonyms[word].Add(synonym);
                }
                else
                {
                    synonyms.Add(word, new List<string>());
                    synonyms[word].Add(synonym);
                }
            }
            foreach (var x in synonyms)
            {
                Console.Write(x.Key + " - ");
                Console.WriteLine(string.Join(", ", x.Value));
            }
        }
    }
}
