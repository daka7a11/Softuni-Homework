using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string[] animalInput = Console.ReadLine().Split();
            while (animalInput[0].ToLower() != "end")
            {
                string animalType = animalInput[0].ToLower();
                string animalName = animalInput[1];
                double animalWeight = double.Parse(animalInput[2]);

                Animal animal = null;

                if (animalType == "hen")
                {
                    double wingSize = double.Parse(animalInput[3]);

                    animal = new Hen(animalName, animalWeight, wingSize);
                }
                else if (animalType == "owl")
                {
                    double wingSize = double.Parse(animalInput[3]);

                    animal = new Owl(animalName, animalWeight, wingSize);
                }
                else if (animalType == "mouse")
                {
                    string livingRegion = animalInput[3];

                    animal = new Mouse(animalName, animalWeight, livingRegion);
                }
                else if (animalType == "cat")
                {
                    string livingRegion = animalInput[3];
                    string breed = animalInput[4];

                    animal = new Cat(animalName, animalWeight, livingRegion, breed);
                }
                else if (animalType == "dog")
                {
                    string livingRegion = animalInput[3];

                    animal = new Dog(animalName, animalWeight, livingRegion);
                }
                else if (animalType == "tiger")
                {
                    string livingRegion = animalInput[3];
                    string breed = animalInput[4];

                    animal = new Tiger(animalName, animalWeight, livingRegion, breed);
                }
                Console.WriteLine(animal.ProduceSound());

                string[] foodInput = Console.ReadLine().Split();

                string foodType = foodInput[0].ToLower();
                int foodQuantity = int.Parse(foodInput[1]);

                Food food = null;

                if (foodType == "vegetable")
                {
                    food = new Vegetable(foodQuantity);
                }
                else if (foodType == "fruit")
                {
                    food = new Fruit(foodQuantity);
                }
                else if (foodType == "meat")
                {
                    food = new Meat(foodQuantity);
                }
                else if (foodType == "seeds")
                {
                    food = new Seeds(foodQuantity);
                }

                animals.Add(animal);

                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                animalInput = Console.ReadLine().Split();
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

    }
}

