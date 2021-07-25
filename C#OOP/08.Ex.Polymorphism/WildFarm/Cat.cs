
namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }
        public override string ProduceSound()
        {
            return "Meow";
        }

        public override double WeightIncrease(int quantity)
        {
            return 0.30 * quantity;
        }
        public override void Eat(Food food)
        {
            if (food is Vegetable)
            {
                IncreaseWeightAndFoodEaten(WeightIncrease(food.Quantity), food.Quantity);
            }
            else
            {
                base.Eat(food);
            }
        }
    }
}
