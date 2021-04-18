using System;
namespace _5._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];
                if (Char.IsDigit(currChar))
                {
                    Console.Write(currChar);
                }
            }
            Console.WriteLine();
            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];
                if (Char.IsLetter(currChar))
                {
                    Console.Write(currChar);
                }
            }
            Console.WriteLine();
            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];
                if (!Char.IsLetterOrDigit(currChar))
                {
                    Console.Write(currChar);
                }
            }
        }
    }
}