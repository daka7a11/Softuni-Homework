using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\+359( |-)[0-9](\1)[0-9]{3}(\1)[0-9]{4}\b";
            string text = Console.ReadLine();
            Regex rg = new Regex(regex);
            var result = rg.Matches(text);
            var matchedPhones = result
                .Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToArray();
            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
