using System;
using System.Linq;

namespace _9._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            IsItPalindrom(input);
        }
        static void IsItPalindrom(string input)
        {
            while (input != "END")
            {
                var reversedInput = input.Reverse().ToArray();
                bool isStringsSame = true;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i]!=reversedInput[i])
                    {
                        isStringsSame = false;
                        break;
                    }
                }
                if (isStringsSame)
                {
                    Console.WriteLine(true);
                }
                else
                {
                    Console.WriteLine(false);
                }

                input = Console.ReadLine();
            }
        }
    }
}
