using System;

namespace SpecialNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int allDigit = 0;
            int sum = 0;
            string nText = n.ToString();
            for (int i = 1; i <= n; i++)
            {
                allDigit = i;
                for (int j = 0; j <= nText.Length - 1; j++)
                {
                    sum += allDigit % 10;
                    allDigit /= 10;
                }
                bool isSpecial =(sum==5)||(sum==7)||(sum==11);
                Console.WriteLine($"{i} -> {isSpecial}");
                sum = 0;
            }
        }
    }
}
