using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    [TestFixture]
    public class AquariumsTests
    {

        private Aquarium aquarium;
        private Fish firstFish;
        private Fish seocondFish;

        [SetUp]
        public void Setup()
        {
            this.aquarium = new Aquarium("Atlantida", 3);
            this.firstFish = new Fish("Nemo");
            this.seocondFish = new Fish("Scarface");

        }

        [Test]
        public void ConstructorIsWorkingCorrectly()
        {
            Aquarium aquarium = new Aquarium("Atlantida", 3);

            

            Assert.AreEqual("Atlantida", aquarium.Name);
            Assert.AreEqual(3, aquarium.Capacity);

        }

        [TestCase(null)]
        public void NameShoundThrowIfNull(string name)
        {
            Aquarium aquarium = null;

            Assert.That(() => aquarium = new Aquarium(name, 50),
                Throws.ArgumentNullException);

        }

        [TestCase(-1)]
        public void CapacityShoundThrowIfNull(int capacity)
        {
            Aquarium aquarium = null;

            Assert.That(() => aquarium = new Aquarium("Atlantis", capacity),
                Throws.ArgumentException);

        }

        [Test]
        public void AddIsWorking()
        {
            this.aquarium.Add(this.firstFish);
            this.aquarium.Add(this.seocondFish);

            Assert.AreEqual(2, this.aquarium.Count);
            
        }

        [Test]
        public void CountShoundThrowIfNull()
        {
            this.aquarium.Add(this.firstFish);
            this.aquarium.Add(this.seocondFish);
            this.aquarium.Add(new Fish("Kancho"));
           

            Assert.That(() => this.aquarium.Add(new Fish("Pencho")),
                    Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveIsWorking()
        {
            this.aquarium.Add(this.firstFish);
            this.aquarium.Add(this.seocondFish);

            this.aquarium.RemoveFish("Scarface");

            Assert.AreEqual(1, this.aquarium.Count);

        }

        [Test]
        public void RemoveShouldThrowIfFishDoesNotExist()
        {
            this.aquarium.Add(this.firstFish);
            this.aquarium.Add(this.seocondFish);

           

            Assert.That(() => this.aquarium.RemoveFish("Steve Jobs"),
                Throws.InvalidOperationException);

        }

        [Test]
        public void SellFishShouldThrowIfFishDoesNotExist()
        {
            this.aquarium.Add(this.firstFish);
            this.aquarium.Add(this.seocondFish);

            Assert.That(() => this.aquarium.SellFish("Steve Jobs"),
                Throws.InvalidOperationException);

        }

        [Test]
        public void SellFishIsWorking()
        {
            this.aquarium.Add(this.firstFish);
            this.aquarium.Add(this.seocondFish);


            var fishToSell = this.aquarium.SellFish("Scarface");

            Assert.AreEqual(this.seocondFish.Name, fishToSell.Name );

        }

        [Test]
        public void SellFishShouldChangeTheStateOfTheFish()
        {
            this.aquarium.Add(this.firstFish);
            this.aquarium.Add(this.seocondFish);


            var fishToSell = this.aquarium.SellFish("Scarface");

            Assert.AreEqual(false, fishToSell.Available);

        }

        [Test]
        public void ReportIsWorking()
        {

            this.aquarium.Add(this.firstFish);
            this.aquarium.Add(this.seocondFish);

            string expectedMessgae = $"Fish available at {aquarium.Name}: {this.firstFish.Name}, {this.seocondFish.Name}";

            string actualMessage = this.aquarium.Report();

            Assert.AreEqual(expectedMessgae, actualMessage);
        }

    }
}
