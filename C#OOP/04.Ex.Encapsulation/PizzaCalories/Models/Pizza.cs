using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private const string INVALID_PIZZA_NAME_EXC_MSG = "Pizza name should be between 1 and 15 symbols.";
        private const string INVALID_NUMBER_OF_TOPPINGS_EXC_MSG = "Number of toppings should be in range [0..10].";
        private const int MAX_TOPPINGS = 10;

        private string name;
        private Dough dough;
        private ICollection<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException(INVALID_PIZZA_NAME_EXC_MSG);
                }
                name = value;
            }
        }
        public Dough Dough
        {
            get
            {
                return dough;
            }
            private set
            {
                dough = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == MAX_TOPPINGS)
            {
                throw new ArgumentException(INVALID_NUMBER_OF_TOPPINGS_EXC_MSG);
            }
            toppings.Add(topping);
        }

        public double TotalCalories()
        {
            double totalCalories = Dough.CalculateDoughTotalCalories();
            foreach (var topping in toppings)
            {
                totalCalories += topping.CalculateToppingCalories();
            }
            return totalCalories;
        }
    }
}
