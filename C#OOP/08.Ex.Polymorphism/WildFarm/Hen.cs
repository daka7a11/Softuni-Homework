
namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override double WeightIncrease(int quantity)
        {
            return 0.35 * quantity;
        }
        public override void Eat(Food food)
        {
            IncreaseWeightAndFoodEaten(WeightIncrease(food.Quantity), food.Quantity);
        }
    }
}
