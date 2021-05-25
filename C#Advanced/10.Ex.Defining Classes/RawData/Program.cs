using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
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
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
             // double tire1Pressure = double.Parse(input[5]);
             // int tire1Age = int.Parse(input[6]);
             // double tire2Pressure = double.Parse(input[7]);
             // int tire2Age = int.Parse(input[8]);
             // double tire3Pressure = double.Parse(input[9]);
             // int tire3Age = int.Parse(input[10]);
             // double tire4Pressure = double.Parse(input[11]);
             // int tire4Age = int.Parse(input[12]);

                Engine engine = new Engine { Speed = engineSpeed, Power = enginePower };
                Cargo cargo = new Cargo { Weight=cargoWeight, Type=cargoType};
                List<Tire> tires = new List<Tire>();
                for (int j = 5; j < input.Length; j+=2)
                {
                    double pressure = double.Parse(input[j]);
                    int age = int.Parse(input[j + 1]);
                    tires.Add(new Tire { Pressure=pressure,Age=age});
                }
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            string command = Console.ReadLine();
            if (command.ToLower()=="fragile")
            {
                foreach (var car in cars.Where(x => x.Cargo.Type=="fragile"))
                {
                    bool IsTireLessThanOne = false;
                    foreach (var tire in car.Tires)
                    {
                        if (tire.Pressure<1)
                        {
                            IsTireLessThanOne = true;
                            break;
                        }
                    }
                    if (IsTireLessThanOne)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if(command.ToLower()=="flamable")
            {
                foreach (var car in cars.Where(x => x.Cargo.Type=="flamable").Where(x => x.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
