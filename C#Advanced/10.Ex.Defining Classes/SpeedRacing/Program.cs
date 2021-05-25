using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKm = double.Parse(input[2]);
                cars.Add(new Car { Model = model, FuelAmount = fuelAmount, FuelConsumptionPerKilometer = fuelConsumptionPerKm });
            }
            string[] command = Console.ReadLine().Split();
            while (command[0].ToLower() != "end")
            {
                string model = command[1];
                double amountOfKm = double.Parse(command[2]);
                Car.Drive(cars,model,amountOfKm);
                command = Console.ReadLine().Split();
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TrevelledDistance}");
            }
        }
    }
}
