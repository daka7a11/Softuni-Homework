using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Snowwhite
{
    public class Dwarf
    {
        public Dwarf(string name,string color,int physics)
        {
            this.Name = name;
            this.Color = color;
            this.Physics = physics;
        }
        public string Name  { get;set;}
        public string Color { get; set; }
        public int Physics { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Dwarf> dwarfs = new List<Dwarf>();
            string[] input = Console.ReadLine().Split(" <:> ");
            while (input[0].ToLower()!="once upon a time")
            {
                string currName = input[0];
                string currColor = input[1];
                int currPhysics = int.Parse(input[2]);
                Dwarf dwarfToUpdate = dwarfs.Find(x => x.Name == currName && x.Color == currColor);
                if (dwarfToUpdate==null)
                {
                    Dwarf currDwarf = new Dwarf(currName, currColor, currPhysics);
                    dwarfs.Add(currDwarf);
                }
                else
                {
                    dwarfToUpdate.Physics = Math.Max(dwarfToUpdate.Physics, currPhysics);
                }
                input = Console.ReadLine().Split(" <:> ");
            }
            foreach (var dwarf in dwarfs.OrderByDescending(x => x.Physics).ThenByDescending(x => dwarfs.Count(y => y.Color == x.Color)))
            {
                Console.WriteLine($"({dwarf.Color}) {dwarf.Name} <-> {dwarf.Physics}");

            }
        }
    }
}
