using System;
using PizzaCalories.Core;
using PizzaCalories.Models;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
