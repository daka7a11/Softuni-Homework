using System;

namespace Vechicles
{
    public abstract class Vechicle
    {
        private double fuelQuantity;
        protected Vechicle(double fuelQuantity, double consumptionLitersPerKm, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity > TankCapacity ? 0 : fuelQuantity;
            FuelConsumptionLPerKm = consumptionLitersPerKm;
        }
        public virtual double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                    fuelQuantity = value;
            }
        }
        public virtual double FuelConsumptionLPerKm { get; set; }
        public double TankCapacity { get; set; }

        public virtual string Drive(double distance)
        {
            if (FuelQuantity >= FuelConsumptionLPerKm * distance)
            {
                FuelQuantity -= FuelConsumptionLPerKm * distance;
                return $"{GetType().Name} travelled {distance} km";
            }
            else
            {
                throw new ArgumentException(String.Format(GlobalConstants.Need_Refueling_Exc_Msg,GetType().Name));
            }
        }
        public virtual void Refuel(double liters)
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
        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
