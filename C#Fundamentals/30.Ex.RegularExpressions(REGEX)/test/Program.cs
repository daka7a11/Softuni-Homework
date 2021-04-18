using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Planet
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public char AttackType { get; set; }
        public int Soldiers { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Planet> allPlanets = new List<Planet>();
            allPlanets.Add(new Planet { Name = "asd", Population = 20, AttackType = 'A', Soldiers = 20000 });
            allPlanets.Add(new Planet { Name = "zxc", Population = 20, AttackType = 'A', Soldiers = 20000 });
            allPlanets.Add(new Planet { Name = "qwe", Population = 20, AttackType = 'D', Soldiers = 20000 });
            allPlanets.Add(new Planet { Name = "rrr", Population = 20, AttackType = 'D', Soldiers = 20000 });
            Console.WriteLine(allPlanets.Where(x => x.AttackType == 'A').Count());
        }
    }
}
