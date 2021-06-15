using System;
namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RaceMotorcycle motor = new RaceMotorcycle(500, 200);
            motor.Drive(10);
        }
    }
}
