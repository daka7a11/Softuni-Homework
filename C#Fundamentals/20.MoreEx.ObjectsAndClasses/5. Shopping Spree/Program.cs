using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Shopping_Spree
{
    public class Person
    {
        public Person ()
        {
            this.BagOfProducts = new List<Product>();
        }
        public string Name { get; set; }
        public int Money { get; set; }
        public List<Product> BagOfProducts { get; set; }

    }
    public class Product
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public Product GetProduct(string nameOfProduct,List<Product> products)
        {
            Product selectedProduct = new Product();
            foreach (Product x in products)
            {
                if (x.Name==nameOfProduct)
                {
                    selectedProduct = x;
                }
            }
            return selectedProduct;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<Person> persons = new List<Person>();
            for (int i = 0; i < input.Count; i++)
            {
                string[] personsAndMoney = input[i].Split("=");
                Person currPerson = new Person();
                currPerson.Name = personsAndMoney[0];
                currPerson.Money = int.Parse(personsAndMoney[1]);
                persons.Add(currPerson);
            }
            input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<Product> products = new List<Product>();
            for (int i = 0; i < input.Count; i++)
            {
                string[] productsAndCosts = input[i].Split("=");
                Product currProduct = new Product();
                currProduct.Name = productsAndCosts[0];
                currProduct.Cost = int.Parse(productsAndCosts[1]);
                products.Add(currProduct);
            }
            string[] command = Console.ReadLine().Split();
            while (command[0].ToLower()!="end")
            {
                string person = command[0];
                string productToBuy = command[1];
                Product selectedProduct = new Product();
                selectedProduct = selectedProduct.GetProduct(productToBuy,products);
                foreach (Person x in persons)
                {
                    if (x.Name==person)
                    {
                        if (x.Money-selectedProduct.Cost>=0)
                        {
                            x.BagOfProducts.Add(selectedProduct);
                            Console.WriteLine($"{x.Name} bought {selectedProduct.Name}");
                            x.Money -= selectedProduct.Cost;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{x.Name} can't afford {selectedProduct.Name}");
                            break;
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }
            foreach (Person x in persons)
            {
                if (x.BagOfProducts.Count>0)
                {
                    Console.Write($"{x.Name} - ");
                    for (int i = 0; i < x.BagOfProducts.Count; i++)
                    { 
                        if (i+1==x.BagOfProducts.Count)
                        {
                            Console.Write($"{x.BagOfProducts[i].Name}");
                        }
                        else
                        {
                        Console.Write($"{x.BagOfProducts[i].Name}, ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{x.Name} - Nothing bought");
                }
                Console.WriteLine();
            }
        }
    }
}
