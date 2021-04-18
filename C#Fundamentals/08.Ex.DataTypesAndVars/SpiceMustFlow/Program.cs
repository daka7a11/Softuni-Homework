using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int days = 0;
            int totalSpice = 0;
            for (int i = startingYield; i >= 100; i -= 10)
            {
                int currSpice = i;
                currSpice -= 26;
                totalSpice += currSpice;
                days++;
            }
            if (totalSpice - 26 > 0)
            {
                totalSpice -= 26;
            }
            Console.WriteLine(days);
            Console.WriteLine(totalSpice);
        }
    }
}
