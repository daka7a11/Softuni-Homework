using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> raid = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            while (raid.Count<n) 
            { 
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                if (heroType == "Druid")
                {
                    raid.Add(new Druid(heroName));
                }
                else if (heroType == "Paladin")
                {
                    raid.Add(new Paladin(heroName));
                }
                else if (heroType == "Rogue")
                {
                    raid.Add(new Rogue(heroName));
                }
                else if (heroType == "Warrior")
                {
                    raid.Add(new Warrior(heroName));
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }
            int boss = int.Parse(Console.ReadLine());
            foreach (var hero in raid)
            {
                Console.WriteLine(hero.CastAbility());
            }
            if (raid.Sum(x => x.Power)>=boss)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
