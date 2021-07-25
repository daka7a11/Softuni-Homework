using System;
namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override double WeightIncrease(int quantity)
        {
            return 0.10 * quantity;
        }
        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                IncreaseWeightAndFoodEaten(WeightIncrease(food.Quantity),food.Quantity);
            }
            else
            {
                throw new ArgumentException(String.Format(GlobalConstants.AnimalDoesNotEat_Exc_Msg,GetType().Name,food.GetType().Name));
            }
        }
    }
}
