using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string animalType = Console.ReadLine();
            while (animalType != "Beast!")
            {
                string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = 0;
                int.TryParse(info[1], out age);
                string gender = info[2];
                if (age > 0)
                {
                    if (gender == "Male" || gender == "Female")
                    {
                        switch (animalType)
                        {
                            case "Dog":
                                animals.Add(new Dog(name, age, gender));
                                break;
                            case "Cat":
                                animals.Add(new Cat(name, age, gender));
                                break;
                            case "Frog":
                                animals.Add(new Frog(name, age, gender));
                                break;
                            case "Kitten":
                                animals.Add(new Kitten(name, age, gender));
                                break;
                            case "Tomcat":
                                animals.Add(new Tomcat(name, age, gender));
                                break;
                            default:
                                Console.WriteLine("Invalid input!");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                animalType = Console.ReadLine();
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}

