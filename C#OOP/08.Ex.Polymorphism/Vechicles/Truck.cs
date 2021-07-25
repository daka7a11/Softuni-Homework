using System;
using System.Collections.Generic;
using System.Text;

namespace Vechicles
{
    public class Truck : Vechicle
    {
        public Truck(double fuelQuantity, double consumptionLitersPerKm, double tankCapacity) 
            : base(fuelQuantity, consumptionLitersPerKm, tankCapacity)
        {
            FuelQuantity = fuelQuantity > TankCapacity ? 0 : fuelQuantity;

        }

        public override double FuelConsumptionLPerKm => base.FuelConsumptionLPerKm + 1.6;
        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException(String.Format(GlobalConstants.Invalid_Fuel));
            }
            if (FuelQuantity + liters <= TankCapacity)
            {
                FuelQuantity += liters;
            }
            else
            {
                throw new ArgumentException(String.Format(GlobalConstants.Cannot_Fit_Liters_Exc_Msg, liters));
            }
        }
    }
}
