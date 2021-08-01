
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("VW", "Golf", 5, 50)]
        public void CarConstructorShouldWorkCorrectly(
            string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act - Assert
            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
            Assert.AreEqual(car.FuelAmount, 0);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void MakeSetterShouldThrowExceptionIfMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "Golf", 5, 50));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ModelSetterShouldThrowExceptionIfModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("VW", model, 5, 50));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumptionSetterShouldThrowExceptionIfValueIsBellowOrZero(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("VW", "Golf", fuelConsumption, 50));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelCapacitySetterShouldThrowExceptionIfValueIsBellowOrZero(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("VW", "Golf", 5, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelShouldThrowExceptionIfFuelIsBellowOrZero(double fuel)
        {
            //Arrange
            Car car = new Car("VW", "Golf", 10, 100);

            //Act - Assert
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        [TestCase(100, 500, 100)]
        [TestCase(50, 5, 5)]
        public void RefuelShouldWorkCorrectly(double fuelCapacity, double fuel, double expectedResult)
        {
            //Arrange
            Car car = new Car("VW", "Golf", 10, fuelCapacity);

            //Act
            car.Refuel(fuel);

            //Assert
            double actualResult = car.FuelAmount;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(10, 10, 101)]
        [TestCase(10, 20, 220)]
        public void DriveShouldThrowExceptionIfFuelNotEnough(double fuelConsumption, double fuel, double km)
        {
            //Arrange
            Car car = new Car("VW", "Golf", fuelConsumption, 100);
            car.Refuel(fuel);

            //Act-/Assert
            Assert.Throws<InvalidOperationException>(() => car.Drive(km));
        }

        [Test]
        [TestCase(10, 50, 200, 30)]
        [TestCase(10, 100, 500, 50)]
        [TestCase(10, 20, 100, 10)]

        public void DriveShouldWorkCorrectly(double fuelConsumption, double fuel, double km, double expectedResult)
        {
            //Arrange
            Car car = new Car("VW", "Golf", fuelConsumption, 100);
            car.Refuel(fuel);

            //Act
            car.Drive(km);

            //Assert
            double actualResult = car.FuelAmount;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}