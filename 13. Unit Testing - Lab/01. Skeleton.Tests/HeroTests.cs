using Moq;
using NUnit.Framework;

using Skeleton;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroShouldGainExperienceWhenTargedDies()
    {
        const int TargetExperience = 200;

        //Arrange
        var fakeWeapon = Mock.Of<IWeapon>(); // Така създаваме Mock на обект, който е празен и не се налага да му сетваме стойности
        var fakeTarget = new Mock<ITarget>(); // Така създаваме Mock на обект, на който ще сетваме стойности.

        fakeTarget
            .Setup(t => t.IsDead())
            .Returns(true);

        fakeTarget.Setup(t => t.GiveExperience())
            .Returns(TargetExperience);

        Hero hero = new Hero("Zapryan", fakeWeapon);

        //Act
        hero.Attack(fakeTarget.Object); 
        
        //Assert
        Assert.That(hero.Experience, Is.EqualTo(TargetExperience));
    }
}