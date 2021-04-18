using System;
using System.Text;

namespace _4.__Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];
                currChar += (char)3;
                sb.Append(currChar);
            }
            Console.WriteLine(sb);
        }
    }
}
