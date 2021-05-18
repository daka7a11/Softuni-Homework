using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            string input = Console.ReadLine();
            while (input.ToLower() != "no more tires")
            {
                string[] splitedInput = input.Split();
                int year = int.Parse(splitedInput[0]);
                double pressure = double.Parse(splitedInput[1]);
                Tire[] tireComplect = new Tire[splitedInput.Length/2];
                int count = 0;
                for (int i = 1; i < splitedInput.Length; i+=2)
                {
                    tireComplect[count] = new Tire (int.Parse(splitedInput[i-1]),double.Parse(splitedInput[i]) );
                    count++;
                }
                tires.Add(tireComplect);

                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input.ToLower() != "engines done")
            {
                string[] splitedInput = input.Split();
                int horsePower = int.Parse(splitedInput[0]);
                double cubicCapacity = double.Parse(splitedInput[1]);
                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);

                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input.ToLower() != "show special")
            {
                string[] splitedInput = input.Split();
                string make = splitedInput[0];
                string model = splitedInput[1];
                int year = int.Parse(splitedInput[2]);
                double fuelQuantity = int.Parse(splitedInput[3]);
                double fuelConsumption = int.Parse(splitedInput[4]);
                int engineIndex = int.Parse(splitedInput[5]);
                int tiresIndex = int.Parse(splitedInput[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);
                input = Console.ReadLine();
            }
            List<Car> specialCars = new List<Car>();
            foreach (var car in cars)
            {
                if (car.Year >= 2017)
                {
                    if (car.Engine.HorsePower > 330)
                    {
                        double totalTiresPressure = GetTiresPressureSum(car.Tires);
                        if (totalTiresPressure >= 9 && totalTiresPressure <= 10)
                        {
                            specialCars.Add(car);
                        } 
                    }
                }
            }
            foreach (var specialCar in specialCars)
            {
                Console.WriteLine($"Make: { specialCar.Make}\nModel: {specialCar.Model}\nYear: {specialCar.Year}\n" +
                    $"HorsePowers: {specialCar.Engine.HorsePower}\nFuelQuantity: {specialCar.FuelQuantity}");
            }
        }
        static double GetTiresPressureSum(Tire[] arr)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i].Pressure;
            }
            return sum;
        }
    }
}
