using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _6._Store_Boxes
{
    class Box
    {
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PricePerBox { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<Box> listOfBoxes = new List<Box>();
            while (input[0].ToLower() != "end")
            {
                Box currBox = new Box();
                currBox.SerialNumber = input[0];
                currBox.Name = input[1];
                currBox.ItemQuantity = int.Parse(input[2]);
                currBox.Price = decimal.Parse(input[3]);
                currBox.PricePerBox = currBox.ItemQuantity * currBox.Price;
                listOfBoxes.Add(currBox);
                input = Console.ReadLine().Split();
            }
            listOfBoxes=listOfBoxes.OrderBy(x => x.PricePerBox).Reverse().ToList();
            foreach (var item in listOfBoxes)
            {
                Console.WriteLine(item.SerialNumber);
                Console.WriteLine($"-- {item.Name} - ${item.Price:F2}: {item.ItemQuantity}");
                Console.WriteLine($"-- ${item.PricePerBox:F2}");
            }
        }
    }
}
