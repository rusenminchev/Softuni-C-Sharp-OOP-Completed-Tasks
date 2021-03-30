using Moq;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Skeleton.Tests.Fakes;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DragonTests
    {

        [Test]
        public void TheDragonShouldIntroduceHimselfWithTheRightMessage()
        {
            const string DragonName = "Drakkaris";

            //Решение с Mock-ване

            //Arrange
            var fakeIntroducer = new Mock<IIntroducer>();

            string introductionMessage = string.Empty;

            fakeIntroducer.Setup(i => i.Introduce(It.IsAny<string>()))
                .Callback((string message) => introductionMessage = message);

            Dragon dragon = new Dragon(DragonName, fakeIntroducer.Object);

            //Act
            dragon.Introduce();

            //Assert
            Assert.That(introductionMessage,
                Is.EqualTo($"Hello, I am {DragonName} - The Dragon! I love to burn things!"));


            // Решение със създаване на фалшив обект за целта на теста
            //Arrange
            //var fakeIntroducer = new FakeIntroducer();
            //Dragon dragon = new Dragon(DragonName, fakeIntroducer);

            ////Act
            //dragon.Introduce();

            ////Assert
            //Assert.That(fakeIntroducer.Message,
            //    Is.EqualTo($"Hello, I am {DragonName} - The Dragon! I love to burn things!"));

        }
    }
}
