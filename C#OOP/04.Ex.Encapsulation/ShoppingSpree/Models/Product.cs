using System;
using ShoppingSpree.Common;

namespace ShoppingSpree.Models
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException(GlobalConstants.EMPTY_NAME_EXC_MSG);
                }
                name = value;
            }
        }
        public decimal Cost
        {
            get
            {
                return cost;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.NEGATIVE_MONEY_EXC_MSG);
                }
                cost = value;
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
