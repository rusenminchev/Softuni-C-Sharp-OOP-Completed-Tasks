using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private const int AttackPoints = 10;

    private Dummy dummy;

    [SetUp]
    public void SetDummy()
    {
        this.dummy = new Dummy(100, 200);
    }

    [Test]
    public void TheAxeShouldLoseDirabilityAfterAttack()
    {
        //Arrange
        Axe axe = new Axe(AttackPoints, 7);


        //Act
        axe.Attack(this.dummy);

        //Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(6));

    }

    [Test]
    public void TheAxeShouldThrowExceptionWhenAttackWithBrokenWeapon()
    {
        //Arrange
        Axe axe = new Axe(AttackPoints, 0);

        //Assert
        Assert.That(() => axe.Attack(this.dummy), //Act
            Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));

    }
}