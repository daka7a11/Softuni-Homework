using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int power = int.Parse(input[1]);
                int displacement = -1;
                string efficiency = "n/a";
                if (input.Length == 3)
                {
                    if (int.TryParse(input[2], out int a))
                    {
                        displacement = int.Parse(input[2]);
                    }
                    else
                    {
                        efficiency = input[input.Length - 1];
                    }
                }
                if (input.Length == 4)
                {
                    displacement = int.Parse(input[2]);
                    efficiency = input[input.Length - 1];
                }
                engines.Add(new Engine(model, power, displacement, efficiency));
            }
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                string engineModel = input[1];
                int weight = -1;
                string color = "n/a";
                if (input.Length == 3)
                {
                    if (int.TryParse(input[2], out int a))
                    {
                        weight = int.Parse(input[2]);
                    }
                    else
                    {
                        color = input[input.Length - 1];
                    }
                }
                if (input.Length == 4)
                {
                    weight = int.Parse(input[2]);
                    color = input[input.Length - 1];
                }
                Engine engine = engines.Find(x => x.Model == engineModel);
                cars.Add(new Car(model, engine, weight, color));
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
