using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model,Engine engine)
        {
            Model = model;
            Engine = engine;
        }
        public Car(string model, Engine engine,int weight) : this(model,engine)
        {
            Weight = weight;
        }
        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            Color = color;
        }
        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            string result = $"{Model}:{Environment.NewLine}";
            result += $" {Engine.Model}:{Environment.NewLine}";
            result += $"  Power: {Engine.Power}{Environment.NewLine}";
            if (Engine.Displacement != -1)
            {
               result+= $"  Displacement: {Engine.Displacement}{Environment.NewLine}";
            }
            else
            {
                result+= $"  Displacement: n/a{Environment.NewLine}";
            }
            result += $"  Efficiency: {Engine.Efficiency}{Environment.NewLine}";
            if (Weight != -1)
            {
                result+= $" Weight: {Weight}{Environment.NewLine}";
            }
            else
            {
                result+= $" Weight: n/a{Environment.NewLine}";
            }
            result += $" Color: {Color}";
            return result;
        }
    }
}
