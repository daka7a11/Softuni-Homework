using System;
using System.Text.RegularExpressions;

namespace _1._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @">>(\w+)<<(\d+\.?\d*)!(\d+)";
            string text = Console.ReadLine();
            double sum = 0;
            Console.WriteLine("Bought furniture:");
            while (text.ToLower()!="purchase")
            {
                var splitedText = Regex.Match(text, regex);
                if (splitedText.Success)
                {
                    string name = splitedText.Groups[1].Value;
                    Console.WriteLine(name);
                    double price = double.Parse(splitedText.Groups[2].Value);
                    int quantity = int.Parse(splitedText.Groups[3].Value);
                    sum += price * quantity;
                }
                text = Console.ReadLine();
            }
            Console.WriteLine($"Total money spend: {sum:F2}");
        }
    }
}
