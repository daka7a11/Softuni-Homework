using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Dragon_Army
{

    class Program
    {
        static void Main(string[] args)
        {
            List<Catalog> catalog = new List<Catalog>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string typeInput = input[0];
                string nameInput = input[1];
                int damageInput = 0;
                int healthInput = 0;
                int armorInput = 0;
                {
                    if (input[2] == "null")
                    {
                        damageInput = 45;
                    }
                    else
                    {
                        damageInput = int.Parse(input[2]);
                    }
                    if (input[3] == "null")
                    {
                        healthInput = 250;
                    }
                    else
                    {
                        healthInput = int.Parse(input[3]);
                    }
                    if (input[4] == "null")
                    {
                        armorInput = 10;
                    }
                    else
                    {
                        armorInput = int.Parse(input[4]);
                    }
                }
                Dragon currDragon = new Dragon(nameInput, damageInput, healthInput, armorInput);
                Catalog checkCatalog = catalog.Find(x => x.TypeDragon == typeInput);
                if (checkCatalog == null)
                {
                    Catalog currCatalog = new Catalog();
                    currCatalog.TypeDragon = typeInput;
                    currCatalog.ListOfDragons.Add(currDragon);
                    catalog.Add(currCatalog);
                }
                else
                {
                    checkCatalog.ListOfDragons.Add(currDragon);
                }
            }
            foreach (var type in catalog)
            {
                Console.WriteLine($"{type.TypeDragon}::({type.ListOfDragons.Average(x => x.Damage):F2}" +
                    $"/{type.ListOfDragons.Average(x => x.Health):F2}" +
                    $"/{type.ListOfDragons.Average(x => x.Armor):F2})");
                foreach (var dragon in type.ListOfDragons.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }
    }
    public class Catalog
    {
        public Catalog()
        {
            ListOfDragons = new List<Dragon>();
        }
        public string TypeDragon { get; set; }
        public List<Dragon> ListOfDragons { get; set; }
    }
    public class Dragon
    {
        public Dragon(string name, int damage, int health, int armor)
        {
            Name = name;
            Damage = damage;
            Health = health;
            Armor = armor;
        }

        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }


    }
}
