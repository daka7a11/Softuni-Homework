using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private List<Person> persons;
        private List<Product> products;
        public Engine()
        {
            persons = new List<Person>();
            products = new List<Product>();
        }
        public void Run()
        {
            try
            {
                GetPeopleInput();

                GetProductInput();

                string[] purchaseArgs = Console.ReadLine().Split(' ');
                while (purchaseArgs[0] != "END")
                {
                    string personName = purchaseArgs[0];
                    string productName = purchaseArgs[1];

                    Person person = persons.FirstOrDefault(x => x.Name == personName);
                    Product product = products.FirstOrDefault(x => x.Name == productName);

                    Console.WriteLine(person.BuyProduct(product));

                    purchaseArgs = Console.ReadLine().Split(' ');
                }
                foreach (var person in persons)
                {
                    Console.Write($"{person} - ");
                    if (person.Bag.Count > 0)
                    {
                        Console.WriteLine(String.Join(", ", person.Bag));
                    }
                    else
                    {
                        Console.WriteLine("Nothing bought");
                    }
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
        private void GetPeopleInput()
        {
            string[] peopleArgs = Console.ReadLine()
                .Split(";");
            foreach (var personStr in peopleArgs)
            {
                string[] personArgs = personStr.Split("=");

                string personName = personArgs[0];
                decimal personMoney = default;
                decimal.TryParse(personArgs[1], out personMoney);

                Person person = new Person(personName, personMoney);
                persons.Add(person);
            }
        }
        private void GetProductInput()
        {
            string[] productsArgs = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var productStr in productsArgs)
            {
                string[] productArgs = productStr.Split("=");
                string productName = productArgs[0];
                decimal productCost = default;
                decimal.TryParse(productArgs[1], out productCost);
                Product product = new Product(productName, productCost);
                products.Add(product);
            }
        }
    }
}
