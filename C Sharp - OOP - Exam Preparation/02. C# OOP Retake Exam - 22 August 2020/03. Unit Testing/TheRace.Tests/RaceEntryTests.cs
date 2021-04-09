using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
//using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitDriver firstDriver;
        private UnitDriver secondDriver;
        private UnitDriver thirdDriver;

        private UnitCar firstCar;
        private UnitCar secondCar;
        private UnitCar thirdCar;

        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.firstCar = new UnitCar("Carrera GT", 300, 3000);
            this.secondCar = new UnitCar("Mustang", 600, 5000);
            this.thirdCar = new UnitCar("Impreza", 500, 4000);

            this.firstDriver = new UnitDriver("Ken Block", this.firstCar);
            this.secondDriver = new UnitDriver("Kubrat Pulev", this.secondCar);
            this.thirdDriver = new UnitDriver("Steve Austin", this.thirdCar);

            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void ConstructorIsWorkingProperly()
        {
            RaceEntry raceEntry = new RaceEntry();

            int expectedCount = 0;

            int actualCount = raceEntry.Counter;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void AddMethodShouldAddNewDriverToTheRaceAndReturnTheApropreateMessage()
        {
            string expectedMessage = $"Driver {firstDriver.Name} added in race.";

            string actualMessage = this.raceEntry.AddDriver(this.firstDriver);

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void AddMethodShouldThrowExpectionIfDriverNameisNull()
        {

            UnitDriver driver = null;

            Assert.That(() => this.raceEntry.AddDriver(driver),
                Throws
                .InvalidOperationException.With.Message
                .EqualTo("Driver cannot be null."));

        }

        [Test]
        public void AddMethodShouldThrowExpectionIfDriverIsAlreadyAdded()
        {

            this.raceEntry.AddDriver(this.firstDriver);

            Assert.That(() => this.raceEntry.AddDriver(this.firstDriver),
                Throws
                .InvalidOperationException.With.Message
                .EqualTo($"Driver {this.firstDriver.Name} is already added."));
        }

        [Test]
        public void CalculateAverageHPIsWorkingCorrectlyAndReturnsTheAverageHPOfTheCarsInTheRace()
        {

            Dictionary<string, UnitDriver> testRaceEntry = new Dictionary<string, UnitDriver>();

            testRaceEntry.Add(this.firstDriver.Name, this.firstDriver);
            testRaceEntry.Add(this.secondDriver.Name, this.secondDriver);
            testRaceEntry.Add(this.thirdDriver.Name, this.thirdDriver);

            double expectedAverageHP = testRaceEntry
                .Values
                .Select(d => d.Car.HorsePower)
                .Average();

            this.raceEntry.AddDriver(firstDriver);
            this.raceEntry.AddDriver(secondDriver);
            this.raceEntry.AddDriver(thirdDriver);

            double actualAverageHP = this.raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedAverageHP, actualAverageHP);
        }


        [Test]
        public void CalculateAverageHPShouldThrowExceptionIfNumberOfPaticipantsIsLessThanTwo()
        {
            this.raceEntry.AddDriver(this.firstDriver);


            Assert.That(() => this.raceEntry.CalculateAverageHorsePower(),
                Throws
                .InvalidOperationException.With.Message
                .EqualTo($"The race cannot start with less than {2} participants."));
        }
    }
}