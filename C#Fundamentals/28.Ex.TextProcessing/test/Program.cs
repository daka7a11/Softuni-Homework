using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            double kvM = double.Parse(Console.ReadLine());
            double totalPrice = kvM * 7.61;
            double discount = totalPrice * 0.18;
            Console.WriteLine($"The final price is: {totalPrice-discount} lv.");
            Console.WriteLine($"The discount is: {discount}");
        }
    }
}
