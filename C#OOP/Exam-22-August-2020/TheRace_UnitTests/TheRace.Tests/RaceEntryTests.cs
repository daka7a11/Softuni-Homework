using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        public UnitDriver unitDriver;
        public UnitCar unitCar;
        public RaceEntry race;


        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
            unitCar = new UnitCar("A", 100, 2000);
            unitDriver = new UnitDriver("Ivan", unitCar);
        }

        [Test]
        public void RaceEntryConstructorShouldInitializeEmptyDictionary()
        {
            //Act-Assert
            Assert.AreEqual(0, race.Counter);
        }

        [Test]
        [TestCase(null)]
        public void AddDriverShouldThrowExceptionWhenDriverIsNull(UnitDriver driver)
        {
            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }

        [Test]
        public void AddDriverShouldThrowExceptionWhenDriverExists()
        {
            //Act
            race.AddDriver(unitDriver);
            var driver = new UnitDriver("Ivan", new UnitCar("a", 50, 100));

            //Assert
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }

        [Test]
        public void AddDriverShouldWorkCorrectly()
        {
            //Act
            var expectedMessage = $"Driver {unitDriver.Name} added in race.";
            var actualMessage = race.AddDriver(unitDriver);

            //Assert
            Assert.AreEqual(1, race.Counter);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowExceptionWhenDriverCountIsLessThan2()
        {
            race.AddDriver(unitDriver);
            Assert.Throws<InvalidOperationException>(() =>race.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerShouldWorkCorrectly()
        {
            race.AddDriver(unitDriver);
            race.AddDriver(new UnitDriver("Dragan", new UnitCar("A",50,2000)));

            var expectingHP = 75;
            var actualHP = race.CalculateAverageHorsePower();

            Assert.AreEqual(expectingHP,actualHP);
        }
    }
}