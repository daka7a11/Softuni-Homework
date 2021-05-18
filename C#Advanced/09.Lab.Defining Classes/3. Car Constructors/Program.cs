using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car firstCar = new Car();
            Car secondCar = new Car("VW","Golf",2005);
            Car thirdCar = new Car("VW","Golf",2008,80,8);
        }
    }
}
