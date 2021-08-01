using System;
using System.Collections.Generic;
using NUnit.Framework;
using ExtendedDatabase;

[TestFixture]
public class ExtendedDatabaseTests
{
    [Test]
    public void ConstructorInitializeWith3Persons()
    {
        //Arrange
        List<Person> persons = new List<Person>()
            {
                new Person(12345, "Ivan"),
                new Person(67890, "Asen"),
                new Person(13579, "Gosho")

            };
        ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(persons.ToArray());

        //Act - Assert
        int expectedResult = 3;
        int actualResult = database.Count;
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void ConstructorShouldThrowExceptionIfPersonsAreMoreThan16()
    {
        //Arrange
        List<Person> persons = new List<Person>();
        for (int i = 1; i <= 17; i++)
        {
            persons.Add(new Person(i, "Ivan" + i));
        }


        //Act - Assert
        Assert.Throws<ArgumentException>(()
            => new ExtendedDatabase.ExtendedDatabase(persons.ToArray()));
    }

    [Test]
    [TestCase(123, "Yordan")]
    public void AddOperationShouldAddPerson(long id, string name)
    {
        const int expectedCount = 4;
        //Arrange
        List<Person> persons = new List<Person>()
            {
                new Person(12345, "Ivan"),
                new Person(67890, "Asen"),
                new Person(13579, "Gosho")

            };
        ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(persons.ToArray());

        //Act
        database.Add(new Person(id, name));
        int actualCount = database.Count;

        //Assert
        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    [TestCase(123, "Yordan")]
    public void AddOperationShouldThrowExceptionWhenTryToAddMoreThan16Persons(long id, string name)
    {
        //Arrange
        List<Person> persons = new List<Person>();
        for (int i = 1; i <= 16; i++)
        {
            persons.Add(new Person(i, "Ivan" + i));
        }
        ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(persons.ToArray());

        //Act-Assert
        Assert.Throws<InvalidOperationException>(() => database.Add(new Person(id, name)));
    }

    [Test]
    [TestCase("Ivan")]
    public void AddOperationShouldThrowExceptionIfThereAreUserWithThisName(string name)
    {
        //Arrange
        List<Person> persons = new List<Person>()
            {
                new Person(12345, "Ivan"),
                new Person(67890, "Asen"),
                new Person(13579, "Gosho")

            };
        ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(persons.ToArray());

        //Act-Assert
        Assert.Throws<InvalidOperationException>(() => database.Add(new Person(121212, name)));
    }

    [Test]
    [TestCase(67890)]
    public void AddOperationShouldThrowExceptionIfThereAreUserWithThisId(long id)
    {
        //Arrange
        List<Person> persons = new List<Person>()
            {
                new Person(12345, "Ivan"),
                new Person(67890, "Asen"),
                new Person(13579, "Gosho")

            };
        ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(persons.ToArray());

        //Act-Assert
        Assert.Throws<InvalidOperationException>(() => database.Add(new Person(id, "AAA")));
    }

    [Test]
    public void RemoveOperationShouldRemoveLastElement()
    {
        const long lastPersonId = 13579;
        const string lastPersonUsername = "Gosho";
        const int expectedCount = 2;
        //Arrange
        List<Person> persons = new List<Person>()
            {
                new Person(12345, "Ivan"),
                new Person(67890, "Asen"),
                new Person(13579, "Gosho")

            };
        ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(persons.ToArray());

        //Act
        database.Remove();

        //Assert
        int actualCount = database.Count;

        Assert.AreEqual(expectedCount, actualCount);
        Assert.Throws<InvalidOperationException>(() => database.FindById(lastPersonId));
        Assert.Throws<InvalidOperationException>(() => database.FindByUsername(lastPersonUsername));
    }

    [Test]
    [TestCase("Gosho")]
    public void FindByUsernameOperationShouldReturnPersonWithGivenUsername(string username)
    {
        //Arrange
        List<Person> persons = new List<Person>()
            {
                new Person(12345, "Ivan"),
                new Person(67890, "Asen"),
                new Person(13579, "Gosho")

            };
        ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(persons.ToArray());

        //Act
        Person actualResult = database.FindByUsername(username);

        //Assert
        Assert.AreEqual(username, actualResult.UserName);
    }

    [Test]
    [TestCase("ivan")]
    public void FindByUsernameOperationShouldThrowExceptionIfNoUserWithThisUsername(string username)
    {
        //Arrange
        List<Person> persons = new List<Person>()
            {
                new Person(12345, "Ivan"),
                new Person(67890, "Asen"),
                new Person(13579, "Gosho")

            };
        ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(persons.ToArray());

        //Act-Assert
        Assert.Throws<InvalidOperationException>(() => database.FindByUsername(username));
    }

    [Test]
    [TestCase(null)]
    public void FindByUsernameOperationShouldThrowExceptionIfUsernameIsNullOrEmpty(string username)
    {
        //Arrange
        List<Person> persons = new List<Person>()
            {
                new Person(12345, "Ivan"),
                new Person(67890, "Asen"),
                new Person(13579, "Gosho")

            };
        ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(persons.ToArray());

        //Act-Assert
        Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username));
    }

    [Test]
    [TestCase(12345)]
    public void FindByIdOperationShouldReturnPersonWithGivenId(long id)
    {
        //Arrange
        List<Person> persons = new List<Person>()
            {
                new Person(12345, "Ivan"),
                new Person(67890, "Asen"),
                new Person(13579, "Gosho")

            };
        ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(persons.ToArray());

        //Act
        Person actualResult = database.FindById(id);

        //Assert
        Assert.AreEqual(id, actualResult.Id);
    }

    [Test]
    [TestCase(123456)]
    public void FindByIdOperationShouldThrowExceptionIfNoUserWithThisId(long id)
    {
        //Arrange
        List<Person> persons = new List<Person>()
            {
                new Person(12345, "Ivan"),
                new Person(67890, "Asen"),
                new Person(13579, "Gosho")

            };
        ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(persons.ToArray());

        //Act-Assert
        Assert.Throws<InvalidOperationException>(() => database.FindById(id));
    }

    [Test]
    [TestCase(-1)]
    public void FindByIdOperationShouldThrowExceptionIfIdIsNegative(long id)
    {
        //Arrange
        List<Person> persons = new List<Person>()
            {
                new Person(12345, "Ivan"),
                new Person(67890, "Asen"),
                new Person(13579, "Gosho")

            };
        ExtendedDatabase.ExtendedDatabase database = new ExtendedDatabase.ExtendedDatabase(persons.ToArray());

        //Act-Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
    }
}

