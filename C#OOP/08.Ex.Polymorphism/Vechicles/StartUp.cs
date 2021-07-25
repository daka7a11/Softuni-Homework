using System;

namespace Vechicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            double fuelQunatity = double.Parse(input[1]);
            double litersPerKm = double.Parse(input[2]);
            double tankCapacity = double.Parse(input[3]);

            Car car = new Car(fuelQunatity, litersPerKm, tankCapacity);

            input = Console.ReadLine().Split();

            fuelQunatity = double.Parse(input[1]);
            litersPerKm = double.Parse(input[2]);
            tankCapacity = double.Parse(input[3]);

            Truck truck = new Truck(fuelQunatity, litersPerKm, tankCapacity);

            input = Console.ReadLine().Split();

            fuelQunatity = double.Parse(input[1]);
            litersPerKm = double.Parse(input[2]);
            tankCapacity = double.Parse(input[3]);

            Bus bus = new Bus(fuelQunatity, litersPerKm, tankCapacity);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    input = Console.ReadLine().Split();
                    double distance = double.Parse(input[2]);
                    if (input[0].ToLower() == "drive")
                    {
                        if (input[1].ToLower() == "car")
                        {
                            Console.WriteLine(car.Drive(distance));
                        }
                        else if (input[1].ToLower() == "truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                        else if (input[1].ToLower() == "bus")
                        {
                            Console.WriteLine(bus.Drive(distance));
                        }
                    }
                    else if (input[0].ToLower() == "refuel")
                    {
                        double liters = double.Parse(input[2]);
                        if (input[1].ToLower() == "car")
                        {
                            car.Refuel(liters);
                        }
                        else if (input[1].ToLower() == "truck")
                        {
                            truck.Refuel(liters);
                        }
                        else if (input[1].ToLower() == "bus")
                        {
                            bus.Refuel(liters);
                        }
                    }
                    else if (input[0].ToLower() == "driveempty")
                    {
                        Console.WriteLine(bus.DriveEmpty(distance));
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
