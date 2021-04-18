using System;
using System.Text.RegularExpressions;

namespace _6._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-][A-Za-z]+)+))(\b|(?=\s))";
            string text = Console.ReadLine();
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match email in matches)
            {
                Console.WriteLine(email);
            }
        }
    }
}
