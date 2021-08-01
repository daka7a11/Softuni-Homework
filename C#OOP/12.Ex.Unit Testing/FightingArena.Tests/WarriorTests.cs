using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [Test]
        [TestCase("Ivan", 100, 1000)]
        [TestCase("Dragan", 1, 1)]
        public void ConstructorShouldWorkCorrectly(string name, int damage, int hp)
        {
            //Arrange
            Warrior warrior = new Warrior(name, damage, hp);

            //Act - Assert
            Assert.AreEqual(warrior.Name, name);
            Assert.AreEqual(warrior.Damage, damage);
            Assert.AreEqual(warrior.HP, hp);

        }

        [Test]
        [TestCase(null, 100, 1000)]
        [TestCase("", 1, 1)]
        [TestCase("   ", 10, 100)]
        public void NameSetterShouldThrowExceptionIfValueIsNullEmptyOrWhiteSpace(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Ivan", 0, 1000)]
        [TestCase("Dragan", -1, 1)]
        public void DamageSetterShouldThrowExceptionIfValueIsZeroOrNegative(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Ivan", 10, -1)]
        [TestCase("Dragan", 20, -50)]
        public void HpSetterShouldThrowExceptionIfValueIsNegative(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Ivan", 50, 5)]
        [TestCase("Stoqn", 50, 0)]
        [TestCase("Dragan", 60, 20)]
        [TestCase("Petar", 70, 30)]
        public void AttackShouldThrowExceptionIfAttackerHpAreBelow30(string name, int damage, int hp)
        {
            //Arrange
            Warrior warrior = new Warrior(name, damage, hp);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("A", 10, 40)));
        }

        [Test]
        [TestCase(40, 0)]
        [TestCase(50, 10)]
        [TestCase(50, 20)]
        [TestCase(50, 29)]
        public void AttackShouldThrowExceptionIfDeffenderHpAreBelow30(int attackerHp, int deffenderHp)
        {
            //Arrange
            Warrior attacker = new Warrior("Attacker", 50, attackerHp);
            Warrior deffender = new Warrior("Deffender", 20, deffenderHp);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(deffender));
        }

        [Test]
        [TestCase(1, 2)]
        [TestCase(10, 20)]
        [TestCase(50, 100)]
        [TestCase(500, 1000)]
        public void AttackShouldThrowExceptionIfAttackerHpAreBelowDeffenderDamage(int attackerHp, int deffenderDamage)
        {
            //Arrange
            Warrior attacker = new Warrior("Attacker", 50, attackerHp);
            Warrior deffender = new Warrior("Deffender", deffenderDamage, 50);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(deffender));
        }

        [Test]
        [TestCase(100, 100, 50, 150, 50, 50)]
        [TestCase(200,200,50,50,150,0)]
        [TestCase(50, 50, 50, 50, 0, 0)]
        [TestCase(100,100,80,150,20,50)]
        [TestCase(100,200,200,200,0,100)]
        public void AttackShouldDecreaseAttackerAdnDeffenderHP(
            int attackerDamage, int attackerHp,
            int deffenderDamage, int deffenderHp,
            int expectedAttackerHP, int expectedDeffenderHP)
        {
            //Arrange
            Warrior attacker = new Warrior("Attacker", attackerDamage, attackerHp);
            Warrior deffender = new Warrior("Deffender", deffenderDamage, deffenderHp);

            //Act
            attacker.Attack(deffender);

            //Assert
            int actualAttackerHP = attacker.HP;
            int actualDeffenderHp = deffender.HP;

            Assert.AreEqual(expectedAttackerHP, actualAttackerHP);
            Assert.AreEqual(expectedDeffenderHP, actualDeffenderHp);
        }
    }
}