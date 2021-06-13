using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }
        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel { get => Ingredients.Sum(x => x.Alcohol); }

        public void Add(Ingredient ingredient)
        {
            Ingredient ing = Ingredients.FirstOrDefault(x => x.Name == ingredient.Name);
            if (ing == null)
            {
                if (Ingredients.Count < Capacity)
                {
                    Ingredients.Add(ingredient);
                }
            }
        }

        public bool Remove(string name)
        {
            Ingredient ing = Ingredients.FirstOrDefault(x => x.Name == name);
            if (ing != null)
            {
                Ingredients.Remove(ing);
                return true;
            }
            return false;
        }

        public Ingredient FindIngredient(string name) => Ingredients.FirstOrDefault(x => x.Name == name);

        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredient ing = null;
            foreach (var item in Ingredients)
            {
                if (ing == null)
                {
                    ing = item;
                    continue;
                }
                if (ing.Alcohol < item.Alcohol)
                {
                    ing = item;
                }
            }
            return ing;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} -Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in Ingredients)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
