
using System;

namespace WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public abstract string ProduceSound();
        public abstract double WeightIncrease(int quantity);
        public virtual void Eat(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += WeightIncrease(food.Quantity);
            }
            else
            {
                throw new ArgumentException(String.Format(GlobalConstants.AnimalDoesNotEat_Exc_Msg, GetType().Name, food.GetType().Name));
            }
        }
        protected void IncreaseWeightAndFoodEaten(double weight, int quantity)
        {
            Weight += weight;
            FoodEaten += quantity;
        }
    }
}
