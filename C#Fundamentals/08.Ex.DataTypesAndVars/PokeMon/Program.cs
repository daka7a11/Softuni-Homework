using System;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int targets = 0;
            double pokePowerPercent = pokePower;
            pokePowerPercent /= 2;
            while (pokePower - distance >= 0)
            {
                if (pokePower == pokePowerPercent)
                {
                    if (exhaustionFactor != 0)
                    {
                        pokePower /= exhaustionFactor;
                        continue;
                    }
                }
                pokePower -= distance;
                targets++;
            }
            Console.WriteLine($"{pokePower}");
            Console.WriteLine($"{targets}");
        }
    }
}
