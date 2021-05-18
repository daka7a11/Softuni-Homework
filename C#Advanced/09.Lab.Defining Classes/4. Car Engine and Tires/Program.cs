using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Tire[] tires = new Tire[4]
                {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 3.1),
                new Tire(2, 2.5),
                };
            Engine engine = new Engine(500, 5000);

            Car car = new Car("Lamborghini", "Urus", 2020, 250, 9, engine, tires);

        }
    }
}
