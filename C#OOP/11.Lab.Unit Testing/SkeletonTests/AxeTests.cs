using NUnit.Framework;
using System;

namespace SkeletonTests
{
    [TestFixture]
    public class AxeTests
    {

        [Test]
        [TestCase(10, 10, 10, 10, 9)]
        [TestCase(100, 100, 50, 50, 99)]
        public void WeaponShouldLoseDurabilityAfterAttack(
            int axeAttack, int axeDurability,
            int dummyHealth, int dummyExp,
            int expectedResult)
        {
            //Arrange
            Axe axe = new Axe(axeAttack, axeDurability);
            Dummy dummy = new Dummy(dummyHealth, dummyExp);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.AreEqual(expectedResult, axe.DurabilityPoints);
        }

        [TestCase(10, 0, 10, 10)]
        [TestCase(100, -1, 50, 50)]
        public void AttackShouldThrowInvalidOperationExceptionWhenAttackWithBrokenWeapon(
           int axeAttack, int axeDurability,
           int dummyHealth, int dummyExp)
        {
            //Arrange
            Axe axe = new Axe(axeAttack, axeDurability);
            Dummy dummy = new Dummy(dummyHealth, dummyExp);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}