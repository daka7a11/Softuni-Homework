using System;
using System.Collections.Generic;

namespace _6._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ",StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] splitedClothes = input[1].Split(",",StringSplitOptions.RemoveEmptyEntries);
                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }
                foreach (var item in splitedClothes)
                {
                    if (clothes[color].ContainsKey(item))
                    {
                        clothes[color][item]++;
                    }
                    else
                    {
                        clothes[color].Add(item,1);
                    }
                }
            }
            string[] searchingCloth = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    if (color.Key == searchingCloth[0] && cloth.Key == searchingCloth[1])
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");

                    }
                }
            }
        }
    }
}
