using System;
using System.Linq;
using NUnit.Framework;

public class DatabaseTests
{
    [Test]
    public void ConstructorShouldBeInitializedWith16Elements()
    {
        //Arrange
        int[] numbers = Enumerable.Range(1, 16).ToArray();
        Database.Database database = new Database.Database(numbers);

        //Act
        int expectedResult = 16;
        int actualResult = database.Count;

        //Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    [TestCase(1, 17)]
    public void DatabaseShouldTrowExceptionIfStoringArrayCapacityIsMoreThan16(int startNumber,
        int arrayCount)
    {
        //Arrange
        int[] numbers = Enumerable.Range(startNumber, arrayCount).ToArray();

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => new Database.Database(numbers));
    }

    [Test]
    [TestCase(1, 14, 5, 15)]
    public void AddOperationShouldAddElementAtNextFreeCell(
        int startNumber,
        int arrayCount,
        int elementToAdd,
        int expectedCount)
    {
        //Arrange
        int[] numbers = Enumerable.Range(startNumber, arrayCount).ToArray();
        Database.Database database = new Database.Database(numbers);

        //Act
        database.Add(elementToAdd);
        int[] databaseArray = database.Fetch();
        int actualResult = databaseArray[databaseArray.Length - 1];
        int actualCount = database.Count;

        //Assert
        Assert.AreEqual(elementToAdd, actualResult);
        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    [TestCase(1, 16, 5)]
    public void AddOperationShouldThrowExceptionWhenArrayCapacityIs16(
        int startNumber,
        int arrayCount,
        int elementToAdd)
    {
        //Arrange
        int[] numbers = Enumerable.Range(startNumber, arrayCount).ToArray();
        Database.Database database = new Database.Database(numbers);

        //Act-Assert
        Assert.Throws<InvalidOperationException>(() => database.Add(elementToAdd));
    }

    [Test]
    [TestCase(1, 16, 15, 15)]
    public void RemoveOperationShouldRemoveLastElement(
        int startNumber,
        int arrayCount,
        int expectedResult,
        int expectedCount)
    {
        //Arrange
        int[] numbers = Enumerable.Range(startNumber, arrayCount).ToArray();
        Database.Database database = new Database.Database(numbers);

        //Act
        database.Remove();

        //Assert
        int actualResult = database.Fetch()[14];
        int actualCount = database.Count;

        Assert.AreEqual(expectedResult,actualResult);
        Assert.AreEqual(expectedCount,actualCount);
    }

    [Test]
    public void RemoveOperationShouldThrowExceptionIfDatabaseIsEmpty()
    {
        //Arrange
        Database.Database database = new Database.Database();

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => database.Remove());
    }

    [Test]
    [TestCase(1, 16)]
    public void FetchShouldReturnArrayElements(
        int startNumber,
        int arrayCount)
    {
        //Arrange
        int[] numbers = Enumerable.Range(startNumber, arrayCount).ToArray();
        Database.Database database = new Database.Database(numbers);

        //Act
        int[] actualResult = database.Fetch();

        //Assert
        CollectionAssert.AreEqual(numbers, actualResult);
    }
}