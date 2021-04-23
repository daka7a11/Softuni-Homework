using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._P_rates
{
    class Town
    {
        public string Name { get; set; }
        public int People { get; set; }
        public int Gold { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Town> targets = new List<Town>();
            string[] input = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);
            while (input[0].ToLower() != "sail")
            {
                string name = input[0];
                int people = int.Parse(input[1]);
                int gold = int.Parse(input[2]);
                if (targets.Exists(x => x.Name == name))
                {
                    Town currTown = targets.Find(x => x.Name == name);
                    currTown.People += people;
                    currTown.Gold += gold;
                }
                else
                {
                    targets.Add(new Town { Name = name, People = people, Gold = gold });
                }
                input = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);
            }
            input = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            while (input[0].ToLower()!="end")
            {
                string command = input[0].ToLower();
                string name = input[1];
                Town townToChange = targets.Find(x => x.Name == name);
                if (command=="plunder")
                {
                    int people = int.Parse(input[2]);
                    int gold = int.Parse(input[3]);
                    townToChange.People -= people;
                    townToChange.Gold -= gold;
                    Console.WriteLine($"{name} plundered! {gold} gold stolen, {people} citizens killed.");
                    if (townToChange.People<=0 || townToChange.Gold<=0)
                    {
                        Console.WriteLine($"{townToChange.Name} has been wiped off the map!");
                        targets.Remove(townToChange);
                    }
                }
                else if (command=="prosper")
                {
                    int gold = int.Parse(input[2]);
                    if (gold > 0 )
                    {
                        townToChange.Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {townToChange.Name} now has {townToChange.Gold} gold.");
                    }
                    else
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                }
                input = Console.ReadLine().Split("=>");
            }
            if (targets.Count>0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {targets.Count} wealthy settlements to go to:");
                foreach (var town in targets.OrderByDescending(x => x.Gold).ThenBy(x => x.Name))
                {
                    Console.WriteLine($"{town.Name} -> Population: {town.People} citizens, Gold: {town.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
