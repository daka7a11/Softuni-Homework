using PizzaCalories.Models;
using System;

namespace PizzaCalories.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] input = Console.ReadLine().Split(' ');
            string pizzaName = input[1];
            input = Console.ReadLine().Split(' ');
            try
            {
                string doughFlourType = input[1];
                string doughBakingTechnique = input[2];
                double doughWeight = double.Parse(input[3]);

                Dough dough = new Dough(doughFlourType, doughBakingTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                while ((input = Console.ReadLine().Split(' '))[0].ToLower() != "end")
                {
                        string toppingType = input[1];
                        double toppingWeight = double.Parse(input[2]);

                        Topping topping = new Topping(toppingType, toppingWeight);

                        pizza.AddTopping(topping);
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():F2} Calories.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
