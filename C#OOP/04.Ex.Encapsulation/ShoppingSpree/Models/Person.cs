using System;
using System.Collections.Generic;
using ShoppingSpree.Common;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private const string NOT_ENOUGHT_MONEY_MSG = "{0} can't afford {1}";
        private const string SUCC_BOUGHT_PRODUCT_MSG = "{0} bought {1}";

        private string name;
        private decimal money;
        private readonly ICollection<Product> bag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
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
        public decimal Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.NEGATIVE_MONEY_EXC_MSG);
                }
                money = value;
            }
        }
        public IReadOnlyCollection<Product> Bag
        {
            get
            {
                return (IReadOnlyCollection<Product>)bag;
            }
        }

        public string BuyProduct(Product product)
        {
            if (Money < product.Cost)
            {
                return String.Format(NOT_ENOUGHT_MONEY_MSG, Name, product.Name);
            }
            Money -= product.Cost;
            bag.Add(product);
            return String.Format(SUCC_BOUGHT_PRODUCT_MSG,Name,product.Name);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
