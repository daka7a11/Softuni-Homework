using System;
using System.Collections.Generic;

namespace _3._Speed_Racing
{
    public class Car
    {
        public Car()
        {

        }
        public Car (string model, int fuelAmount, double fuelConsumationPerKM)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumationPerKM = fuelConsumationPerKM;
            this.TraveledDistance = 0;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumationPerKM { get; set; }
        public double TraveledDistance { get; set; }
        public void MoveTheCar(string model, int amountOfKm,List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Model==model)
                {
                    if ((amountOfKm*cars[i].FuelConsumationPerKM)>cars[i].FuelAmount)
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                    else
                    {
                        cars[i].FuelAmount -= (amountOfKm * cars[i].FuelConsumationPerKM);
                        cars[i].TraveledDistance += amountOfKm;
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>(n);
            for (int i = 0; i < n; i++)
            {
                string[] initializesCars = Console.ReadLine().Split();
                Car currCar = new Car(initializesCars[0], int.Parse(initializesCars[1]), double.Parse(initializesCars[2]));
                cars.Add(currCar);
            }
            string[] input = Console.ReadLine().Split();
            while (input[0].ToLower()!="end")
            {
                Car car = new Car();
                car.MoveTheCar(input[1],int.Parse(input[2]),cars);
                input = Console.ReadLine().Split();
            }
            foreach (Car x in cars)
            {
                Console.WriteLine($"{x.Model} {x.FuelAmount:F2} {x.TraveledDistance}");
            }
        }
    }
}
