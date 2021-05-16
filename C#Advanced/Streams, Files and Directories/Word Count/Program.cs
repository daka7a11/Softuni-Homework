using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("../../../words.txt");
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var word in words)
            {
                result.Add(word.ToLower(), 0);
            }
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    foreach (var word in result)
                    {
                        result[word.Key] += GetWordCount(line, word.Key);
                    }
                    line = reader.ReadLine();
                }
            }
            using (StreamWriter writer = new StreamWriter("../../../actualResult.txt"))
            {
                foreach (var word in result)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
            using (StreamWriter writer = new StreamWriter("../../../expectedResult.txt"))
            {
                foreach (var word in result.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
        static int GetWordCount(string text, string word)
        {
            int count = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]) || Char.IsWhiteSpace(text[i]))
                {
                    sb.Append(text[i]);
                }
            }
            string[] splitedText = sb.ToString().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var x in splitedText)
            {
                if (x.ToLower()==word.ToLower())
                {
                    count++;
                }
            }
            return count;
        }
    }
}
