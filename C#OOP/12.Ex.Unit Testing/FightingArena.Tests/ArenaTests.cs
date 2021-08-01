using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        [Test]
        public void ConstructorShouldInitializeEmptyList()
        {
            //Arrange
            Arena arena = new Arena();

            //Act - Assert
            int expectedCount = 0;
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase("Ivan", 50, 100)]
        public void EnrollShouldWorkCorrectly(string name, int damage, int hp)
        {
            //Arrange
            Arena arena = new Arena();

            //Act
            arena.Enroll(new Warrior(name, damage, hp));

            //Assert
            int expectedCount = 1;
            int actualCount = arena.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Warrior warr = arena.Warriors.FirstOrDefault(x => x.Name == name);
            Assert.AreEqual(name, warr.Name);
            Assert.AreEqual(damage, warr.Damage);
            Assert.AreEqual(hp, warr.HP);
        }

        [Test]
        public void EnrollShouldThrowExceptionIfThereAreWarriorWithGivenName()
        {
            //Arrange
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Ivan", 50, 100));
            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Ivan", 100, 200)));
        }

        [Test]
        [TestCase("Attacker","Deffender")]
        public void FightShouldThrowExceptionIfAttackerIsNull(string attackerName, string deffenderName)
        {
            //Arrange
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Deffender", 50, 100));

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, deffenderName));
        }

        [Test]
        [TestCase("Attacker", "Deffender")]
        public void FightShouldThrowExceptionIfDeffenderIsNull(string attackerName, string deffenderName)
        {
            //Arrange
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Attacker", 50, 100));

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, deffenderName));
        }

        [Test]
        [TestCase("Attacker", "Deffender")]
        public void FightShouldWorkCorrectly(string attackerName, string deffenderName)
        {
            //Arrange
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Attacker", 50, 100));
            arena.Enroll(new Warrior("Deffender", 50, 100));

            //Act
            arena.Fight(attackerName, deffenderName);

            //Assert
            int expectedAttackerHP = 50;
            int excpectedDeffenderHP = 50;

            int actualAttackerHP = arena.Warriors.FirstOrDefault(x => x.Name == attackerName).HP;
            int actualDeffenderHP = arena.Warriors.FirstOrDefault(x => x.Name == deffenderName).HP;

            Assert.AreEqual(expectedAttackerHP,actualAttackerHP);
            Assert.AreEqual(excpectedDeffenderHP, actualAttackerHP);
        }
    }
}
