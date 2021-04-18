using System;
using System.Text.RegularExpressions;

namespace _1._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b[A-Z][a-z]+\s[A-Z][a-z]+\b";
            Regex rg = new Regex(regex);
            string text = Console.ReadLine();
            var result = rg.Matches(text);
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
