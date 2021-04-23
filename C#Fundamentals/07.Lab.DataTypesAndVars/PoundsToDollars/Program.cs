using System;

namespace PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            int pounds = int.Parse(Console.ReadLine());
            decimal dollars = pounds * 1.31M;
            Console.WriteLine($"{dollars:F3}");
        }
    }
}
