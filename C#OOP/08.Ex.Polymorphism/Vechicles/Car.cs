using System;
using System.Collections.Generic;
using System.Text;

namespace Vechicles
{
    public class Car : Vechicle
    {
        public Car(double fuelQuantity, double consumptionLitersPerKm, double tankCapacity) 
            : base(fuelQuantity, consumptionLitersPerKm, tankCapacity)
        {
            FuelQuantity = fuelQuantity > TankCapacity ? 0 : fuelQuantity;

        }

        public override double FuelConsumptionLPerKm => base.FuelConsumptionLPerKm + 0.9;
    }
}
