using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            List<int> originalDrums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> drums = new List<int>();
            for (int i = 0; i < originalDrums.Count; i++)
            {
                drums.Add(originalDrums[i]);
            }
            string input = Console.ReadLine();
            while(input!="Hit it again, Gabsy!")
            {
                int n = int.Parse(input);
                for (int i = 0; i < drums.Count; i++)
                {
                    if (drums[i]-n>0)
                    {
                        drums[i] -= n;
                    }
                    else
                    {
                        drums[i] -= n;
                        if (money-(originalDrums[i]*3)>=0)
                        {
                            drums[i] = int.Parse(originalDrums[i].ToString());
                            money -= originalDrums[i] * 3;
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",drums.Where(x => x>0)));
            Console.WriteLine($"Gabsy has {money:F2}lv.");
        }
    }
}
