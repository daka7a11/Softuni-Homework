using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        public Tire(int year, double pressure)
        {
            Pressure = pressure;
            Year = year;
        }

        public int Year { get; set; }
        public double Pressure { get; set; }
    }
}
