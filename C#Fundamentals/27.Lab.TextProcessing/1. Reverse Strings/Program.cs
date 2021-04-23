using System;
using System.Linq;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            while (word != "end")
            {
                char[] reversedWord = word.Reverse().ToArray();
                Console.WriteLine($"{word} = {string.Join("",reversedWord)}");
                word = Console.ReadLine();
            }
        }
    }
}
