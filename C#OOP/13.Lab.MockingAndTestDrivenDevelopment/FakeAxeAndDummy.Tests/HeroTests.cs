using FakeAxeAndDummy;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    [TestCase(1000)]
    public void HeroShouldGainXPWhenKillTarget(int XP)
    {
        //Arrange
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        
        fakeTarget.Setup(x => x.IsDead()).Returns(true);
        fakeTarget.Setup(x => x.GiveExperience()).Returns(XP);

        Hero hero = new Hero("Pesho",fakeWeapon.Object);

        //Act
        hero.Attack(fakeTarget.Object);

        //Assert
        int actualResult = hero.Experience;

        Assert.AreEqual(XP, actualResult);
    }
}