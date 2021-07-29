
using NUnit.Framework;
using System;

namespace SkeletonTests
{
    [TestFixture]
    class DummyTests
    {
        [Test]
        [TestCase(100,100,50,50)]
        [TestCase(100,100,40,60)]
        public void DummyShouldLoseHealthIfAttacked(int health, int exp,int attackPoints, int expectedResult)
        {
            //Arrange
            Dummy dummy = new Dummy(health,exp);

            //Act
            dummy.TakeAttack(attackPoints);

            //Assert
            Assert.AreEqual(expectedResult, dummy.Health);
        }
        [Test]
        [TestCase(0, 100,50)]
        public void DeadDummyShouldThrowInvalidOperationExceptionIfAttacked(int health, int exp, int attackPoints)
        {
            //Arrange
            Dummy dummy = new Dummy(health, exp);

            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackPoints));
        }
        [Test]
        [TestCase(0, 50)]
        public void DeadDummyShouldGiveXP(int health, int exp)
        {
            //Arrange
            Dummy dummy = new Dummy(health, exp);

            //Act-Assert
            int expectedResult = exp;
            int actualResult = dummy.GiveExperience();
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        [TestCase(50, 50)]
        public void AliveDummyShouldThrowInvalidOperationExceptionWhenTryToGiveExperience(int health, int exp)
        {
            //Arrange
            Dummy dummy = new Dummy(health, exp);

            //Act-Assert
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
