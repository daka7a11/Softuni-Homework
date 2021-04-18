using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Vehicle_Catalogue
{
    class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

    }
    class Car
    {
        public Car(string brand, string model, int horsePower)
        {
            this.Brand = brand;
            this.Model = model;
            this.HorsePower = horsePower;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class CatalogVehicle
    {
        public CatalogVehicle()
        {
            Trucks = new List<Truck>();
            Cars = new List<Car>();
        }
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
    }
    class Program
    {
        static void Main(string[] args)//{type}/{brand}/{model}/{horse power / weight}
        {
            string[] input = Console.ReadLine().Split("/");
            List<Truck> currListOfTrucks = new List<Truck>();
            List<Car> currListOfCars = new List<Car>();
            CatalogVehicle catalogVehicle = new CatalogVehicle();
            while (input[0].ToLower() != "end")
            {
                if (input[0].ToLower() == "truck")
                {
                    Truck currVehicle = new Truck(input[1], input[2], int.Parse(input[3]));
                    catalogVehicle.Trucks.Add(currVehicle);
                }
                else if (input[0].ToLower() == "car")
                {
                    Car currVehicle = new Car(input[1], input[2], int.Parse(input[3]));
                    catalogVehicle.Cars.Add(currVehicle);
                }
                input = Console.ReadLine().Split("/");
            }
            if (catalogVehicle.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in catalogVehicle.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalogVehicle.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in catalogVehicle.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}
