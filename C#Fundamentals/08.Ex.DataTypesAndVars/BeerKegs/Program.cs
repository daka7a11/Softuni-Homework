using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfKegs = int.Parse(Console.ReadLine());
            double biggestKegVol = 0D;
            string biggestKegName=string.Empty;
            for (int i = 0; i < numOfKegs; i++)
            {
                string name = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double currKeg = Math.PI * (radius * radius) * height;
                if (currKeg>biggestKegVol)
                {
                    biggestKegVol = currKeg;
                    biggestKegName = name;
                }
            }
            Console.WriteLine(biggestKegName);
        }
    }
}
