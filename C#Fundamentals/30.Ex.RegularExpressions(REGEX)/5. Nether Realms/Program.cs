using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Demon> allDemons = new List<Demon>();
            string numberPattern = @"[-+]?\d+\.?\d*";
            string[] input = Console.ReadLine().Split(new[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var demon in input)
            {
                string filter = "0123456789+-*/.";
                int health = demon.Where(d => !filter.Contains(d)).Sum(d => d);
                double damage = 0;
                MatchCollection numberMatches = Regex.Matches(demon, numberPattern);
                foreach (Match match in numberMatches)
                {
                    damage += double.Parse(match.Value);
                }
                foreach (var ch in demon)
                {
                    if (ch == '*')
                    {
                        damage *= 2.0;
                    }
                    if (ch == '/')
                    {
                        damage /= 2.0;
                    }
                }
                allDemons.Add(new Demon { Name = demon, Health = health, Damage = damage });
            }
            foreach (var demon in allDemons.OrderBy(x => x.Name))
            {
                Console.WriteLine(demon);
            }
        }
    }
    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:F2} damage";
        }
    }
}
