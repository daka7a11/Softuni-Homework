using System;
using System.Collections.Generic;
using System.Text;

namespace Vechicles
{
    public class Bus : Vechicle
    {
        public Bus(double fuelQuantity, double consumptionLitersPerKm, double tankCapacity)
            : base(fuelQuantity, consumptionLitersPerKm, tankCapacity)
        {
            FuelQuantity = fuelQuantity > TankCapacity ? 0 : fuelQuantity;

        }
        public override string Drive(double distance)
        {
            if (FuelQuantity >= (FuelConsumptionLPerKm + 1.4) * distance)
            {
                FuelQuantity -= (FuelConsumptionLPerKm + 1.4) * distance;
                return $"{GetType().Name} travelled {distance} km";
            }
            else
            {
                throw new ArgumentException(String.Format(GlobalConstants.Need_Refueling_Exc_Msg, GetType().Name));
            }
        }
        public string DriveEmpty(double distance)
        {
            return base.Drive(distance);
        }
    }
}
