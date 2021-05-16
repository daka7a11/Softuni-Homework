using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in text.Where(x => Char.IsUpper(x[0])))
            {
                Console.WriteLine(word);
            }
        }
    }
}
