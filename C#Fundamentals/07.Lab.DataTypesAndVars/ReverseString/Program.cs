using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string newString = string.Empty;
            for (int i = input.Length-1; i >= 0; i--)
            {
                string currDigit = input[i].ToString();
                newString += currDigit;
            }
            Console.WriteLine(newString);
        }
    }
}
