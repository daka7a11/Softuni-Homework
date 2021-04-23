using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _4._Star_Enigma
{
    class Planet
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public string AttackType { get; set; }
        public int Soldiers { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Planet> planets = new List<Planet>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int countSTAR = 0;
                string star = "star";
                for (int j = 0; j < input.Length; j++)
                {
                    if (star.Contains((input[j].ToString()).ToLower()))
                    {
                        countSTAR++;
                    }
                }
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < input.Length; j++)
                {
                    sb.Append((char)(input[j] - countSTAR));
                }
                string pattern = @"@([A-Za-z]+)[^@\-!:>]*:(\d+)[^@\-!:>]*!([A-Z])![^@\-!:>]*->(\d+)";
                Match match = Regex.Match(sb.ToString(), pattern);
                if (!match.Success)
                {
                    continue;
                }
                string name = match.Groups[1].Value;
                int population = int.Parse(match.Groups[2].Value);
                string typeAttack = match.Groups[3].Value;
                int soldiers = int.Parse(match.Groups[4].Value);
                planets.Add(new Planet { Name = name, Population = population, AttackType = typeAttack, Soldiers = soldiers });
            }
            int attackedCount = planets.Where(p => p.AttackType == "A").Count();
            int destroyedCount = planets.Where(p => p.AttackType == "D").Count();
            Console.WriteLine($"Attacked planets: {attackedCount}");
            foreach (var planet in planets.Where(p => p.AttackType == "A").OrderBy(p => p.Name))
            {
                Console.WriteLine($"-> {planet.Name}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedCount}");
            foreach (var planet in planets.Where(p => p.AttackType == "D").OrderBy(p => p.Name))
            {
                Console.WriteLine($"-> {planet.Name}");
            }
        }
    }
}
