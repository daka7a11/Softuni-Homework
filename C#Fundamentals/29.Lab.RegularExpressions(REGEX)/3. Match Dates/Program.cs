using System;
using System.Text.RegularExpressions;

namespace _3._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\2(?<year>\d{4})\b";
            string text = Console.ReadLine();
            var dates = Regex.Matches(text, regex);

        }
    }
}
