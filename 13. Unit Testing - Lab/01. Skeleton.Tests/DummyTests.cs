using Microsoft.VisualBasic;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Diagnostics;

[TestFixture]
public class DummyTests
{
    private const int DeadDummyHealth = 0;
    private const int AliveDummyHealth = 100;
    private const int DummyExperience = 200;
    private const int AttackPoints = 10;

    private Dummy aliveDummy;
    private Dummy deadDummy;

    [SetUp]
    public void SetDummy()
    {
        this.aliveDummy = new Dummy(AliveDummyHealth, DummyExperience);
        this.deadDummy = new Dummy(DeadDummyHealth, DummyExperience);
    }

    [Test]
    public void DummyShouldLoseHealthAfterBeenAttacked()
    {
 
        //Act
        this.aliveDummy.TakeAttack(AttackPoints);

        //Assert
        Assert.That(this.aliveDummy.Health, Is.EqualTo(90));

    }

    [Test]
    public void DeadDummyShouldThrowExceptionIfAttacked()
    {

        //Assert
        Assert.That(() => this.deadDummy.TakeAttack(AttackPoints), //Act

            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."),
            "Dead target cannot be attacked!");
    }

    [Test]
    public void DeadDummyShouldGiveExperience()
    {
      
        //Act
        var experience = this.deadDummy.GiveExperience();

        //Assert
        Assert.That(experience, Is.EqualTo(DummyExperience));

    }

    [Test]
    public void AliveDummyShouldNotGiveExperience()
    {
        
        //Assert
        Assert.That(() => this.aliveDummy.GiveExperience(), //Act
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
