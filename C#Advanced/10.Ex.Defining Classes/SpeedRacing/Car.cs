using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double  TrevelledDistance { get; set; }

        public static void Drive(List<Car> cars ,string model, double distance)
        {
            foreach (var car in cars)
            {
                if (car.Model==model)
                {
                    if (car.FuelConsumptionPerKilometer*distance>car.FuelAmount)
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                    else
                    {
                        car.FuelAmount -= car.FuelConsumptionPerKilometer * distance;
                        car.TrevelledDistance += distance;
                    }
                }
            }
        }
    }
}
