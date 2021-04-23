using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().ToLower().Split();
            Dictionary<string, int> materials = new Dictionary<string, int>();
            materials.Add("shards",0);
            materials.Add("fragments",0);
            materials.Add("motes",0);
            bool isObtained = false;
            string obtainedKey = string.Empty;
            while (!isObtained)
            {
                for (int i = 0; i < input.Length; i += 2)
                {
                    bool isLegendary = false;
                    string name = input[i+1];
                   if(name=="shards" || name=="fragments" || name=="motes")
                    {
                        isLegendary = true;
                    }
                        if (materials.ContainsKey(input[i + 1]))
                    {
                        materials[input[i + 1]] += int.Parse(input[i]);
                    }
                    else
                    {
                        materials.Add(input[i + 1], int.Parse(input[i]));
                    }
                    if (materials[input[i + 1]] >= 250 && isLegendary)
                    {
                        isObtained = true;
                        break;
                    }
                }
                for (int i = 0; i < materials.Count; i++)
                {
                    var currItem = materials.ElementAt(i);
                    string currItemKey = currItem.Key;
                    int currItemValue = currItem.Value;
                    if (currItemKey == "shards" || currItemKey == "fragments" || currItemKey == "motes")
                    {
                        if (currItemValue >= 250)
                        {
                            if (currItemKey == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (currItemKey == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }
                            else if (currItemKey == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }
                            materials[currItemKey] -= 250;
                            obtainedKey = currItemKey;
                        }
                    }
                }
                if (!isObtained)
                {
                input = Console.ReadLine().ToLower().Split();
                }
            }
            SortedDictionary<string, int> legendaryMaterials = new SortedDictionary<string, int>();
            foreach (var x in materials)
            {
                if (x.Key == "shards" || x.Key == "fragments" || x.Key == "motes")
                {
                    legendaryMaterials.Add(x.Key, x.Value);
                }
            }
            materials.Remove("shards");
            materials.Remove("fragments");
            materials.Remove("motes");
            foreach (var x in legendaryMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{x.Key}: {x.Value}");
            }
            foreach (var x in materials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{x.Key}: {x.Value}");
            }
        }
    }
}
