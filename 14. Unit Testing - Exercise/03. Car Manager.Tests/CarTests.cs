using System;
using NUnit.Framework;

//using CarManager;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            this.car = new Car("WV", "Golf", 10, 50);
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Car car = new Car("WV", "Golf", 7.6, 50);

            Assert.AreEqual("WV", car.Make);
            Assert.AreEqual("Golf", car.Model);
            Assert.AreEqual(7.6, car.FuelConsumption);
            Assert.AreEqual(50, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void ConstructorShouldSetFuelAmountToZero()
        {
            Car car = new Car("WV", "Golf", 7.6, 50);

            double expenctedFuelAmount = 0;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expenctedFuelAmount, actualFuelAmount);
        }

        [TestCase("")]
        [TestCase(null)]
        public void ConstructorShouldThrowExceptionIfMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, "Golf", 7.6, 50);
            });
        }


        [TestCase("")]
        [TestCase(null)]
        public void ConstructorShouldThrowExceptionIfModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("WV", model, 7.6, 50);
            });
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void ConstructorShouldThrowExceptionIfFuelConsumptionIsZeroOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("WV", "Golf", fuelConsumption, 50);
            });
        }

         [Test]
        public void ConstructorShouldThrowExceptionIfFuelAmountIsNegative()
        {
            double fuelToRefuel = -10;

            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(fuelToRefuel);
            });
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void ConstructorShouldThrowExceptionIfFuelCapacityIsZeroOrNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("WV", "Golf", 7.6, fuelCapacity);
            });
        }

        [Test]
        public void RefuelMethodIsWorkingProperly()
        {
            double fuelToRefuel = 10;

            double expectedFuelAmount = 10;

            this.car.Refuel(fuelToRefuel);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void RefuelMethodCannotIncreaseTheAmountAboveTheCapacity()
        {
            double fuelToRefuel = 55;

            this.car.Refuel(fuelToRefuel);

            Assert.AreEqual(this.car.FuelCapacity, car.FuelAmount);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void RefuelMethodShouldThrowExceptionIfTryToRefuelWithZeroOrNegativeAmount(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(fuelToRefuel);
            });
        }

        [Test]
        public void DriveMethodIsWorkingProperly()
        {
            double distance = 100;
            double fuelNeeded = (distance / 100) * this.car.FuelConsumption;
            this.car.Refuel(10);
            double expectedFuelAmount = this.car.FuelAmount - fuelNeeded;

            this.car.Drive(distance);

            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

        [Test]
        public void DriveMethodShouldThrowExceptionIfFuelNeededIsMoreThanFuemAmount()
        {
            double distance = 100;
            double fuelNeeded = (distance / 100) * this.car.FuelConsumption;
            this.car.Refuel(8);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.car.Drive(distance);
            });
        }
    }
}