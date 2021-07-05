using System;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const double BASE_CALORIES_PER_GRAM = 2.0;
        private const string INVALID_TOPPING_TYPE_EXC_MSG = "Cannot place {0} on top of your pizza.";
        private const string INVALID_TOPPING_WEIGHT_EXC_MSG = "{0} weight should be in the range [1..50].";

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }
        public string Type
        {
            get
            {
                return type;
            }
            private set
            {
                if (!(value.ToLower() == "meat" 
                    || value.ToLower() == "veggies" 
                    || value.ToLower() == "cheese"
                    || value.ToLower() == "sauce"))
                {
                    throw new ArgumentException(String.Format(INVALID_TOPPING_TYPE_EXC_MSG,value));
                }
                type = value;
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(String.Format(INVALID_TOPPING_WEIGHT_EXC_MSG,type));
                }
                weight = value;
            }
        }

        public double CalculateToppingCalories()
        {
            double toppingTypeCalories = GetTypeCalories();
            return (BASE_CALORIES_PER_GRAM * toppingTypeCalories) * weight;
        }
        private double GetTypeCalories()
        {
            if (type.ToLower() == "meat")
            {
                return 1.2;
            }
            else if (type.ToLower() == "veggies")
            {
                return 0.8;
            }
            else if (type.ToLower() == "cheese")
            {
                return 1.1;
            }
            else if (type.ToLower() == "sauce")
            {
                return 0.9;
            }
            else
            {
                throw new ArgumentException(String.Format(INVALID_TOPPING_TYPE_EXC_MSG, type));
            }
        }
    }
}
