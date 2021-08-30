using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;

        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
        }

        [Test]
        [TestCase("Asus", "ROG", 5000)]
        public void ComputerConstructorShouldWorkCorrectly(string manufacturer, string model, decimal price)
        {
            Computer computer = new Computer(manufacturer, model, price);

            Assert.AreEqual(manufacturer, computer.Manufacturer);
            Assert.AreEqual(model, computer.Model);
            Assert.AreEqual(price, computer.Price);
        }

        [Test]
        public void ComputerManagerConstructorShouldInitializesEmptyList()
        {
            Assert.AreEqual(0, computerManager.Computers.Count);
            Assert.AreEqual(0, computerManager.Count);
        }

        [Test]
        [TestCase(null)]
        public void AddShouldThrowExceptionWhenComputerIsNull(Computer computer)
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(computer));
        }

        [Test]
        [TestCase("A", "B")]
        [TestCase("Asus", "ROG")]
        public void AddShouldThrowExceptionWhenComputerExists(string manufacturer, string model)
        {
            //Arrange
            computerManager.AddComputer(new Computer("A", "B", 15));
            computerManager.AddComputer(new Computer("Asus", "ROG", 5000));
            Computer computer = new Computer(manufacturer, model, 0);

            //Act-Assert
            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
        }

        [Test]
        [TestCase("A", "B", 500)]
        [TestCase("Asus", "ROG", 100)]
        public void AddShouldWorkCorrectly(string manufacturer, string model, decimal price)
        {
            //Arrange
            Computer computer = new Computer(manufacturer, model, price);

            //Act
            computerManager.AddComputer(computer);

            //Assert
            int expectedCount = 1;
            int actualCount = computerManager.Count;

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedCount, computerManager.Computers.Count);
        }

        [Test]
        [TestCase(null)]
        public void GetComputerShouldThrowExceptionWhenManufacturerIsNull(string manufacturer)
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(manufacturer, "B"));
        }

        [Test]
        [TestCase(null)]
        public void GetComputerShouldThrowExceptionWhenModelIsNull(string model)
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("A", model));
        }

        [Test]
        [TestCase("A", "B")]
        public void GetComputerShouldThrowExceptionWhenComputerNotExists(string manufacturer, string model)
        {
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer(manufacturer, model));
        }

        [Test]
        [TestCase("A", "B")]
        [TestCase("Asus", "ROG")]
        public void GetComputerShouldWorkCorrectly(string manufacturer, string model)
        {
            //Arrange
            Computer computer = new Computer(manufacturer, model, 5000);
            computerManager.AddComputer(computer);

            //Act
            Computer result = computerManager.GetComputer(manufacturer, model);

            //Assert
            Assert.AreEqual(computer.Manufacturer, result.Manufacturer);
            Assert.AreEqual(computer.Model, result.Model);
            Assert.AreEqual(computer,result);
        }

        [Test]
        [TestCase("Asus", "ROG")]
        public void RemoveShouldWorkCorrectly(string manufacturer, string model)
        {
            //Arrange
            computerManager.AddComputer(new Computer("Asus", "ROG", 5000));

            //Act
            computerManager.RemoveComputer(manufacturer, model);

            //Assert
            int expectedCount = 0;
            int actualCount = computerManager.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        [TestCase(null)]
        public void GetComputersByManufacturerShouldThrowExceptionWhenManufacturerIsNull(string manufacturer)
        {
            Assert.Throws<ArgumentNullException>(()=> computerManager.GetComputersByManufacturer(manufacturer));
        }

        [Test]
        [TestCase("A")]
        public void GetComputersByManufacturerShouldWorkCorrectly(string manufacturer)
        {
            //Arrange
            var comp = new Computer("A", "ROG", 5000);
            var comp2 = new Computer("A", "ASD", 5000);
            var comp3 = new Computer("B", "WWW", 5000);

            computerManager.AddComputer(comp);
            computerManager.AddComputer(comp2);
            computerManager.AddComputer(comp3);

            //Act
            var coll = computerManager.GetComputersByManufacturer(manufacturer);

            //Assert
            int expectedCount = 2;
            int actualCount = coll.Count;
            Assert.AreEqual(expectedCount,actualCount);
            CollectionAssert.Contains(coll,comp);
            CollectionAssert.Contains(coll,comp2);
        }
    }
}