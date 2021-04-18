using System;
using System.Text;

namespace _7.__String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            int strength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];
                if (currChar=='>')
                {
                    strength += int.Parse(input[i + 1].ToString());
                    result.Append(currChar);
                    continue;
                }
                if (strength>0)
                {
                    strength--;
                    continue;
                }
                result.Append(currChar);
            }
            Console.WriteLine(result);
        }
    }
}
