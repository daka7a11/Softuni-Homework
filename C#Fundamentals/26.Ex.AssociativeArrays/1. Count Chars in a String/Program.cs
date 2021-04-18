using System;
using System.Collections.Generic;

namespace _1._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Dictionary<char, int> chars = new Dictionary<char, int>();
            foreach (var x in input)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    char currDigit = x[i];
                    if (chars.ContainsKey(currDigit))
                    {
                        chars[currDigit]++;
                    }
                    else
                    {
                        chars.Add(currDigit,1);
                    }
                }
            }
            foreach (var x in chars)
            {
                Console.WriteLine($"{x.Key.ToString()} -> {x.Value}");
            }
        }
    }
}
