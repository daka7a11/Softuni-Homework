using System;
using System.Collections.Generic;

namespace _5._Vehicle_Catalogue
{
    public class Vehicle
    {
        public Vehicle(string type, string model, string color,int horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            List<Vehicle> vehicles = new List<Vehicle>();
            while (input[0].ToLower()!="end")
            {
                Vehicle currVehicle = new Vehicle(input[0].ToLower(),input[1],input[2].ToLower(),int.Parse(input[3]));
                vehicles.Add(currVehicle);
                input = Console.ReadLine().Split();
            }
            string command = Console.ReadLine();
            while (command.ToLower()!="close the catalogue")
            {
                foreach (Vehicle x in vehicles)
                {
                    if (x.Model==command)
                    {
                        if (x.Type=="car")
                        {
                            Console.WriteLine($"Type: Car \nModel: {x.Model} \nColor: {x.Color} \nHorsepower: {x.HorsePower}");
                        }
                        else if (x.Type=="truck")
                        {
                            Console.WriteLine($"Type: Truck \nModel: {x.Model} \nColor: {x.Color} \nHorsepower: {x.HorsePower}");
                        }
                    }
                }
                command = Console.ReadLine();
            }
            double avgCarsHp = 0;
            int carCount = 0;
            double avgTrucksHp = 0;
            int truckCount = 0;
            foreach (Vehicle x in vehicles)
            {
                if (x.Type.ToLower()=="car")
                {
                    carCount++;
                    avgCarsHp += x.HorsePower;
                }
                else if (x.Type.ToLower()=="truck")
                {
                    truckCount++;
                    avgTrucksHp += x.HorsePower;
                }
            }
            if (avgCarsHp>0)
            {
            avgCarsHp /= carCount;
            }
            if (avgTrucksHp>0)
            {
            avgTrucksHp /= truckCount;
            }
            if (carCount>0)
            {
            Console.WriteLine($"Cars have average horsepower of: {avgCarsHp:F2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:F2}.");
            }
            if (truckCount>0)
            {
            Console.WriteLine($"Trucks have average horsepower of: {avgTrucksHp:F2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:F2}.");
            }
        }
    }
}
