﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }
        public int Count => this.cars.Count;
        public string AddCar(Car car)
        {
            if (cars.Any(x => x.RegistrationNumber==car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count>=capacity)
            {
               return $"Parking is full!";
            }
            else
            {
                cars.Add(car);
               return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
            if (car==null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.Remove(car);
                return $"Successfully removed {registrationNumber}";
            }
        }
        public Car GetCar(string registratioNumber)
        {
            return cars.FirstOrDefault(x => x.RegistrationNumber == registratioNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNumber in registrationNumbers)
            {
                Car car = cars.FirstOrDefault(x => x.RegistrationNumber == regNumber);
                if (car != null)
                {
                    cars.Remove(car);
                }
            }
        }
    }
}
