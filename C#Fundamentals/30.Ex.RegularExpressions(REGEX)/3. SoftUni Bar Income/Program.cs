using System;
using System.Text.RegularExpressions;

namespace _3._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+\.?\d*)\$";
            string text = Console.ReadLine();
            double totalMoneyForDay = 0;
            while (text.ToLower()!="end of shift")
            {
                Match customer = Regex.Match(text, pattern);
                if (customer.Success)
                {
                    string customerName = customer.Groups[1].ToString();
                    string product = customer.Groups[2].ToString();
                    int quantity = int.Parse(customer.Groups[3].ToString());
                    double price = double.Parse(customer.Groups[4].ToString());
                    double totalPrice = quantity * price;

                    Console.WriteLine($"{customerName}: {product} - {totalPrice:F2}");

                    totalMoneyForDay += totalPrice;
                }
                text = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalMoneyForDay:F2}");
        }
    }
}
