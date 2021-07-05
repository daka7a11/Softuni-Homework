using System;
namespace PizzaCalories.Models
{
    public class Dough
    {
        private const double BASE_CALORIES_PER_GRAM = 2.0;
        private const string INVALID_FLOUR_TYPE_EXC_MSG = "Invalid type of dough.";
        private const string INVALID_DOUGH_WEIGHT_EXC_MSG = "Dough weight should be in the range [1..200].";

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return flourType;
            }
            private set
            {
                if (!(value.ToLower() == "white" || value.ToLower() == "wholegrain"))
                {
                    throw new ArgumentException(INVALID_FLOUR_TYPE_EXC_MSG);
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            private set
            {
                if (!(value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade"))
                {
                    throw new ArgumentException(INVALID_FLOUR_TYPE_EXC_MSG);
                }
                bakingTechnique = value;
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
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(INVALID_DOUGH_WEIGHT_EXC_MSG);
                }
                weight = value;
            }
        }

        public double CalculateDoughTotalCalories()
        {
            double flourCalories = GetFlourCalories();
            double bakingCalories = GetBackingTechniqueCalories();
            return (BASE_CALORIES_PER_GRAM * weight) * flourCalories * bakingCalories;
        }
        private double GetFlourCalories()
        {
            if (flourType.ToLower() == "white")
            {
                return 1.5;
            }
            else if (flourType.ToLower() == "wholegrain")
            {
                return 1.0;
            }
            else
            {
                throw new ArgumentException(INVALID_FLOUR_TYPE_EXC_MSG);
            }
        }
        private double GetBackingTechniqueCalories()
        {
            if (bakingTechnique.ToLower() == "crispy")
            {
                return 0.9;
            }
            else if (bakingTechnique.ToLower() == "chewy")
            {
                return 1.1;
            }
            else if (bakingTechnique.ToLower() == "homemade")
            {
                return 1.0;
            }
            else
            {
                throw new ArgumentException(INVALID_FLOUR_TYPE_EXC_MSG);
            }
        }
    }
}
