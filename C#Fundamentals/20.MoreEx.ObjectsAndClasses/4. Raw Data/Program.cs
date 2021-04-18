using System;
using System.Collections.Generic;

namespace _4._Raw_Data
{
    public class Car
    {
        public Car()
        {
            this.Engine = new Engine();
            this.Cargo = new Cargo();
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
    }
    public class Engine
    {
        public Engine()
        {

        }
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }
    public class Cargo
    {
        public Cargo ()
        {

        }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>(n);
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Car currCar = new Car();
                currCar.Model = input[0];
                currCar.Engine.EngineSpeed = int.Parse(input[1]);
                currCar.Engine.EnginePower = int.Parse(input[2]);
                currCar.Cargo.CargoWeight = int.Parse(input[3]);
                currCar.Cargo.CargoType = input[4];
                cars.Add(currCar);
            }
            string command = Console.ReadLine();
            if (command=="fragile")
            {
                foreach (Car x in cars)
                {
                    if (x.Cargo.CargoType=="fragile")
                    {
                        if (x.Cargo.CargoWeight<1000)
                        {
                            Console.WriteLine(x.Model);
                        }
                    }
                }
            }
            else if (command=="flamable")
            {
                foreach (Car x in cars)
                {
                    if (x.Cargo.CargoType=="flamable")
                    {
                        if (x.Engine.EnginePower>250)
                        {
                            Console.WriteLine(x.Model);
                        }
                    }
                }
            }
        }
    }
}
