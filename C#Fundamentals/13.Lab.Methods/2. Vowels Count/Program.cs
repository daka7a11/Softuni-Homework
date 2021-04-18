using System;

namespace _2._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            VowelsCount(text);
        }
        static void VowelsCount(string text)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'a' ||
                    text[i] == 'e' ||
                    text[i] == 'u' ||
                    text[i] == 'i' ||
                    text[i] == 'o')
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
